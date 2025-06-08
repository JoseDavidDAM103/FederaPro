package com.example.federaproapi.karting.servicios;

import com.example.federaproapi.karting.dto.CrearKartingCarreraDTO;
import com.example.federaproapi.karting.modelos.KartingCarrera;
import com.example.federaproapi.karting.modelos.KartingCircuito;
import com.example.federaproapi.karting.modelos.KartingCompeticione;
import com.example.federaproapi.karting.repositorios.KartingCarreraRepository;
import com.example.federaproapi.karting.repositorios.KartingCircuitoRepository;
import com.example.federaproapi.karting.repositorios.KartingCompeticioneRepository;
import org.springframework.stereotype.Service;

import java.time.ZoneId;
import java.util.List;
import java.util.Optional;

@Service
public class KartingCarreraService {

    private final KartingCarreraRepository repository;
    private final KartingCompeticioneRepository competicioneRepository;
    private final KartingCircuitoRepository circuitoRepository;

    public KartingCarreraService(KartingCarreraRepository repository, KartingCompeticioneRepository competicioneRepository, KartingCircuitoRepository circuitoRepository) {
        this.repository = repository;
        this.circuitoRepository = circuitoRepository;
        this.competicioneRepository = competicioneRepository;
    }

    public List<KartingCarrera> findAll() {
        return repository.findAll();
    }

    public Optional<KartingCarrera> findById(Integer id) {
        return repository.findById(id);
    }

    public KartingCarrera save(KartingCarrera carrera) {
        return repository.save(carrera);
    }

    public void deleteById(Integer id) {
        repository.deleteById(id);
    }

    public List<KartingCarrera> findByCompeticionId(Integer idCompeticion) {
        return repository.findByIdCompeticionId(idCompeticion);
    }

    public List<KartingCarrera> findByCircuitoId(Integer idCircuito) {
        return repository.findByIdCircuitoId(idCircuito);
    }

    public KartingCarrera crearDesdeDTO(CrearKartingCarreraDTO dto) {
        KartingCarrera carrera = new KartingCarrera();

        // Obtener entidades necesarias
        KartingCompeticione competicion = competicioneRepository
                .findByNombre(dto.nombreCompeticion);

        KartingCircuito circuito;
        circuito = circuitoRepository
                .findById(dto.circuitoId)
                .orElseThrow(() -> new RuntimeException("Circuito no encontrado"));

        // Setear datos
        carrera.setFecha(dto.fecha.atStartOfDay(ZoneId.systemDefault()).toInstant());
        carrera.setIdCompeticion(competicion);
        carrera.setIdCircuito(circuito);

        return repository.save(carrera);
    }
}
