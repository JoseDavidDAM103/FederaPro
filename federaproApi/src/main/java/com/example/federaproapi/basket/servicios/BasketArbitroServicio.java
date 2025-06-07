package com.example.federaproapi.basket.servicios;

import com.example.federaproapi.basket.modelos.BasketArbitro;
import com.example.federaproapi.basket.repositorios.BasketArbitroRepositorio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class BasketArbitroServicio {

    @Autowired
    private BasketArbitroRepositorio basketArbitroRepositorio;

    // Obtener un árbitro por su ID
    public Optional<BasketArbitro> obtenerArbitroPorId(Integer id) {
        return basketArbitroRepositorio.findById(id);
    }

    // Obtener todos los partidos que un árbitro ha arbitrado
    public List<BasketArbitro> obtenerArbitrosPorPartidos(Integer idPartido) {
        return basketArbitroRepositorio.findAll().stream()
                .filter(arbitro -> arbitro.getBasketPartidos().stream()
                        .anyMatch(partido -> partido.getId().equals(idPartido)))
                .toList();
    }

    // Agregar un nuevo árbitro
    public BasketArbitro agregarArbitro(BasketArbitro arbitro) {
        return basketArbitroRepositorio.save(arbitro);
    }
}

