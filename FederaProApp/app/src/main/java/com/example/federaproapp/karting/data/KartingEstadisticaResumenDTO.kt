package com.example.federaproapp.karting.data

data class KartingEstadisticaResumenDTO(
    val nombrePiloto: String,
    val equipo: String,
    val victorias: Int,
    val podios: Int,
    val vueltasTotales: Int
)