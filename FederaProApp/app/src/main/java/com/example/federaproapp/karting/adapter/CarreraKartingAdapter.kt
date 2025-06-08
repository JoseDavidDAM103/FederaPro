package com.example.federaproapp.karting.adapter

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.federaproapp.R
import com.example.federaproapp.karting.data.KartingCarreraDTO

class CarreraKartingAdapter(
    private var lista: List<KartingCarreraDTO>,
    private val onItemClick: (KartingCarreraDTO) -> Unit
) : RecyclerView.Adapter<CarreraKartingAdapter.ViewHolder>() {

    class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val tvFecha: TextView = view.findViewById(R.id.tvFechaCarrera)
        val tvNombre: TextView = view.findViewById(R.id.tvCircuitoCarrera)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_carrera_karting, parent, false)
        return ViewHolder(view)
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val carrera = lista[position]
        holder.tvNombre.text = carrera.nombreCircuito
        holder.tvFecha.text = carrera.fecha ?: "Sin fecha"

        holder.itemView.setOnClickListener {
            onItemClick(carrera)
        }
    }

    override fun getItemCount(): Int = lista.size

    fun actualizarLista(nuevaLista: List<KartingCarreraDTO>) {
        lista = nuevaLista
        notifyDataSetChanged()
    }
}