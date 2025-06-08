package com.example.federaproapp.api

import com.example.federaproapp.data.LoginRequest
import com.example.federaproapp.data.UsuarioDTO
import retrofit2.Call
import retrofit2.http.Body
import retrofit2.http.POST

interface AuthApi {

    @POST("login")
    fun login(@Body request: LoginRequest): Call<UsuarioDTO>
}