package com.example.federaproapp.karting.adapter

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.federaproapp.R
import com.example.federaproapp.karting.data.KartingCompeticionDTO

class CompeticionKartingAdapter(
    private var lista: List<KartingCompeticionDTO>,
    private val onItemClick: (KartingCompeticionDTO) -> Unit
) : RecyclerView.Adapter<CompeticionKartingAdapter.CompeticionViewHolder>() {

    inner class CompeticionViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val tvNombre: TextView = itemView.findViewById(R.id.tvNombreCompeticion)
        val tvTipo: TextView = itemView.findViewById(R.id.tvTipoCompeticion)

        init {
            itemView.setOnClickListener {
                onItemClick(lista[adapterPosition])
            }
        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): CompeticionViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_competicion_karting, parent, false)
        return CompeticionViewHolder(view)
    }

    override fun onBindViewHolder(holder: CompeticionViewHolder, position: Int) {
        val competicion = lista[position]
        holder.tvNombre.text = competicion.nombre
        holder.tvTipo.text = competicion.tipo
    }
    fun actualizarLista(nuevaLista: List<KartingCompeticionDTO>) {
        lista = nuevaLista.toMutableList()
        notifyDataSetChanged()
    }

    override fun getItemCount(): Int = lista.size
}