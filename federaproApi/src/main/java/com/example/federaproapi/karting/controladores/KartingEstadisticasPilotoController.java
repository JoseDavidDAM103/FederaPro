package com.example.federaproapi.karting.controladores;

import com.example.federaproapi.karting.dto.KartingEstadisticaDTO;
import com.example.federaproapi.karting.dto.KartingEstadisticaPilotoDTO;
import com.example.federaproapi.karting.modelos.KartingCarrera;
import com.example.federaproapi.karting.modelos.KartingEstadisticasPiloto;
import com.example.federaproapi.karting.modelos.KartingPiloto;
import com.example.federaproapi.karting.repositorios.KartingCarreraRepository;
import com.example.federaproapi.karting.repositorios.KartingEstadisticasPilotoRepository;
import com.example.federaproapi.karting.repositorios.KartingPilotoRepository;
import com.example.federaproapi.karting.servicios.KartingEstadisticasPilotoService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.*;
import java.util.stream.Collectors;

@RestController
@RequestMapping("/karting/estadisticas/piloto")
@CrossOrigin(origins = "*")
public class KartingEstadisticasPilotoController {

    private final KartingEstadisticasPilotoService service;
    private final KartingEstadisticasPilotoRepository estadisticasPilotoRepository;
    private final KartingPilotoRepository kartingPilotoRepository;
    private final KartingCarreraRepository kartingCarreraRepository;

    public KartingEstadisticasPilotoController(KartingEstadisticasPilotoService service, KartingCarreraRepository kartingCarreraRepository,
                                               KartingPilotoRepository kartingPilotoRepository, KartingEstadisticasPilotoRepository estadisticasPilotoRepository) {
        this.service = service;
        this.kartingPilotoRepository = kartingPilotoRepository;
        this.kartingCarreraRepository = kartingCarreraRepository;
        this.estadisticasPilotoRepository = estadisticasPilotoRepository;
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

    @GetMapping("/victorias")
    public List<KartingEstadisticaDTO> getVictorias(@RequestParam String nombreCompeticion) {
        List<KartingEstadisticasPiloto> todas = estadisticasPilotoRepository.findByCompeticion(nombreCompeticion);

        Map<String, Long> conteo = todas.stream()
                .filter(e -> e.getPosicion() != null && e.getPosicion() == 1)
                .collect(Collectors.groupingBy(e -> e.getIdPiloto().getNombre(), Collectors.counting()));

        return mapearEstadisticas(conteo);
    }

    @GetMapping("/podios")
    public List<KartingEstadisticaDTO> getPodios(@RequestParam String nombreCompeticion) {
        List<KartingEstadisticasPiloto> todas = estadisticasPilotoRepository.findByCompeticion(nombreCompeticion);

        Map<String, Long> conteo = todas.stream()
                .filter(e -> e.getPosicion() != null && e.getPosicion() <= 3)
                .collect(Collectors.groupingBy(e -> e.getIdPiloto().getNombre(), Collectors.counting()));

        return mapearEstadisticas(conteo);
    }

    @GetMapping("/vueltas")
    public List<KartingEstadisticaDTO> getVueltas(@RequestParam String nombreCompeticion) {
        List<KartingEstadisticasPiloto> todas = estadisticasPilotoRepository.findByCompeticion(nombreCompeticion);

        Map<String, Integer> sumatorio = new HashMap<>();

        for (var estadistica : todas) {
            if (estadistica.getVueltas() != null) {
                String piloto = estadistica.getIdPiloto().getNombre();
                sumatorio.put(piloto, sumatorio.getOrDefault(piloto, 0) + estadistica.getVueltas());
            }
        }

        return sumatorio.entrySet().stream()
                .map(e -> {
                    KartingEstadisticaDTO dto = new KartingEstadisticaDTO();
                    dto.setNombrePiloto(e.getKey());
                    dto.setValor(e.getValue());
                    return dto;
                })
                .sorted((a, b) -> Integer.compare(b.getValor(), a.getValor()))
                .collect(Collectors.toList());
    }

    private List<KartingEstadisticaDTO> mapearEstadisticas(Map<String, Long> conteo) {
        return conteo.entrySet().stream()
                .map(e -> {
                    KartingEstadisticaDTO dto = new KartingEstadisticaDTO();
                    dto.setNombrePiloto(e.getKey());
                    dto.setValor(e.getValue().intValue());
                    return dto;
                })
                .sorted((a, b) -> Integer.compare(b.getValor(), a.getValor()))
                .collect(Collectors.toList());
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
    public List<KartingEstadisticaPilotoDTO> guardarTodasDesdeDTO(@RequestBody List<KartingEstadisticaPilotoDTO> dtos) {
        List<KartingEstadisticaPilotoDTO> guardadas = new ArrayList<>();

        for (KartingEstadisticaPilotoDTO dto : dtos) {
            KartingPiloto piloto = kartingPilotoRepository.findByNombre(dto.getNombrePiloto());
            if (piloto == null) continue;

            KartingCarrera carrera = kartingCarreraRepository.findById(dto.getIdCarrera())
                    .orElseThrow(() -> new RuntimeException("Carrera no encontrada con ID: " + dto.getIdCarrera()));

            KartingEstadisticasPiloto estadistica = new KartingEstadisticasPiloto();
            estadistica.setIdPiloto(piloto);
            estadistica.setIdCarrera(carrera);
            estadistica.setPosicion(dto.getPosicion());
            estadistica.setTiempoTotal(dto.getTiempoTotal());
            estadistica.setVueltas(dto.getVueltas());

            KartingEstadisticasPiloto guardada = service.save(estadistica);
            guardadas.add(toDTO(guardada));
        }

        return guardadas;
    }

    public static KartingEstadisticaPilotoDTO toDTO(KartingEstadisticasPiloto e) {
        KartingEstadisticaPilotoDTO dto = new KartingEstadisticaPilotoDTO();
        dto.setId(e.getId());
        dto.setIdCarrera(e.getIdCarrera().getId());
        dto.setNombrePiloto(e.getIdPiloto().getNombre());
        dto.setPosicion(e.getPosicion());
        dto.setTiempoTotal(e.getTiempoTotal());
        dto.setVueltas(e.getVueltas());
        return dto;
    }
}