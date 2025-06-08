package com.example.federaproapi.karting.dto;

import lombok.AllArgsConstructor;
import lombok.Data;

import java.time.Instant;

@Data
@AllArgsConstructor
public class KartingCarreraDTO {
    private Integer id;
    private Instant fecha;
    private String circuito;
    private int numero;
}
