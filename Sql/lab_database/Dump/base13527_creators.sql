-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: base13527
-- ------------------------------------------------------
-- Server version	5.7.9-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `creators`
--

DROP TABLE IF EXISTS `creators`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `creators` (
  `film` decimal(6,0) DEFAULT NULL,
  `person` decimal(6,0) DEFAULT NULL,
  `charact` varchar(50) NOT NULL,
  `role` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `creators`
--

LOCK TABLES `creators` WRITE;
/*!40000 ALTER TABLE `creators` DISABLE KEYS */;
INSERT INTO `creators` VALUES (1,1,'player','arab'),(13,5,'producer',NULL),(3,4,'kompositor',NULL),(8,5,'player','plantotor'),(1,1,'soundmaker',NULL),(1,27,'regiser',NULL),(2,12,'regiser',NULL),(2,13,'player','main'),(2,9,'player','second'),(2,30,'grimmer',NULL),(3,14,'player','main'),(3,15,'produser',NULL),(3,23,'soundmaker',NULL),(4,8,'player','main'),(4,8,'produser',NULL),(4,3,'regiser',NULL),(5,24,'player','main'),(5,16,'player','second'),(5,17,'regiser',NULL),(5,18,'produser',NULL),(5,18,'soundmaker',NULL),(6,19,'player','main'),(6,20,'player','second'),(6,20,'player','clon'),(6,20,'produser',NULL),(6,21,'regiser',NULL),(6,30,'soundmaker',NULL),(7,31,'player','main'),(7,10,'regiser',NULL),(7,11,'produser',NULL),(8,23,'player','main'),(8,24,'player','second'),(8,9,'regiser',NULL),(9,13,'player','main'),(9,2,'player','boy'),(9,22,'regiser',NULL),(10,25,'player','main'),(10,26,'player','second'),(10,27,'regiser',NULL),(11,2,'player','main'),(11,3,'player','mama'),(11,19,'produser',NULL),(12,29,'player','main'),(12,9,'player','second'),(12,18,'produser',NULL),(13,25,'player','main'),(13,15,'player','second'),(13,22,'regiser',NULL),(14,3,'produser',NULL),(14,8,'player','main'),(14,30,'soundmaker',NULL),(14,25,'player','tump'),(15,28,'player','main'),(15,29,'player','second'),(15,24,'regiser',NULL),(16,8,'player','main'),(16,3,'player','second'),(16,15,'player','gun'),(16,17,'player','type'),(16,12,'regiser',NULL),(16,22,'produser',NULL),(8,31,'player','aunt'),(17,25,'player','main'),(17,7,'player','moop'),(17,3,'regiser',NULL),(17,20,'produser',NULL),(17,6,'player','plato'),(17,18,'player','tok'),(10,27,'player','third'),(15,24,'player','man'),(27,10,'player','youn');
/*!40000 ALTER TABLE `creators` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-05-22 22:33:24
