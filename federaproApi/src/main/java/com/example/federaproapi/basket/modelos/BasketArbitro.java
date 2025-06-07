package com.example.federaproapi.basket.modelos;

import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.Getter;
import lombok.Setter;

import java.util.LinkedHashSet;
import java.util.Set;

@Getter
@Setter
@Entity
@Table(name = "basket_arbitros")
public class BasketArbitro {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_arbitro", nullable = false)
    private Integer id;

    @Size(max = 100)
    @NotNull
    @Column(name = "nombre", nullable = false, length = 100)
    private String nombre;

    @Column(name = "experiencia")
    private Integer experiencia;

    @OneToMany(mappedBy = "idArbitro")
    private Set<BasketPartido> basketPartidos = new LinkedHashSet<>();

}