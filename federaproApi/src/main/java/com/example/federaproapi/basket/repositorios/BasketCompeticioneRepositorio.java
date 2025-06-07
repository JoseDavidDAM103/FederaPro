package com.example.federaproapi.basket.repositorios;

import com.example.federaproapi.basket.modelos.BasketCompeticione;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public interface BasketCompeticioneRepositorio extends JpaRepository<BasketCompeticione, Integer> {
    Optional<BasketCompeticione> findByNombre(String competicionNombre);
    // Aquí podemos añadir consultas personalizadas si es necesario
}
