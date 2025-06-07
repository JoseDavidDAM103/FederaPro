package com.example.federaproapi.basket.servicios;

import com.example.federaproapi.basket.modelos.BasketEstadisticasEquipo;
import com.example.federaproapi.basket.repositorios.BasketEstadisticasEquipoRepositorio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.math.BigDecimal;
import java.util.List;
import java.util.Optional;

@Service
public class BasketEstadisticasEquipoServicio {

    @Autowired
    private BasketEstadisticasEquipoRepositorio basketEstadisticasEquipoRepositorio;

    // Obtener estadísticas de un equipo en un partido específico
    public Optional<BasketEstadisticasEquipo> obtenerEstadisticasPorEquipoYPartido(Integer idEquipo, Integer idPartido) {
        return basketEstadisticasEquipoRepositorio.findAll().stream()
                .filter(est -> est.getIdEquipo().getId().equals(idEquipo) && est.getIdPartido().getId().equals(idPartido))
                .findFirst();
    }

    // Obtener todas las estadísticas de un equipo
    public List<BasketEstadisticasEquipo> obtenerEstadisticasPorEquipo(Integer idEquipo) {
        return basketEstadisticasEquipoRepositorio.findAll().stream()
                .filter(est -> est.getIdEquipo().getId().equals(idEquipo))
                .toList();
    }

    // Agregar nuevas estadísticas de equipo
    public BasketEstadisticasEquipo agregarEstadisticasEquipo(BasketEstadisticasEquipo estadisticas) {
        return basketEstadisticasEquipoRepositorio.save(estadisticas);
    }

    // Obtener las medias de las estadísticas de un equipo
    public Optional<BasketEstadisticasEquipo> obtenerMediasEstadisticasPorEquipo(Integer idEquipo) {
        List<BasketEstadisticasEquipo> estadisticas = basketEstadisticasEquipoRepositorio.findAll();

        // Filtrar las estadísticas solo del equipo
        List<BasketEstadisticasEquipo> estadisticasEquipo = estadisticas.stream()
                .filter(est -> est.getIdEquipo().getId().equals(idEquipo))
                .toList();

        if (estadisticasEquipo.isEmpty()) {
            return Optional.empty();
        }

        // Inicializamos las variables para las sumas de las estadísticas
        BigDecimal totalPuntos = BigDecimal.ZERO;
        BigDecimal totalRebotes = BigDecimal.ZERO;
        BigDecimal totalAsistencias = BigDecimal.ZERO;
        BigDecimal totalRobos = BigDecimal.ZERO;
        BigDecimal totalTapones = BigDecimal.ZERO;
        BigDecimal totalPerdidas = BigDecimal.ZERO;

        // Sumamos las estadísticas de todos los partidos
        for (BasketEstadisticasEquipo est : estadisticasEquipo) {
            totalPuntos = totalPuntos.add(new BigDecimal(est.getPuntos()));
            totalRebotes = totalRebotes.add(new BigDecimal(est.getRebotes()));
            totalAsistencias = totalAsistencias.add(new BigDecimal(est.getAsistencias()));
            totalRobos = totalRobos.add(new BigDecimal(est.getRobos()));
            totalTapones = totalTapones.add(new BigDecimal(est.getTapones()));
            totalPerdidas = totalPerdidas.add(new BigDecimal(est.getPerdidas()));
        }

// Calculamos las medias
        int cantidadPartidos = estadisticasEquipo.size();
        BasketEstadisticasEquipo medias = new BasketEstadisticasEquipo();
        medias.setPuntos(totalPuntos.divide(new BigDecimal(cantidadPartidos), BigDecimal.ROUND_HALF_UP).intValue());
        medias.setRebotes(totalRebotes.divide(new BigDecimal(cantidadPartidos), BigDecimal.ROUND_HALF_UP).intValue());
        medias.setAsistencias(totalAsistencias.divide(new BigDecimal(cantidadPartidos), BigDecimal.ROUND_HALF_UP).intValue());
        medias.setRobos(totalRobos.divide(new BigDecimal(cantidadPartidos), BigDecimal.ROUND_HALF_UP).intValue());
        medias.setTapones(totalTapones.divide(new BigDecimal(cantidadPartidos), BigDecimal.ROUND_HALF_UP).intValue());
        medias.setPerdidas(totalPerdidas.divide(new BigDecimal(cantidadPartidos), BigDecimal.ROUND_HALF_UP).intValue());

        return Optional.of(medias);
    }
}

