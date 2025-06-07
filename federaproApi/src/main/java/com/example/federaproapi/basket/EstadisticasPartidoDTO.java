package com.example.federaproapi.basket;

import lombok.Getter;
import lombok.Setter;

import java.util.List;

@Getter
@Setter
public class EstadisticasPartidoDTO {
    private Integer partidoId;
    private List<EstadisticaEquipoDTO> estadisticasEquipos;
    private List<EstadisticaJugadorDTO> estadisticasJugadores;
}

