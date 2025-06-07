package com.example.federaproapi.basket;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class CrearActualizarJugadorDTO {
    public Integer id;
    public String nombre;
    public Double altura;
    public Double peso;
    public String posicion;
    public Integer dorsal;
    public Integer equipoId;
}