package com.example.federaproapi.configuracion.controladores;

import com.example.federaproapi.configuracion.modelos.Configuraciontabla;
import com.example.federaproapi.configuracion.modelos.Deporte;
import com.example.federaproapi.configuracion.repositorios.DeporteRepository;
import com.example.federaproapi.configuracion.servicios.ConfiguracionTablaService;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/configuraciones")
public class ConfiguracionTablaController {

    private final ConfiguracionTablaService configuracionService;
    private final DeporteRepository deporteRepository;


    public ConfiguracionTablaController(ConfiguracionTablaService configuracionService, DeporteRepository deporteRepository) {
        this.configuracionService = configuracionService;
        this.deporteRepository = deporteRepository;
    }


    @GetMapping("/deporte/{idDeporte}")
    public ResponseEntity<List<Configuraciontabla>> obtenerPorDeporte(@PathVariable Integer idDeporte) {
        Deporte deporte = deporteRepository.findById(idDeporte).orElse(null);

        if (deporte == null) {
            // Si el Deporte no existe, devolvemos un error
            return ResponseEntity.status(404).body(null);  // o cualquier otro error adecuado
        }

        // Pasamos el objeto Deporte al servicio
        List<Configuraciontabla> configuraciones = configuracionService.obtenerPorDeporte(deporte);
        return ResponseEntity.ok(configuraciones);
    }


    // Endpoint para generar las tablas de un deporte
    @PostMapping("/generar/{idDeporte}")
    public ResponseEntity<String> generarTablas(@PathVariable Integer idDeporte) {
        // Buscar el Deporte por su idDeporte
        Deporte deporte = deporteRepository.findById(idDeporte).orElse(null);

        if (deporte == null) {
            // Si el Deporte no existe, devolvemos un error
            return ResponseEntity.status(404).body("Deporte no encontrado");
        }

        // Llamar al servicio que generará las tablas con el objeto Deporte
        String resultado = configuracionService.generarTablas(deporte);
        if (resultado.contains("correctamente")) {
            return ResponseEntity.ok(resultado); // Respuesta exitosa
        } else {
            return ResponseEntity.status(500).body(resultado); // Respuesta de error
        }
    }
}