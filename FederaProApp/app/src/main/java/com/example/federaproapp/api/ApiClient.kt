package com.example.federaproapp.api

import com.example.federaproapp.basket.api.BasketApiService
import com.example.federaproapp.karting.api.KartingApiService
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object ApiClient {
    val instance: BasketApiService by lazy {
        Retrofit.Builder()
            .baseUrl("http://192.168.2.105:8080/")
            .addConverterFactory(GsonConverterFactory.create())
            .build()
            .create(BasketApiService::class.java)
    }
}

object LoginClient {
    val instance: AuthApi by lazy {
        Retrofit.Builder()
            .baseUrl("http://192.168.2.105:8080/")
            .addConverterFactory(GsonConverterFactory.create())
            .build()
            .create(AuthApi::class.java)
    }
}

object KartingClient {
    val instance: KartingApiService by lazy {
        Retrofit.Builder()
            .baseUrl("http://192.168.2.105:8080/")
            .addConverterFactory(GsonConverterFactory.create())
            .build()
            .create(KartingApiService::class.java)
    }
}