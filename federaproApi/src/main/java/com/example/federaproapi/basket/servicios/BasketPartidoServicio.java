package com.example.federaproapi.basket.servicios;

import com.example.federaproapi.basket.EstadisticaEquipoDTO;
import com.example.federaproapi.basket.EstadisticaJugadorDTO;
import com.example.federaproapi.basket.EstadisticasPartidoDTO;
import com.example.federaproapi.basket.PartidoDTO;
import com.example.federaproapi.basket.modelos.*;
import com.example.federaproapi.basket.repositorios.*;
import jakarta.transaction.Transactional;
import org.apache.commons.csv.CSVFormat;
import org.apache.commons.csv.CSVParser;
import org.apache.commons.csv.CSVPrinter;
import org.apache.commons.csv.CSVRecord;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;

import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigDecimal;
import java.time.Instant;
import java.time.LocalDate;
import java.util.Arrays;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

import static java.time.LocalDate.parse;

@Service
public class BasketPartidoServicio {

    @Autowired
    private BasketPartidoRepositorio basketPartidoRepositorio;
    @Autowired
    private BasketCompeticioneRepositorio competicionRepository;
    @Autowired
    private BasketEquipoRepository equipoRepository;
    @Autowired
    private BasketArbitroRepositorio arbitroRepository;
    @Autowired
    private BasketEstadisticasEquipoRepositorio estadisticasEquipoRepositorio;
    @Autowired
    private BasketEstadisticasJugadorRepositorio estadisticasJugadorRepositorio;
    @Autowired
    private BasketJugadorRepositorio jugadorRepositorio;

    // Obtener todos los partidos
    public List<BasketPartido> obtenerTodosLosPartidos() {
        return basketPartidoRepositorio.findAll();
    }

    // Obtener partidos de un equipo, ya sea como local o visitante
    public List<PartidoDTO> obtenerPartidosDeEquipo(int id) {
        BasketEquipo equipo = equipoRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Equipo no encontrado"));

        List<BasketPartido> partidos = basketPartidoRepositorio.findByEquipoLocal_IdOrEquipoVisitante_Id(
                equipo.getId(),
                equipo.getId()
        );

        return partidos.stream().map(p -> {
            PartidoDTO dto = new PartidoDTO();
            dto.setJornada(p.getJornada());
            dto.setFecha(p.getFecha());
            dto.setEquipoLocal(p.getEquipoLocal().getNombre());
            dto.setEquipoVisitante(p.getEquipoVisitante().getNombre());

            if (p.getResultadoLocal() != null && p.getResultadoVisitante() != null) {
                dto.setResultado(p.getResultadoLocal() + " - " + p.getResultadoVisitante());
            } else {
                dto.setResultado("Pendiente");
            }

            return dto;
        }).collect(Collectors.toList());
    }

    public EstadisticasPartidoDTO obtenerEstadisticasPorPartido(Integer partidoId) {
        BasketPartido partido = basketPartidoRepositorio.findById(partidoId)
                .orElseThrow(() -> new RuntimeException("Partido no encontrado"));

        List<BasketEstadisticasEquipo> estadisticasEquipos =
                estadisticasEquipoRepositorio.findByIdPartido(partido);

        List<EstadisticaEquipoDTO> equiposDTO = estadisticasEquipos.stream()
                .map(est -> {
                    EstadisticaEquipoDTO dto = new EstadisticaEquipoDTO();
                    dto.setEquipo(est.getIdEquipo().getNombre());
                    dto.setPartidoId(est.getIdPartido().getId());
                    dto.setPuntos(est.getPuntos());
                    dto.setRebotes(est.getRebotes());
                    dto.setAsistencias(est.getAsistencias());
                    dto.setRobos(est.getRobos());
                    dto.setTapones(est.getTapones());
                    dto.setPerdidas(est.getPerdidas());
                    return dto;
                }).collect(Collectors.toList());

        List<BasketEstadisticasJugador> estadisticasJugadores =
                estadisticasJugadorRepositorio.findByIdPartido(partido);

        List<EstadisticaJugadorDTO> jugadoresDTO = estadisticasJugadores.stream()
                .map(est -> {
                    EstadisticaJugadorDTO dto = new EstadisticaJugadorDTO();
                    dto.setIdJugador(est.getIdJugador().getId());
                    dto.setPartidoId(est.getIdPartido().getId());
                    dto.setPuntos(est.getPuntos());
                    dto.setRebotes(est.getRebotes());
                    dto.setAsistencias(est.getAsistencias());
                    dto.setRobos(est.getRobos());
                    dto.setTapones(est.getTapones());
                    dto.setPerdidas(est.getPerdidas());
                    return dto;
                }).collect(Collectors.toList());

        EstadisticasPartidoDTO dto = new EstadisticasPartidoDTO();
        dto.setPartidoId(partidoId);
        dto.setEstadisticasEquipos(equiposDTO);
        dto.setEstadisticasJugadores(jugadoresDTO);

        return dto;
    }

