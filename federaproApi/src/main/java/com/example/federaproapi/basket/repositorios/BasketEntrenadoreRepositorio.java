package com.example.federaproapi.basket.repositorios;

import com.example.federaproapi.basket.modelos.BasketEntrenadore;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface BasketEntrenadoreRepositorio extends JpaRepository<BasketEntrenadore, Integer> {
}
