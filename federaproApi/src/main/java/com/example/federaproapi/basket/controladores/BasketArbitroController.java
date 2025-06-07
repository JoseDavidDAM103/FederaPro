package com.example.federaproapi.basket.controladores;

import com.example.federaproapi.basket.modelos.BasketArbitro;
import com.example.federaproapi.basket.servicios.BasketArbitroServicio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

import static com.example.federaproapi.basket.BasketConstants.BASKET;

@RestController
@RequestMapping(BASKET + "/arbitros")
public class BasketArbitroController {

    @Autowired
    private BasketArbitroServicio basketArbitroServicio;

    // Obtener un árbitro por su ID
    @GetMapping("/{id}")
    public ResponseEntity<BasketArbitro> obtenerArbitroPorId(@PathVariable Integer id) {
        Optional<BasketArbitro> arbitro = basketArbitroServicio.obtenerArbitroPorId(id);
        return arbitro.isPresent() ? ResponseEntity.ok(arbitro.get()) : ResponseEntity.status(HttpStatus.NOT_FOUND).build();
    }

    // Obtener los partidos que un árbitro ha arbitrado
    @GetMapping("/partidos/{idPartido}")
    public ResponseEntity<List<BasketArbitro>> obtenerArbitrosPorPartidos(@PathVariable Integer idPartido) {
        List<BasketArbitro> arbitros = basketArbitroServicio.obtenerArbitrosPorPartidos(idPartido);
        return arbitros.isEmpty() ? ResponseEntity.status(HttpStatus.NOT_FOUND).build() : ResponseEntity.ok(arbitros);
    }

    // Agregar un nuevo árbitro
    @PostMapping
    public ResponseEntity<BasketArbitro> agregarArbitro(@RequestBody BasketArbitro arbitro) {
        BasketArbitro nuevoArbitro = basketArbitroServicio.agregarArbitro(arbitro);
        return ResponseEntity.status(HttpStatus.CREATED).body(nuevoArbitro);
    }
}
