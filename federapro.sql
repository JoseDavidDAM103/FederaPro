-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: federapro
-- ------------------------------------------------------
-- Server version	8.3.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `basket_arbitros`
--

DROP TABLE IF EXISTS `basket_arbitros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `basket_arbitros` (
  `id_arbitro` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `experiencia` int DEFAULT NULL,
  PRIMARY KEY (`id_arbitro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basket_arbitros`
--

LOCK TABLES `basket_arbitros` WRITE;
/*!40000 ALTER TABLE `basket_arbitros` DISABLE KEYS */;
/*!40000 ALTER TABLE `basket_arbitros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `basket_competiciones`
--

DROP TABLE IF EXISTS `basket_competiciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `basket_competiciones` (
  `id_competicion` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `tipo` tinytext,
  PRIMARY KEY (`id_competicion`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basket_competiciones`
--

LOCK TABLES `basket_competiciones` WRITE;
/*!40000 ALTER TABLE `basket_competiciones` DISABLE KEYS */;
INSERT INTO `basket_competiciones` VALUES (8,'Liga ACB','Liga'),(9,'Liga Endesa','Liga'),(10,'Liga de Verano','Liga');
/*!40000 ALTER TABLE `basket_competiciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `basket_entrenadores`
--

DROP TABLE IF EXISTS `basket_entrenadores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `basket_entrenadores` (
  `id_entrenador` int NOT NULL AUTO_INCREMENT,
  `id_equipo` int NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `experiencia` int DEFAULT NULL,
  PRIMARY KEY (`id_entrenador`),
  KEY `id_equipo` (`id_equipo`),
  CONSTRAINT `basket_entrenadores_ibfk_1` FOREIGN KEY (`id_equipo`) REFERENCES `basket_equipos` (`id_equipo`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basket_entrenadores`
--

LOCK TABLES `basket_entrenadores` WRITE;
/*!40000 ALTER TABLE `basket_entrenadores` DISABLE KEYS */;
/*!40000 ALTER TABLE `basket_entrenadores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `basket_equipos`
--

DROP TABLE IF EXISTS `basket_equipos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `basket_equipos` (
  `id_equipo` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `ciudad` varchar(100) DEFAULT NULL,
  `fundacion` int DEFAULT NULL,
  `estadio` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_equipo`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basket_equipos`
--

LOCK TABLES `basket_equipos` WRITE;
/*!40000 ALTER TABLE `basket_equipos` DISABLE KEYS */;
INSERT INTO `basket_equipos` VALUES (1,'Real Madrid','Madrid',1912,'Bernabeu'),(2,'Unicaja','Bilbao',1950,'Vasconia'),(3,'Barcelona','Barcelona',1915,'Palau'),(47,'Basket León','León',1970,'Palacio de Deportes León'),(48,'Murciélagos Basket','Murcia',1985,'Pabellón del Sureste'),(49,'CB Huesca','Huesca',1992,'Pabellón Príncipe Felipe');
/*!40000 ALTER TABLE `basket_equipos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `basket_equipos_competiciones`
--

DROP TABLE IF EXISTS `basket_equipos_competiciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `basket_equipos_competiciones` (
  `id_equipo` int NOT NULL,
  `id_competicion` int NOT NULL,
  PRIMARY KEY (`id_equipo`,`id_competicion`),
  KEY `id_competicion` (`id_competicion`),
  CONSTRAINT `basket_equipos_competiciones_ibfk_1` FOREIGN KEY (`id_equipo`) REFERENCES `basket_equipos` (`id_equipo`),
  CONSTRAINT `basket_equipos_competiciones_ibfk_2` FOREIGN KEY (`id_competicion`) REFERENCES `basket_competiciones` (`id_competicion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basket_equipos_competiciones`
--

LOCK TABLES `basket_equipos_competiciones` WRITE;
/*!40000 ALTER TABLE `basket_equipos_competiciones` DISABLE KEYS */;
INSERT INTO `basket_equipos_competiciones` VALUES (1,8),(2,8),(3,8),(47,8),(48,8),(49,8),(1,9),(2,9),(3,9),(47,9),(48,9),(49,9),(1,10),(2,10),(3,10),(47,10),(48,10),(49,10);
/*!40000 ALTER TABLE `basket_equipos_competiciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `basket_estadisticas_equipo`
--

DROP TABLE IF EXISTS `basket_estadisticas_equipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `basket_estadisticas_equipo` (
  `id_estadistica` int NOT NULL AUTO_INCREMENT,
  `id_partido` int NOT NULL,
  `id_equipo` int NOT NULL,
  `puntos` int DEFAULT '0',
  `rebotes` int DEFAULT '0',
  `asistencias` int DEFAULT '0',
  `robos` int DEFAULT '0',
  `tapones` int DEFAULT '0',
  `perdidas` int DEFAULT '0',
  PRIMARY KEY (`id_estadistica`),
  KEY `id_partido` (`id_partido`),
  KEY `id_equipo` (`id_equipo`),
  CONSTRAINT `basket_estadisticas_equipo_ibfk_1` FOREIGN KEY (`id_partido`) REFERENCES `basket_partidos` (`id_partido`) ON DELETE CASCADE,
  CONSTRAINT `basket_estadisticas_equipo_ibfk_2` FOREIGN KEY (`id_equipo`) REFERENCES `basket_equipos` (`id_equipo`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basket_estadisticas_equipo`
--

LOCK TABLES `basket_estadisticas_equipo` WRITE;
/*!40000 ALTER TABLE `basket_estadisticas_equipo` DISABLE KEYS */;
INSERT INTO `basket_estadisticas_equipo` VALUES (3,34,1,100,20,30,4,2,15),(4,34,47,80,12,8,10,2,20);
/*!40000 ALTER TABLE `basket_estadisticas_equipo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `basket_estadisticas_jugador`
--

DROP TABLE IF EXISTS `basket_estadisticas_jugador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `basket_estadisticas_jugador` (
  `id_estadistica` int NOT NULL AUTO_INCREMENT,
  `id_partido` int NOT NULL,
  `id_jugador` int NOT NULL,
  `puntos` int DEFAULT '0',
  `rebotes` int DEFAULT '0',
  `asistencias` int DEFAULT '0',
  `robos` int DEFAULT '0',
  `tapones` int DEFAULT '0',
  `perdidas` int DEFAULT '0',
  `minutos` decimal(4,2) DEFAULT '0.00',
  PRIMARY KEY (`id_estadistica`),
  KEY `id_partido` (`id_partido`),
  KEY `id_jugador` (`id_jugador`),
  CONSTRAINT `basket_estadisticas_jugador_ibfk_1` FOREIGN KEY (`id_partido`) REFERENCES `basket_partidos` (`id_partido`) ON DELETE CASCADE,
  CONSTRAINT `basket_estadisticas_jugador_ibfk_2` FOREIGN KEY (`id_jugador`) REFERENCES `basket_jugadores` (`id_jugador`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=73 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basket_estadisticas_jugador`
--

LOCK TABLES `basket_estadisticas_jugador` WRITE;
/*!40000 ALTER TABLE `basket_estadisticas_jugador` DISABLE KEYS */;
INSERT INTO `basket_estadisticas_jugador` VALUES (64,34,2,2,23,3,3,5,4,NULL),(65,34,3,3,3,5,4,5,7,NULL),(66,34,4,8,3,2,2,1,0,NULL),(67,34,5,10,2,2,3,5,4,NULL),(68,34,6,20,2,2,3,4,5,NULL),(69,34,7,3,5,7,8,3,0,NULL),(70,34,8,1,5,7,3,1,5,NULL),(71,34,9,1,1,2,3,1,5,NULL),(72,34,10,0,0,0,0,0,0,NULL);
/*!40000 ALTER TABLE `basket_estadisticas_jugador` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `basket_jugador_competicion`
--

DROP TABLE IF EXISTS `basket_jugador_competicion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `basket_jugador_competicion` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_jugador` int NOT NULL,
  `id_competicion` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_jugador` (`id_jugador`),
  KEY `id_competicion` (`id_competicion`),
  CONSTRAINT `basket_jugador_competicion_ibfk_1` FOREIGN KEY (`id_jugador`) REFERENCES `basket_jugadores` (`id_jugador`),
  CONSTRAINT `basket_jugador_competicion_ibfk_2` FOREIGN KEY (`id_competicion`) REFERENCES `basket_competiciones` (`id_competicion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basket_jugador_competicion`
--

LOCK TABLES `basket_jugador_competicion` WRITE;
/*!40000 ALTER TABLE `basket_jugador_competicion` DISABLE KEYS */;
/*!40000 ALTER TABLE `basket_jugador_competicion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `basket_jugadores`
--

DROP TABLE IF EXISTS `basket_jugadores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `basket_jugadores` (
  `id_jugador` int NOT NULL AUTO_INCREMENT,
  `id_equipo` int NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `altura` decimal(3,2) DEFAULT NULL,
  `peso` decimal(5,2) DEFAULT NULL,
  `posicion` tinytext,
  `dorsal` int DEFAULT NULL,
  `fecha_nacimiento` date DEFAULT NULL,
  PRIMARY KEY (`id_jugador`),
  KEY `id_equipo` (`id_equipo`),
  CONSTRAINT `basket_jugadores_ibfk_1` FOREIGN KEY (`id_equipo`) REFERENCES `basket_equipos` (`id_equipo`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basket_jugadores`
--

LOCK TABLES `basket_jugadores` WRITE;
/*!40000 ALTER TABLE `basket_jugadores` DISABLE KEYS */;
INSERT INTO `basket_jugadores` VALUES (1,1,'Carlos Gómez',1.92,85.00,'Escolta',7,NULL),(2,1,'Andr�s L�pez',2.01,95.50,'Ala-P�vot',12,NULL),(3,1,'David Navarro',1.88,82.00,'Base',4,NULL),(4,1,'Fernando Ruiz',2.06,102.30,'P�vot',15,NULL),(5,1,'Luis Ram�rez',1.95,88.70,'Alero',9,NULL),(6,1,'Miguel Torres',1.90,86.50,'Escolta',11,NULL),(7,1,'�scar Delgado',2.03,98.20,'Ala-P�vot',10,NULL),(8,1,'Iv�n S�nchez',1.85,80.00,'Base',5,NULL),(9,1,'Javier Romero',2.08,106.00,'P�vot',13,NULL),(10,1,'Pablo M�rquez',1.97,90.00,'Alero',6,NULL),(11,2,'Juan Alberto',1.92,85.00,'Escolta',7,NULL),(12,2,'David Alonso',2.01,95.50,'Ala-P�vot',12,NULL),(13,2,'Juan Rodriguez',1.88,82.00,'Base',4,NULL),(14,2,'Antionio P�rez',2.06,102.30,'P�vot',15,NULL),(15,2,'Gonzalo Ramos',1.95,88.70,'Alero',9,NULL),(16,2,'Felipe Scola',1.90,86.50,'Escolta',11,NULL),(17,2,'Pablo P�rez',2.03,98.20,'Ala-P�vot',10,NULL),(18,2,'Iv�n Ruiz',1.85,80.00,'Base',5,NULL),(19,2,'Jos� Reina',2.08,106.00,'P�vot',13,NULL),(20,2,'Paulo Dom�nguez',1.97,90.00,'Alero',6,NULL),(21,48,'Juan Alberto',1.92,85.00,'Escolta',7,NULL),(22,48,'David Alonso',2.01,95.50,'Ala-P�vot',12,NULL),(23,48,'Juan Rodriguez',1.88,82.00,'Base',4,NULL),(24,48,'Antionio P�rez',2.06,102.30,'P�vot',15,NULL),(25,48,'Gonzalo Ramos',1.95,88.70,'Alero',9,NULL),(26,48,'Felipe Scola',1.90,86.50,'Escolta',11,NULL),(27,48,'Pablo P�rez',2.03,98.20,'Ala-P�vot',10,NULL),(28,48,'Iv�n Ruiz',1.85,80.00,'Base',5,NULL),(29,48,'Jos� Reina',2.08,106.00,'P�vot',13,NULL),(30,48,'Paulo Dom�nguez',1.97,90.00,'Alero',6,NULL),(31,49,'Juan Alberto',1.92,85.00,'Escolta',7,NULL),(32,49,'David Alonso',2.01,95.50,'Ala-P�vot',12,NULL),(33,49,'Juan Rodriguez',1.88,82.00,'Base',4,NULL),(34,49,'Antionio P�rez',2.06,102.30,'P�vot',15,NULL),(35,49,'Gonzalo Ramos',1.95,88.70,'Alero',9,NULL),(36,49,'Felipe Scola',1.90,86.50,'Escolta',11,NULL),(37,49,'Pablo P�rez',2.03,98.20,'Ala-P�vot',10,NULL),(38,49,'Iv�n Ruiz',1.85,80.00,'Base',5,NULL),(39,49,'Jos� Reina',2.08,106.00,'P�vot',13,NULL),(40,49,'Paulo Dom�nguez',1.97,90.00,'Alero',6,NULL),(41,3,'Juan Alberto',1.92,85.00,'Escolta',7,NULL),(42,3,'David Alonso',2.01,95.50,'Ala-Pívot',12,NULL),(43,3,'Juan Rodriguez',1.88,82.00,'Base',4,NULL),(44,3,'Antionio Pérez',2.06,102.30,'Pívot',15,NULL),(45,3,'Gonzalo Ramos',1.95,88.70,'Alero',9,NULL),(46,3,'Felipe Scola',1.90,86.50,'Escolta',11,NULL),(47,3,'Pablo Pérez',2.03,98.20,'Ala-Pívot',10,NULL),(48,3,'Iván Ruiz',1.85,80.00,'Base',5,NULL),(49,3,'José Reina',2.08,106.00,'Pívot',13,NULL),(50,3,'Paulo Domínguez',1.97,90.00,'Alero',6,NULL),(51,1,'Raúl Casas',1.75,68.00,'Escolta',7,NULL);
/*!40000 ALTER TABLE `basket_jugadores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `basket_partidos`
--

DROP TABLE IF EXISTS `basket_partidos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `basket_partidos` (
  `id_partido` int NOT NULL AUTO_INCREMENT,
  `id_competicion` int NOT NULL,
  `equipo_local` int NOT NULL,
  `equipo_visitante` int NOT NULL,
  `fecha` datetime NOT NULL,
  `resultado_local` int DEFAULT '0',
  `resultado_visitante` int DEFAULT '0',
  `id_arbitro` int DEFAULT NULL,
  `jornada` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`id_partido`),
  KEY `id_competicion` (`id_competicion`),
  KEY `equipo_local` (`equipo_local`),
  KEY `equipo_visitante` (`equipo_visitante`),
  KEY `id_arbitro` (`id_arbitro`),
  CONSTRAINT `basket_partidos_ibfk_1` FOREIGN KEY (`id_competicion`) REFERENCES `basket_competiciones` (`id_competicion`) ON DELETE CASCADE,
  CONSTRAINT `basket_partidos_ibfk_2` FOREIGN KEY (`equipo_local`) REFERENCES `basket_equipos` (`id_equipo`) ON DELETE CASCADE,
  CONSTRAINT `basket_partidos_ibfk_3` FOREIGN KEY (`equipo_visitante`) REFERENCES `basket_equipos` (`id_equipo`) ON DELETE CASCADE,
  CONSTRAINT `basket_partidos_ibfk_4` FOREIGN KEY (`id_arbitro`) REFERENCES `basket_arbitros` (`id_arbitro`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basket_partidos`
--

LOCK TABLES `basket_partidos` WRITE;
/*!40000 ALTER TABLE `basket_partidos` DISABLE KEYS */;
INSERT INTO `basket_partidos` VALUES (1,8,47,1,'2025-05-20 00:00:00',NULL,NULL,NULL,1),(2,8,47,48,'2025-05-20 00:00:00',NULL,NULL,NULL,2),(3,8,47,49,'2025-05-20 00:00:00',NULL,NULL,NULL,3),(4,8,47,3,'2025-05-20 00:00:00',NULL,NULL,NULL,4),(5,8,47,2,'2025-05-20 00:00:00',NULL,NULL,NULL,5),(6,8,1,48,'2025-05-20 00:00:00',NULL,NULL,NULL,6),(7,8,1,49,'2025-05-20 00:00:00',NULL,NULL,NULL,7),(8,8,1,3,'2025-05-20 00:00:00',NULL,NULL,NULL,8),(9,8,1,2,'2025-05-20 00:00:00',NULL,NULL,NULL,9),(10,8,48,49,'2025-05-20 00:00:00',NULL,NULL,NULL,10),(11,8,48,3,'2025-05-20 00:00:00',NULL,NULL,NULL,11),(12,8,48,2,'2025-05-20 00:00:00',NULL,NULL,NULL,12),(13,8,49,3,'2025-05-20 00:00:00',NULL,NULL,NULL,13),(14,8,49,2,'2025-05-20 00:00:00',NULL,NULL,NULL,14),(15,8,3,2,'2025-05-20 00:00:00',NULL,NULL,NULL,15),(16,9,1,48,'2025-05-20 00:00:00',NULL,NULL,NULL,1),(17,9,1,47,'2025-05-20 00:00:00',NULL,NULL,NULL,2),(18,9,1,2,'2025-05-20 00:00:00',NULL,NULL,NULL,3),(19,9,1,49,'2025-05-20 00:00:00',NULL,NULL,NULL,4),(20,9,1,3,'2025-05-20 00:00:00',NULL,NULL,NULL,5),(21,9,48,47,'2025-05-20 00:00:00',NULL,NULL,NULL,6),(22,9,48,2,'2025-05-20 00:00:00',NULL,NULL,NULL,7),(23,9,48,49,'2025-05-20 00:00:00',NULL,NULL,NULL,8),(24,9,48,3,'2025-05-20 00:00:00',NULL,NULL,NULL,9),(25,9,47,2,'2025-05-20 00:00:00',NULL,NULL,NULL,10),(26,9,47,49,'2025-05-20 00:00:00',NULL,NULL,NULL,11),(27,9,47,3,'2025-05-20 00:00:00',NULL,NULL,NULL,12),(28,9,2,49,'2025-05-20 00:00:00',NULL,NULL,NULL,13),(29,9,2,3,'2025-05-20 00:00:00',NULL,NULL,NULL,14),(30,9,49,3,'2025-05-20 00:00:00',NULL,NULL,NULL,15),(31,10,48,47,'2025-05-20 00:00:00',NULL,10,NULL,1),(32,10,1,3,'2025-05-20 00:00:00',NULL,5,NULL,1),(33,10,49,2,'2025-05-20 00:00:00',NULL,6,NULL,1),(34,10,1,47,'2025-05-27 00:00:00',100,80,NULL,2),(35,10,49,48,'2025-05-27 00:00:00',NULL,NULL,NULL,2),(36,10,2,3,'2025-05-27 00:00:00',NULL,NULL,NULL,2),(37,10,49,47,'2025-06-03 00:00:00',NULL,NULL,NULL,3),(38,10,2,1,'2025-06-03 00:00:00',NULL,NULL,NULL,3),(39,10,3,48,'2025-06-03 00:00:00',NULL,NULL,NULL,3),(40,10,2,47,'2025-06-10 00:00:00',NULL,NULL,NULL,4),(41,10,3,49,'2025-06-10 00:00:00',NULL,NULL,NULL,4),(42,10,48,1,'2025-06-10 00:00:00',NULL,NULL,NULL,4),(43,10,3,47,'2025-06-17 00:00:00',NULL,NULL,NULL,5),(44,10,48,2,'2025-06-17 00:00:00',NULL,NULL,NULL,5),(45,10,1,49,'2025-06-17 00:00:00',NULL,NULL,NULL,5),(46,10,47,48,'2025-06-24 00:00:00',NULL,NULL,NULL,6),(47,10,3,1,'2025-06-24 00:00:00',NULL,NULL,NULL,6),(48,10,2,49,'2025-06-24 00:00:00',NULL,NULL,NULL,6),(49,10,47,1,'2025-07-01 00:00:00',NULL,NULL,NULL,7),(50,10,48,49,'2025-07-01 00:00:00',NULL,NULL,NULL,7),(51,10,3,2,'2025-07-01 00:00:00',NULL,NULL,NULL,7),(52,10,47,49,'2025-07-08 00:00:00',NULL,NULL,NULL,8),(53,10,1,2,'2025-07-08 00:00:00',NULL,NULL,NULL,8),(54,10,48,3,'2025-07-08 00:00:00',NULL,NULL,NULL,8),(55,10,47,2,'2025-07-15 00:00:00',NULL,NULL,NULL,9),(56,10,49,3,'2025-07-15 00:00:00',NULL,NULL,NULL,9),(57,10,1,48,'2025-07-15 00:00:00',NULL,NULL,NULL,9),(58,10,47,3,'2025-07-22 00:00:00',NULL,NULL,NULL,10),(59,10,2,48,'2025-07-22 00:00:00',NULL,NULL,NULL,10),(60,10,49,1,'2025-07-22 00:00:00',NULL,NULL,NULL,10);
/*!40000 ALTER TABLE `basket_partidos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `configuraciontablas`
--

DROP TABLE IF EXISTS `configuraciontablas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `configuraciontablas` (
  `id_config` int NOT NULL AUTO_INCREMENT,
  `id_deporte` int NOT NULL,
  `consulta_creacion` longtext,
  PRIMARY KEY (`id_config`),
  KEY `id_deporte` (`id_deporte`),
  CONSTRAINT `configuraciontablas_ibfk_1` FOREIGN KEY (`id_deporte`) REFERENCES `deportes` (`id_deporte`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `configuraciontablas`
--

LOCK TABLES `configuraciontablas` WRITE;
/*!40000 ALTER TABLE `configuraciontablas` DISABLE KEYS */;
INSERT INTO `configuraciontablas` VALUES (1,1,'CREATE TABLE Basket_Equipos (id_equipo INT AUTO_INCREMENT PRIMARY KEY, nombre VARCHAR(100) NOT NULL, ciudad VARCHAR(100), fundacion YEAR, estadio VARCHAR(100));'),(2,1,'CREATE TABLE Basket_Jugadores (id_jugador INT AUTO_INCREMENT PRIMARY KEY, id_equipo INT NOT NULL, nombre VARCHAR(100) NOT NULL, altura DECIMAL(3,2), peso DECIMAL(5,2), posicion ENUM(\'Base\', \'Escolta\', \'Alero\', \'Ala-Pívot\', \'Pívot\'), dorsal INT, FOREIGN KEY (id_equipo) REFERENCES Basket_Equipos(id_equipo) ON DELETE CASCADE);'),(3,1,'CREATE TABLE Basket_Entrenadores (id_entrenador INT AUTO_INCREMENT PRIMARY KEY, id_equipo INT NOT NULL, nombre VARCHAR(100) NOT NULL, experiencia INT, FOREIGN KEY (id_equipo) REFERENCES Basket_Equipos(id_equipo) ON DELETE CASCADE);'),(4,1,'CREATE TABLE Basket_Arbitros (id_arbitro INT AUTO_INCREMENT PRIMARY KEY, nombre VARCHAR(100) NOT NULL, experiencia INT);'),(5,1,'CREATE TABLE Basket_Competiciones (id_competicion INT AUTO_INCREMENT PRIMARY KEY, nombre VARCHAR(100) NOT NULL, tipo ENUM(\'Liga\', \'Copa\', \'Amistoso\'));'),(6,1,'CREATE TABLE Basket_Partidos (id_partido INT AUTO_INCREMENT PRIMARY KEY, id_competicion INT NOT NULL, equipo_local INT NOT NULL, equipo_visitante INT NOT NULL, fecha DATETIME NOT NULL, resultado_local INT DEFAULT 0, resultado_visitante INT DEFAULT 0, id_arbitro INT, FOREIGN KEY (id_competicion) REFERENCES Basket_Competiciones(id_competicion) ON DELETE CASCADE, FOREIGN KEY (equipo_local) REFERENCES Basket_Equipos(id_equipo) ON DELETE CASCADE, FOREIGN KEY (equipo_visitante) REFERENCES Basket_Equipos(id_equipo) ON DELETE CASCADE, FOREIGN KEY (id_arbitro) REFERENCES Basket_Arbitros(id_arbitro) ON DELETE SET NULL);'),(7,3,'CREATE TABLE Karting_Equipos (id_equipo INT AUTO_INCREMENT PRIMARY KEY, nombre VARCHAR(100) NOT NULL, pais VARCHAR(100), sponsor VARCHAR(100));'),(8,3,'CREATE TABLE Karting_Pilotos (id_piloto INT AUTO_INCREMENT PRIMARY KEY, id_equipo INT NOT NULL, nombre VARCHAR(100) NOT NULL, categoria VARCHAR(50) NOT NULL, fecha_nacimiento DATE, nacionalidad VARCHAR(50), numero_kart INT, FOREIGN KEY (id_equipo) REFERENCES Karting_Equipos(id_equipo) ON DELETE CASCADE);'),(9,3,'CREATE TABLE Karting_Circuitos (id_circuito INT AUTO_INCREMENT PRIMARY KEY, nombre VARCHAR(100) NOT NULL, ubicacion VARCHAR(100), longitud DECIMAL(5,2), pais VARCHAR(50));'),(10,3,'CREATE TABLE Karting_Competiciones (id_competicion INT AUTO_INCREMENT PRIMARY KEY, nombre VARCHAR(100) NOT NULL, categoria ENUM(\"Junior\", \"Senior\", \"Master\") NOT NULL, tipo ENUM(\"Mundial\", \"Europeo\", \"Nacional\", \"Regional\"), fecha_inicio DATE, fecha_fin DATE);'),(11,3,'CREATE TABLE Karting_Carreras (id_carrera INT AUTO_INCREMENT PRIMARY KEY, id_competicion INT NOT NULL, id_circuito INT NOT NULL, fecha DATETIME NOT NULL, FOREIGN KEY (id_competicion) REFERENCES Karting_Competiciones(id_competicion) ON DELETE CASCADE, FOREIGN KEY (id_circuito) REFERENCES Karting_Circuitos(id_circuito) ON DELETE CASCADE);'),(12,3,'CREATE TABLE Karting_Estadisticas_Piloto (id_estadistica INT AUTO_INCREMENT PRIMARY KEY, id_carrera INT NOT NULL, id_piloto INT NOT NULL, posicion INT, tiempo_total DECIMAL(10,2), vueltas INT, FOREIGN KEY (id_carrera) REFERENCES Karting_Carreras(id_carrera) ON DELETE CASCADE, FOREIGN KEY (id_piloto) REFERENCES Karting_Pilotos(id_piloto) ON DELETE CASCADE);'),(13,3,'CREATE TABLE Karting_Estadisticas_Equipo (id_estadistica INT AUTO_INCREMENT PRIMARY KEY, id_carrera INT NOT NULL, id_equipo INT NOT NULL, tiempo_promedio DECIMAL(10,2), puntos INT DEFAULT 0, FOREIGN KEY (id_carrera) REFERENCES Karting_Carreras(id_carrera) ON DELETE CASCADE, FOREIGN KEY (id_equipo) REFERENCES Karting_Equipos(id_equipo) ON DELETE CASCADE);'),(14,1,'CREATE TABLE Basket_Estadisticas_Equipo (id_estadistica INT AUTO_INCREMENT PRIMARY KEY, id_partido INT NOT NULL, id_equipo INT NOT NULL, puntos INT DEFAULT 0, rebotes INT DEFAULT 0, asistencias INT DEFAULT 0, robos INT DEFAULT 0, tapones INT DEFAULT 0, perdidas INT DEFAULT 0, FOREIGN KEY (id_partido) REFERENCES Basket_Partidos(id_partido) ON DELETE CASCADE, FOREIGN KEY (id_equipo) REFERENCES Basket_Equipos(id_equipo) ON DELETE CASCADE);'),(15,1,'CREATE TABLE Basket_Estadisticas_Jugador (id_estadistica INT AUTO_INCREMENT PRIMARY KEY, id_partido INT NOT NULL, id_jugador INT NOT NULL, puntos INT DEFAULT 0, rebotes INT DEFAULT 0, asistencias INT DEFAULT 0, robos INT DEFAULT 0, tapones INT DEFAULT 0, perdidas INT DEFAULT 0, minutos DECIMAL(4,2) DEFAULT 0.00, FOREIGN KEY (id_partido) REFERENCES Basket_Partidos(id_partido) ON DELETE CASCADE, FOREIGN KEY (id_jugador) REFERENCES Basket_Jugadores(id_jugador) ON DELETE CASCADE);'),(16,1,'CREATE TABLE basket_equipos_competiciones (\n    id_equipo INT NOT NULL,\n    id_competicion INT NOT NULL,\n    PRIMARY KEY (id_equipo, id_competicion),\n    FOREIGN KEY (id_equipo) REFERENCES basket_equipos(id_equipo),\n    FOREIGN KEY (id_competicion) REFERENCES basket_competiciones(id_competicion)\n);'),(17,1,'CREATE TABLE basket_jugador_competicion (\n    id INT AUTO_INCREMENT PRIMARY KEY,\n    id_jugador INT NOT NULL,\n    id_competicion INT NOT NULL,\n    FOREIGN KEY (id_jugador) REFERENCES basket_jugadores(id_jugador),\n    FOREIGN KEY (id_competicion) REFERENCES basket_competiciones(id_competicion)\n);'),(18,3,'CREATE TABLE karting_competiciones_equipos (\r\n    id_competicion INT NOT NULL,\r\n    id_equipo INT NOT NULL,\r\n    PRIMARY KEY (id_competicion, id_equipo),\r\n    FOREIGN KEY (id_competicion) REFERENCES karting_competiciones(id_competicion) ON DELETE CASCADE,\r\n    FOREIGN KEY (id_equipo) REFERENCES karting_equipos(id_equipo) ON DELETE CASCADE\r\n);');
/*!40000 ALTER TABLE `configuraciontablas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `deportes`
--

DROP TABLE IF EXISTS `deportes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `deportes` (
  `id_deporte` int NOT NULL AUTO_INCREMENT,
  `id_nemonico` varchar(10) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  PRIMARY KEY (`id_deporte`),
  UNIQUE KEY `id_nemonico` (`id_nemonico`),
  UNIQUE KEY `nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `deportes`
--

LOCK TABLES `deportes` WRITE;
/*!40000 ALTER TABLE `deportes` DISABLE KEYS */;
INSERT INTO `deportes` VALUES (1,'BASKET','Baloncesto'),(3,'KARTING','Karting FIA');
/*!40000 ALTER TABLE `deportes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `karting_carreras`
--

DROP TABLE IF EXISTS `karting_carreras`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `karting_carreras` (
  `id_carrera` int NOT NULL AUTO_INCREMENT,
  `id_competicion` int NOT NULL,
  `id_circuito` int NOT NULL,
  `fecha` datetime NOT NULL,
  PRIMARY KEY (`id_carrera`),
  KEY `id_competicion` (`id_competicion`),
  KEY `id_circuito` (`id_circuito`),
  CONSTRAINT `karting_carreras_ibfk_1` FOREIGN KEY (`id_competicion`) REFERENCES `karting_competiciones` (`id_competicion`) ON DELETE CASCADE,
  CONSTRAINT `karting_carreras_ibfk_2` FOREIGN KEY (`id_circuito`) REFERENCES `karting_circuitos` (`id_circuito`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `karting_carreras`
--

LOCK TABLES `karting_carreras` WRITE;
/*!40000 ALTER TABLE `karting_carreras` DISABLE KEYS */;
INSERT INTO `karting_carreras` VALUES (1,1,1,'2025-06-19 22:00:00');
/*!40000 ALTER TABLE `karting_carreras` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `karting_circuitos`
--

DROP TABLE IF EXISTS `karting_circuitos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `karting_circuitos` (
  `id_circuito` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `ubicacion` varchar(100) DEFAULT NULL,
  `longitud` decimal(5,2) DEFAULT NULL,
  `pais` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_circuito`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `karting_circuitos`
--

LOCK TABLES `karting_circuitos` WRITE;
/*!40000 ALTER TABLE `karting_circuitos` DISABLE KEYS */;
INSERT INTO `karting_circuitos` VALUES (1,'Spa','Belgica',7.05,'Belgica');
/*!40000 ALTER TABLE `karting_circuitos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `karting_competiciones`
--

DROP TABLE IF EXISTS `karting_competiciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `karting_competiciones` (
  `id_competicion` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `categoria` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `tipo` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `fecha_inicio` date DEFAULT NULL,
  `fecha_fin` date DEFAULT NULL,
  PRIMARY KEY (`id_competicion`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `karting_competiciones`
--

LOCK TABLES `karting_competiciones` WRITE;
/*!40000 ALTER TABLE `karting_competiciones` DISABLE KEYS */;
INSERT INTO `karting_competiciones` VALUES (1,'Formula 1','Automovilismo','Automovilismo','2025-06-01','2025-06-30');
/*!40000 ALTER TABLE `karting_competiciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `karting_competiciones_equipos`
--

DROP TABLE IF EXISTS `karting_competiciones_equipos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `karting_competiciones_equipos` (
  `id_competicion` int NOT NULL,
  `id_equipo` int NOT NULL,
  PRIMARY KEY (`id_competicion`,`id_equipo`),
  KEY `id_equipo` (`id_equipo`),
  CONSTRAINT `karting_competiciones_equipos_ibfk_1` FOREIGN KEY (`id_competicion`) REFERENCES `karting_competiciones` (`id_competicion`) ON DELETE CASCADE,
  CONSTRAINT `karting_competiciones_equipos_ibfk_2` FOREIGN KEY (`id_equipo`) REFERENCES `karting_equipos` (`id_equipo`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `karting_competiciones_equipos`
--

LOCK TABLES `karting_competiciones_equipos` WRITE;
/*!40000 ALTER TABLE `karting_competiciones_equipos` DISABLE KEYS */;
INSERT INTO `karting_competiciones_equipos` VALUES (1,1),(1,2),(1,3),(1,4);
/*!40000 ALTER TABLE `karting_competiciones_equipos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `karting_equipos`
--

DROP TABLE IF EXISTS `karting_equipos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `karting_equipos` (
  `id_equipo` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `pais` varchar(100) DEFAULT NULL,
  `sponsor` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_equipo`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `karting_equipos`
--

LOCK TABLES `karting_equipos` WRITE;
/*!40000 ALTER TABLE `karting_equipos` DISABLE KEYS */;
INSERT INTO `karting_equipos` VALUES (1,'Red Bull','Austria','Honda'),(2,'Ferrrari','Italia','HP'),(3,'Aston Martin','Reino Unido','Aramco'),(4,'Williams','Reino Unido','Atlassian');
/*!40000 ALTER TABLE `karting_equipos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `karting_estadisticas_equipo`
--

DROP TABLE IF EXISTS `karting_estadisticas_equipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `karting_estadisticas_equipo` (
  `id_estadistica` int NOT NULL AUTO_INCREMENT,
  `id_carrera` int NOT NULL,
  `id_equipo` int NOT NULL,
  `tiempo_promedio` decimal(10,2) DEFAULT NULL,
  `puntos` int DEFAULT '0',
  PRIMARY KEY (`id_estadistica`),
  KEY `id_carrera` (`id_carrera`),
  KEY `id_equipo` (`id_equipo`),
  CONSTRAINT `karting_estadisticas_equipo_ibfk_1` FOREIGN KEY (`id_carrera`) REFERENCES `karting_carreras` (`id_carrera`) ON DELETE CASCADE,
  CONSTRAINT `karting_estadisticas_equipo_ibfk_2` FOREIGN KEY (`id_equipo`) REFERENCES `karting_equipos` (`id_equipo`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `karting_estadisticas_equipo`
--

LOCK TABLES `karting_estadisticas_equipo` WRITE;
/*!40000 ALTER TABLE `karting_estadisticas_equipo` DISABLE KEYS */;
/*!40000 ALTER TABLE `karting_estadisticas_equipo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `karting_estadisticas_piloto`
--

DROP TABLE IF EXISTS `karting_estadisticas_piloto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `karting_estadisticas_piloto` (
  `id_estadistica` int NOT NULL AUTO_INCREMENT,
  `id_carrera` int NOT NULL,
  `id_piloto` int NOT NULL,
  `posicion` int DEFAULT NULL,
  `tiempo_total` decimal(10,2) DEFAULT NULL,
  `vueltas` int DEFAULT NULL,
  PRIMARY KEY (`id_estadistica`),
  KEY `id_carrera` (`id_carrera`),
  KEY `id_piloto` (`id_piloto`),
  CONSTRAINT `karting_estadisticas_piloto_ibfk_1` FOREIGN KEY (`id_carrera`) REFERENCES `karting_carreras` (`id_carrera`) ON DELETE CASCADE,
  CONSTRAINT `karting_estadisticas_piloto_ibfk_2` FOREIGN KEY (`id_piloto`) REFERENCES `karting_pilotos` (`id_piloto`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `karting_estadisticas_piloto`
--

LOCK TABLES `karting_estadisticas_piloto` WRITE;
/*!40000 ALTER TABLE `karting_estadisticas_piloto` DISABLE KEYS */;
INSERT INTO `karting_estadisticas_piloto` VALUES (1,1,1,1,800.00,10);
/*!40000 ALTER TABLE `karting_estadisticas_piloto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `karting_pilotos`
--

DROP TABLE IF EXISTS `karting_pilotos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `karting_pilotos` (
  `id_piloto` int NOT NULL AUTO_INCREMENT,
  `id_equipo` int NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `categoria` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `fecha_nacimiento` date DEFAULT NULL,
  `nacionalidad` varchar(50) DEFAULT NULL,
  `numero_kart` int DEFAULT NULL,
  PRIMARY KEY (`id_piloto`),
  KEY `id_equipo` (`id_equipo`),
  CONSTRAINT `karting_pilotos_ibfk_1` FOREIGN KEY (`id_equipo`) REFERENCES `karting_equipos` (`id_equipo`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `karting_pilotos`
--

LOCK TABLES `karting_pilotos` WRITE;
/*!40000 ALTER TABLE `karting_pilotos` DISABLE KEYS */;
INSERT INTO `karting_pilotos` VALUES (1,3,'Fernando Alonso','F1','1981-07-21','España',14);
/*!40000 ALTER TABLE `karting_pilotos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `id_usuario` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `correo` varchar(150) NOT NULL,
  `contraseña` varchar(255) NOT NULL,
  `rol` enum('admin','usuario') NOT NULL DEFAULT 'usuario',
  `fecha_registro` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `id_deporte` int NOT NULL,
  PRIMARY KEY (`id_usuario`),
  UNIQUE KEY `correo` (`correo`),
  KEY `fk_usuario_deporte` (`id_deporte`),
  CONSTRAINT `fk_usuario_deporte` FOREIGN KEY (`id_deporte`) REFERENCES `deportes` (`id_deporte`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'admin_basket','basket@federa.com','admin123','admin','2025-06-07 10:32:32',1),(2,'admin_karting','karting@federa.com','admin123','admin','2025-06-07 10:32:35',3),(3,'hhthh','trhh','123','usuario',NULL,1);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-11 20:30:46
