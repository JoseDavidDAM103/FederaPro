package com.example.federaproapi.basket.controladores;

import com.example.federaproapi.basket.modelos.BasketEstadisticasJugador;
import com.example.federaproapi.basket.servicios.BasketEstadisticasJugadorServicio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

import static com.example.federaproapi.basket.BasketConstants.BASKET;

@RestController
@RequestMapping(BASKET + "/estadisticas/jugadores")
public class BasketEstadisticasJugadorControlador {

    @Autowired
    private BasketEstadisticasJugadorServicio estadisticasJugadorServicio;

    // Obtener todas las estadísticas de jugadores
    @GetMapping
    public ResponseEntity<List<BasketEstadisticasJugador>> obtenerTodasLasEstadisticas() {
        List<BasketEstadisticasJugador> estadisticas = estadisticasJugadorServicio.obtenerTodasLasEstadisticas();
        return new ResponseEntity<>(estadisticas, HttpStatus.OK);
    }

    // Obtener estadísticas de un jugador específico
    @GetMapping("/{id}")
    public ResponseEntity<BasketEstadisticasJugador> obtenerEstadisticasJugador(@PathVariable Integer id) {
        Optional<BasketEstadisticasJugador> estadisticas = estadisticasJugadorServicio.obtenerEstadisticasJugadorPorId(id);
        return estadisticas.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }

    // Guardar estadísticas de jugador
    @PostMapping
    public ResponseEntity<BasketEstadisticasJugador> crearEstadisticasJugador(@RequestBody BasketEstadisticasJugador estadisticasJugador) {
        BasketEstadisticasJugador nuevaEstadistica = estadisticasJugadorServicio.guardarEstadisticasJugador(estadisticasJugador);
        return new ResponseEntity<>(nuevaEstadistica, HttpStatus.CREATED);
    }

    // Eliminar estadísticas de jugador
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> eliminarEstadisticasJugador(@PathVariable Integer id) {
        estadisticasJugadorServicio.eliminarEstadisticasJugador(id);
        return ResponseEntity.noContent().build();
    }

    // Obtener las medias de un jugador específico
    @GetMapping("/medias/{id}")
    public ResponseEntity<BasketEstadisticasJugador> obtenerMediasJugador(@PathVariable Integer id) {
        BasketEstadisticasJugador medias = estadisticasJugadorServicio.calcularMediasJugador(id);
        if (medias == null) {
            return ResponseEntity.notFound().build();
        }
        return new ResponseEntity<>(medias, HttpStatus.OK);
    }
}
