package com.example.federaproapi.basket.controladores;

import com.example.federaproapi.basket.modelos.BasketEquipo;
import com.example.federaproapi.basket.modelos.BasketJugadore;
import com.example.federaproapi.basket.repositorios.BasketEquipoRepository;
import com.example.federaproapi.basket.servicios.BasketEquipoService;
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
import java.io.InputStream;
import java.nio.file.Files;
import java.util.List;
import java.util.Optional;
import java.util.Set;

import static com.example.federaproapi.basket.BasketConstants.BASKET;

@RestController
@RequestMapping(BASKET +"/equipos")
public class BasketEquipoController {

    private final BasketEquipoService basketEquipoService;
    @Autowired
    private BasketEquipoRepository basketEquipoRepository;

    public BasketEquipoController(BasketEquipoService basketEquipoService) {
        this.basketEquipoService = basketEquipoService;
    }

    // Obtener todos los equipos
    @GetMapping
    public ResponseEntity<List<BasketEquipo>> obtenerTodosEquipos() {
        List<BasketEquipo> equipos = basketEquipoService.obtenerTodosEquipos();
        return ResponseEntity.ok(equipos);
    }

    // Obtener un equipo por su ID
    @GetMapping("/{id}")
    public ResponseEntity<BasketEquipo> obtenerEquipoPorId(@PathVariable Integer id) {
        Optional<BasketEquipo> equipo = basketEquipoService.obtenerEquipoPorId(id);
        if (equipo.isPresent()) {
            return ResponseEntity.ok(equipo.get());
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
    }

    // Crear un nuevo equipo o actualizar uno existente
    @PostMapping
    public ResponseEntity<BasketEquipo> guardarEquipo(@RequestBody BasketEquipo equipo) {
        BasketEquipo nuevoEquipo = basketEquipoService.guardarEquipo(equipo);
        return ResponseEntity.status(HttpStatus.CREATED).body(nuevoEquipo);
    }

    @GetMapping("/buscar")
    public List<BasketEquipo> buscarEquipos(@RequestParam(required = false) String nombre,
                                            @RequestParam(required = false) String ciudad) {
        return basketEquipoService.buscarEquipos(nombre, ciudad);
    }

    // Eliminar un equipo por su ID
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> eliminarEquipo(@PathVariable Integer id) {
        basketEquipoService.eliminarEquipo(id);
        return ResponseEntity.status(HttpStatus.NO_CONTENT).build();
    }
    // Obtener todos los jugadores de un equipo
    @GetMapping("/{idEquipo}/jugadores")
    public ResponseEntity<List<BasketJugadore>> obtenerJugadores(@PathVariable Integer idEquipo) {
        List<BasketJugadore> jugadores = basketEquipoService.obtenerJugadoresDeEquipo(idEquipo);
        return ResponseEntity.ok(jugadores);
    }

    // Endpoint para generar y descargar la plantilla CSV
    @GetMapping("/plantilla")
    public ResponseEntity<byte[]> descargarPlantillaCSV() {
        String filePath = "plantilla_equipos_competicion.csv";
        try {
            // Generar la plantilla CSV en el servidor
            basketEquipoService.generarPlantillaCSV(); // Este método debe crear el archivo en el servidor

            // Leer el archivo CSV generado
            File archivo = new File(filePath);

            if (!archivo.exists()) {
                return ResponseEntity.status(404).body(("Plantilla no encontrada").getBytes());
            }

            FileInputStream fileInputStream = new FileInputStream(archivo);
            byte[] contenidoArchivo = fileInputStream.readAllBytes();
            fileInputStream.close(); // Asegurarse de cerrar el flujo de archivo

            // Configurar la respuesta para enviar el archivo como una descarga
            return ResponseEntity.ok()
                    .header(HttpHeaders.CONTENT_DISPOSITION, "attachment; filename=" + archivo.getName())
                    .contentType(MediaType.valueOf("text/csv")) // Usar MediaType específico para CSV
                    .body(contenidoArchivo);

        } catch (IOException e) {
            return ResponseEntity.status(500).body(("Error al generar o descargar la plantilla CSV: " + e.getMessage()).getBytes());
        }
    }

    @GetMapping("/nombre/{nombre}")
    public ResponseEntity<BasketEquipo> obtenerEquipoPorNombre(@PathVariable String nombre) {
        Optional<BasketEquipo> equipo = basketEquipoRepository.findByNombre(nombre);
        return equipo.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }

    // Endpoint para cargar los equipos desde un archivo CSV
    @PostMapping("/cargar")
    public ResponseEntity<String> cargarEquiposDesdeCSV(@RequestParam("archivo") MultipartFile archivoCSV) {
        try {
            // Procesar el archivo CSV directamente sin guardarlo en el sistema de archivos
            InputStream inputStream = archivoCSV.getInputStream();

            // Llamamos al servicio para procesar el archivo CSV y cargar los datos
            basketEquipoService.cargarEquiposDesdeCSV(inputStream);

            return ResponseEntity.ok("Equipos cargados exitosamente.");
        } catch (IOException e) {
            return ResponseEntity.status(500).body("Error al cargar equipos desde el archivo CSV: " + e.getMessage());
        }
    }

}