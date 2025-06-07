package com.example.federaproapi.basket.modelos;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import lombok.Getter;
import lombok.Setter;
import org.hibernate.annotations.ColumnDefault;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import java.time.Instant;
import java.time.LocalDate;
import java.util.LinkedHashSet;
import java.util.Set;

@Getter
@Setter
@Entity
@Table(name = "basket_partidos")
public class BasketPartido {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_partido", nullable = false)
    private Integer id;

    @NotNull
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JoinColumn(name = "id_competicion", nullable = false)
    private BasketCompeticione idCompeticion;

    @NotNull
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JoinColumn(name = "equipo_local", nullable = false)
    private BasketEquipo equipoLocal;

    @NotNull
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JoinColumn(name = "equipo_visitante", nullable = false)
    private BasketEquipo equipoVisitante;

    @NotNull
    @Column(name = "fecha", nullable = false)
    private LocalDate fecha;

    @ColumnDefault("0")
    @Column(name = "resultado_local")
    private Integer resultadoLocal;

    @ColumnDefault("0")
    @Column(name = "resultado_visitante")
    private Integer resultadoVisitante;

    @ManyToOne(fetch = FetchType.LAZY)
    @OnDelete(action = OnDeleteAction.SET_NULL)
    @JoinColumn(name = "id_arbitro")
    private BasketArbitro idArbitro;

    @JsonIgnore
    @OneToMany(mappedBy = "idPartido")
    private Set<BasketEstadisticasEquipo> basketEstadisticasEquipos = new LinkedHashSet<>();

    @JsonIgnore
    @OneToMany(mappedBy = "idPartido")
    private Set<BasketEstadisticasJugador> basketEstadisticasJugadors = new LinkedHashSet<>();

    @Column(nullable = false)
    private Integer jornada;

}