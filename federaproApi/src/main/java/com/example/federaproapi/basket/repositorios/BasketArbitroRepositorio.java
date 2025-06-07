package com.example.federaproapi.basket.repositorios;

import com.example.federaproapi.basket.modelos.BasketArbitro;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public interface BasketArbitroRepositorio extends JpaRepository<BasketArbitro, Integer> {
    Optional<BasketArbitro> findByNombre(String arbitroNombre);
}