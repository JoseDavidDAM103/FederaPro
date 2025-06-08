package com.example.federaproapp.karting.api

import com.example.federaproapp.karting.data.KartingCarreraDTO
import com.example.federaproapp.karting.data.KartingClasificacionEquipoDTO
import com.example.federaproapp.karting.data.KartingClasificacionPilotoDTO
import com.example.federaproapp.karting.data.KartingCompeticionDTO
import com.example.federaproapp.karting.data.KartingEstadisticaPilotoDTO
import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Path
import retrofit2.http.Query

interface KartingApiService {

    @GET("karting/competiciones")
    fun obtenerCompeticionesKarting(): Call<List<KartingCompeticionDTO>>


    @GET("karting/competiciones/{nombre}/clasificacion-pilotos")
    fun obtenerClasificacionPilotos(@Path("nombre") nombreCompeticion: String): Call<List<KartingClasificacionPilotoDTO>>

    @GET("karting/competiciones/{nombre}/clasificacion-equipos")
    fun obtenerClasificacionEquipos(@Path("nombre") nombreCompeticion: String): Call<List<KartingClasificacionEquipoDTO>>

    @GET("karting/competiciones/{nombre}/carreras")
    fun obtenerCarrerasPorCompeticion(@Path("nombre") nombreCompeticion: String): Call<List<KartingCarreraDTO>>

    @GET("karting/estadisticas//victorias")
    fun obtenerRankingVictorias(@Query("nombreCompeticion") nombre: String): Call<List<KartingEstadisticaPilotoDTO>>

    @GET("karting/estadisticas/piloto/podios")
    fun obtenerRankingPodios(@Query("nombreCompeticion") nombre: String): Call<List<KartingEstadisticaPilotoDTO>>

    @GET("karting/estadisticas/piloto/vueltas")
    fun obtenerRankingVueltas(@Query("nombreCompeticion") nombre: String): Call<List<KartingEstadisticaPilotoDTO>>
}