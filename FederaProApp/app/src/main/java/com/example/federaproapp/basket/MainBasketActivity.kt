package com.example.federaproapp.basket

import android.content.Intent
import android.os.Bundle
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.fragment.app.Fragment
import com.example.federaproapp.R
import com.example.federaproapp.basket.fragments.ClasificacionFragment
import com.example.federaproapp.basket.fragments.PartidosFragment
import com.example.federaproapp.basket.fragments.EstadisticasFragment
import com.google.android.material.bottomnavigation.BottomNavigationView

class MainBasketActivity : AppCompatActivity() {

    private var competicionId: Int = -1
    private var competicionNombre: String? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        // Obtener datos de la competición seleccionada
        competicionId = intent.getIntExtra("competicionId", -1)
        competicionNombre = intent.getStringExtra("competicionNombre")

        if (competicionId == -1 || competicionNombre == null) {
            Toast.makeText(this, "No se recibió una competición válida", Toast.LENGTH_SHORT).show()
            finish()
            return
        }

        val navView = findViewById<BottomNavigationView>(R.id.bottomNavigationView)

        navView.setOnItemSelectedListener {
            when (it.itemId) {
                R.id.nav_clasificacion -> loadFragment(ClasificacionFragment())
                R.id.nav_partidos -> loadFragment(PartidosFragment())
                R.id.nav_estadisticas -> loadFragment(EstadisticasFragment())
                else -> false
            }
        }

        // Cargar el primer fragmento por defecto
        loadFragment(ClasificacionFragment())
    }

    private fun loadFragment(fragment: Fragment): Boolean {
        val args = Bundle().apply {
            putInt("competicionId", competicionId)
            putString("competicionNombre", competicionNombre)
        }
        fragment.arguments = args

        supportFragmentManager.beginTransaction()
            .replace(R.id.fragment_container, fragment)
            .commit()
        return true
    }
    override fun onBackPressed() {
        val fm = supportFragmentManager
        if (fm.backStackEntryCount > 0) {
            fm.popBackStack()
        } else {
            // Si no hay historial, volver a selección
            val intent = Intent(this, SeleccionCompeticionActivity::class.java)
            startActivity(intent)
            finish()
        }
    }
}