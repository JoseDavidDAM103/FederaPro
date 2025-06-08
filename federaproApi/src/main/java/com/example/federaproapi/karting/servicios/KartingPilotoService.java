package com.example.federaproapi.karting.servicios;

import com.example.federaproapi.karting.modelos.KartingCompeticione;
import com.example.federaproapi.karting.modelos.KartingEquipo;
import com.example.federaproapi.karting.modelos.KartingPiloto;
import com.example.federaproapi.karting.repositorios.KartingCompeticioneRepository;
import com.example.federaproapi.karting.repositorios.KartingPilotoRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;
import java.util.Set;
import java.util.stream.Collectors;

@Service
public class KartingPilotoService {

    private final KartingPilotoRepository pilotoRepository;
    private final KartingCompeticioneRepository competicioneRepository;

    public KartingPilotoService(KartingPilotoRepository pilotoRepository, KartingCompeticioneRepository competicioneRepository) {
        this.pilotoRepository = pilotoRepository;
        this.competicioneRepository = competicioneRepository;
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

    public List<KartingPiloto> obtenerPilotosPorCompeticion(String nombreCompeticion) {
        KartingCompeticione competicion = competicioneRepository.findByNombre(nombreCompeticion);

        Set<KartingEquipo> equipos = competicion.getEquipos(); // Asegúrate de que esta relación existe

        return equipos.stream()
                .flatMap(equipo -> pilotoRepository.findByIdEquipoId(equipo.getId()).stream())
                .collect(Collectors.toList());
    }
}
