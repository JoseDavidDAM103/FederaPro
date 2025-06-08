package com.example.federaproapp.karting.fragments

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.federaproapp.api.KartingClient
import com.example.federaproapp.databinding.FragmentClasificacionKartingBinding
import com.example.federaproapp.karting.adapter.ClasificacionEquipoAdapter
import com.example.federaproapp.karting.adapter.ClasificacionPilotoAdapter
import com.example.federaproapp.karting.data.KartingClasificacionEquipoDTO
import com.example.federaproapp.karting.data.KartingClasificacionPilotoDTO
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class ClasificacionFragmentKarting : Fragment() {
    private var _binding: FragmentClasificacionKartingBinding? = null
    private val binding get() = _binding!!

    private var nombreCompeticion: String? = null

    private lateinit var pilotoAdapter: ClasificacionPilotoAdapter
    private lateinit var equipoAdapter: ClasificacionEquipoAdapter

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        nombreCompeticion = arguments?.getString("nombreCompeticion")
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentClasificacionKartingBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        setupRecyclerViews()
        cargarClasificacion()
    }

    private fun setupRecyclerViews() {
        pilotoAdapter = ClasificacionPilotoAdapter(emptyList())
        binding.rvPilotos.layoutManager = LinearLayoutManager(requireContext())
        binding.rvPilotos.adapter = pilotoAdapter

        equipoAdapter = ClasificacionEquipoAdapter(emptyList())
        binding.rvEquipos.layoutManager = LinearLayoutManager(requireContext())
        binding.rvEquipos.adapter = equipoAdapter
    }

    private fun cargarClasificacion() {
        nombreCompeticion?.let { nombre ->
            KartingClient.instance.obtenerClasificacionPilotos(nombre).enqueue(object : Callback<List<KartingClasificacionPilotoDTO>> {
                override fun onResponse(
                    call: Call<List<KartingClasificacionPilotoDTO>>,
                    response: Response<List<KartingClasificacionPilotoDTO>>
                ) {
                    if (response.isSuccessful && response.body() != null) {
                        pilotoAdapter.actualizarLista(response.body()!!)
                    } else {
                        Toast.makeText(context, "Error al cargar clasificación de pilotos", Toast.LENGTH_SHORT).show()
                    }
                }

                override fun onFailure(call: Call<List<KartingClasificacionPilotoDTO>>, t: Throwable) {
                    Toast.makeText(context, "Error de conexión al cargar pilotos", Toast.LENGTH_SHORT).show()
                }
            })

            KartingClient.instance.obtenerClasificacionEquipos(nombre).enqueue(object : Callback<List<KartingClasificacionEquipoDTO>> {
                override fun onResponse(
                    call: Call<List<KartingClasificacionEquipoDTO>>,
                    response: Response<List<KartingClasificacionEquipoDTO>>
                ) {
                    if (response.isSuccessful && response.body() != null) {
                        equipoAdapter.actualizarLista(response.body()!!)
                    } else {
                        Toast.makeText(context, "Error al cargar clasificación de equipos", Toast.LENGTH_SHORT).show()
                    }
                }

                override fun onFailure(call: Call<List<KartingClasificacionEquipoDTO>>, t: Throwable) {
                    Toast.makeText(context, "Error de conexión al cargar equipos", Toast.LENGTH_SHORT).show()
                }
            })
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
    companion object {
        fun newInstance(nombreCompeticion: String): ClasificacionFragmentKarting {
            val fragment = ClasificacionFragmentKarting()
            val args = Bundle()
            args.putString("nombreCompeticion", nombreCompeticion)
            fragment.arguments = args
            return fragment
        }
    }
}