    // Obtener partido por ID
    public Optional<BasketPartido> obtenerPartidoPorId(Integer id) {
        return basketPartidoRepositorio.findById(id);
    }

    // Crear un nuevo partido
    public BasketPartido crearPartido(BasketPartido partido) {
        return basketPartidoRepositorio.save(partido);
    }

    // Actualizar un partido
    public BasketPartido actualizarPartido(Integer id, BasketPartido partidoActualizado) {
        if (basketPartidoRepositorio.existsById(id)) {
            partidoActualizado.setId(id);
            return basketPartidoRepositorio.save(partidoActualizado);
        } else {
            return null;
        }
    }

    // Eliminar un partido
    public boolean eliminarPartido(Integer id) {
        if (basketPartidoRepositorio.existsById(id)) {
            basketPartidoRepositorio.deleteById(id);
            return true;
        } else {
            return false;
        }
    }

    public void generarPlantillaCSV(String filePath) throws IOException {
        // Crear un FileWriter para el archivo donde se guardará la plantilla
        try (FileWriter writer = new FileWriter(filePath);
             CSVPrinter csvPrinter = new CSVPrinter(writer, CSVFormat.DEFAULT.withHeader("Competicion", "Equipo Local", "Equipo Visitante", "Fecha", "Resultado Local", "Resultado Visitante", "Arbitro").withDelimiter(';'))) {
            csvPrinter.flush();
        }
    }

    public void cargarPartidosDesdeCSV(MultipartFile file) throws IOException {
        try (CSVParser csvParser = CSVFormat.DEFAULT.withHeader().withDelimiter(';').parse(new InputStreamReader(file.getInputStream()))) {
            for (CSVRecord record : csvParser) {
                // Obtener los valores del CSV
                String competicionNombre = record.get("Competición");
                String equipoLocalNombre = record.get("Equipo Local");
                String equipoVisitanteNombre = record.get("Equipo Visitante");
                String fechaString = record.get("Fecha");
                int resultadoLocal = Integer.parseInt(record.get("Resultado Local"));
                int resultadoVisitante = Integer.parseInt(record.get("Resultado Visitante"));
                String arbitroNombre = record.get("Árbitro");

                // Buscar la competición
                BasketCompeticione competicion = competicionRepository.findByNombre(competicionNombre)
                        .orElseThrow(() -> new RuntimeException("Competición no encontrada"));

                // Buscar los equipos
                BasketEquipo equipoLocal = equipoRepository.findByNombre(equipoLocalNombre)
                        .orElseThrow(() -> new RuntimeException("Equipo local no encontrado"));
                BasketEquipo equipoVisitante = equipoRepository.findByNombre(equipoVisitanteNombre)
                        .orElseThrow(() -> new RuntimeException("Equipo visitante no encontrado"));

                // Buscar el árbitro
                BasketArbitro arbitro = arbitroRepository.findByNombre(arbitroNombre)
                        .orElseThrow(() -> new RuntimeException("Árbitro no encontrado"));

                // Parsear la fecha
                LocalDate fecha = parse(fechaString);

                // Crear el nuevo partido
                BasketPartido partido = new BasketPartido();
                partido.setIdCompeticion(competicion);
                partido.setEquipoLocal(equipoLocal);
                partido.setEquipoVisitante(equipoVisitante);
                partido.setFecha(fecha);
                partido.setResultadoLocal(resultadoLocal);
                partido.setResultadoVisitante(resultadoVisitante);
                partido.setIdArbitro(arbitro);

                // Guardar el partido en la base de datos
                basketPartidoRepositorio.save(partido);
            }
        }
    }
    public List<PartidoDTO> obtenerPartidos(String nombreCompeticion) {
        BasketCompeticione competicion = competicionRepository.findByNombre(nombreCompeticion)
                .orElseThrow(() -> new RuntimeException("Competición no encontrada"));

        List<BasketPartido> partidos = basketPartidoRepositorio.findByIdCompeticion(competicion);

        return partidos.stream().map(p -> {
            PartidoDTO dto = new PartidoDTO();
            dto.setJornada(p.getJornada());
            dto.setId(p.getId());
            dto.setFecha(p.getFecha());
            dto.setEquipoLocal(p.getEquipoLocal().getNombre());
            dto.setEquipoVisitante(p.getEquipoVisitante().getNombre());
            if(p.getResultadoLocal() == null || p.getResultadoVisitante() == null) {
                if(p.getFecha().isAfter(LocalDate.now()) )
                    dto.setResultado("Aún sin disputar");
                else {
                    dto.setResultado("Faltan por añadir las estadisticas");
                }
            } else {
                dto.setResultado(p.getResultadoLocal()
                        + "-" + p.getResultadoVisitante());
            }
            return dto;
        }).collect(Collectors.toList());
    }

