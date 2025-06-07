package com.example.federaproapp


import android.content.Intent
import android.os.Bundle
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.example.federaproapp.databinding.ActivityLoginBinding

class LoginActivity : AppCompatActivity() {

    private lateinit var binding: ActivityLoginBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityLoginBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.btnLogin.setOnClickListener {
            val usuario = binding.etUsuario.text.toString()
            val contrasena = binding.etContrasena.text.toString()

            if (usuario == "admin" && contrasena == "admin123") {
                val intent = Intent(this, SeleccionCompeticionActivity::class.java)
                startActivity(intent)
                finish()  // para que no se pueda volver con el botón atrás
            } else {
                Toast.makeText(this, "Usuario o contraseña incorrectos", Toast.LENGTH_SHORT).show()
                binding.etContrasena.text?.clear()
            }
        }
        binding.tvIrRegistro.setOnClickListener {
            startActivity(Intent(this, RegistroActivity::class.java))
        }
    }
}