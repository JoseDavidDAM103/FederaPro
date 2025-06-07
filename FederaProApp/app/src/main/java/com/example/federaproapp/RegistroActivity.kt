package com.example.federaproapp

import android.content.Intent
import android.os.Bundle
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.example.federaproapp.databinding.ActivityRegistroBinding

class RegistroActivity : AppCompatActivity() {

    private lateinit var binding: ActivityRegistroBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityRegistroBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.btnRegistrar.setOnClickListener {
            val nombre = binding.etNombreCompleto.text.toString()
            val correo = binding.etCorreo.text.toString()
            val usuario = binding.etNuevoUsuario.text.toString()
            val contrasena = binding.etNuevaContrasena.text.toString()

            if (nombre.isBlank() || correo.isBlank() || usuario.isBlank() || contrasena.isBlank()) {
                Toast.makeText(this, "Por favor completa todos los campos", Toast.LENGTH_SHORT).show()
            } else {
                // Simular registro exitoso
                Toast.makeText(this, "¡Registro exitoso, bienvenido $nombre!", Toast.LENGTH_SHORT).show()
                startActivity(Intent(this, SeleccionCompeticionActivity::class.java))
                finish()
            }
        }
    }
}