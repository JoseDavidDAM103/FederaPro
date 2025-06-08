package com.example.federaproapi.karting.controladores;

import com.example.federaproapi.karting.dto.KartingCarreraDTO;
import com.example.federaproapi.karting.dto.KartingClasificacionEquipoDTO;
import com.example.federaproapi.karting.dto.KartingClasificacionPilotoDTO;
import com.example.federaproapi.karting.modelos.KartingCompeticione;
import com.example.federaproapi.karting.servicios.KartingCompeticioneService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/karting/competiciones")
@CrossOrigin(origins = "*")
public class KartingCompeticioneController {

    private final KartingCompeticioneService service;

    public KartingCompeticioneController(KartingCompeticioneService service) {
        this.service = service;
    }

    @GetMapping
    public List<KartingCompeticione> getAll() {
        return service.findAll();
    }

    @GetMapping("/{id}")
    public ResponseEntity<KartingCompeticione> getById(@PathVariable Integer id) {
        return service.findById(id)
                .map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }

    @PostMapping
    public KartingCompeticione create(@RequestBody KartingCompeticione competicion) {
        return service.save(competicion);
    }

    @PutMapping("/{id}")
    public ResponseEntity<KartingCompeticione> update(@PathVariable Integer id, @RequestBody KartingCompeticione updated) {
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

    @GetMapping("/{nombre}/carreras")
    public List<KartingCarreraDTO> getCarrerasDeCompeticion(@PathVariable String nombre) {
        return service.getCarrerasDeCompeticion(nombre);
    }

    @GetMapping("/{nombre}/clasificacion/pilotos")
    public List<KartingClasificacionPilotoDTO> clasificacionPilotos(@PathVariable String nombre) {
        return service.getClasificacionPilotos(nombre);
    }

    @GetMapping("/{nombre}/clasificacion/equipos")
    public List<KartingClasificacionEquipoDTO> clasificacionEquipos(@PathVariable String nombre) {
        return service.getClasificacionEquipos(nombre);
    }
}
