package com.example.federaproapi.karting.servicios;

import com.example.federaproapi.karting.modelos.KartingEstadisticasEquipo;
import com.example.federaproapi.karting.repositorios.KartingEstadisticasEquipoRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class KartingEstadisticasEquipoService {

    private final KartingEstadisticasEquipoRepository repository;

    public KartingEstadisticasEquipoService(KartingEstadisticasEquipoRepository repository) {
        this.repository = repository;
    }

    public List<KartingEstadisticasEquipo> findAll() {
        return repository.findAll();
    }

    public Optional<KartingEstadisticasEquipo> findById(Integer id) {
        return repository.findById(id);
    }

    public KartingEstadisticasEquipo save(KartingEstadisticasEquipo entity) {
        return repository.save(entity);
    }

    public void deleteById(Integer id) {
        repository.deleteById(id);
    }

    public List<KartingEstadisticasEquipo> findByEquipoId(Integer equipoId) {
        return repository.findByIdEquipoId(equipoId);
    }

    public List<KartingEstadisticasEquipo> findByCarreraId(Integer carreraId) {
        return repository.findByIdCarreraId(carreraId);
    }
}
