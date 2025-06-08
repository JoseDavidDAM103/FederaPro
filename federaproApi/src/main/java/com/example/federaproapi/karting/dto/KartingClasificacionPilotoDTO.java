package com.example.federaproapi.karting.dto;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class KartingClasificacionPilotoDTO {
    private String nombrePiloto;
    private String equipo;
    private int puntos;
}