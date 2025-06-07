package com.example.federaproapi.configuracion.servicios;

import com.example.federaproapi.configuracion.modelos.Configuraciontabla;
import com.example.federaproapi.configuracion.modelos.Deporte;
import com.example.federaproapi.configuracion.repositorios.ConfiguracionTablaRepository;
import com.example.federaproapi.configuracion.repositorios.DeporteRepository;
import jakarta.persistence.EntityManager;
import jakarta.persistence.Query;
import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;
import java.util.List;

@Service
public class ConfiguracionTablaService {

    private final ConfiguracionTablaRepository configuracionTablaRepository;

    @Autowired
    private DeporteRepository deporteRepository;

    @Autowired
    private EntityManager entityManager;

    public ConfiguracionTablaService(ConfiguracionTablaRepository configuracionTablaRepository) {
        this.configuracionTablaRepository = configuracionTablaRepository;
    }

    public List<Configuraciontabla> obtenerPorDeporte( Deporte deporte) {
        return configuracionTablaRepository.findByIdDeporte(deporte);
    }

    @Transactional
    public String generarTablas(Deporte idDeporte) {
        try {

            // Obtener todas las consultas asociadas al deporte
            List<Configuraciontabla> consultas = configuracionTablaRepository.findByIdDeporte(idDeporte);

            // Establecer conexión con la base de datos
            try (Connection connection = DriverManager.getConnection("jdbc:mysql://localhost:3306/federapro", "root", "mysql")) {
                Statement statement = connection.createStatement();

                // Ejecutar cada consulta de creación de tablas
                for (Configuraciontabla configuraciontabla : consultas) {
                    String query = configuraciontabla.getConsultaCreacion();
                    Query nativeQuery = entityManager.createNativeQuery(query);
                    nativeQuery.executeUpdate();
                }
            } catch (Exception e) {
                return "Error al ejecutar las consultas: " + e.getMessage();
            }

            return "Tablas generadas correctamente.";
        } catch (Exception e) {
            return "Error al generar las tablas: " + e.getMessage();
        }
    }
}
