package com.example.federaproapi.karting.servicios;

import com.example.federaproapi.karting.modelos.KartingEstadisticasPiloto;
import com.example.federaproapi.karting.repositorios.KartingEstadisticasPilotoRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class KartingEstadisticasPilotoService {

    private final KartingEstadisticasPilotoRepository repository;

    public KartingEstadisticasPilotoService(KartingEstadisticasPilotoRepository repository) {
        this.repository = repository;
    }

    public List<KartingEstadisticasPiloto> findAll() {
        return repository.findAll();
    }

    public Optional<KartingEstadisticasPiloto> findById(Integer id) {
        return repository.findById(id);
    }

    public KartingEstadisticasPiloto save(KartingEstadisticasPiloto estadistica) {
        return repository.save(estadistica);
    }

    public void deleteById(Integer id) {
        repository.deleteById(id);
    }

    public List<KartingEstadisticasPiloto> findByPilotoId(Integer pilotoId) {
        return repository.findByIdPilotoId(pilotoId);
    }

    public List<KartingEstadisticasPiloto> findByCarreraId(Integer carreraId) {
        return repository.findByIdCarreraId(carreraId);
    }
}
