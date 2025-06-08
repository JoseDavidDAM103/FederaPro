package com.example.federaproapi.karting.dto;

import lombok.Getter;
import lombok.Setter;

import java.time.LocalDate;

@Getter
@Setter
public class CrearKartingCarreraDTO {
    public String nombreCompeticion;
    public int circuitoId;
    public LocalDate fecha;
}
