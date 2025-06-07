package com.example.federaproapi.karting.controladores;

import com.example.federaproapi.karting.modelos.KartingCircuito;
import com.example.federaproapi.karting.servicios.KartingCircuitoService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/karting/circuitos")
@CrossOrigin(origins = "*")
public class KartingCircuitoController {

    private final KartingCircuitoService service;

    public KartingCircuitoController(KartingCircuitoService service) {
        this.service = service;
    }

    @GetMapping
    public List<KartingCircuito> getAll() {
        return service.findAll();
    }

    @GetMapping("/{id}")
    public ResponseEntity<KartingCircuito> getById(@PathVariable Integer id) {
        return service.findById(id)
                .map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }

    @PostMapping
    public KartingCircuito create(@RequestBody KartingCircuito circuito) {
        return service.save(circuito);
    }

    @PutMapping("/{id}")
    public ResponseEntity<KartingCircuito> update(@PathVariable Integer id, @RequestBody KartingCircuito updated) {
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
}
