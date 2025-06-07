package com.example.federaproapi.basket.modelos;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import lombok.Getter;
import lombok.Setter;
import org.hibernate.annotations.ColumnDefault;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

@Getter
@Setter
@Entity
@Table(name = "basket_estadisticas_equipo")
public class BasketEstadisticasEquipo {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_estadistica", nullable = false)
    private Integer id;

    @NotNull
    @JsonIgnore
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JoinColumn(name = "id_equipo", nullable = false)
    private BasketEquipo idEquipo;

    @ColumnDefault("0")
    @Column(name = "puntos")
    private Integer puntos;

    @ColumnDefault("0")
    @Column(name = "rebotes")
    private Integer rebotes;

    @ColumnDefault("0")
    @Column(name = "asistencias")
    private Integer asistencias;

    @ColumnDefault("0")
    @Column(name = "robos")
    private Integer robos;

    @ColumnDefault("0")
    @Column(name = "tapones")
    private Integer tapones;

    @ColumnDefault("0")
    @Column(name = "perdidas")
    private Integer perdidas;

    @NotNull
    @JsonIgnore
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JoinColumn(name = "id_partido", nullable = false)
    private BasketPartido idPartido;

}