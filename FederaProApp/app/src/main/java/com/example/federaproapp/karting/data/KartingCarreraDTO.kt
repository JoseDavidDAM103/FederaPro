package com.example.federaproapp.karting.data

import java.time.LocalDate

data class KartingCarreraDTO(
    val id: Int,
    val nombreCircuito: String,
    val fecha: String // Puedes usar `String` si los datos vienen como texto ISO desde el backend
)