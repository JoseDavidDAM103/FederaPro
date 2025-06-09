package com.example.federaproapp.data

data class LoginResponse(
    val idUsuario: Long,
    val nombre: String,
    val correo: String,
    val rol: String,
    val idDeporte: Long,
    val nombreDeporte: String
)
