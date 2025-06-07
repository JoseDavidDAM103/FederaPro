package com.example.federaproapi.configuracion.controladores;

import com.example.federaproapi.configuracion.dto.LoginRequest;
import com.example.federaproapi.configuracion.dto.LoginResponse;
import com.example.federaproapi.configuracion.dto.UsuarioRegistroRequest;
import com.example.federaproapi.configuracion.modelos.Deporte;
import com.example.federaproapi.configuracion.modelos.Usuario;
import com.example.federaproapi.configuracion.servicios.ConfiguracionTablaService;
import com.example.federaproapi.configuracion.servicios.UsuarioService;
import com.example.federaproapi.utils.enums.Rol;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/usuarios")
public class UsuarioController {

    private final UsuarioService usuarioService;
    private final ConfiguracionTablaService configuracionTablaService;

    public UsuarioController(UsuarioService usuarioService, ConfiguracionTablaService configuracionTablaService) {
        this.usuarioService = usuarioService;
        this.configuracionTablaService = configuracionTablaService;
    }

    @GetMapping("/{id}")
    public ResponseEntity<Usuario> obtenerPorId(@PathVariable Integer id) {
        return ResponseEntity.of(usuarioService.obtenerPorId(id));
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> eliminar(@PathVariable Integer id) {
        usuarioService.eliminar(id);
        return ResponseEntity.noContent().build();
    }

    @PostMapping("/login")
    public ResponseEntity<?> login(@RequestBody LoginRequest request) {
        System.out.println("Correo recibido: " + request.getCorreo());
        System.out.println("Contraseña recibida: " + request.getContraseña());

        return usuarioService.obtenerPorCorreo(request.getCorreo())
                .map(u -> {
                    System.out.println("Usuario encontrado: " + u.getCorreo());
                    System.out.println("Contraseña en BD: " + u.getContraseña());
                    if (u.getContraseña().equals(request.getContraseña())) {
                        System.out.println("Contraseña válida");
                        return ResponseEntity.ok(new LoginResponse(u));
                    } else {
                        System.out.println("Contraseña incorrecta");
                        return ResponseEntity.status(401).build();
                    }
                })
                .orElseGet(() -> {
                    System.out.println("Usuario no encontrado");
                    return ResponseEntity.status(401).build();
                });
    }

    @GetMapping("/existe")
    public ResponseEntity<Boolean> existeCorreo(@RequestParam String correo) {
        boolean existe = usuarioService.existePorCorreo(correo);
        return ResponseEntity.ok(existe);
    }

    @PostMapping
    public ResponseEntity<?> registrar(@RequestBody UsuarioRegistroRequest request) {
        if (usuarioService.existePorCorreo(request.correo)) {
            return ResponseEntity.status(HttpStatus.CONFLICT).body("Ya existe un usuario con ese correo");
        }

        Deporte deporte = new Deporte();
        deporte.setId(request.idDeporte);

        Usuario usuario = new Usuario();
        usuario.setNombre(request.nombre);
        usuario.setCorreo(request.correo);
        usuario.setContraseña(request.contraseña);
        usuario.setRol(Rol.valueOf(request.rol));
        usuario.setDeporte(deporte);

        Usuario creado = usuarioService.guardar(usuario);

        if (usuario.getRol() == Rol.admin) {
            configuracionTablaService.generarTablas(deporte);
        }

        return ResponseEntity.status(HttpStatus.CREATED).body(creado);
    }
}
