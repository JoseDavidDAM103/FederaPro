package com.example.federaproapp.adapter

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.example.federaproapp.data.PartidoDTO
import com.example.federaproapp.databinding.ItemPartidoBinding

class PartidosAdapter(private val partidos: List<PartidoDTO>) :
    RecyclerView.Adapter<PartidosAdapter.ViewHolder>() {

    inner class ViewHolder(val binding: ItemPartidoBinding) : RecyclerView.ViewHolder(binding.root)

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val binding = ItemPartidoBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return ViewHolder(binding)
    }

    override fun getItemCount(): Int = partidos.size

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val partido = partidos[position]
        with(holder.binding) {
            tvEquipos.text = "${partido.equipoLocal} vs ${partido.equipoVisitante}"
            tvResultado.text = partido.resultado
            // Formatear la fecha
            val originalFormat = java.text.SimpleDateFormat("yyyy-MM-dd", java.util.Locale.getDefault())
            val targetFormat = java.text.SimpleDateFormat("dd/MM/yyyy", java.util.Locale.getDefault())
            val fechaFormateada = try {
                val date = originalFormat.parse(partido.fecha)
                targetFormat.format(date)
            } catch (e: Exception) {
                partido.fecha // En caso de error, muestra la original
            }

            tvFecha.text = fechaFormateada
        }
    }
}