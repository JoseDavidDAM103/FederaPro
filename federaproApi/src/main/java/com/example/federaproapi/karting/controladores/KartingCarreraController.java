package com.example.federaproapi.karting.controladores;

import com.example.federaproapi.karting.modelos.KartingCarrera;
import com.example.federaproapi.karting.servicios.KartingCarreraService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/karting/carreras")
@CrossOrigin(origins = "*")
public class KartingCarreraController {

    private final KartingCarreraService service;

    public KartingCarreraController(KartingCarreraService service) {
        this.service = service;
    }

    @GetMapping
    public List<KartingCarrera> getAll() {
        return service.findAll();
    }

    @GetMapping("/{id}")
    public ResponseEntity<KartingCarrera> getById(@PathVariable Integer id) {
        return service.findById(id)
                .map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }

    @PostMapping
    public KartingCarrera create(@RequestBody KartingCarrera carrera) {
        return service.save(carrera);
    }

    @PutMapping("/{id}")
    public ResponseEntity<KartingCarrera> update(@PathVariable Integer id, @RequestBody KartingCarrera updated) {
        return service.findById(id)
                .map(existing -> {
                    updated.setId(id);
                    return ResponseEntity.ok(service.save(updated));
                }).orElse(ResponseEntity.notFound().build());
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> delete(@PathVariable Integer id) {
        if (service.findById(id).isPresent()) {
            service.deleteById(id);
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.notFound().build();
    }

    @GetMapping("/competicion/{idCompeticion}")
    public List<KartingCarrera> getByCompeticion(@PathVariable Integer idCompeticion) {
        return service.findByCompeticionId(idCompeticion);
    }

    @GetMapping("/circuito/{idCircuito}")
    public List<KartingCarrera> getByCircuito(@PathVariable Integer idCircuito) {
        return service.findByCircuitoId(idCircuito);
    }
}