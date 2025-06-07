package com.example.federaproapi.basket.controladores;

import com.example.federaproapi.basket.modelos.BasketEstadisticasEquipo;
import com.example.federaproapi.basket.servicios.BasketEstadisticasEquipoServicio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

import static com.example.federaproapi.basket.BasketConstants.BASKET;

@RestController
@RequestMapping(BASKET +"/estadisticas-equipo")
public class BasketEstadisticasEquipoControlador {

    @Autowired
    private BasketEstadisticasEquipoServicio basketEstadisticasEquipoServicio;

    // Obtener estadísticas de un equipo en un partido específico
    @GetMapping("/equipo/{idEquipo}/partido/{idPartido}")
    public ResponseEntity<BasketEstadisticasEquipo> obtenerEstadisticasPorEquipoYPartido(@PathVariable Integer idEquipo, @PathVariable Integer idPartido) {
        Optional<BasketEstadisticasEquipo> estadisticas = basketEstadisticasEquipoServicio.obtenerEstadisticasPorEquipoYPartido(idEquipo, idPartido);
        return estadisticas.isPresent() ? ResponseEntity.ok(estadisticas.get()) : ResponseEntity.status(HttpStatus.NOT_FOUND).build();
    }

    // Obtener todas las estadísticas de un equipo
    @GetMapping("/equipo/{idEquipo}")
    public ResponseEntity<List<BasketEstadisticasEquipo>> obtenerEstadisticasPorEquipo(@PathVariable Integer idEquipo) {
        List<BasketEstadisticasEquipo> estadisticas = basketEstadisticasEquipoServicio.obtenerEstadisticasPorEquipo(idEquipo);
        return estadisticas.isEmpty() ? ResponseEntity.status(HttpStatus.NOT_FOUND).build() : ResponseEntity.ok(estadisticas);
    }

    // Agregar nuevas estadísticas de equipo
    @PostMapping
    public ResponseEntity<BasketEstadisticasEquipo> agregarEstadisticasEquipo(@RequestBody BasketEstadisticasEquipo estadisticas) {
        BasketEstadisticasEquipo nuevaEstadistica = basketEstadisticasEquipoServicio.agregarEstadisticasEquipo(estadisticas);
        return ResponseEntity.status(HttpStatus.CREATED).body(nuevaEstadistica);
    }

    // Obtener las medias de las estadísticas de un equipo
    @GetMapping("/equipo/{idEquipo}/media")
    public ResponseEntity<BasketEstadisticasEquipo> obtenerMediasEstadisticasPorEquipo(@PathVariable Integer idEquipo) {
        Optional<BasketEstadisticasEquipo> medias = basketEstadisticasEquipoServicio.obtenerMediasEstadisticasPorEquipo(idEquipo);
        return medias.isPresent() ? ResponseEntity.ok(medias.get()) : ResponseEntity.status(HttpStatus.NOT_FOUND).build();
    }
}

