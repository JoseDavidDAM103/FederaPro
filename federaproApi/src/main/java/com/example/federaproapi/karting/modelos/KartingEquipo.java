package com.example.federaproapi.karting.modelos;

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
@Table(name = "karting_equipos")
public class KartingEquipo {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_equipo", nullable = false)
    private Integer id;

    @Size(max = 100)
    @NotNull
    @Column(name = "nombre", nullable = false, length = 100)
    private String nombre;

    @Size(max = 100)
    @Column(name = "pais", length = 100)
    private String pais;

    @Size(max = 100)
    @Column(name = "sponsor", length = 100)
    private String sponsor;

    @JsonIgnore
    @OneToMany(mappedBy = "idEquipo")
    private Set<KartingEstadisticasEquipo> kartingEstadisticasEquipos = new LinkedHashSet<>();

    @JsonIgnore
    @OneToMany(mappedBy = "idEquipo")
    private Set<KartingPiloto> kartingPilotos = new LinkedHashSet<>();

}