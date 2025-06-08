package com.example.federaproapp.karting.adapter


import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.federaproapp.R
import com.example.federaproapp.karting.data.KartingEstadisticaPilotoDTO

class EstadisticaPilotoAdapter(
    private var lista: List<KartingEstadisticaPilotoDTO>
) : RecyclerView.Adapter<EstadisticaPilotoAdapter.ViewHolder>() {

    class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val tvNombrePiloto: TextView = view.findViewById(R.id.tvNombrePiloto)
        val tvValor: TextView = view.findViewById(R.id.tvValorEstadistica)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_estadistica_piloto, parent, false)
        return ViewHolder(view)
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val estadistica = lista[position]
        holder.tvNombrePiloto.text = estadistica.nombrePiloto
        holder.tvValor.text = estadistica.valor.toString()
    }

    override fun getItemCount(): Int = lista.size

    fun actualizarLista(nuevaLista: List<KartingEstadisticaPilotoDTO>) {
        lista = nuevaLista
        notifyDataSetChanged()
    }
}