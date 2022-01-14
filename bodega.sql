-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: localhost    Database: bodega
-- ------------------------------------------------------
-- Server version	8.0.26

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
-- Table structure for table `equipo`
--

DROP TABLE IF EXISTS `equipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equipo` (
  `id_equipo` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `imagen` longblob,
  PRIMARY KEY (`id_equipo`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipo`
--

LOCK TABLES `equipo` WRITE;
/*!40000 ALTER TABLE `equipo` DISABLE KEYS */;
INSERT INTO `equipo` VALUES (1,'Mesa de selección',NULL),(2,'Elevador de cangilones',NULL),(3,'Despalilladora-estrujadora',NULL),(4,'Prensa neumática',NULL),(5,'Intercambiador tubular',NULL),(6,'Limpiador de barricas',NULL),(7,'Depósitos de acero inoxidable autovaciantes de 2000 litros #10',NULL),(8,'Depósitos de acero inoxidable autovaciantes de 2000 litros #11',NULL),(9,'Depósitos de acero inoxidable autovaciantes de 2000 litros #12',NULL),(10,'Depósitos de acero inoxidable de 3000 litros #1',NULL),(11,'Depósitos de acero inoxidable de 3000 litros #2',NULL),(12,'Depósitos de acero inoxidable de 3000 litros #3',NULL),(13,'Depósitos de acero inoxidable de 3000 litros #4',NULL),(14,'Depósitos de acero inoxidable de 3000 litros #5',NULL),(15,'Depósitos de acero inoxidable de 3000 litros #6',NULL),(16,'Depósitos de acero inoxidable de 3000 litros #7',NULL),(17,'Depósitos de acero inoxidable de 3000 litros #6',NULL),(18,'Depósitos de acero inoxidable de 3000 litros #9',NULL),(19,'Depósitos de acero inoxidable de 3000 litros #10',NULL),(20,'Depósito de acero inoxidable de 2000 litros #4F',NULL),(21,'Depósito de acero inoxidable de 2000 litros #5F',NULL),(22,'Depósito de acero inoxidable de 2000 litros #6F',NULL),(23,'Depósito isotérmico #1F',NULL),(24,'Depósito isotérmico #2F',NULL),(25,'Depósito isotérmico #3F',NULL),(26,'Depósito siempre-lleno',NULL),(27,'Mangas de trasiego',NULL),(28,'Bomba de trasiego de tinto',NULL),(29,'Bomba de trasiego de blancos',NULL),(30,'Filtro de tierras',NULL),(31,'Filtro de placas',NULL),(32,'Equipo de frío',NULL),(33,'Embotelladora',NULL),(34,'Pasterizador',NULL),(35,'Equipo de microfiltración',NULL);
/*!40000 ALTER TABLE `equipo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupo`
--

DROP TABLE IF EXISTS `grupo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `grupo` (
  `id_grupo` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(25) NOT NULL,
  PRIMARY KEY (`id_grupo`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupo`
--

LOCK TABLES `grupo` WRITE;
/*!40000 ALTER TABLE `grupo` DISABLE KEYS */;
INSERT INTO `grupo` VALUES (1,'Primero AOV'),(2,'Segundo AOV'),(3,'Primero VIT'),(4,'Segundo VIT'),(5,'Otro');
/*!40000 ALTER TABLE `grupo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `localizacion`
--

DROP TABLE IF EXISTS `localizacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `localizacion` (
  `id_localizacion` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `imagen` longblob,
  PRIMARY KEY (`id_localizacion`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `localizacion`
--

LOCK TABLES `localizacion` WRITE;
/*!40000 ALTER TABLE `localizacion` DISABLE KEYS */;
INSERT INTO `localizacion` VALUES (1,'Zona de recepción de MP y Fermentación',NULL),(2,'Zona de estabilización',NULL),(3,'Sala de embotellado',NULL),(4,'Laboratorio de alimentos',NULL),(5,'Laboratorio de Licores',NULL),(6,'Almacén de producto acabado',NULL),(7,'Almacén de auxiliares o Zulo',NULL),(8,'Almacén de producto enológico',NULL);
/*!40000 ALTER TABLE `localizacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `objetivo`
--

DROP TABLE IF EXISTS `objetivo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `objetivo` (
  `id_objetivo` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(25) NOT NULL,
  PRIMARY KEY (`id_objetivo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `objetivo`
--

LOCK TABLES `objetivo` WRITE;
/*!40000 ALTER TABLE `objetivo` DISABLE KEYS */;
INSERT INTO `objetivo` VALUES (1,'Instalaciones'),(2,'Equipos');
/*!40000 ALTER TABLE `objetivo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `operacion`
--

DROP TABLE IF EXISTS `operacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `operacion` (
  `id_operacion` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`id_operacion`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `operacion`
--

LOCK TABLES `operacion` WRITE;
/*!40000 ALTER TABLE `operacion` DISABLE KEYS */;
INSERT INTO `operacion` VALUES (1,'Limpieza previa'),(2,'Limpieza post-uso'),(3,'Limpieza mantenimiento'),(4,'Limpieza accidental'),(5,'Mantenimiento previo'),(6,'Mantenimiento ordinario');
/*!40000 ALTER TABLE `operacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `registro`
--

DROP TABLE IF EXISTS `registro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `registro` (
  `id_registro` int NOT NULL AUTO_INCREMENT,
  `fecha_hora` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `id_grupo` int DEFAULT NULL,
  `id_localizacion` int DEFAULT NULL,
  `id_objetivo` int DEFAULT NULL,
  `id_operacion` int DEFAULT NULL,
  `id_equipo` int DEFAULT NULL,
  PRIMARY KEY (`id_registro`),
  KEY `registro_fk_localizacion` (`id_localizacion`),
  KEY `registro_fk_objetivo` (`id_objetivo`),
  KEY `registro_fk_operacion` (`id_operacion`),
  KEY `registro_fk_equipo` (`id_equipo`),
  KEY `registro_fk_grupo` (`id_grupo`),
  CONSTRAINT `registro_fk_equipo` FOREIGN KEY (`id_equipo`) REFERENCES `equipo` (`id_equipo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `registro_fk_grupo` FOREIGN KEY (`id_grupo`) REFERENCES `grupo` (`id_grupo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `registro_fk_localizacion` FOREIGN KEY (`id_localizacion`) REFERENCES `localizacion` (`id_localizacion`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `registro_fk_objetivo` FOREIGN KEY (`id_objetivo`) REFERENCES `objetivo` (`id_objetivo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `registro_fk_operacion` FOREIGN KEY (`id_operacion`) REFERENCES `operacion` (`id_operacion`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registro`
--

LOCK TABLES `registro` WRITE;
/*!40000 ALTER TABLE `registro` DISABLE KEYS */;
INSERT INTO `registro` VALUES (11,'2021-12-14 10:39:26',1,1,1,1,1),(12,'2021-12-14 10:41:08',1,1,1,2,1),(13,'2021-12-14 10:50:31',1,1,2,1,2);
/*!40000 ALTER TABLE `registro` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-01-11 11:01:29
