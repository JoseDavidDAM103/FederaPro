package com.example.federaproapp.karting.adapter

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.federaproapp.R
import com.example.federaproapp.karting.data.KartingClasificacionPilotoDTO

class ClasificacionPilotoAdapter(
    private var lista: List<KartingClasificacionPilotoDTO>
) : RecyclerView.Adapter<ClasificacionPilotoAdapter.ViewHolder>() {

    class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val tvNombre: TextView = view.findViewById(R.id.tvNombrePiloto)
        val tvEquipo: TextView = view.findViewById(R.id.tvEquipo)
        val tvPuntos: TextView = view.findViewById(R.id.tvPuntos)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_clasificacion_piloto, parent, false)
        return ViewHolder(view)
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val piloto = lista[position]
        holder.tvNombre.text = piloto.piloto
        holder.tvEquipo.text = piloto.equipo ?: ""
        holder.tvPuntos.text = "${piloto.puntos} pts"
    }

    override fun getItemCount(): Int = lista.size

    fun actualizarLista(nuevaLista: List<KartingClasificacionPilotoDTO>) {
        lista = nuevaLista
        notifyDataSetChanged()
    }
}
