package com.example.federaproapi.karting.controladores;

import com.example.federaproapi.karting.modelos.KartingEstadisticasPiloto;
import com.example.federaproapi.karting.servicios.KartingEstadisticasPilotoService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/karting/estadisticas/piloto")
@CrossOrigin(origins = "*")
public class KartingEstadisticasPilotoController {

    private final KartingEstadisticasPilotoService service;

    public KartingEstadisticasPilotoController(KartingEstadisticasPilotoService service) {
        this.service = service;
    }

    @GetMapping
    public List<KartingEstadisticasPiloto> getAll() {
        return service.findAll();
    }

    @GetMapping("/{id}")
    public ResponseEntity<KartingEstadisticasPiloto> getById(@PathVariable Integer id) {
        return service.findById(id)
                .map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }

    @PostMapping
    public KartingEstadisticasPiloto create(@RequestBody KartingEstadisticasPiloto estadistica) {
        return service.save(estadistica);
    }

    @PutMapping("/{id}")
    public ResponseEntity<KartingEstadisticasPiloto> update(@PathVariable Integer id, @RequestBody KartingEstadisticasPiloto updated) {
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

    @GetMapping("/piloto/{pilotoId}")
    public List<KartingEstadisticasPiloto> getByPiloto(@PathVariable Integer pilotoId) {
        return service.findByPilotoId(pilotoId);
    }

    @GetMapping("/carrera/{carreraId}")
    public List<KartingEstadisticasPiloto> getByCarrera(@PathVariable Integer carreraId) {
        return service.findByCarreraId(carreraId);
    }
}