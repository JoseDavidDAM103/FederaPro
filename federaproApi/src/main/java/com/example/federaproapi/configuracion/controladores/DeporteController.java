package com.example.federaproapi.configuracion.controladores;

import com.example.federaproapi.configuracion.modelos.Deporte;
import com.example.federaproapi.configuracion.servicios.DeporteService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/deportes")
public class DeporteController {

    private final DeporteService deporteService;

    public DeporteController(DeporteService deporteService) {
        this.deporteService = deporteService;
    }

    @GetMapping
    public ResponseEntity<List<Deporte>> obtenerTodos() {
        return ResponseEntity.ok(deporteService.obtenerTodos());
    }

    @GetMapping("/{id}")
    public ResponseEntity<Deporte> obtenerPorId(@PathVariable Integer id) {
        return ResponseEntity.of(deporteService.obtenerPorId(id));
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> eliminar(@PathVariable Integer id) {
        deporteService.eliminar(id);
        return ResponseEntity.noContent().build();
    }
}
