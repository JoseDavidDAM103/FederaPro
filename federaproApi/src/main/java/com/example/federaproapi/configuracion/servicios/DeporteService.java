package com.example.federaproapi.configuracion.servicios;

import com.example.federaproapi.configuracion.modelos.Deporte;
import com.example.federaproapi.configuracion.repositorios.DeporteRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class DeporteService {

    private final DeporteRepository deporteRepository;

    public DeporteService(DeporteRepository deporteRepository) {
        this.deporteRepository = deporteRepository;
    }

    public List<Deporte> obtenerTodos() {
        return deporteRepository.findAll();
    }

    public Optional<Deporte> obtenerPorId(Integer id) {
        return deporteRepository.findById(id);
    }

    public Optional<Deporte> obtenerPorNemonico(String nemonico) {
        return deporteRepository.findByIdNemonico(nemonico);
    }

    public Deporte guardar(Deporte deporte) {
        return deporteRepository.save(deporte);
    }

    public void eliminar(Integer id) {
        deporteRepository.deleteById(id);
    }
}
