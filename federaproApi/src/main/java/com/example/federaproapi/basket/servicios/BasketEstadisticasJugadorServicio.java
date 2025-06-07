package com.example.federaproapi.basket.servicios;

import com.example.federaproapi.basket.modelos.BasketEstadisticasJugador;
import com.example.federaproapi.basket.modelos.BasketJugadore;
import com.example.federaproapi.basket.modelos.BasketPartido;
import com.example.federaproapi.basket.repositorios.BasketEstadisticasJugadorRepositorio;
import com.example.federaproapi.basket.repositorios.BasketJugadorRepositorio;
import com.example.federaproapi.basket.repositorios.BasketPartidoRepositorio;
import org.apache.commons.csv.CSVFormat;
import org.apache.commons.csv.CSVParser;
import org.apache.commons.csv.CSVRecord;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigDecimal;
import java.util.List;
import java.util.Optional;

@Service
public class BasketEstadisticasJugadorServicio {

    @Autowired
    private BasketEstadisticasJugadorRepositorio estadisticasJugadorRepositorio;


    @Autowired
    private BasketPartidoRepositorio partidoRepository;

    @Autowired
    private BasketJugadorRepositorio jugadorRepository;

    // Método para obtener todas las estadísticas de jugadores
    public List<BasketEstadisticasJugador> obtenerTodasLasEstadisticas() {
        return estadisticasJugadorRepositorio.findAll();
    }

    // Método para obtener las estadísticas de un jugador específico
    public Optional<BasketEstadisticasJugador> obtenerEstadisticasJugadorPorId(Integer id) {
        return estadisticasJugadorRepositorio.findById(id);
    }

    // Método para guardar nuevas estadísticas de jugador
    public BasketEstadisticasJugador guardarEstadisticasJugador(BasketEstadisticasJugador estadisticasJugador) {
        return estadisticasJugadorRepositorio.save(estadisticasJugador);
    }

    // Método para borrar estadísticas de jugador
    public void eliminarEstadisticasJugador(Integer id) {
        estadisticasJugadorRepositorio.deleteById(id);
    }

    public void cargarEstadisticasDesdeCSV(Integer idPartido, InputStreamReader fileReader) throws IOException {
        try (CSVParser csvParser = CSVFormat.DEFAULT.withHeader().withDelimiter(';').parse(fileReader)) {
            for (CSVRecord record : csvParser) {
                // Leer los valores del CSV
                String nombreJugador = record.get("Nombre Jugador");
                Integer puntos = Integer.parseInt(record.get("Puntos"));
                Integer rebotes = Integer.parseInt(record.get("Rebotes"));
                Integer asistencias = Integer.parseInt(record.get("Asistencias"));
                Integer robos = Integer.parseInt(record.get("Robos"));
                Integer tapones = Integer.parseInt(record.get("Tapones"));
                Integer perdidas = Integer.parseInt(record.get("Perdidas"));
                BigDecimal minutos = new BigDecimal(record.get("Minutos"));

                // Verificar si el partido existe
                BasketPartido partido = partidoRepository.findById(idPartido)
                        .orElseThrow(() -> new RuntimeException("Partido no encontrado"));

                // Buscar el jugador por nombre
                BasketJugadore jugador = jugadorRepository.findByNombre(nombreJugador)
                        .orElseThrow(() -> new RuntimeException("Jugador no encontrado"));

                // Crear y guardar la estadística del jugador
                BasketEstadisticasJugador estadisticas = new BasketEstadisticasJugador();
                estadisticas.setIdPartido(partido);
                estadisticas.setIdJugador(jugador);
                estadisticas.setPuntos(puntos);
                estadisticas.setRebotes(rebotes);
                estadisticas.setAsistencias(asistencias);
                estadisticas.setRobos(robos);
                estadisticas.setTapones(tapones);
                estadisticas.setPerdidas(perdidas);
                estadisticas.setMinutos(minutos);

                estadisticasJugadorRepositorio.save(estadisticas);
            }
        }
    }


    // Método para calcular las medias de un jugador
    public BasketEstadisticasJugador calcularMediasJugador(Integer jugadorId) {
        // Obtiene todas las estadísticas del jugador
        List<BasketEstadisticasJugador> estadisticasJugador = estadisticasJugadorRepositorio.findByIdJugador_Id(jugadorId);

        // Si no hay estadísticas, retornamos null o alguna respuesta adecuada
        if (estadisticasJugador.isEmpty()) {
            return null;
        }

        // Inicializamos las variables para calcular las sumas
        BigDecimal totalPuntos = BigDecimal.ZERO;
        BigDecimal totalRebotes = BigDecimal.ZERO;
        BigDecimal totalAsistencias = BigDecimal.ZERO;
        BigDecimal totalRobos = BigDecimal.ZERO;
        BigDecimal totalTapones = BigDecimal.ZERO;
        BigDecimal totalPerdidas = BigDecimal.ZERO;

        // Iteramos sobre las estadísticas del jugador para calcular el total
        for (BasketEstadisticasJugador estadistica : estadisticasJugador) {
            totalPuntos = totalPuntos.add(new BigDecimal(estadistica.getPuntos()));
            totalRebotes = totalRebotes.add(new BigDecimal(estadistica.getRebotes()));
            totalAsistencias = totalAsistencias.add(new BigDecimal(estadistica.getAsistencias()));
            totalRobos = totalRobos.add(new BigDecimal(estadistica.getRobos()));
            totalTapones = totalTapones.add(new BigDecimal(estadistica.getTapones()));
            totalPerdidas = totalPerdidas.add(new BigDecimal(estadistica.getPerdidas()));
        }

        // Calculamos la media dividiendo el total entre la cantidad de partidos
        BigDecimal cantidadPartidos = new BigDecimal(estadisticasJugador.size());

        BasketEstadisticasJugador medias = new BasketEstadisticasJugador();
        medias.setPuntos(totalPuntos.divide(cantidadPartidos, 2, BigDecimal.ROUND_HALF_UP).intValue());
        medias.setRebotes(totalRebotes.divide(cantidadPartidos, 2, BigDecimal.ROUND_HALF_UP).intValue());
        medias.setAsistencias(totalAsistencias.divide(cantidadPartidos, 2, BigDecimal.ROUND_HALF_UP).intValue());
        medias.setRobos(totalRobos.divide(cantidadPartidos, 2, BigDecimal.ROUND_HALF_UP).intValue());
        medias.setTapones(totalTapones.divide(cantidadPartidos, 2, BigDecimal.ROUND_HALF_UP).intValue());
        medias.setPerdidas(totalPerdidas.divide(cantidadPartidos, 2, BigDecimal.ROUND_HALF_UP).intValue());

        return medias;
    }
}

