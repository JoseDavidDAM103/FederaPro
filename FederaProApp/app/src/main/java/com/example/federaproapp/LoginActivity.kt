package com.example.federaproapp


import android.content.Intent
import android.os.Bundle
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.example.federaproapp.api.LoginClient
import com.example.federaproapp.basket.SeleccionCompeticionActivity
import com.example.federaproapp.data.LoginRequest
import com.example.federaproapp.data.UsuarioDTO
import com.example.federaproapp.databinding.ActivityLoginBinding
import retrofit2.Call

class LoginActivity : AppCompatActivity() {

    private lateinit var binding: ActivityLoginBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityLoginBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.btnLogin.setOnClickListener {
            val usuario = binding.etUsuario.text.toString().trim()
            val contrasena = binding.etContrasena.text.toString().trim()

            if (usuario.isEmpty() || contrasena.isEmpty()) {
                Toast.makeText(this, "Por favor completa todos los campos", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }

            val loginRequest = LoginRequest(usuario, contrasena)

            LoginClient.instance.login(loginRequest).enqueue(object : retrofit2.Callback<UsuarioDTO> {
                override fun onResponse(call: Call<UsuarioDTO>, response: retrofit2.Response<UsuarioDTO>) {
                    if (response.isSuccessful && response.body() != null) {
                        val intent = Intent(this@LoginActivity, SeleccionCompeticionActivity::class.java)
                        intent.putExtra("usuario", response.body()!!.usuario)
                        startActivity(intent)
                        finish()
                    } else {
                        Toast.makeText(this@LoginActivity, "Credenciales incorrectas", Toast.LENGTH_SHORT).show()
                        binding.etContrasena.text?.clear()
                    }
                }

                override fun onFailure(call: Call<UsuarioDTO>, t: Throwable) {
                    Toast.makeText(this@LoginActivity, "Error de conexión: ${t.localizedMessage}", Toast.LENGTH_LONG).show()
                }
            })
        }

        binding.tvIrRegistro.setOnClickListener {
            startActivity(Intent(this, RegistroActivity::class.java))
        }
    }
}