package com.example.federaproapi.karting.servicios;

import com.example.federaproapi.karting.modelos.KartingCircuito;
import com.example.federaproapi.karting.repositorios.KartingCircuitoRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class KartingCircuitoService {

    private final KartingCircuitoRepository repository;

    public KartingCircuitoService(KartingCircuitoRepository repository) {
        this.repository = repository;
    }

    public List<KartingCircuito> findAll() {
        return repository.findAll();
    }

    public Optional<KartingCircuito> findById(Integer id) {
        return repository.findById(id);
    }

    public KartingCircuito save(KartingCircuito circuito) {
        return repository.save(circuito);
    }

    public void deleteById(Integer id) {
        repository.deleteById(id);
    }
}