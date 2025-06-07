package com.example.federaproapi.karting.servicios;

import com.example.federaproapi.karting.modelos.KartingEquipo;
import com.example.federaproapi.karting.repositorios.KartingEquipoRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class KartingEquipoService {

    private final KartingEquipoRepository equipoRepository;

    public KartingEquipoService(KartingEquipoRepository equipoRepository) {
        this.equipoRepository = equipoRepository;
    }

    public List<KartingEquipo> findAll() {
        return equipoRepository.findAll();
    }

    public Optional<KartingEquipo> findById(Integer id) {
        return equipoRepository.findById(id);
    }

    public KartingEquipo save(KartingEquipo equipo) {
        return equipoRepository.save(equipo);
    }

    public void deleteById(Integer id) {
        equipoRepository.deleteById(id);
    }
}
