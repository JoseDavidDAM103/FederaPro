package com.example.federaproapp.karting

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import androidx.fragment.app.Fragment
import com.example.federaproapp.R
import com.example.federaproapp.databinding.ActivityMainKartingBinding
import com.example.federaproapp.karting.fragments.CarrerasFragmentKarting
import com.example.federaproapp.karting.fragments.ClasificacionFragmentKarting
import com.example.federaproapp.karting.fragments.EstadisticasFragmentKarting

class MainKartingActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainKartingBinding
    private lateinit var nombreCompeticion: String
    private lateinit var tipoCompeticion: String

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainKartingBinding.inflate(layoutInflater)
        setContentView(binding.root)

        nombreCompeticion = intent.getStringExtra("nombreCompeticion") ?: ""
        tipoCompeticion = intent.getStringExtra("tipoCompeticion") ?: ""

        // Título dinámico
        supportActionBar?.title = "$nombreCompeticion ($tipoCompeticion)"

        binding.bottomNavigation.setOnItemSelectedListener {
            when (it.itemId) {
                R.id.nav_clasificacion -> {
                    loadFragment(ClasificacionFragmentKarting.newInstance(nombreCompeticion))
                    true
                }

                R.id.nav_carreras -> {
                    loadFragment(CarrerasFragmentKarting.newInstance(nombreCompeticion))
                    true
                }

                R.id.nav_estadisticas -> {
                    loadFragment(EstadisticasFragmentKarting.newInstance(nombreCompeticion))
                    true
                }

                else -> false
            }
        }

        // Fragmento inicial
        binding.bottomNavigation.selectedItemId = R.id.nav_clasificacion
    }

    private fun loadFragment(fragment: Fragment) {
        supportFragmentManager.beginTransaction()
            .replace(R.id.fragmentContainer, fragment)
            .commit()
    }
}