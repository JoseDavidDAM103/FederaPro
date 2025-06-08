package com.example.federaproapi.karting.dto;

import lombok.Getter;
import lombok.Setter;

import java.math.BigDecimal;

@Getter
@Setter
public class KartingEstadisticaPilotoDTO {
    private String nombrePiloto;
    private Integer idCarrera;
    private Integer posicion;
    private BigDecimal tiempoTotal;
    private Integer vueltas;
}
