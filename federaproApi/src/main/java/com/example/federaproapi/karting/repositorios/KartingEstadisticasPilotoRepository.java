package com.example.federaproapi.karting.repositorios;

import com.example.federaproapi.karting.modelos.KartingEstadisticasPiloto;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface KartingEstadisticasPilotoRepository extends JpaRepository<KartingEstadisticasPiloto, Integer> {
    List<KartingEstadisticasPiloto> findByIdPilotoId(Integer idPiloto);
    List<KartingEstadisticasPiloto> findByIdCarreraId(Integer idCarrera);

    @Query("SELECT e FROM KartingEstadisticasPiloto e WHERE e.idCarrera.idCompeticion.nombre = :nombreCompeticion")
    List<KartingEstadisticasPiloto> findByCompeticion(@Param("nombreCompeticion") String nombreCompeticion);
}
