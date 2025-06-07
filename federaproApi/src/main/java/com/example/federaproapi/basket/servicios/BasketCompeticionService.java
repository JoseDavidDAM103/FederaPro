package com.example.federaproapi.basket.servicios;

import com.example.federaproapi.basket.ClasificacionEquipoDTO;
import com.example.federaproapi.basket.modelos.BasketCompeticione;
import com.example.federaproapi.basket.modelos.BasketEquipo;
import com.example.federaproapi.basket.modelos.BasketPartido;
import com.example.federaproapi.basket.repositorios.BasketCompeticioneRepositorio;
import com.example.federaproapi.basket.repositorios.BasketPartidoRepositorio;
import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.util.*;
import java.util.stream.Collectors;

@Service
public class BasketCompeticionService {

    @Autowired
    private BasketCompeticioneRepositorio basketCompeticioneRepositorio;

    @Autowired
    private BasketPartidoRepositorio basketPartidoRepositorio;

    // Obtener todos los competiciones
    public List<BasketCompeticione> obtenerTodasLasCompeticiones() {
        return basketCompeticioneRepositorio.findAll();
    }

    // Obtener competicion por ID
    public Optional<BasketCompeticione> obtenerCompeticionPorId(Integer id) {
        return basketCompeticioneRepositorio.findById(id);
    }

    // Crear una nueva competicion
    public BasketCompeticione crearCompeticion(BasketCompeticione competicion) {
        return basketCompeticioneRepositorio.save(competicion);
    }

    // Actualizar competicion
    public BasketCompeticione actualizarCompeticion(Integer id, BasketCompeticione competicionActualizada) {
        if (basketCompeticioneRepositorio.existsById(id)) {
            competicionActualizada.setId(id);
            return basketCompeticioneRepositorio.save(competicionActualizada);
        } else {
            return null;
        }
    }

    // Eliminar competicion
    public boolean eliminarCompeticion(Integer id) {
        if (basketCompeticioneRepositorio.existsById(id)) {
            basketCompeticioneRepositorio.deleteById(id);
            return true;
        } else {
            return false;
        }
    }

    @Transactional
    public void generarPartidos(String nombreCompeticion) {
            BasketCompeticione competicion = basketCompeticioneRepositorio.findByNombre(nombreCompeticion)
                    .orElseThrow(() -> new RuntimeException("Competición no encontrada"));

            List<BasketEquipo> equipos = new ArrayList<>(competicion.getEquipos());

            if (equipos.size() % 2 != 0) {
                equipos.add(null); // añadir "bye" si número impar
            }

            int numEquipos = equipos.size();
            int numJornadas = (numEquipos - 1) * 2;
            int partidosPorJornada = numEquipos / 2;

            List<BasketPartido> partidos = new ArrayList<>();

            // Generar partidos por jornada (ida y vuelta)
            for (int jornada = 0; jornada < numJornadas; jornada++) {
                for (int i = 0; i < partidosPorJornada; i++) {
                    int localIndex = (jornada + i) % (numEquipos - 1);
                    int visitanteIndex = (numEquipos - 1 - i + jornada) % (numEquipos - 1);

                    if (i == 0) visitanteIndex = numEquipos - 1;

                    BasketEquipo local = equipos.get(localIndex);
                    BasketEquipo visitante = equipos.get(visitanteIndex);

                    // Si es jornada de vuelta, se invierte localía
                    boolean esVuelta = jornada >= (numJornadas / 2);
                    if (esVuelta) {
                        BasketEquipo temp = local;
                        local = visitante;
                        visitante = temp;
                    }

                    // Ignorar partidos con "bye" (null)
                    if (local == null || visitante == null) continue;

                    BasketPartido partido = new BasketPartido();
                    partido.setIdCompeticion(competicion);
                    partido.setEquipoLocal(local);
                    partido.setEquipoVisitante(visitante);
                    partido.setJornada(jornada + 1);
                    partido.setFecha(LocalDate.of(2025, 5, 20).plusDays(jornada * 7)); // una jornada por semana

                    partidos.add(partido);
                }
            }

            basketPartidoRepositorio.saveAll(partidos);
        }

    public List<ClasificacionEquipoDTO> obtenerClasificacion(String nombreCompeticion) {
        BasketCompeticione competicion = basketCompeticioneRepositorio.findByNombre(nombreCompeticion)
                .orElseThrow(() -> new RuntimeException("Competición no encontrada"));

        List<BasketPartido> partidos = basketPartidoRepositorio.findByIdCompeticion(competicion);

        Map<String, ClasificacionEquipoDTO> tabla = new HashMap<>();

        for (BasketPartido partido : partidos) {
            if (partido.getResultadoLocal() == null || partido.getResultadoVisitante() == null) {
                continue;
            }
            String local = partido.getEquipoLocal().getNombre();
            String visitante = partido.getEquipoVisitante().getNombre();
            int resultadoLocal = partido.getResultadoLocal(); // Ej: "80-75"
            int resultadoVis = partido.getResultadoVisitante();

            tabla.putIfAbsent(local, new ClasificacionEquipoDTO(local, 0, 0, 0, 0));
            tabla.putIfAbsent(visitante, new ClasificacionEquipoDTO(visitante, 0, 0, 0, 0));

            ClasificacionEquipoDTO localStats = tabla.get(local);
            ClasificacionEquipoDTO visitanteStats = tabla.get(visitante);

            localStats.setPartidosJugados(localStats.getPartidosJugados() + 1);
            visitanteStats.setPartidosJugados(visitanteStats.getPartidosJugados() + 1);

            if (resultadoLocal > resultadoVis) {
                localStats.setVictorias(localStats.getVictorias() + 1);
                visitanteStats.setDerrotas(visitanteStats.getDerrotas() + 1);
                localStats.setPuntos(localStats.getPuntos() + 1);
            } else {
                visitanteStats.setVictorias(visitanteStats.getVictorias() + 1);
                localStats.setDerrotas(localStats.getDerrotas() + 1);
                visitanteStats.setPuntos(visitanteStats.getPuntos() + 1);
            }
        }

        return tabla.values().stream()
                .sorted(Comparator.comparingInt(ClasificacionEquipoDTO::getPuntos).reversed())
                .collect(Collectors.toList());
    }
}