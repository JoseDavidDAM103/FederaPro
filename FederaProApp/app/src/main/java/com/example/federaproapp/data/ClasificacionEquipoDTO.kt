package com.example.federaproapp.data

data class ClasificacionEquipoDTO(
    val nombreEquipo: String,
    val partidosJugados: Int,
    val victorias: Int,
    val derrotas: Int,
    val puntos: Int
)