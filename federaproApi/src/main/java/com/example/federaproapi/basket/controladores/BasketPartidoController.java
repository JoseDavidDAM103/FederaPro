package com.example.federaproapi.basket.controladores;

import com.example.federaproapi.basket.EstadisticasPartidoDTO;
import com.example.federaproapi.basket.PartidoDTO;
import com.example.federaproapi.basket.modelos.BasketPartido;
import com.example.federaproapi.basket.servicios.BasketPartidoServicio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.List;
import java.util.Optional;

import static com.example.federaproapi.basket.BasketConstants.BASKET;

@RestController
@RequestMapping(BASKET +"/partidos")
public class BasketPartidoController {

    @Autowired
    private BasketPartidoServicio basketPartidoServicio;

    // Obtener todos los partidos
    @GetMapping
    public ResponseEntity<List<BasketPartido>> obtenerTodosLosPartidos() {
        List<BasketPartido> partidos = basketPartidoServicio.obtenerTodosLosPartidos();
        return new ResponseEntity<>(partidos, HttpStatus.OK);
    }

    // Obtener un partido por ID
    @GetMapping("/{id}")
    public ResponseEntity<BasketPartido> obtenerPartidoPorId(@PathVariable Integer id) {
        Optional<BasketPartido> partido = basketPartidoServicio.obtenerPartidoPorId(id);
        return partido.map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.status(HttpStatus.NOT_FOUND).build());
    }

    // Crear un nuevo partido
    @PostMapping
    public ResponseEntity<BasketPartido> crearPartido(@RequestBody BasketPartido partido) {
        BasketPartido nuevoPartido = basketPartidoServicio.crearPartido(partido);
        return new ResponseEntity<>(nuevoPartido, HttpStatus.CREATED);
    }

    // Actualizar un partido existente
    @PutMapping("/{id}")
    public ResponseEntity<BasketPartido> actualizarPartido(@PathVariable Integer id, @RequestBody BasketPartido partidoActualizado) {
        BasketPartido partido = basketPartidoServicio.actualizarPartido(id, partidoActualizado);
        return partido != null ? ResponseEntity.ok(partido) : ResponseEntity.status(HttpStatus.NOT_FOUND).build();
    }

    // Eliminar un partido
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> eliminarPartido(@PathVariable Integer id) {
        boolean eliminado = basketPartidoServicio.eliminarPartido(id);
        return eliminado ? ResponseEntity.noContent().build() : ResponseEntity.status(HttpStatus.NOT_FOUND).build();
    }

    @GetMapping("/plantilla")
    public ResponseEntity<byte[]> descargarPlantillaCSV() {
        String filePath = "plantilla_partidos.csv"; // Ruta donde se guardará la plantilla

        try {
            // Generar la plantilla CSV en el servidor
            basketPartidoServicio.generarPlantillaCSV(filePath);

            // Leer el archivo CSV generado
            File archivo = new File(filePath);
            if (!archivo.exists()) {
                return ResponseEntity.status(404).body(("Plantilla no encontrada").getBytes());
            }

            FileInputStream fileInputStream = new FileInputStream(archivo);
            byte[] contenidoArchivo = fileInputStream.readAllBytes();
            fileInputStream.close(); // Asegúrate de cerrar el flujo de archivo

            // Configurar la respuesta para enviar el archivo como una descarga
            return ResponseEntity.ok()
                    .header(HttpHeaders.CONTENT_DISPOSITION, "attachment; filename=" + archivo.getName())
                    .contentType(MediaType.valueOf("text/csv"))
                    .body(contenidoArchivo);

        } catch (IOException e) {
            return ResponseEntity.status(500).body(("Error al generar o descargar la plantilla CSV: " + e.getMessage()).getBytes());
        }
    }

    @PostMapping("/cargar")
    public ResponseEntity<String> cargarPartidos(@RequestParam("file") MultipartFile file) {
        try {
            basketPartidoServicio.cargarPartidosDesdeCSV(file);
            return ResponseEntity.status(HttpStatus.OK).body("Partidos cargados con éxito.");
        } catch (IOException e) {
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body("Error al cargar los partidos: " + e.getMessage());
        }
    }

    // Obtener todos los partidos de un equipo (local o visitante)
    @GetMapping("/equipo/{idEquipo}")
    public ResponseEntity<List<PartidoDTO>> obtenerPartidosDeEquipo(@PathVariable Integer idEquipo) {
        List<PartidoDTO> partidos = basketPartidoServicio.obtenerPartidosDeEquipo(idEquipo);
        return partidos.isEmpty() ? ResponseEntity.status(HttpStatus.NOT_FOUND).build() : ResponseEntity.ok(partidos);
    }

    @GetMapping("/competicion/{nombre}")
    public ResponseEntity<List<PartidoDTO>> obtenerPartidos(@PathVariable String nombre) {
        List<PartidoDTO> partidos = basketPartidoServicio.obtenerPartidos(nombre);
        return ResponseEntity.ok(partidos);
    }

    @GetMapping("/estadisticas/{id}")
    public ResponseEntity<EstadisticasPartidoDTO> obtenerEstadisticas(@PathVariable Integer id) {
        EstadisticasPartidoDTO dto = basketPartidoServicio.obtenerEstadisticasPorPartido(id);
        return ResponseEntity.ok(dto);
    }

    @PostMapping("/{id}/estadisticas")
    public ResponseEntity<String> registrarEstadisticas(@PathVariable Integer id, @RequestBody EstadisticasPartidoDTO estadisticas) {
        try {
            basketPartidoServicio.registrarEstadisticasDelPartido(id, estadisticas);
            return ResponseEntity.ok("Estadísticas registradas correctamente.");
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body("Error al registrar estadísticas: " + e.getMessage());
        }
    }
}
