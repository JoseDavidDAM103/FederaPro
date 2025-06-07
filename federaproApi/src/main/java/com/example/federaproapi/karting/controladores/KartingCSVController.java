package com.example.federaproapi.karting.controladores;

import com.example.federaproapi.karting.servicios.KartingCSVService;
import jakarta.servlet.http.HttpServletResponse;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;

@RestController
@RequestMapping("/karting/csv")
@CrossOrigin(origins = "*")
public class KartingCSVController {

    private final KartingCSVService csvService;

    public KartingCSVController(KartingCSVService csvService) {
        this.csvService = csvService;
    }

    // ------------------ PLANTILLAS ------------------

    @GetMapping("/plantilla/pilotos")
    public void descargarPlantillaPilotos(HttpServletResponse response) throws IOException {
        response.setContentType("text/csv");
        response.setHeader("Content-Disposition", "attachment; filename=plantilla_pilotos.csv");
        response.getOutputStream().write(csvService.generarPlantillaCSVPilotos().readAllBytes());
    }

    @GetMapping("/plantilla/equipos")
    public void descargarPlantillaEquipos(HttpServletResponse response) throws IOException {
        response.setContentType("text/csv");
        response.setHeader("Content-Disposition", "attachment; filename=plantilla_equipos.csv");
        response.getOutputStream().write(csvService.generarPlantillaCSVEquipos().readAllBytes());
    }

    @GetMapping("/plantilla/circuitos")
    public void descargarPlantillaCircuitos(HttpServletResponse response) throws IOException {
        response.setContentType("text/csv");
        response.setHeader("Content-Disposition", "attachment; filename=plantilla_circuitos.csv");
        response.getOutputStream().write(csvService.generarPlantillaCSVCircuitos().readAllBytes());
    }

    // ------------------ CARGA ------------------

    @PostMapping(value = "/cargar/pilotos/{idEquipo}", consumes = MediaType.MULTIPART_FORM_DATA_VALUE)
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void cargarPilotos(@RequestParam("file") MultipartFile file, @PathVariable int idEquipo) throws IOException {
        csvService.cargarPilotosDesdeCSV(file.getInputStream(), idEquipo);
    }

    @PostMapping(value = "/cargar/equipos", consumes = MediaType.MULTIPART_FORM_DATA_VALUE)
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void cargarEquipos(@RequestParam("file") MultipartFile file) throws IOException {
        csvService.cargarEquiposDesdeCSV(file.getInputStream());
    }

    @PostMapping(value = "/cargar/circuitos", consumes = MediaType.MULTIPART_FORM_DATA_VALUE)
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void cargarCircuitos(@RequestParam("file") MultipartFile file) throws IOException {
        csvService.cargarCircuitosDesdeCSV(file.getInputStream());
    }
}
