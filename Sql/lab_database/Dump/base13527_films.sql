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
-- Table structure for table `films`
--

DROP TABLE IF EXISTS `films`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `films` (
  `id` decimal(6,0) NOT NULL,
  `NameFilm` varchar(50) NOT NULL,
  `Studio` varchar(50) NOT NULL,
  `Year` decimal(4,0) NOT NULL,
  `Country` varchar(30) DEFAULT NULL,
  `Time` decimal(4,2) NOT NULL,
  `Genre` char(30) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `films`
--

LOCK TABLES `films` WRITE;
/*!40000 ALTER TABLE `films` DISABLE KEYS */;
INSERT INTO `films` VALUES (1,'Arab','WarnerBr',1995,'Turkey',1.25,'adventure'),(2,'Kitaec','Chaonli',1995,'China',1.32,'adventure'),(3,'Milayu','RashitSt',1983,'India',2.15,'adventure'),(4,'Piter','LenFilm',2001,'Russian Federation',1.17,'adventure'),(5,'PupEarth','Odessia',2005,'UKraine',0.57,'horor'),(6,'Zelenue','DreamWorks',2007,'Mexico',3.57,'Triller'),(7,'KUKU','Gorkii',1965,'USSR',1.38,'horor'),(8,'miror','MGM',1981,'USA',1.21,'horor'),(9,'Kamalu','MGM',2015,'London',2.22,'drama'),(10,'microb','Columbia',2003,'France',3.22,'science'),(11,'trulala','paramaunt',1999,'Italy',1.16,'family'),(12,'Wolf','Gorkii',2010,'Kenia',1.47,'fantasy'),(13,'lubof','warnerbr',2011,'Japan',3.13,'detective'),(14,'MY Young Brother','Molot',2015,'Russian Federation',1.42,'comedy'),(15,'Mumia','Paramaunt',2012,'Egept',2.27,'fantasy'),(16,'Stalker','21cent',2005,'Russian Federation',2.23,'fantasy'),(17,'Muravii','Phantom',2015,'Russian Federation',2.53,'Horor');
/*!40000 ALTER TABLE `films` ENABLE KEYS */;
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
