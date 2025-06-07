package com.example.federaproapi.karting.repositorios;

import com.example.federaproapi.karting.modelos.KartingEstadisticasEquipo;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface KartingEstadisticasEquipoRepository extends JpaRepository<KartingEstadisticasEquipo, Integer> {
    List<KartingEstadisticasEquipo> findByIdEquipoId(Integer idEquipo);
    List<KartingEstadisticasEquipo> findByIdCarreraId(Integer idCarrera);
}
