package com.example.federaproapi.karting.servicios;

import com.example.federaproapi.karting.modelos.KartingCompeticione;
import com.example.federaproapi.karting.repositorios.KartingCompeticioneRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class KartingCompeticioneService {

    private final KartingCompeticioneRepository repository;

    public KartingCompeticioneService(KartingCompeticioneRepository repository) {
        this.repository = repository;
    }

    public List<KartingCompeticione> findAll() {
        return repository.findAll();
    }

    public Optional<KartingCompeticione> findById(Integer id) {
        return repository.findById(id);
    }

    public KartingCompeticione save(KartingCompeticione competicion) {
        return repository.save(competicion);
    }

    public void deleteById(Integer id) {
        repository.deleteById(id);
    }
}