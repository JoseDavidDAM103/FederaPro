package com.example.federaproapp


import android.content.Intent
import android.os.Bundle
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.example.federaproapp.api.LoginClient
import com.example.federaproapp.basket.SeleccionCompeticionActivity
import com.example.federaproapp.data.LoginRequest
import com.example.federaproapp.data.LoginResponse
import com.example.federaproapp.data.UsuarioDTO
import com.example.federaproapp.databinding.ActivityLoginBinding
import com.example.federaproapp.karting.SeleccionCompeticionKartingActivity
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class LoginActivity : AppCompatActivity() {

    private lateinit var binding: ActivityLoginBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityLoginBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.btnLogin.setOnClickListener {
            val correo = binding.etUsuario.text.toString().trim()
            val contraseña = binding.etContrasena.text.toString().trim()

            if (correo.isEmpty() || contraseña.isEmpty()) {
                Toast.makeText(this, "Por favor completa todos los campos", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }

            val loginRequest = LoginRequest(correo, contraseña)

            LoginClient.instance.login(loginRequest).enqueue(object : Callback<LoginResponse> {
                override fun onResponse(call: Call<LoginResponse>, response: Response<LoginResponse>) {
                    if (response.isSuccessful && response.body() != null) {
                        val user = response.body()!!

                        val intent = if (user.nombreDeporte.equals("baloncesto", ignoreCase = true)) {
                            Intent(this@LoginActivity, SeleccionCompeticionActivity::class.java)
                        } else {
                            Intent(this@LoginActivity, SeleccionCompeticionKartingActivity::class.java)
                        }

                        intent.putExtra("idUsuario", user.idUsuario)
                        intent.putExtra("nombre", user.nombre)
                        intent.putExtra("rol", user.rol)
                        intent.putExtra("idDeporte", user.idDeporte)
                        intent.putExtra("nombreDeporte", user.nombreDeporte)

                        startActivity(intent)
                        finish()
                    } else {
                        Toast.makeText(this@LoginActivity, "Credenciales incorrectas", Toast.LENGTH_SHORT).show()
                        binding.etContrasena.text?.clear()
                    }
                }

                override fun onFailure(call: Call<LoginResponse>, t: Throwable) {
                    Toast.makeText(this@LoginActivity, "Error de conexión: ${t.localizedMessage}", Toast.LENGTH_LONG).show()
                }
            })
        }

        binding.tvIrRegistro.setOnClickListener {
            startActivity(Intent(this, RegistroActivity::class.java))
        }
    }
}