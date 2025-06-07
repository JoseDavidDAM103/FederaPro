package com.example.federaproapi.karting.modelos;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.Getter;
import lombok.Setter;

import java.math.BigDecimal;
import java.util.LinkedHashSet;
import java.util.Set;

@Getter
@Setter
@Entity
@Table(name = "karting_circuitos")
public class KartingCircuito {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_circuito", nullable = false)
    private Integer id;

    @Size(max = 100)
    @NotNull
    @Column(name = "nombre", nullable = false, length = 100)
    private String nombre;

    @Size(max = 100)
    @Column(name = "ubicacion", length = 100)
    private String ubicacion;

    @Column(name = "longitud", precision = 5, scale = 2)
    private BigDecimal longitud;

    @Size(max = 50)
    @Column(name = "pais", length = 50)
    private String pais;

    @JsonIgnore
    @OneToMany(mappedBy = "idCircuito")
    private Set<KartingCarrera> kartingCarreras = new LinkedHashSet<>();

}