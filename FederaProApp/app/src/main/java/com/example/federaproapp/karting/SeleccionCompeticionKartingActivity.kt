package com.example.federaproapp.karting

import android.content.Intent
import android.os.Bundle
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.federaproapp.api.ApiClient
import com.example.federaproapp.api.KartingClient
import com.example.federaproapp.databinding.ActivitySeleccionCompeticionKartingBinding
import com.example.federaproapp.karting.adapter.CompeticionKartingAdapter
import com.example.federaproapp.karting.data.KartingCompeticionDTO
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class SeleccionCompeticionKartingActivity : AppCompatActivity() {

    private lateinit var binding: ActivitySeleccionCompeticionKartingBinding
    private lateinit var adapter: CompeticionKartingAdapter

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivitySeleccionCompeticionKartingBinding.inflate(layoutInflater)
        setContentView(binding.root)

        setupRecyclerView()
        cargarCompeticiones()

        binding.btnRecargar.setOnClickListener {
            cargarCompeticiones()
        }
    }

    private fun setupRecyclerView() {
        adapter = CompeticionKartingAdapter(lista = listOf()) { competicion ->
            val intent = Intent(this, MainKartingActivity::class.java).apply {
                putExtra("nombreCompeticion", competicion.nombre)
                putExtra("tipoCompeticion", competicion.tipo)
            }
            startActivity(intent)
        }

        binding.rvCompeticionesKarting.layoutManager = LinearLayoutManager(this)
        binding.rvCompeticionesKarting.adapter = adapter
    }

    private fun cargarCompeticiones() {
        binding.btnRecargar.isEnabled = false

        KartingClient.instance.obtenerCompeticionesKarting().enqueue(object : Callback<List<KartingCompeticionDTO>> {
            override fun onResponse(
                call: Call<List<KartingCompeticionDTO>>,
                response: Response<List<KartingCompeticionDTO>>
            ) {
                binding.btnRecargar.isEnabled = true
                if (response.isSuccessful && response.body() != null) {
                    adapter.actualizarLista(response.body()!!)
                } else {
                    Toast.makeText(this@SeleccionCompeticionKartingActivity, "Error al cargar competiciones", Toast.LENGTH_SHORT).show()
                }
            }

            override fun onFailure(call: Call<List<KartingCompeticionDTO>>, t: Throwable) {
                binding.btnRecargar.isEnabled = true
                Toast.makeText(this@SeleccionCompeticionKartingActivity, "Error de conexión", Toast.LENGTH_SHORT).show()
            }
        })
    }
}