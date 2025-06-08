package com.example.federaproapi.karting.modelos;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.Getter;
import lombok.Setter;

import java.time.LocalDate;
import java.util.LinkedHashSet;
import java.util.Set;

@Getter
@Setter
@Entity
@Table(name = "karting_competiciones")
public class KartingCompeticione {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_competicion", nullable = false)
    private Integer id;

    @Size(max = 100)
    @NotNull
    @Column(name = "nombre", nullable = false, length = 100)
    private String nombre;

    @NotNull
    @Lob
    @Column(name = "categoria", nullable = false)
    private String categoria;

    @Lob
    @Column(name = "tipo")
    private String tipo;

    @Column(name = "fecha_inicio")
    private LocalDate fechaInicio;

    @Column(name = "fecha_fin")
    private LocalDate fechaFin;

    @JsonIgnore
    @OneToMany(mappedBy = "idCompeticion")
    private Set<KartingCarrera> kartingCarreras = new LinkedHashSet<>();

    @ManyToMany
    @JoinTable(
            name = "karting_competiciones_equipos",
            joinColumns = @JoinColumn(name = "id_competicion"),
            inverseJoinColumns = @JoinColumn(name = "id_equipo")
    )
    private Set<KartingEquipo> equipos = new LinkedHashSet<>();
}