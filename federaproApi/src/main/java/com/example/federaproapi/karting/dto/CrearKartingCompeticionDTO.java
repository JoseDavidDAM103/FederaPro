package com.example.federaproapi.karting.dto;

import lombok.Getter;
import lombok.Setter;

import java.time.LocalDate;
import java.util.List;

@Getter
@Setter
public class CrearKartingCompeticionDTO {
    public String nombre;
    public String tipo;
    public String categoria;
    public LocalDate fechaInicio;
    public LocalDate fechaFin;
    public List<Integer> equiposIds;
}
