package com.example.federaproapi.karting.controladores;

import com.example.federaproapi.karting.modelos.KartingPiloto;
import com.example.federaproapi.karting.servicios.KartingPilotoService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/karting/pilotos")
@CrossOrigin(origins = "*")
public class KartingPilotoController {

    private final KartingPilotoService pilotoService;

    public KartingPilotoController(KartingPilotoService pilotoService) {
        this.pilotoService = pilotoService;
    }

    @GetMapping
    public List<KartingPiloto> getAllPilotos() {
        return pilotoService.findAll();
    }

    @GetMapping("/{id}")
    public ResponseEntity<KartingPiloto> getPilotoById(@PathVariable Integer id) {
        return pilotoService.findById(id)
                .map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }

    @PostMapping
    public KartingPiloto createPiloto(@RequestBody KartingPiloto piloto) {
        return pilotoService.save(piloto);
    }

    @PutMapping("/{id}")
    public ResponseEntity<KartingPiloto> updatePiloto(@PathVariable Integer id, @RequestBody KartingPiloto updated) {
        return pilotoService.findById(id)
                .map(existing -> {
                    updated.setId(id);
                    return ResponseEntity.ok(pilotoService.save(updated));
                }).orElse(ResponseEntity.notFound().build());
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deletePiloto(@PathVariable Integer id) {
        if (pilotoService.findById(id).isPresent()) {
            pilotoService.deleteById(id);
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.notFound().build();
    }

    @GetMapping("/equipo/{equipoId}")
    public List<KartingPiloto> getPilotosByEquipo(@PathVariable Integer equipoId) {
        return pilotoService.findByEquipoId(equipoId);
    }
}
