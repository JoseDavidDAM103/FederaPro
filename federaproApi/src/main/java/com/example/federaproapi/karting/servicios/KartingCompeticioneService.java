package com.example.federaproapi.karting.servicios;

import com.example.federaproapi.karting.dto.KartingCarreraDTO;
import com.example.federaproapi.karting.dto.KartingClasificacionEquipoDTO;
import com.example.federaproapi.karting.dto.KartingClasificacionPilotoDTO;
import com.example.federaproapi.karting.modelos.*;
import com.example.federaproapi.karting.repositorios.*;
import org.springframework.stereotype.Service;

import java.util.*;
import java.util.stream.Collectors;

@Service
public class KartingCompeticioneService {

    private final KartingCompeticioneRepository repository;
    private final KartingEstadisticasPilotoRepository estadisticasPiloto;
    private final KartingPilotoRepository piloto;
    private final KartingEstadisticasEquipoRepository estadisticasEquipo;
    private final KartingCarreraRepository carrera;

    public KartingCompeticioneService(KartingCompeticioneRepository repository, KartingEstadisticasEquipoRepository estadisticasEquipo,
                                      KartingEstadisticasPilotoRepository estadisticasPiloto, KartingCarreraRepository carrera, KartingPilotoRepository piloto) {
        this.repository = repository;
        this.estadisticasPiloto = estadisticasPiloto;
        this.estadisticasEquipo = estadisticasEquipo;
        this.carrera = carrera;
        this.piloto = piloto;
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


    public List<KartingCarreraDTO> getCarrerasDeCompeticion(String nombreCompeticion) {
        KartingCompeticione competicion = repository.findByNombre(nombreCompeticion);
        if (competicion == null) {
            throw new RuntimeException("Competición no encontrada: " + nombreCompeticion);
        }

        List<KartingCarrera> carreras = carrera.findByIdCompeticionOrderByFechaAsc(competicion);

        List<KartingCarreraDTO> resultado = new ArrayList<>();
        int numero = 1;
        for (KartingCarrera carrera : carreras) {
            resultado.add(new KartingCarreraDTO(
                    carrera.getId(),
                    carrera.getFecha(),
                    carrera.getIdCircuito().getNombre(),
                    numero++
            ));
        }

        return resultado;
    }

    public List<KartingClasificacionPilotoDTO> getClasificacionPilotos(String nombreCompeticion) {
        KartingCompeticione competicion = repository.findByNombre(nombreCompeticion);
        if (competicion == null) throw new RuntimeException("Competición no encontrada");

        // 1. Obtener todas las carreras de la competición
        Set<KartingCarrera> carreras = competicion.getKartingCarreras();

        // 2. Obtener todas las estadísticas de esas carreras
        List<KartingEstadisticasPiloto> estadisticas = estadisticasPiloto.findAll().stream()
                .filter(est -> carreras.contains(est.getIdCarrera()))
                .toList();

        // 3. Calcular puntos
        Map<KartingPiloto, Integer> puntuaciones = new HashMap<>();
        for (var est : estadisticas) {
            int puntos = calcularPuntosPorPosicion(est.getPosicion());
            puntuaciones.merge(est.getIdPiloto(), puntos, Integer::sum);
        }

        // 4. Transformar y ordenar
        return puntuaciones.entrySet().stream()
                .map(entry -> new KartingClasificacionPilotoDTO(
                        entry.getKey().getNombre(),
                        entry.getKey().getIdEquipo() != null ? entry.getKey().getIdEquipo().getNombre() : "Sin equipo",
                        entry.getValue()))
                .sorted(Comparator.comparingInt(KartingClasificacionPilotoDTO::getPuntos).reversed())
                .collect(Collectors.toList());
    }

    public List<KartingClasificacionEquipoDTO> getClasificacionEquipos(String nombreCompeticion) {
        KartingCompeticione competicion = repository.findByNombre(nombreCompeticion);
        if (competicion == null) throw new RuntimeException("Competición no encontrada");

        Set<KartingCarrera> carreras = competicion.getKartingCarreras();

        List<KartingEstadisticasPiloto> estadisticas = estadisticasPiloto.findAll().stream()
                .filter(est -> carreras.contains(est.getIdCarrera()))
                .toList();

        Map<KartingEquipo, Integer> puntosPorEquipo = new HashMap<>();
        for (var est : estadisticas) {
            var equipo = est.getIdPiloto().getIdEquipo();
            if (equipo == null) continue;
            int puntos = calcularPuntosPorPosicion(est.getPosicion());
            puntosPorEquipo.merge(equipo, puntos, Integer::sum);
        }

        return puntosPorEquipo.entrySet().stream()
                .map(entry -> new KartingClasificacionEquipoDTO(entry.getKey().getNombre(), entry.getValue()))
                .sorted(Comparator.comparingInt(KartingClasificacionEquipoDTO::getPuntos).reversed())
                .collect(Collectors.toList());
    }

    private int calcularPuntosPorPosicion(int posicion) {
        return switch (posicion) {
            case 1 -> 25;
            case 2 -> 18;
            case 3 -> 15;
            case 4 -> 12;
            case 5 -> 10;
            case 6 -> 8;
            case 7 -> 6;
            case 8 -> 4;
            case 9 -> 2;
            case 10 -> 1;
            default -> 0;
        };
    }
}