package com.example.federaproapi.basket.servicios;

import com.example.federaproapi.basket.modelos.BasketEntrenadore;
import com.example.federaproapi.basket.repositorios.BasketEntrenadoreRepositorio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class BasketEntrenadorService {

    @Autowired
    private BasketEntrenadoreRepositorio basketEntrenadoreRepositorio;

    // Obtener todos los entrenadores de un equipo
    public List<BasketEntrenadore> obtenerEntrenadoresPorEquipo(Integer idEquipo) {
        return basketEntrenadoreRepositorio.findAll().stream()
                .filter(entrenador -> entrenador.getIdEquipo().getId().equals(idEquipo))
                .toList();
    }

    // Agregar un nuevo entrenador
    public BasketEntrenadore agregarEntrenador(BasketEntrenadore entrenador) {
        return basketEntrenadoreRepositorio.save(entrenador);
    }

    // Obtener un entrenador por su ID
    public Optional<BasketEntrenadore> obtenerEntrenadorPorId(Integer id) {
        return basketEntrenadoreRepositorio.findById(id);
    }
}
