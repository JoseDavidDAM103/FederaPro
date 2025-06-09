package com.example.federaproapp.karting.fragments

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.federaproapp.api.KartingClient
import com.example.federaproapp.databinding.FragmentCarrerasKartingBinding
import com.example.federaproapp.karting.adapter.CarreraKartingAdapter
import com.example.federaproapp.karting.data.KartingCarreraDTO
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class CarrerasFragmentKarting : Fragment() {
    private var _binding: FragmentCarrerasKartingBinding? = null
    private val binding get() = _binding!!
    private var nombreCompeticion: String? = null
    private lateinit var adapter: CarreraKartingAdapter

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        nombreCompeticion = arguments?.getString("nombreCompeticion")
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentCarrerasKartingBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        adapter = CarreraKartingAdapter(emptyList()) { carrera ->
            Toast.makeText(requireContext(), "Carrera: ${carrera.circuito}", Toast.LENGTH_SHORT).show()
            // Aquí puedes abrir un detalle o estadísticas
        }

        binding.rvCarrerasKarting.layoutManager = LinearLayoutManager(requireContext())
        binding.rvCarrerasKarting.adapter = adapter

        cargarCarreras()
    }

    private fun cargarCarreras() {
        if (nombreCompeticion == null) return

        KartingClient.instance.obtenerCarrerasPorCompeticion(nombreCompeticion!!)
            .enqueue(object : Callback<List<KartingCarreraDTO>> {
                override fun onResponse(
                    call: Call<List<KartingCarreraDTO>>,
                    response: Response<List<KartingCarreraDTO>>
                ) {
                    if (response.isSuccessful && response.body() != null) {
                        adapter.actualizarLista(response.body()!!)
                    } else {
                        Toast.makeText(requireContext(), "Error al cargar carreras", Toast.LENGTH_SHORT).show()
                    }
                }

                override fun onFailure(call: Call<List<KartingCarreraDTO>>, t: Throwable) {
                    Toast.makeText(requireContext(), "Error de conexión", Toast.LENGTH_SHORT).show()
                }
            })
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }

    companion object {
        fun newInstance(nombreCompeticion: String): CarrerasFragmentKarting {
            val fragment = CarrerasFragmentKarting()
            val args = Bundle()
            args.putString("nombreCompeticion", nombreCompeticion)
            fragment.arguments = args
            return fragment
        }
    }
}