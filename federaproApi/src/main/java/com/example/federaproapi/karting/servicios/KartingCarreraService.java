package com.example.federaproapi.karting.servicios;

import com.example.federaproapi.karting.modelos.KartingCarrera;
import com.example.federaproapi.karting.repositorios.KartingCarreraRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class KartingCarreraService {

    private final KartingCarreraRepository repository;

    public KartingCarreraService(KartingCarreraRepository repository) {
        this.repository = repository;
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
}
