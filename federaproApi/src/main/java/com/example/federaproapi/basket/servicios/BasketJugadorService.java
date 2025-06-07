package com.example.federaproapi.basket.servicios;

import com.example.federaproapi.basket.CrearActualizarJugadorDTO;
import com.example.federaproapi.basket.modelos.BasketEquipo;
import com.example.federaproapi.basket.modelos.BasketJugadore;
import com.example.federaproapi.basket.repositorios.BasketEquipoRepository;
import com.example.federaproapi.basket.repositorios.BasketJugadorRepositorio;
import jakarta.persistence.EntityNotFoundException;
import org.apache.commons.csv.CSVFormat;
import org.apache.commons.csv.CSVParser;
import org.apache.commons.csv.CSVPrinter;
import org.apache.commons.csv.CSVRecord;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.*;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

@Service
public class BasketJugadorService {

    @Autowired
    private BasketJugadorRepositorio basketJugadorRepositorio;

    @Autowired
    private BasketEquipoRepository basketEquipoRepositorio;

    // Obtener todos los jugadores
    public List<BasketJugadore> obtenerTodosLosJugadores() {
        return basketJugadorRepositorio.findAll();
    }

    // Obtener un jugador por su ID
    public Optional<BasketJugadore> obtenerJugadorPorId(Integer id) {
        return basketJugadorRepositorio.findById(id);
    }

    // Crear un nuevo jugador
    public BasketJugadore crearJugador(CrearActualizarJugadorDTO jugador) {
        BasketJugadore nuevo = new BasketJugadore();

        if (jugador != null) {
            nuevo.setNombre(jugador.nombre);
            nuevo.setPosicion(jugador.posicion);
            nuevo.setDorsal(jugador.dorsal);
            nuevo.setPeso(jugador.peso);
            nuevo.setAltura(jugador.altura);
            nuevo.setEquipo(basketEquipoRepositorio.findById(jugador.equipoId).orElse(null));
        }

        return basketJugadorRepositorio.save(nuevo);
    }

    public BasketJugadore actualizarJugadorDesdeDTO(Integer id, CrearActualizarJugadorDTO dto) {
        BasketJugadore jugador = basketJugadorRepositorio.findById(id).orElse(null);
        if (jugador == null) return null;

        jugador.setNombre(dto.nombre);
        jugador.setPosicion(dto.posicion);
        jugador.setDorsal(dto.dorsal);
        jugador.setPeso(dto.peso);
        jugador.setAltura(dto.altura);
        jugador.setEquipo(basketEquipoRepositorio.findById(dto.equipoId).orElse(null));

        return basketJugadorRepositorio.save(jugador);
    }

    public List<BasketJugadore> buscarJugadores(String nombreEquipo, String posicion, String nombre) {
        return basketJugadorRepositorio.findAll().stream()
                .filter(jugador -> {
                    boolean coincide = true;

                    if (nombre != null && !nombre.isBlank()) {
                        coincide &= jugador.getNombre().toLowerCase().contains(nombre.toLowerCase());
                    }

                    if (posicion != null && !posicion.isBlank()) {
                        coincide &= jugador.getPosicion().equalsIgnoreCase(posicion);
                    }

                    if (nombreEquipo != null && !nombreEquipo.isBlank()) {
                        BasketEquipo equipo = jugador.getEquipo();
                        coincide &= equipo != null && equipo.getNombre().toLowerCase().contains(nombreEquipo.toLowerCase());
                    }

                    return coincide;
                })
                .collect(Collectors.toList());
    }

    // Eliminar un jugador por su ID
    public boolean eliminarJugador(Integer id) {
        if (basketJugadorRepositorio.existsById(id)) {
            basketJugadorRepositorio.deleteById(id);
            return true;
        }
        return false;
    }

    public ByteArrayInputStream generarPlantillaCSVJugadores() {
        String[] headers = { "Nombre", "Altura", "Peso", "Posicion", "Dorsal" };
        ByteArrayOutputStream out = new ByteArrayOutputStream();

        try (OutputStreamWriter writer = new OutputStreamWriter(out, StandardCharsets.UTF_8)) {
            // BOM al principio
            writer.write('\uFEFF');

            try (CSVPrinter printer = new CSVPrinter(writer, CSVFormat.DEFAULT
                    .withHeader(headers)
                    .withDelimiter(';'))) {
                // Solo cabecera
            }
        } catch (IOException e) {
            throw new RuntimeException("Error generando plantilla CSV de jugadores", e);
        }

        return new ByteArrayInputStream(out.toByteArray());
    }

    public void cargarJugadoresDesdeCSV(InputStream inputStream, int equipo) throws IOException {
        // Leer contenido del InputStream y eliminar BOM si existe
        StringBuilder content = new StringBuilder();
        try (BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream, StandardCharsets.ISO_8859_1))) {
            String line;
            boolean isFirstLine = true;
            while ((line = reader.readLine()) != null) {
                // Eliminar BOM solo en la primera línea
                if (isFirstLine) {
                    line = line.replace("\uFEFF", "");
                    isFirstLine = false;
                }
                content.append(line).append("\n");
            }
        }

        BasketEquipo equipoBD = basketEquipoRepositorio.findById(equipo)
                .orElseThrow(() -> new EntityNotFoundException("Equipo no encontrado"));

        // Procesar el CSV limpio
        try (CSVParser csvParser = CSVFormat.DEFAULT
                .withFirstRecordAsHeader()
                .withDelimiter(';')
                .parse(new StringReader(content.toString()))) {

            for (CSVRecord record : csvParser) {
                String nombre = record.get("Nombre").trim();  // trim por seguridad
                double altura = Double.parseDouble(record.get("Altura"));
                double peso = Double.parseDouble(record.get("Peso"));
                String posicion = record.get("Posicion").trim();
                int dorsal = Integer.parseInt(record.get("Dorsal"));

                if (!basketJugadorRepositorio.existsByDorsalAndEquipo(dorsal, equipoBD)) {
                    BasketJugadore jugador = new BasketJugadore();
                    jugador.setNombre(nombre);
                    jugador.setAltura(altura);
                    jugador.setPeso(peso);
                    jugador.setPosicion(posicion);
                    jugador.setDorsal(dorsal);
                    jugador.setEquipo(equipoBD);

                    basketJugadorRepositorio.save(jugador);
                }
            }
        }
    }

}
