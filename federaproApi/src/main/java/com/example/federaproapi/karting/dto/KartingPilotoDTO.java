package com.example.federaproapi.karting.dto;

import lombok.Getter;
import lombok.Setter;

import java.time.LocalDate;

@Getter
@Setter
public class KartingPilotoDTO {
    private Integer id;
    private Integer equipoId;
    private String nombre;
    private String categoria;
    private String nacionalidad;
    private LocalDate fechaNacimiento;
    private Integer numeroKart;

    private String nombreEquipo;
}
