package com.example.federaproapp.karting.adapter

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.federaproapp.R
import com.example.federaproapp.karting.data.KartingCarreraDTO
import java.text.SimpleDateFormat
import java.util.Locale

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
        holder.tvNombre.text = carrera.circuito
        holder.tvFecha.text = formatearFecha(carrera.fecha)

        holder.itemView.setOnClickListener {
            onItemClick(carrera)
        }
    }

    private fun formatearFecha(fechaISO: String): String {
        return try {
            val parser = SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss", Locale.getDefault())
            val date = parser.parse(fechaISO)
            val formatter = SimpleDateFormat("dd/MM/yyyy", Locale.getDefault())
            formatter.format(date!!)
        } catch (e: Exception) {
            fechaISO
        }
    }

    override fun getItemCount(): Int = lista.size

    fun actualizarLista(nuevaLista: List<KartingCarreraDTO>) {
        lista = nuevaLista
        notifyDataSetChanged()
    }
}