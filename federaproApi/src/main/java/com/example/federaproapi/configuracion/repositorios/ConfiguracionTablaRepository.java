package com.example.federaproapi.configuracion.repositorios;

import com.example.federaproapi.configuracion.modelos.Configuraciontabla;
import com.example.federaproapi.configuracion.modelos.Deporte;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface ConfiguracionTablaRepository extends JpaRepository<Configuraciontabla, Integer> {
    List<Configuraciontabla> findByIdDeporte(Deporte deporte);
}
