package com.example.federaproapi.karting.repositorios;

import com.example.federaproapi.karting.modelos.KartingCarrera;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface KartingCarreraRepository extends JpaRepository<KartingCarrera, Integer> {
    List<KartingCarrera> findByIdCompeticionId(Integer idCompeticion);
    List<KartingCarrera> findByIdCircuitoId(Integer idCircuito);
}
