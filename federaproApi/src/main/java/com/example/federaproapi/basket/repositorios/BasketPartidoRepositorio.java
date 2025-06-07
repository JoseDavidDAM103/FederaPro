package com.example.federaproapi.basket.repositorios;

import com.example.federaproapi.basket.modelos.BasketCompeticione;
import com.example.federaproapi.basket.modelos.BasketPartido;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface BasketPartidoRepositorio extends JpaRepository<BasketPartido, Integer> {

    List<BasketPartido> findByEquipoLocal_IdOrEquipoVisitante_Id(Integer idEquipoLocal, Integer idEquipoVisitante);

    List<BasketPartido> findByIdCompeticion(BasketCompeticione idCompeticion);

}