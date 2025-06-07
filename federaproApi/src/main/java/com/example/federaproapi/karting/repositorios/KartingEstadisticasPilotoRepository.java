package com.example.federaproapi.karting.repositorios;

import com.example.federaproapi.karting.modelos.KartingEstadisticasPiloto;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface KartingEstadisticasPilotoRepository extends JpaRepository<KartingEstadisticasPiloto, Integer> {
    List<KartingEstadisticasPiloto> findByIdPilotoId(Integer idPiloto);
    List<KartingEstadisticasPiloto> findByIdCarreraId(Integer idCarrera);
}
