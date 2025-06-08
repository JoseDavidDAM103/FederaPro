package com.example.federaproapi.karting.modelos;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import lombok.Getter;
import lombok.Setter;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import java.time.Instant;
import java.util.LinkedHashSet;
import java.util.Set;

@Getter
@Setter
@Entity
@Table(name = "karting_carreras")
public class KartingCarrera {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_carrera", nullable = false)
    private Integer id;

    @NotNull
    @Column(name = "fecha", nullable = false)
    private Instant fecha;

    @NotNull
    @JsonIgnore
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JoinColumn(name = "id_competicion", nullable = false)
    private KartingCompeticione idCompeticion;

    @NotNull
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JoinColumn(name = "id_circuito", nullable = false)
    private KartingCircuito idCircuito;

    @JsonIgnore
    @OneToMany(mappedBy = "idCarrera")
    private Set<KartingEstadisticasEquipo> kartingEstadisticasEquipos = new LinkedHashSet<>();

    @JsonIgnore
    @OneToMany(mappedBy = "idCarrera")
    private Set<KartingEstadisticasPiloto> kartingEstadisticasPilotos = new LinkedHashSet<>();

}