package com.example.federaproapi.configuracion.modelos;

import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import lombok.Getter;
import lombok.Setter;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

@Getter
@Setter
@Entity
@Table(name = "configuraciontablas")
public class Configuraciontabla {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_config", nullable = false)
    private Integer id;

    @NotNull
    @Lob
    @Column(name = "consulta_creacion", nullable = false, columnDefinition = "LONGTEXT")
    private String consultaCreacion;

    @NotNull
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JoinColumn(name = "id_deporte", nullable = false)
    private Deporte idDeporte;

}