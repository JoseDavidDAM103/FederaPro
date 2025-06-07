package com.example.federaproapi.karting.controladores;

import com.example.federaproapi.karting.modelos.KartingEstadisticasEquipo;
import com.example.federaproapi.karting.servicios.KartingEstadisticasEquipoService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/karting/estadisticas/equipo")
@CrossOrigin(origins = "*")
public class KartingEstadisticasEquipoController {

    private final KartingEstadisticasEquipoService service;

    public KartingEstadisticasEquipoController(KartingEstadisticasEquipoService service) {
        this.service = service;
    }

    @GetMapping
    public List<KartingEstadisticasEquipo> getAll() {
        return service.findAll();
    }

    @GetMapping("/{id}")
    public ResponseEntity<KartingEstadisticasEquipo> getById(@PathVariable Integer id) {
        return service.findById(id)
                .map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }

    @PostMapping
    public KartingEstadisticasEquipo create(@RequestBody KartingEstadisticasEquipo estadistica) {
        return service.save(estadistica);
    }

    @PutMapping("/{id}")
    public ResponseEntity<KartingEstadisticasEquipo> update(@PathVariable Integer id, @RequestBody KartingEstadisticasEquipo updated) {
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

    @GetMapping("/equipo/{equipoId}")
    public List<KartingEstadisticasEquipo> getByEquipo(@PathVariable Integer equipoId) {
        return service.findByEquipoId(equipoId);
    }

    @GetMapping("/carrera/{carreraId}")
    public List<KartingEstadisticasEquipo> getByCarrera(@PathVariable Integer carreraId) {
        return service.findByCarreraId(carreraId);
    }
}