    @Transactional
    public void registrarEstadisticasDelPartido(Integer idPartido, EstadisticasPartidoDTO dto) {
        BasketPartido partido = basketPartidoRepositorio.findById(idPartido)
                .orElseThrow(() -> new RuntimeException("Partido no encontrado"));

        if (dto.getEstadisticasEquipos().size() != 2) {
            throw new IllegalArgumentException("Debe haber exactamente dos estadísticas de equipo (local y visitante).");
        }

        EstadisticaEquipoDTO estadisticaEquipoLocalDTO = dto.getEstadisticasEquipos().get(0);
        EstadisticaEquipoDTO estadisticaEquipoVisitanteDTO = dto.getEstadisticasEquipos().get(1);


        BasketEstadisticasEquipo estadisticasLocal = new BasketEstadisticasEquipo();
        BasketEstadisticasEquipo estadisticasVisitante =new BasketEstadisticasEquipo();

        Optional<BasketEquipo> equipoLocal = equipoRepository.findByNombre(estadisticaEquipoLocalDTO.getEquipo());

        estadisticasLocal.setIdEquipo(equipoLocal.get());
        estadisticasLocal.setIdPartido(partido);
        estadisticasLocal.setPuntos(estadisticaEquipoLocalDTO.getPuntos());
        estadisticasLocal.setRebotes(estadisticaEquipoLocalDTO.getRebotes());
        estadisticasLocal.setRobos(estadisticaEquipoLocalDTO.getRobos());
        estadisticasLocal.setPerdidas(estadisticaEquipoLocalDTO.getPerdidas());
        estadisticasLocal.setTapones(estadisticaEquipoLocalDTO.getTapones());
        estadisticasLocal.setAsistencias(estadisticaEquipoLocalDTO.getAsistencias());



        Optional<BasketEquipo> equipoVis = equipoRepository.findByNombre(estadisticaEquipoVisitanteDTO.getEquipo());

        estadisticasVisitante.setIdEquipo(equipoVis.get());
        estadisticasVisitante.setIdPartido(partido);
        estadisticasVisitante.setPuntos(estadisticaEquipoVisitanteDTO.getPuntos());
        estadisticasVisitante.setRebotes(estadisticaEquipoVisitanteDTO.getRebotes());
        estadisticasVisitante.setRobos(estadisticaEquipoVisitanteDTO.getRobos());
        estadisticasVisitante.setPerdidas(estadisticaEquipoVisitanteDTO.getPerdidas());
        estadisticasVisitante.setTapones(estadisticaEquipoVisitanteDTO.getTapones());
        estadisticasVisitante.setAsistencias(estadisticaEquipoVisitanteDTO.getAsistencias());

        estadisticasEquipoRepositorio.save(estadisticasLocal);
        estadisticasEquipoRepositorio.save(estadisticasVisitante);


        // Guardar estadísticas de jugadores
        for (var estadisticaJugador : dto.getEstadisticasJugadores()) {
            BasketJugadore jugador = jugadorRepositorio.findById(estadisticaJugador.getIdJugador())
                    .orElseThrow(() -> new RuntimeException("Jugador no encontrado"));
            BasketEstadisticasJugador estadisticasJugador = new BasketEstadisticasJugador();

            estadisticasJugador.setIdJugador(jugador);
            estadisticasJugador.setIdPartido(partido);
            estadisticasJugador.setPuntos(estadisticaJugador.getPuntos());
            estadisticasJugador.setRebotes(estadisticaJugador.getRebotes());
            estadisticasJugador.setAsistencias(estadisticaJugador.getAsistencias());
            estadisticasJugador.setRobos(estadisticaJugador.getRobos());
            estadisticasJugador.setTapones(estadisticaJugador.getTapones());
            estadisticasJugador.setPerdidas(estadisticaJugador.getPerdidas());
            estadisticasJugadorRepositorio.save(estadisticasJugador);
        }

        // Actualizar resultado del partido
        partido.setResultadoLocal(estadisticasLocal.getPuntos());
        partido.setResultadoVisitante(estadisticasVisitante.getPuntos());
        basketPartidoRepositorio.save(partido);
    }
}
