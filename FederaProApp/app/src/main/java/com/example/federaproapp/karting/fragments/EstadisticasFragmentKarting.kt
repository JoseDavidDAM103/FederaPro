package com.example.federaproapp.karting.fragments

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.*
import androidx.core.view.setPadding
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
    private var datosActuales: List<KartingEstadisticaPilotoDTO> = emptyList()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        nombreCompeticion = arguments?.getString("nombreCompeticion")
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentEstadisticasKartingBinding.inflate(inflater, container, false)

        adapter = EstadisticaPilotoAdapter(emptyList())
        binding.rvEstadisticas.layoutManager = LinearLayoutManager(requireContext())
        binding.rvEstadisticas.adapter = adapter

        val opciones = listOf("Victorias", "Podios", "Vueltas completadas")
        val spinnerAdapter = ArrayAdapter(requireContext(), android.R.layout.simple_spinner_item, opciones)
        spinnerAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)
        binding.spinnerEstadisticas.adapter = spinnerAdapter

        binding.spinnerEstadisticas.onItemSelectedListener = object : AdapterView.OnItemSelectedListener {
            override fun onItemSelected(parent: AdapterView<*>, view: View?, pos: Int, id: Long) {
                val tipo = when (pos) {
                    0 -> "victorias"
                    1 -> "podios"
                    2 -> "vueltas"
                    else -> return
                }
                cargarEstadisticas(tipo)
            }

            override fun onNothingSelected(parent: AdapterView<*>) {}
        }

        return binding.root
    }

    private fun cargarEstadisticas(tipo: String) {
        if (nombreCompeticion.isNullOrEmpty()) return

        val call = when (tipo) {
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
                    val datos = response.body()!!
                    datosActuales = datos
                    adapter.actualizarLista(datos)
                    mostrarGrafica(datos)
                }
            }

            override fun onFailure(call: Call<List<KartingEstadisticaPilotoDTO>>, t: Throwable) {
                Toast.makeText(context, "Error de conexión", Toast.LENGTH_SHORT).show()
            }
        })
    }

    private fun mostrarGrafica(lista: List<KartingEstadisticaPilotoDTO>) {
        binding.layoutGrafica.removeAllViews()
        if (lista.isEmpty()) return

        val maxValor = lista.maxOf { it.valor }

        for (piloto in lista) {
            val fila = LinearLayout(requireContext()).apply {
                orientation = LinearLayout.HORIZONTAL
                setPadding(8)
                layoutParams = LinearLayout.LayoutParams(
                    LinearLayout.LayoutParams.MATCH_PARENT,
                    LinearLayout.LayoutParams.WRAP_CONTENT
                )
            }

            val nombre = TextView(requireContext()).apply {
                text = piloto.nombrePiloto
                layoutParams = LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.WRAP_CONTENT, 1f)
            }

            val barra = ProgressBar(requireContext(), null, android.R.attr.progressBarStyleHorizontal).apply {
                max = maxValor
                progress = piloto.valor
                layoutParams = LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.WRAP_CONTENT, 2f)
            }

            fila.addView(nombre)
            fila.addView(barra)
            binding.layoutGrafica.addView(fila)
        }
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