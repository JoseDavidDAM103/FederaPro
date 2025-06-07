package com.example.federaproapi.karting.repositorios;

import com.example.federaproapi.karting.modelos.KartingPiloto;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface KartingPilotoRepository extends JpaRepository<KartingPiloto, Integer> {
    List<KartingPiloto> findByIdEquipoId(Integer idEquipo);
}
