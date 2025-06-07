package com.example.federaproapi.karting.modelos;

import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import lombok.Getter;
import lombok.Setter;
import org.hibernate.annotations.ColumnDefault;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import java.math.BigDecimal;

@Getter
@Setter
@Entity
@Table(name = "karting_estadisticas_equipo")
public class KartingEstadisticasEquipo {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_estadistica", nullable = false)
    private Integer id;

    @NotNull
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JoinColumn(name = "id_carrera", nullable = false)
    private KartingCarrera idCarrera;

    @NotNull
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JoinColumn(name = "id_equipo", nullable = false)
    private KartingEquipo idEquipo;

    @Column(name = "tiempo_promedio", precision = 10, scale = 2)
    private BigDecimal tiempoPromedio;

    @ColumnDefault("0")
    @Column(name = "puntos")
    private Integer puntos;

}