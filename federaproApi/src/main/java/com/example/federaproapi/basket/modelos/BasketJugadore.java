package com.example.federaproapi.basket.modelos;

import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.Getter;
import lombok.Setter;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import java.math.BigDecimal;
import java.time.LocalDate;
import java.util.LinkedHashSet;
import java.util.Set;

@Getter
@Setter
@Entity
@Table(name = "basket_jugadores")
public class BasketJugadore {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_jugador", nullable = false)
    private Integer id;

    @JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "id_equipo", nullable = false)
    private BasketEquipo equipo;

    @Size(max = 100)
    @NotNull
    @Column(name = "nombre", nullable = false, length = 100)
    private String nombre;

    @Column(name = "altura")
    private double altura;

    @Column(name = "peso")
    private double peso;


    @Column(name = "fecha_nacimiento")
    private LocalDate fechaNacimiento;


    @Size(max = 100)
    @Column(name = "posicion")
    private String posicion;

    @Column(name = "dorsal")
    private Integer dorsal;

    @OneToMany(mappedBy = "idJugador")
    @JsonIgnore
    private Set<BasketEstadisticasJugador> basketEstadisticasJugadors = new LinkedHashSet<>();

}