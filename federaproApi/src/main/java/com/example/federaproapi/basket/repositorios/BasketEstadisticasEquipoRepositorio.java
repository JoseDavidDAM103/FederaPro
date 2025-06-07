package com.example.federaproapi.basket.repositorios;

import com.example.federaproapi.basket.modelos.BasketEstadisticasEquipo;
import com.example.federaproapi.basket.modelos.BasketPartido;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface BasketEstadisticasEquipoRepositorio extends JpaRepository<BasketEstadisticasEquipo, Integer> {
    List<BasketEstadisticasEquipo> findByIdPartido(BasketPartido partido);
}
