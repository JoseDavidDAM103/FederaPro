package com.example.federaproapp.fragments

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.federaproapp.adapter.ClasificacionAdapter
import com.example.federaproapp.api.ApiClient
import com.example.federaproapp.data.ClasificacionEquipoDTO
import com.example.federaproapp.databinding.FragmentClasificacionBinding
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class ClasificacionFragment : Fragment() {

    private var _binding: FragmentClasificacionBinding? = null
    private val binding get() = _binding!!
    private lateinit var adapter: ClasificacionAdapter

    private var competicionNombre: String? = null

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentClasificacionBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        competicionNombre = arguments?.getString("competicionNombre")

        if (competicionNombre.isNullOrBlank()) {
            Toast.makeText(requireContext(), "Nombre de competición no válido", Toast.LENGTH_SHORT).show()
            return
        }

        binding.rvClasificacion.layoutManager = LinearLayoutManager(requireContext())
        adapter = ClasificacionAdapter(emptyList())
        binding.rvClasificacion.adapter = adapter

        cargarClasificacion()
    }

    private fun cargarClasificacion() {
        ApiClient.instance.obtenerClasificacion(competicionNombre!!).enqueue(object : Callback<List<ClasificacionEquipoDTO>> {
            override fun onResponse(
                call: Call<List<ClasificacionEquipoDTO>>,
                response: Response<List<ClasificacionEquipoDTO>>
            ) {
                if (!isAdded) return
                if (response.isSuccessful && response.body() != null) {
                    adapter.updateData(response.body()!!)
                } else {
                    Toast.makeText(requireContext(), "Error al cargar clasificación", Toast.LENGTH_SHORT).show()
                }
            }

            override fun onFailure(call: Call<List<ClasificacionEquipoDTO>>, t: Throwable) {
                if (!isAdded) return
                Toast.makeText(requireContext(), "Fallo de conexión: ${t.message}", Toast.LENGTH_SHORT).show()
            }
        })
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}