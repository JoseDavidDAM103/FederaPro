package com.example.federaproapi.basket.repositorios;

import com.example.federaproapi.basket.modelos.BasketEstadisticasJugador;
import com.example.federaproapi.basket.modelos.BasketPartido;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface BasketEstadisticasJugadorRepositorio extends JpaRepository<BasketEstadisticasJugador, Integer> {
    List<BasketEstadisticasJugador> findByIdJugador_Id(Integer jugadorId);

    List<BasketEstadisticasJugador> findByIdPartido(BasketPartido partido);
}
