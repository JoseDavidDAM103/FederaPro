package com.example.federaproapp.basket.api

import com.example.federaproapp.basket.data.BasketCompeticioneDTO
import com.example.federaproapp.basket.data.ClasificacionEquipoDTO
import com.example.federaproapp.basket.data.EstadisticaJugadorDTO
import com.example.federaproapp.basket.data.PartidoDTO
import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Path
import retrofit2.http.Query

interface BasketApiService {
    @GET("basket/competiciones/clasificacion/{nombre}")
    fun obtenerClasificacion(@Path("nombre") nombre: String): Call<List<ClasificacionEquipoDTO>>

    @GET("basket/partidos/competicion/{nombre}")
    fun getPartidos(
        @Path("nombre") nombreCompeticion: String
    ): Call<List<PartidoDTO>>

    @GET("basket/estadisticas/mejores")
    fun getMejoresEstadisticas(@Query("orden") tipo: String): Call<List<EstadisticaJugadorDTO>>

    @GET("basket/competiciones")
    fun getCompeticiones(): Call<List<BasketCompeticioneDTO>>
}