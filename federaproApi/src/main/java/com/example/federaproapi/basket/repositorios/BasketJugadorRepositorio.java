package com.example.federaproapi.basket.repositorios;

import com.example.federaproapi.basket.modelos.BasketEquipo;
import com.example.federaproapi.basket.modelos.BasketJugadore;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public interface BasketJugadorRepositorio extends JpaRepository<BasketJugadore, Integer> {

    boolean existsByDorsalAndEquipo(int dorsal, BasketEquipo equipo);

    Optional<BasketJugadore> findByNombre(String nombreJugador);
}
