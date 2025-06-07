package com.example.federaproapi.karting.servicios;

import com.example.federaproapi.karting.modelos.KartingPiloto;
import com.example.federaproapi.karting.repositorios.KartingPilotoRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class KartingPilotoService {

    private final KartingPilotoRepository pilotoRepository;

    public KartingPilotoService(KartingPilotoRepository pilotoRepository) {
        this.pilotoRepository = pilotoRepository;
    }

    public List<KartingPiloto> findAll() {
        return pilotoRepository.findAll();
    }

    public Optional<KartingPiloto> findById(Integer id) {
        return pilotoRepository.findById(id);
    }

    public KartingPiloto save(KartingPiloto piloto) {
        return pilotoRepository.save(piloto);
    }

    public void deleteById(Integer id) {
        pilotoRepository.deleteById(id);
    }

    public List<KartingPiloto> findByEquipoId(Integer equipoId) {
        return pilotoRepository.findByIdEquipoId(equipoId);
    }
}
