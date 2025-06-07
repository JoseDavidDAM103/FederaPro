package com.example.federaproapi.karting.servicios;

import com.example.federaproapi.karting.modelos.KartingCircuito;
import com.example.federaproapi.karting.modelos.KartingEquipo;
import com.example.federaproapi.karting.modelos.KartingPiloto;
import com.example.federaproapi.karting.repositorios.KartingCircuitoRepository;
import com.example.federaproapi.karting.repositorios.KartingEquipoRepository;
import com.example.federaproapi.karting.repositorios.KartingPilotoRepository;
import jakarta.persistence.EntityNotFoundException;
import org.apache.commons.csv.CSVFormat;
import org.apache.commons.csv.CSVParser;
import org.apache.commons.csv.CSVPrinter;
import org.apache.commons.csv.CSVRecord;
import org.springframework.stereotype.Service;

import java.io.*;
import java.math.BigDecimal;
import java.nio.charset.StandardCharsets;
import java.util.Optional;
import java.util.stream.Stream;

@Service
public class KartingCSVService {

    private final KartingPilotoRepository pilotoRepo;
    private final KartingEquipoRepository equipoRepo;
    private final KartingCircuitoRepository circuitoRepo;

    public KartingCSVService(
            KartingPilotoRepository pilotoRepo,
            KartingEquipoRepository equipoRepo,
            KartingCircuitoRepository circuitoRepo
    ) {
        this.pilotoRepo = pilotoRepo;
        this.equipoRepo = equipoRepo;
        this.circuitoRepo = circuitoRepo;
    }

    // ---------------- PILOTOS ----------------

    public ByteArrayInputStream generarPlantillaCSVPilotos() {
        String[] headers = { "Nombre", "Categoria", "FechaNacimiento", "Nacionalidad", "NumeroKart" };
        return generarPlantillaGenerica(headers);
    }

    public void cargarPilotosDesdeCSV(InputStream is, int idEquipo) throws IOException {
        String contenido = limpiarBOM(is);

        KartingEquipo equipo = equipoRepo.findById(idEquipo)
                .orElseThrow(() -> new EntityNotFoundException("Equipo no encontrado"));

        try (CSVParser parser = CSVFormat.DEFAULT
                .withFirstRecordAsHeader()
                .withDelimiter(';')
                .parse(new StringReader(contenido))) {

            for (CSVRecord record : parser) {
                String nombre = record.get("Nombre").trim();
                String categoria = record.get("Categoria").trim();
                String nacionalidad = record.get("Nacionalidad").trim();
                String fechaNacimientoStr = record.get("FechaNacimiento").trim();
                String numeroKartStr = record.get("NumeroKart").trim();

                boolean existe = pilotoRepo.findByIdEquipoId(idEquipo).stream()
                        .anyMatch(p -> p.getNombre().equalsIgnoreCase(nombre));

                if (!existe) {
                    KartingPiloto piloto = new KartingPiloto();
                    piloto.setNombre(nombre);
                    piloto.setCategoria(categoria);
                    piloto.setNacionalidad(nacionalidad);
                    piloto.setFechaNacimiento(fechaNacimientoStr.isEmpty() ? null : java.time.LocalDate.parse(fechaNacimientoStr));
                    piloto.setNumeroKart(numeroKartStr.isEmpty() ? null : Integer.parseInt(numeroKartStr));
                    piloto.setIdEquipo(equipo);

                    pilotoRepo.save(piloto);
                }
            }
        }
    }

    // ---------------- EQUIPOS ----------------

    public ByteArrayInputStream generarPlantillaCSVEquipos() {
        String[] headers = { "Nombre", "Pais", "Sponsor" };
        return generarPlantillaGenerica(headers);
    }

    public void cargarEquiposDesdeCSV(InputStream is) throws IOException {
        String contenido = limpiarBOM(is);

        try (CSVParser parser = CSVFormat.DEFAULT
                .withFirstRecordAsHeader()
                .withDelimiter(';')
                .parse(new StringReader(contenido))) {

            for (CSVRecord record : parser) {
                String nombre = record.get("Nombre").trim();
                String pais = record.get("Pais").trim();
                String sponsor = record.get("Sponsor").trim();

                boolean existe = equipoRepo.findAll().stream()
                        .anyMatch(e -> e.getNombre().equalsIgnoreCase(nombre));

                if (!existe) {
                    KartingEquipo equipo = new KartingEquipo();
                    equipo.setNombre(nombre);
                    equipo.setPais(pais);
                    equipo.setSponsor(sponsor);

                    equipoRepo.save(equipo);
                }
            }
        }
    }

    // ---------------- CIRCUITOS ----------------

    public ByteArrayInputStream generarPlantillaCSVCircuitos() {
        String[] headers = { "Nombre", "Ubicacion", "Longitud", "Pais" };
        return generarPlantillaGenerica(headers);
    }

    public void cargarCircuitosDesdeCSV(InputStream is) throws IOException {
        String contenido = limpiarBOM(is);

        try (CSVParser parser = CSVFormat.DEFAULT
                .withFirstRecordAsHeader()
                .withDelimiter(';')
                .parse(new StringReader(contenido))) {

            for (CSVRecord record : parser) {
                String nombre = record.get("Nombre").trim();
                String ubicacion = record.get("Ubicacion").trim();
                String pais = record.get("Pais").trim();
                String longitudStr = record.get("Longitud").trim();

                boolean existe = circuitoRepo.findAll().stream()
                        .anyMatch(c -> c.getNombre().equalsIgnoreCase(nombre));

                if (!existe) {
                    KartingCircuito circuito = new KartingCircuito();
                    circuito.setNombre(nombre);
                    circuito.setUbicacion(ubicacion);
                    circuito.setPais(pais);
                    circuito.setLongitud(longitudStr.isEmpty() ? null : new BigDecimal(longitudStr));

                    circuitoRepo.save(circuito);
                }
            }
        }
    }

    // ---------------- UTILIDADES ----------------

    private ByteArrayInputStream generarPlantillaGenerica(String[] headers) {
        ByteArrayOutputStream out = new ByteArrayOutputStream();

        try (OutputStreamWriter writer = new OutputStreamWriter(out, StandardCharsets.UTF_8)) {
            writer.write('\uFEFF'); // BOM
            try (CSVPrinter printer = new CSVPrinter(writer, CSVFormat.DEFAULT
                    .withHeader(headers)
                    .withDelimiter(';'))) {
                // solo cabecera
            }
        } catch (IOException e) {
            throw new RuntimeException("Error generando plantilla CSV", e);
        }

        return new ByteArrayInputStream(out.toByteArray());
    }

    private String limpiarBOM(InputStream is) throws IOException {
        StringBuilder content = new StringBuilder();
        try (BufferedReader reader = new BufferedReader(new InputStreamReader(is, StandardCharsets.UTF_8))) {
            String line;
            boolean isFirstLine = true;
            while ((line = reader.readLine()) != null) {
                if (isFirstLine) {
                    // Elimina BOM si existe
                    line = line.replace("\uFEFF", "");
                    isFirstLine = false;
                }
                content.append(line).append("\n");
            }
        }
        return content.toString();
    }
}
