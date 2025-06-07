package com.example.federaproapi.basket.controladores;

import com.example.federaproapi.basket.CrearActualizarJugadorDTO;
import com.example.federaproapi.basket.modelos.BasketEquipo;
import com.example.federaproapi.basket.modelos.BasketJugadore;
import com.example.federaproapi.basket.servicios.BasketJugadorService;
import jakarta.annotation.Resource;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.io.InputStreamResource;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.List;
import java.util.Optional;

import static com.example.federaproapi.basket.BasketConstants.BASKET;

@RestController
@RequestMapping(BASKET +"/jugadores")
public class BasketJugadorController {

    @Autowired
    private BasketJugadorService basketJugadorServicio;

    // Obtener todos los jugadores
    @GetMapping
    public ResponseEntity<List<BasketJugadore>> obtenerTodosLosJugadores() {
        List<BasketJugadore> jugadores = basketJugadorServicio.obtenerTodosLosJugadores();
        return new ResponseEntity<>(jugadores, HttpStatus.OK);
    }

    // Obtener un jugador por su ID
    @GetMapping("/{id}")
    public ResponseEntity<BasketJugadore> obtenerJugadorPorId(@PathVariable Integer id) {
        Optional<BasketJugadore> jugador = basketJugadorServicio.obtenerJugadorPorId(id);
        return jugador.map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.status(HttpStatus.NOT_FOUND).build());
    }

    @GetMapping("/buscar")
    public ResponseEntity<List<BasketJugadore>> buscarJugadores(
            @RequestParam(required = false) String nombreEquipo,
            @RequestParam(required = false) String posicion,
            @RequestParam(required = false) String nombre) {

        List<BasketJugadore> resultados = basketJugadorServicio.buscarJugadores(nombreEquipo, posicion, nombre);
        return new ResponseEntity<>(resultados, HttpStatus.OK);
    }

    // Crear un nuevo jugador
    @PostMapping
    public ResponseEntity<BasketJugadore> crearJugador(@RequestBody CrearActualizarJugadorDTO jugador) {
        BasketJugadore nuevoJugador = basketJugadorServicio.crearJugador(jugador);
        return new ResponseEntity<>(nuevoJugador, HttpStatus.CREATED);
    }

    // Actualizar un jugador existente
    @PutMapping("/{id}")
    public ResponseEntity<BasketJugadore> actualizarJugador(@PathVariable Integer id, @RequestBody CrearActualizarJugadorDTO dto) {
        BasketJugadore jugador = basketJugadorServicio.actualizarJugadorDesdeDTO(id, dto);
        return jugador != null ? ResponseEntity.ok(jugador) : ResponseEntity.status(HttpStatus.NOT_FOUND).build();
    }

    // Eliminar un jugador
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> eliminarJugador(@PathVariable Integer id) {
        boolean eliminado = basketJugadorServicio.eliminarJugador(id);
        return eliminado ? ResponseEntity.noContent().build() : ResponseEntity.status(HttpStatus.NOT_FOUND).build();
    }

    @GetMapping("/plantilla")
    public ResponseEntity<byte[]> descargarPlantillaCSV() {
        ByteArrayInputStream plantillaStream = basketJugadorServicio.generarPlantillaCSVJugadores();
        byte[] contenido = plantillaStream.readAllBytes();

        return ResponseEntity.ok()
                .header(HttpHeaders.CONTENT_DISPOSITION, "attachment; filename=plantilla_jugadores.csv")
                .contentType(MediaType.valueOf("text/csv"))
                .body(contenido);

    }

    @PostMapping("/cargar")
    public ResponseEntity<String> cargarJugadoresDesdeCSV(
            @RequestParam("file") MultipartFile file,
            @RequestParam("equipoId") int equipoId) {

        try {
            basketJugadorServicio.cargarJugadoresDesdeCSV(file.getInputStream(), equipoId);
            return ResponseEntity.ok("Jugadores cargados correctamente");
        } catch (IOException e) {
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body("Error al procesar el archivo CSV");
        } catch (EntityNotFoundException e) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Equipo no encontrado");
        }
    }
}
