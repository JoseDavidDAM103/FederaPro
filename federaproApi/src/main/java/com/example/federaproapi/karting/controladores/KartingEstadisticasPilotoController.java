package com.example.federaproapi.karting.controladores;

import com.example.federaproapi.karting.dto.KartingEstadisticaPilotoDTO;
import com.example.federaproapi.karting.modelos.KartingCarrera;
import com.example.federaproapi.karting.modelos.KartingEstadisticasPiloto;
import com.example.federaproapi.karting.modelos.KartingPiloto;
import com.example.federaproapi.karting.repositorios.KartingCarreraRepository;
import com.example.federaproapi.karting.repositorios.KartingPilotoRepository;
import com.example.federaproapi.karting.servicios.KartingEstadisticasPilotoService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/karting/estadisticas/piloto")
@CrossOrigin(origins = "*")
public class KartingEstadisticasPilotoController {

    private final KartingEstadisticasPilotoService service;
    private final KartingPilotoRepository kartingPilotoRepository;
    private final KartingCarreraRepository kartingCarreraRepository;

    public KartingEstadisticasPilotoController(KartingEstadisticasPilotoService service, KartingCarreraRepository kartingCarreraRepository, KartingPilotoRepository kartingPilotoRepository) {
        this.service = service;
        this.kartingPilotoRepository = kartingPilotoRepository;
        this.kartingCarreraRepository = kartingCarreraRepository;
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

    @PostMapping("/guardar")
    public List<KartingEstadisticasPiloto> guardarTodasDesdeDTO(@RequestBody List<KartingEstadisticaPilotoDTO> dtos) {
        List<KartingEstadisticasPiloto> guardadas = new ArrayList<>();

        for (KartingEstadisticaPilotoDTO dto : dtos) {
            KartingPiloto piloto = kartingPilotoRepository.findByNombre(dto.getNombrePiloto());
            if (piloto == null) continue; // o lanza excepción si lo prefieres

            KartingCarrera carrera = kartingCarreraRepository.findById(dto.getIdCarrera())
                    .orElseThrow(() -> new RuntimeException("Carrera no encontrada con ID: " + dto.getIdCarrera()));

            KartingEstadisticasPiloto estadistica = new KartingEstadisticasPiloto();
            estadistica.setIdPiloto(piloto);
            estadistica.setIdCarrera(carrera);
            estadistica.setPosicion(dto.getPosicion());
            estadistica.setTiempoTotal(dto.getTiempoTotal());
            estadistica.setVueltas(dto.getVueltas());

            guardadas.add(service.save(estadistica));
        }

        return guardadas;
    }
}