package com.example.federaproapi.karting.repositorios;

import com.example.federaproapi.karting.modelos.KartingPiloto;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface KartingPilotoRepository extends JpaRepository<KartingPiloto, Integer> {
    List<KartingPiloto> findByIdEquipoId(Integer idEquipo);

    KartingPiloto findByNombre(@Size(max = 100) @NotNull String nombre);
}
