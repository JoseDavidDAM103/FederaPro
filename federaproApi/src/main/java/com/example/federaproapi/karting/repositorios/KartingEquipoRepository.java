package com.example.federaproapi.karting.repositorios;


import com.example.federaproapi.karting.modelos.KartingEquipo;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface KartingEquipoRepository extends JpaRepository<KartingEquipo, Integer> {
}
