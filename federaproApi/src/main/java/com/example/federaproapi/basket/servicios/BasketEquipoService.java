package com.example.federaproapi.basket.servicios;

import com.example.federaproapi.basket.modelos.BasketEquipo;
import com.example.federaproapi.basket.modelos.BasketJugadore;
import com.example.federaproapi.basket.repositorios.BasketEquipoRepository;
import org.apache.commons.csv.CSVFormat;
import org.apache.commons.csv.CSVParser;
import org.apache.commons.csv.CSVPrinter;
import org.apache.commons.csv.CSVRecord;
import org.springframework.core.io.InputStreamResource;
import org.springframework.http.HttpHeaders;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.io.*;
import java.nio.charset.StandardCharsets;
import java.util.List;
import java.util.Optional;
import java.util.Set;
import java.util.stream.Collectors;

@Service
public class BasketEquipoService {

    private final BasketEquipoRepository basketEquipoRepository;

    public BasketEquipoService(BasketEquipoRepository basketEquipoRepository) {
        this.basketEquipoRepository = basketEquipoRepository;
    }

    /**
     * Obtener todos los jugadores de un equipo
     *
     * @param idEquipo ID del equipo
     * @return Set de jugadores
     */
    public List<BasketJugadore> obtenerJugadoresDeEquipo(Integer idEquipo) {
        Optional<BasketEquipo> equipoOpt = basketEquipoRepository.findById(idEquipo);
        if (equipoOpt.isPresent()) {
            return equipoOpt.get().getBasketJugadores();
        } else {
            throw new RuntimeException("Equipo no encontrado");
        }
    }

    // Método para obtener todos los equipos
    public List<BasketEquipo> obtenerTodosEquipos() {
        return basketEquipoRepository.findAll();
    }

    // Método para obtener un equipo por su ID
    public Optional<BasketEquipo> obtenerEquipoPorId(Integer id) {
        return basketEquipoRepository.findById(id);
    }

    // Método para crear o actualizar un equipo
    public BasketEquipo guardarEquipo(BasketEquipo equipo) {
        BasketEquipo nuevo  = new BasketEquipo();

        nuevo.setNombre(equipo.getNombre());
        nuevo.setCiudad(equipo.getCiudad());
        nuevo.setFundacion(equipo.getFundacion());
        nuevo.setEstadio(equipo.getEstadio());

        return basketEquipoRepository.save(nuevo);
    }

    public List<BasketEquipo> buscarEquipos(String nombre, String ciudad) {
        return basketEquipoRepository.findAll().stream()
                .filter(e -> (nombre == null || nombre.isBlank() || e.getNombre().toLowerCase().contains(nombre.toLowerCase())))
                .filter(e -> (ciudad == null || ciudad.isBlank() || e.getCiudad().toLowerCase().contains(ciudad.toLowerCase())))
                .collect(Collectors.toList());
    }

    // Método para eliminar un equipo
    public void eliminarEquipo(Integer id) {
        basketEquipoRepository.deleteById(id);
    }

    // Método para generar la plantilla CSV
    public void generarPlantillaCSV() throws IOException {
        // Preparamos la cabecera del archivo CSV
        String[] cabecera = {"Nombre", "Ciudad", "Fundacion", "Estadio"};

        // Definimos la ruta y el nombre del archivo CSV
        String filePath = "plantilla_equipos_competicion.csv";

        // Crear el archivo CSV y escribir las cabeceras con delimitador adecuado
        try (CSVPrinter csvPrinter = new CSVPrinter(new FileWriter(filePath),
                CSVFormat.DEFAULT
                        .withDelimiter(';')  // Usar punto y coma como delimitador
                        .withQuote('"')      // Encerrar los valores entre comillas dobles
                        .withHeader(cabecera))) {

            // Aquí no vamos a agregar datos, solo las cabeceras
            System.out.println("Plantilla CSV generada correctamente en: " + filePath);
        }
    }

    // Método para cargar equipos desde el archivo CSV
    public void cargarEquiposDesdeCSV(InputStream inputStream) throws IOException {
        // Primero, leer el InputStream y eliminar el BOM si existe
        StringBuilder content = new StringBuilder();
        try (InputStreamReader reader = new InputStreamReader(inputStream, StandardCharsets.UTF_8)) {
            int c;
            while ((c = reader.read()) != -1) {
                content.append((char) c);
            }
        }

        // Eliminar el BOM si existe en la primera posición
        String csvContent = content.toString().replace("\uFEFF", "");

        // Ahora procesar el CSV sin el BOM
        try (CSVParser csvParser = CSVFormat.DEFAULT
                .withHeader()  // Para usar la primera línea como los nombres de las columnas
                .withDelimiter(';')
                .parse(new StringReader(csvContent))) {

            // Iterar sobre cada registro en el CSV
            for (CSVRecord record : csvParser) {
                String nombre = record.get("Nombre");
                String ciudad = record.get("Ciudad");
                int fundacion = Integer.parseInt(record.get("Fundacion"));
                String estadio = record.get("Estadio");

                // Lógica para guardar los datos en la base de datos
                // Comprobar si ya existe un equipo con el mismo nombre
                if (!basketEquipoRepository.existsByNombre(nombre)) {
                    BasketEquipo equipo = new BasketEquipo();
                    equipo.setNombre(nombre);
                    equipo.setCiudad(ciudad);
                    equipo.setFundacion(fundacion);
                    equipo.setEstadio(estadio);

                    basketEquipoRepository.save(equipo);
                }
            }
        }
    }
}
