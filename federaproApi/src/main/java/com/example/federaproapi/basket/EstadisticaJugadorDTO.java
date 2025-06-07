package com.example.federaproapi.basket;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class EstadisticaJugadorDTO {
    private Integer idJugador;
    private Integer partidoId;
    private Integer puntos;
    private Integer rebotes;
    private Integer asistencias;
    private Integer robos;
    private Integer tapones;
    private Integer minutosJugados;
    private Integer perdidas;

}