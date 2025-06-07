package com.example.federaproapi.karting.modelos;

import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import lombok.Getter;
import lombok.Setter;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import java.math.BigDecimal;

@Getter
@Setter
@Entity
@Table(name = "karting_estadisticas_piloto")
public class KartingEstadisticasPiloto {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_estadistica", nullable = false)
    private Integer id;

    @NotNull
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JoinColumn(name = "id_carrera", nullable = false)
    private KartingCarrera idCarrera;

    @Column(name = "posicion")
    private Integer posicion;

    @Column(name = "tiempo_total", precision = 10, scale = 2)
    private BigDecimal tiempoTotal;

    @Column(name = "vueltas")
    private Integer vueltas;

    @NotNull
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JoinColumn(name = "id_piloto", nullable = false)
    private KartingPiloto idPiloto;

}