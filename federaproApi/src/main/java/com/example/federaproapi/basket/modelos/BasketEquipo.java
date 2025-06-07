package com.example.federaproapi.basket.modelos;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonManagedReference;
import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.Getter;
import lombok.Setter;

import java.util.ArrayList;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

@Getter
@Setter
@Entity
@Table(name = "basket_equipos")
public class BasketEquipo {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_equipo", nullable = false)
    private Integer id;

    @Size(max = 100)
    @NotNull
    @Column(name = "nombre", nullable = false, length = 100)
    private String nombre;

    @Size(max = 100)
    @Column(name = "ciudad", length = 100)
    private String ciudad;

    @Column(name = "fundacion")
    private Integer fundacion;

    @Size(max = 100)
    @Column(name = "estadio", length = 100)
    private String estadio;

    @OneToMany(mappedBy = "idEquipo")
    private Set<BasketEntrenadore> basketEntrenadores = new LinkedHashSet<>();

    @OneToMany(mappedBy = "idEquipo")
    private Set<BasketEstadisticasEquipo> basketEstadisticasEquipos = new LinkedHashSet<>();

    @OneToMany(mappedBy = "equipo", cascade = CascadeType.ALL, orphanRemoval = true)
    @JsonIgnore
    private List<BasketJugadore> basketJugadores = new ArrayList<>();

    @OneToMany(mappedBy = "equipoLocal")
    @JsonIgnore
    private Set<BasketPartido> basketPartidosLoc = new LinkedHashSet<>();

    @OneToMany(mappedBy = "equipoVisitante")
    @JsonIgnore
    private Set<BasketPartido> basketPartidosVis = new LinkedHashSet<>();

    @ManyToMany
    @JoinTable(
            name = "basket_equipos_competiciones",
            joinColumns = @JoinColumn(name = "id_equipo"),
            inverseJoinColumns = @JoinColumn(name = "id_competicion")
    )
    @JsonIgnore
    private Set<BasketCompeticione> basketCompeticiones = new LinkedHashSet<>();

}