package com.example.federaproapi.basket;

public class ClasificacionEquipoDTO {
    private String nombreEquipo;
    private int partidosJugados;
    private int victorias;
    private int derrotas;
    private int puntos;

    public ClasificacionEquipoDTO(String nombreEquipo, int partidosJugados, int victorias, int derrotas, int puntos) {
        this.nombreEquipo = nombreEquipo;
        this.partidosJugados = partidosJugados;
        this.victorias = victorias;
        this.derrotas = derrotas;
        this.puntos = puntos;
    }

    public String getNombreEquipo() {
        return nombreEquipo;
    }
    public void setNombreEquipo(String nombreEquipo) {
        this.nombreEquipo = nombreEquipo;
    }
    public int getPartidosJugados() {
        return partidosJugados;
    }
    public void setPartidosJugados(int partidosJugados) {
        this.partidosJugados = partidosJugados;
    }
    public int getVictorias() {
        return victorias;
    }
    public void setVictorias(int victorias) {
        this.victorias = victorias;
    }
    public int getDerrotas() {
        return derrotas;
    }
    public void setDerrotas(int derrotas) {
        this.derrotas = derrotas;
    }
    public int getPuntos() {
        return puntos;
    }
    public void setPuntos(int puntos) {
        this.puntos = puntos;
    }

}
