package com.example.federaproapi.basket.modelos;

import com.fasterxml.jackson.annotation.JsonIgnore;
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
@Table(name = "basket_competiciones")
public class BasketCompeticione {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_competicion", nullable = false)
    private Integer id;

    @Size(max = 100)
    @NotNull
    @Column(name = "nombre", nullable = false, length = 100)
    private String nombre;

    @Lob
    @Column(name = "tipo")
    private String tipo;

    @OneToMany(mappedBy = "idCompeticion")
    @JsonIgnore
    private Set<BasketPartido> basketPartidos = new LinkedHashSet<>();

    @JsonIgnore
    @ManyToMany
    @JoinTable(
            name = "basket_equipos_competiciones",
            joinColumns = @JoinColumn(name = "id_competicion"),
            inverseJoinColumns = @JoinColumn(name = "id_equipo")
    )
    private Set<BasketEquipo> equipos;
}