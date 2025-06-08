package com.example.federaproapp.karting.adapter

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.federaproapp.R
import com.example.federaproapp.karting.data.KartingClasificacionEquipoDTO

class ClasificacionEquipoAdapter(
    private var lista: List<KartingClasificacionEquipoDTO>
) : RecyclerView.Adapter<ClasificacionEquipoAdapter.ViewHolder>() {

    class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val tvEquipo: TextView = view.findViewById(R.id.tvNombreEquipo)
        val tvPuntos: TextView = view.findViewById(R.id.tvPuntosEquipo)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_clasificacion_equipo, parent, false)
        return ViewHolder(view)
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val equipo = lista[position]
        holder.tvEquipo.text = equipo.equipo
        holder.tvPuntos.text = "${equipo.puntos} pts"
    }

    override fun getItemCount(): Int = lista.size

    fun actualizarLista(nuevaLista: List<KartingClasificacionEquipoDTO>) {
        lista = nuevaLista
        notifyDataSetChanged()
    }
}