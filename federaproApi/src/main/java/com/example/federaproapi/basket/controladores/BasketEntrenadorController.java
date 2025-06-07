package com.example.federaproapi.basket.controladores;

import com.example.federaproapi.basket.modelos.BasketEntrenadore;
import com.example.federaproapi.basket.servicios.BasketEntrenadorService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

import static com.example.federaproapi.basket.BasketConstants.BASKET;

@RestController
@RequestMapping(BASKET +"/entrenadores")
public class BasketEntrenadorController {

    @Autowired
    private BasketEntrenadorService basketEntrenadoreServicio;

    // Obtener todos los entrenadores de un equipo
    @GetMapping("/equipo/{idEquipo}")
    public ResponseEntity<List<BasketEntrenadore>> obtenerEntrenadoresPorEquipo(@PathVariable Integer idEquipo) {
        List<BasketEntrenadore> entrenadores = basketEntrenadoreServicio.obtenerEntrenadoresPorEquipo(idEquipo);
        return entrenadores.isEmpty() ? ResponseEntity.status(HttpStatus.NOT_FOUND).build() : ResponseEntity.ok(entrenadores);
    }

    // Agregar un nuevo entrenador
    @PostMapping
    public ResponseEntity<BasketEntrenadore> agregarEntrenador(@RequestBody BasketEntrenadore entrenador) {
        BasketEntrenadore nuevoEntrenador = basketEntrenadoreServicio.agregarEntrenador(entrenador);
        return ResponseEntity.status(HttpStatus.CREATED).body(nuevoEntrenador);
    }

    // Obtener un entrenador por su ID
    @GetMapping("/{id}")
    public ResponseEntity<BasketEntrenadore> obtenerEntrenadorPorId(@PathVariable Integer id) {
        Optional<BasketEntrenadore> entrenador = basketEntrenadoreServicio.obtenerEntrenadorPorId(id);
        return entrenador.isPresent() ? ResponseEntity.ok(entrenador.get()) : ResponseEntity.status(HttpStatus.NOT_FOUND).build();
    }
}