package com.example.federaproapp

import android.content.Intent
import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.example.federaproapp.api.ApiClient
import com.example.federaproapp.data.BasketCompeticioneDTO
import com.example.federaproapp.databinding.ActivitySeleccionCompeticionBinding
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class SeleccionCompeticionActivity : AppCompatActivity() {

    private lateinit var binding: ActivitySeleccionCompeticionBinding
    private var listaCompeticiones: List<BasketCompeticioneDTO> = emptyList()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivitySeleccionCompeticionBinding.inflate(layoutInflater)
        setContentView(binding.root)

        cargarCompeticiones()
    }

    private fun cargarCompeticiones() {
        ApiClient.instance.getCompeticiones().enqueue(object : Callback<List<BasketCompeticioneDTO>> {
            override fun onResponse(
                call: Call<List<BasketCompeticioneDTO>>,
                response: Response<List<BasketCompeticioneDTO>>
            ) {
                if (response.isSuccessful) {
                    listaCompeticiones = response.body() ?: emptyList()
                    mostrarLista(listaCompeticiones)
                } else {
                    Toast.makeText(this@SeleccionCompeticionActivity, "Error al obtener competiciones", Toast.LENGTH_SHORT).show()
                }
            }

            override fun onFailure(call: Call<List<BasketCompeticioneDTO>>, t: Throwable) {
                Toast.makeText(this@SeleccionCompeticionActivity, "Error de conexión", Toast.LENGTH_SHORT).show()
            }
        })
    }

    private fun mostrarLista(lista: List<BasketCompeticioneDTO>) {
        val nombres = lista.map { it.nombre }
        val adapter = ArrayAdapter(this, android.R.layout.simple_list_item_1, nombres)
        binding.listViewCompeticiones.adapter = adapter

        binding.listViewCompeticiones.setOnItemClickListener { _, _, position, _ ->
            val seleccionada = lista[position]
            val intent = Intent(this, MainActivity::class.java).apply {
                putExtra("competicionId", seleccionada.id)
                putExtra("competicionNombre", seleccionada.nombre)
            }
            startActivity(intent)
            finish()
        }
    }
}