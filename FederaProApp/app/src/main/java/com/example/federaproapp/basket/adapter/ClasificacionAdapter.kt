package com.example.federaproapp.basket.adapter

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.example.federaproapp.basket.data.ClasificacionEquipoDTO
import com.example.federaproapp.databinding.ItemClasificacionBinding

class ClasificacionAdapter(private var lista: List<ClasificacionEquipoDTO>) :
    RecyclerView.Adapter<ClasificacionAdapter.ViewHolder>() {

    inner class ViewHolder(val binding: ItemClasificacionBinding) :
        RecyclerView.ViewHolder(binding.root)

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val binding = ItemClasificacionBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return ViewHolder(binding)
    }

    override fun getItemCount(): Int = lista.size

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val equipo = lista[position]
        with(holder.binding) {
            tvNombreEquipo.text = equipo.nombreEquipo
            tvPartidos.text = "PJ: ${equipo.partidosJugados}"
            tvVictorias.text = "V: ${equipo.victorias}"
            tvDerrotas.text = "D: ${equipo.derrotas}"
            tvPuntos.text = "Pts: ${equipo.puntos}"
        }
    }

    fun updateData(nuevaLista: List<ClasificacionEquipoDTO>) {
        lista = nuevaLista
        notifyDataSetChanged()
    }
}