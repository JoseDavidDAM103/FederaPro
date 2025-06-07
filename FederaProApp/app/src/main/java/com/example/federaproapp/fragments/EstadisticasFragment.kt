package com.example.federaproapp.fragments

import android.graphics.Color
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import com.example.federaproapp.api.ApiClient
import com.example.federaproapp.databinding.FragmentEstadisticasBinding
import com.example.federaproapp.data.EstadisticaJugadorDTO
import com.github.mikephil.charting.components.Description
import com.github.mikephil.charting.components.Legend
import com.github.mikephil.charting.data.BarData
import com.github.mikephil.charting.data.BarDataSet
import com.github.mikephil.charting.data.BarEntry
import com.github.mikephil.charting.data.PieData
import com.github.mikephil.charting.data.PieDataSet
import com.github.mikephil.charting.data.PieEntry
import com.github.mikephil.charting.formatter.IndexAxisValueFormatter
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class EstadisticasFragment : Fragment() {

    private var _binding: FragmentEstadisticasBinding? = null
    private val binding get() = _binding!!

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentEstadisticasBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        val lista = mockEstadisticas()
        mostrarGrafico(lista, "puntos")
        mostrarGrafico(lista, "rebotes")
        mostrarGrafico(lista, "asistencias")
    }

    private fun cargarEstadisticas() {
        ApiClient.instance.getMejoresEstadisticas("puntos").enqueue(object :
            Callback<List<EstadisticaJugadorDTO>> {
            override fun onResponse(
                call: Call<List<EstadisticaJugadorDTO>>,
                response: Response<List<EstadisticaJugadorDTO>>
            ) {
                if (response.isSuccessful) {
                    val datos = response.body() ?: emptyList()

                }
            }

            override fun onFailure(call: Call<List<EstadisticaJugadorDTO>>, t: Throwable) {
                // Manejo de error (opcional)
            }
        })
    }

    private fun mostrarGrafico(lista: List<EstadisticaJugadorDTO>, tipo: String) {
        val entries = lista.map { jugador ->
            val valor = when (tipo) {
                "puntos" -> jugador.puntos
                "rebotes" -> jugador.rebotes
                "asistencias" -> jugador.asistencias
                else -> 0
            }
            PieEntry(valor.toFloat(), jugador.nombreJugador)
        }

        val dataSet = PieDataSet(entries, tipo.replaceFirstChar { it.uppercaseChar() })

        // Colores más suaves (pastel)
        dataSet.colors = listOf(
            Color.parseColor("#90CAF9"), // Azul pastel
            Color.parseColor("#A5D6A7"), // Verde pastel
            Color.parseColor("#CE93D8"), // Violeta pastel
            Color.parseColor("#FFF59D"), // Amarillo pastel
            Color.parseColor("#FFAB91"), // Naranja pastel
            Color.parseColor("#B0BEC5")  // Gris claro
        )

        dataSet.valueTextColor = Color.DKGRAY
        dataSet.valueTextSize = 12f

        val data = PieData(dataSet)

        val chart = when (tipo) {
            "puntos" -> binding.pieChartPuntos
            "rebotes" -> binding.pieChartRebotes
            "asistencias" -> binding.pieChartAsistencias
            else -> return
        }

        chart.data = data
        chart.setEntryLabelColor(Color.DKGRAY)
        chart.setEntryLabelTextSize(12f)
        chart.setUsePercentValues(false)

        chart.description = Description().apply { text = "" }
        // Leyenda bien estructurada
        chart.legend.apply {
            isEnabled = false
            textSize = 12f
            textColor = Color.DKGRAY
            form = Legend.LegendForm.CIRCLE
            horizontalAlignment = Legend.LegendHorizontalAlignment.CENTER
            verticalAlignment = Legend.LegendVerticalAlignment.BOTTOM
            orientation = Legend.LegendOrientation.HORIZONTAL
            setDrawInside(false)
            maxSizePercent = 0.95f
        }

        chart.invalidate()
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }

    private fun mockEstadisticas(): List<EstadisticaJugadorDTO> {
        return listOf(
            EstadisticaJugadorDTO(1, "Juan Pérez", 25, 8, 5, 2, 1, 3),
            EstadisticaJugadorDTO(2, "Carlos Ruiz", 18, 11, 4, 1, 0, 2),
            EstadisticaJugadorDTO(3, "Luis Gómez", 30, 5, 7, 3, 2, 4),
            EstadisticaJugadorDTO(4, "Miguel Torres", 22, 10, 6, 1, 1, 1),
            EstadisticaJugadorDTO(5, "Sergio Díaz", 16, 9, 9, 0, 1, 2)
        )
    }

}
