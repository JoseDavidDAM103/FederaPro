package com.example.federaproapp.fragments

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.federaproapp.adapter.PartidosAdapter
import com.example.federaproapp.api.ApiClient
import com.example.federaproapp.data.PartidoDTO
import com.example.federaproapp.databinding.FragmentPartidosBinding
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class PartidosFragment : Fragment() {

    private var _binding: FragmentPartidosBinding? = null
    private val binding get() = _binding!!
    private lateinit var adapter: PartidosAdapter

    private var competicionNombre: String? = null

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentPartidosBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        // Obtener el nombre de la competición desde los argumentos
        competicionNombre = arguments?.getString("competicionNombre")

        if (competicionNombre.isNullOrBlank()) {
            Toast.makeText(requireContext(), "Nombre de competición no válido", Toast.LENGTH_SHORT).show()
            return
        }

        binding.rvPartidos.layoutManager = LinearLayoutManager(requireContext())

        cargarPartidos()
    }

    private fun cargarPartidos() {
        ApiClient.instance.getPartidos(competicionNombre!!).enqueue(object :
            Callback<List<PartidoDTO>> {
            override fun onResponse(call: Call<List<PartidoDTO>>, response: Response<List<PartidoDTO>>) {
                if (!isAdded) return
                if (response.isSuccessful) {
                    adapter = PartidosAdapter(response.body() ?: emptyList())
                    binding.rvPartidos.adapter = adapter
                } else {
                    Toast.makeText(requireContext(), "Error al cargar los partidos", Toast.LENGTH_SHORT).show()
                }
            }

            override fun onFailure(call: Call<List<PartidoDTO>>, t: Throwable) {
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