package com.example.federaproapp.adapter

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.example.federaproapp.databinding.ItemEstadisticaJugadorBinding
import com.example.federaproapp.data.EstadisticaJugadorDTO

class EstadisticasJugadorAdapter(
    private val lista: List<EstadisticaJugadorDTO>
) : RecyclerView.Adapter<EstadisticasJugadorAdapter.ViewHolder>() {

    inner class ViewHolder(val binding: ItemEstadisticaJugadorBinding) :
        RecyclerView.ViewHolder(binding.root)

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val binding = ItemEstadisticaJugadorBinding.inflate(
            LayoutInflater.from(parent.context),
            parent,
            false
        )
        return ViewHolder(binding)
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val jugador = lista[position]
        with(holder.binding) {
            tvNombreJugador.text = jugador.nombreJugador
            tvPuntos.text = "PTS: ${jugador.puntos}"
            tvRebotes.text = "REB: ${jugador.rebotes}"
            tvAsistencias.text = "AST: ${jugador.asistencias}"
            tvRobos.text = "ROB: ${jugador.robos}"
            tvTapones.text = "TAP: ${jugador.tapones}"
            tvPerdidas.text = "TO: ${jugador.perdidas}"
        }
    }

    override fun getItemCount(): Int = lista.size
}