package com.example.federaproapi.karting.controladores;

import com.example.federaproapi.karting.dto.KartingPilotoDTO;
import com.example.federaproapi.karting.modelos.KartingEquipo;
import com.example.federaproapi.karting.modelos.KartingPiloto;
import com.example.federaproapi.karting.servicios.KartingEquipoService;
import com.example.federaproapi.karting.servicios.KartingPilotoService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/karting/pilotos")
@CrossOrigin(origins = "*")
public class KartingPilotoController {

    private final KartingPilotoService pilotoService;
    private final KartingEquipoService equipoService;

    public KartingPilotoController(KartingPilotoService pilotoService, KartingEquipoService equipoService) {
        this.pilotoService = pilotoService;
        this.equipoService = equipoService;
    }

    @GetMapping
    public List<KartingPilotoDTO> listarPilotos() {
        return pilotoService.findAll().stream().map(p -> {
            KartingPilotoDTO dto = new KartingPilotoDTO();
            dto.setId(p.getId());
            dto.setEquipoId(p.getIdEquipo().getId());
            dto.setNombre(p.getNombre());
            dto.setCategoria(p.getCategoria());
            dto.setNacionalidad(p.getNacionalidad());
            dto.setFechaNacimiento(p.getFechaNacimiento());
            dto.setNumeroKart(p.getNumeroKart());
            dto.setNombreEquipo(p.getIdEquipo().getNombre());
            return dto;
        }).toList();
    }

    @GetMapping("/{id}")
    public ResponseEntity<KartingPiloto> getPilotoById(@PathVariable Integer id) {
        return pilotoService.findById(id)
                .map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }

    @GetMapping("/competicion/{nombre}")
    public List<KartingPiloto> getPilotosPorCompeticion(@PathVariable String nombre) {
        return pilotoService.obtenerPilotosPorCompeticion(nombre);
    }

    @PostMapping
    public ResponseEntity<?> crearPiloto(@RequestBody KartingPilotoDTO dto) {
        Optional<KartingEquipo> equipo = equipoService.findById(dto.getEquipoId());
        if (equipo.isEmpty()) {
            return ResponseEntity.badRequest().body("Equipo no encontrado");
        }

        KartingPiloto piloto = new KartingPiloto();
        piloto.setIdEquipo(equipo.get());
        piloto.setNombre(dto.getNombre());
        piloto.setCategoria(dto.getCategoria());
        piloto.setNacionalidad(dto.getNacionalidad());
        piloto.setFechaNacimiento(dto.getFechaNacimiento());
        piloto.setNumeroKart(dto.getNumeroKart());

        pilotoService.save(piloto);
        return ResponseEntity.ok("Piloto creado");
    }

    @PutMapping("/{id}")
    public ResponseEntity<?> updatePiloto(@PathVariable Integer id, @RequestBody KartingPilotoDTO dto) {
        return pilotoService.findById(id).map(existing -> {
            Optional<KartingEquipo> equipo = equipoService.findById(dto.getEquipoId());
            if (equipo.isEmpty()) {
                return ResponseEntity.badRequest().body("Equipo no encontrado");
            }

            existing.setNombre(dto.getNombre());
            existing.setCategoria(dto.getCategoria());
            existing.setNacionalidad(dto.getNacionalidad());
            existing.setFechaNacimiento(dto.getFechaNacimiento());
            existing.setNumeroKart(dto.getNumeroKart());
            existing.setIdEquipo(equipo.get());

            pilotoService.save(existing);
            return ResponseEntity.ok("Piloto actualizado");
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
