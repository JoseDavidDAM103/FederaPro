package com.example.federaproapi.basket.repositorios;

import com.example.federaproapi.basket.modelos.BasketEquipo;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface BasketEquipoRepository extends JpaRepository<BasketEquipo, Integer> {
    boolean existsByNombre(String nombre);

    Optional<BasketEquipo> findByNombre(String equipoLocalNombre);
}
