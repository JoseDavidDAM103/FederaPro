package com.example.federaproapi.karting.controladores;

import com.example.federaproapi.karting.modelos.KartingEquipo;
import com.example.federaproapi.karting.servicios.KartingEquipoService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/karting/equipos")
@CrossOrigin(origins = "*")
public class KartingEquipoController {

    private final KartingEquipoService equipoService;

    public KartingEquipoController(KartingEquipoService equipoService) {
        this.equipoService = equipoService;
    }

    @GetMapping
    public List<KartingEquipo> getAllEquipos() {
        return equipoService.findAll();
    }

    @GetMapping("/{id}")
    public ResponseEntity<KartingEquipo> getEquipoById(@PathVariable Integer id) {
        return equipoService.findById(id)
                .map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }

    @PostMapping
    public KartingEquipo createEquipo(@RequestBody KartingEquipo equipo) {
        return equipoService.save(equipo);
    }

    @PutMapping("/{id}")
    public ResponseEntity<KartingEquipo> updateEquipo(@PathVariable Integer id, @RequestBody KartingEquipo updated) {
        return equipoService.findById(id)
                .map(existing -> {
                    updated.setId(id);
                    return ResponseEntity.ok(equipoService.save(updated));
                }).orElse(ResponseEntity.notFound().build());
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteEquipo(@PathVariable Integer id) {
        if (equipoService.findById(id).isPresent()) {
            equipoService.deleteById(id);
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.notFound().build();
    }
}
