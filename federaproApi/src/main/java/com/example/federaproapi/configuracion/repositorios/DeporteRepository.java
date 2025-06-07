package com.example.federaproapi.configuracion.repositorios;

import com.example.federaproapi.configuracion.modelos.Deporte;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface DeporteRepository extends JpaRepository<Deporte, Integer> {
    Optional<Deporte> findByIdNemonico(String idNemonico);
}
