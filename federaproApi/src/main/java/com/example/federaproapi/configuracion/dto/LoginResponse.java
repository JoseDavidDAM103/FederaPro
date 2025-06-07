package com.example.federaproapi.configuracion.dto;

import com.example.federaproapi.configuracion.modelos.Usuario;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class LoginResponse {
    private Integer idUsuario;
    private String nombre;
    private String correo;
    private String rol;
    private Integer idDeporte;
    private String nombreDeporte;

    public LoginResponse(Usuario u) {
        this.idUsuario = u.getId();
        this.nombre = u.getNombre();
        this.correo = u.getCorreo();
        this.rol = u.getRol().toString();
        this.idDeporte = u.getDeporte().getId();
        this.nombreDeporte = u.getDeporte().getNombre();
    }
}