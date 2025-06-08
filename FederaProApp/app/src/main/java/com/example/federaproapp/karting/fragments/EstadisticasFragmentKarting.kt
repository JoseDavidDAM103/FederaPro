package com.example.federaproapp.karting.fragments

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.AdapterView
import android.widget.ArrayAdapter
import androidx.fragment.app.Fragment
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.federaproapp.api.KartingClient
import com.example.federaproapp.databinding.FragmentEstadisticasKartingBinding
import com.example.federaproapp.karting.adapter.EstadisticaPilotoAdapter
import com.example.federaproapp.karting.data.KartingEstadisticaPilotoDTO
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class EstadisticasFragmentKarting : Fragment() {
    private var _binding: FragmentEstadisticasKartingBinding? = null
    private val binding get() = _binding!!

    private var nombreCompeticion: String? = null
    private lateinit var adapter: EstadisticaPilotoAdapter

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        nombreCompeticion = arguments?.getString("nombreCompeticion")
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentEstadisticasKartingBinding.inflate(inflater, container, false)

        // Adapter con lista vacía
        adapter = EstadisticaPilotoAdapter(emptyList())
        binding.rvEstadisticas.layoutManager = LinearLayoutManager(requireContext())
        binding.rvEstadisticas.adapter = adapter

        // Spinner de tipo de estadística
        val opciones = listOf("Victorias", "Podios", "Vueltas completadas")
        val spinnerAdapter = ArrayAdapter(requireContext(), android.R.layout.simple_spinner_item, opciones)
        spinnerAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)
        binding.spinnerEstadisticas.adapter = spinnerAdapter

        binding.spinnerEstadisticas.onItemSelectedListener = object : AdapterView.OnItemSelectedListener {
            override fun onItemSelected(parent: AdapterView<*>, view: View?, pos: Int, id: Long) {
                when (pos) {
                    0 -> cargarEstadisticas("victorias")
                    1 -> cargarEstadisticas("podios")
                    2 -> cargarEstadisticas("vueltas")
                }
            }

            override fun onNothingSelected(parent: AdapterView<*>) {}
        }

        return binding.root
    }

    private fun cargarEstadisticas(tipo: String) {
        if (nombreCompeticion.isNullOrEmpty()) return

        val call: Call<List<KartingEstadisticaPilotoDTO>> = when (tipo) {
            "victorias" -> KartingClient.instance.obtenerRankingVictorias(nombreCompeticion!!)
            "podios" -> KartingClient.instance.obtenerRankingPodios(nombreCompeticion!!)
            "vueltas" -> KartingClient.instance.obtenerRankingVueltas(nombreCompeticion!!)
            else -> return
        }

        call.enqueue(object : Callback<List<KartingEstadisticaPilotoDTO>> {
            override fun onResponse(
                call: Call<List<KartingEstadisticaPilotoDTO>>,
                response: Response<List<KartingEstadisticaPilotoDTO>>
            ) {
                if (response.isSuccessful && response.body() != null) {
                    adapter.actualizarLista(response.body()!!)
                }
            }

            override fun onFailure(call: Call<List<KartingEstadisticaPilotoDTO>>, t: Throwable) {
                // Puedes añadir un log o toast aquí
            }
        })
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }

    companion object {
        fun newInstance(nombreCompeticion: String?): EstadisticasFragmentKarting {
            val fragment = EstadisticasFragmentKarting()
            fragment.arguments = Bundle().apply {
                putString("nombreCompeticion", nombreCompeticion)
            }
            return fragment
        }
    }
}