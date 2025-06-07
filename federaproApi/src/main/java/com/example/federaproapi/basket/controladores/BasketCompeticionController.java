package com.example.federaproapi.basket.controladores;

import com.example.federaproapi.basket.ClasificacionEquipoDTO;
import com.example.federaproapi.basket.CrearCompeticionDTO;
import com.example.federaproapi.basket.modelos.BasketCompeticione;
import com.example.federaproapi.basket.modelos.BasketEquipo;
import com.example.federaproapi.basket.servicios.BasketCompeticionService;
import com.example.federaproapi.basket.servicios.BasketEquipoService;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;
import java.util.Set;
import java.util.stream.Collectors;

import static com.example.federaproapi.basket.BasketConstants.BASKET;

@RestController
@RequestMapping(BASKET + "/competiciones")
public class BasketCompeticionController {

    @Autowired
    private BasketCompeticionService basketCompeticionServicio;

    @Autowired
    private BasketEquipoService basketEquipoService;

    // Obtener todas las competiciones
    @GetMapping
    public ResponseEntity<List<BasketCompeticione>> obtenerTodasLasCompeticiones() {
        List<BasketCompeticione> competiciones = basketCompeticionServicio.obtenerTodasLasCompeticiones();
        return new ResponseEntity<>(competiciones, HttpStatus.OK);
    }

    // Obtener una competicion por ID
    @GetMapping("/{id}")
    public ResponseEntity<BasketCompeticione> obtenerCompeticionPorId(@PathVariable Integer id) {
        Optional<BasketCompeticione> competicion = basketCompeticionServicio.obtenerCompeticionPorId(id);
        return competicion.map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.status(HttpStatus.NOT_FOUND).build());
    }

    // Crear una nueva competicion
    @PostMapping
    public ResponseEntity<BasketCompeticione> crearCompeticion(@RequestBody CrearCompeticionDTO dto) {
        BasketCompeticione competicion = new BasketCompeticione();
        competicion.setNombre(dto.nombre);
        competicion.setTipo(dto.tipo);

        Set<BasketEquipo> equipos = dto.equipoIds.stream()
                .map(id -> basketEquipoService.obtenerEquipoPorId(id).orElseThrow(() -> new EntityNotFoundException("Equipo no encontrado")))
                .collect(Collectors.toSet());

        competicion.setEquipos(equipos);

        BasketCompeticione nuevaCompeticion = basketCompeticionServicio.crearCompeticion(competicion);
        return new ResponseEntity<>(nuevaCompeticion, HttpStatus.CREATED);
    }

    // Actualizar una competicion existente
    @PutMapping("/{id}")
    public ResponseEntity<BasketCompeticione> actualizarCompeticion(@PathVariable Integer id, @RequestBody BasketCompeticione competicionActualizada) {
        BasketCompeticione competicion = basketCompeticionServicio.actualizarCompeticion(id, competicionActualizada);
        return competicion != null ? ResponseEntity.ok(competicion) : ResponseEntity.status(HttpStatus.NOT_FOUND).build();
    }

    // Eliminar una competicion
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> eliminarCompeticion(@PathVariable Integer id) {
        boolean eliminado = basketCompeticionServicio.eliminarCompeticion(id);
        return eliminado ? ResponseEntity.noContent().build() : ResponseEntity.status(HttpStatus.NOT_FOUND).build();
    }

    @PostMapping("/{nombre}/generar-partidos")
    public ResponseEntity<?> generarPartidos(@PathVariable String nombre) {
        basketCompeticionServicio.generarPartidos(nombre);
        return ResponseEntity.ok().build();
    }

    @GetMapping("/clasificacion/{nombreCompeticion}")
    public ResponseEntity<List<ClasificacionEquipoDTO>> obtenerClasificacion(@PathVariable String nombreCompeticion) {
        return ResponseEntity.ok(basketCompeticionServicio.obtenerClasificacion(nombreCompeticion));
    }
}
