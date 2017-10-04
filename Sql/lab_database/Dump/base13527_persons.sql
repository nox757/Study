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
-- Table structure for table `persons`
--

DROP TABLE IF EXISTS `persons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `persons` (
  `id` decimal(6,0) NOT NULL,
  `fio` varchar(50) NOT NULL,
  `country` varchar(30) NOT NULL,
  `birth` date NOT NULL,
  `death` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persons`
--

LOCK TABLES `persons` WRITE;
/*!40000 ALTER TABLE `persons` DISABLE KEYS */;
INSERT INTO `persons` VALUES (1,'Gulkin Petr Igorevich','USSR','1959-08-25','2011-06-13'),(2,'Gusev Ilai Igorevich','Italy','1996-08-25','0000-00-00'),(3,'Belov Denis Sinovich','Russian Federation','1983-05-22','0000-00-00'),(4,'Brima Yanus Maidovich','India','1993-05-29','0000-00-00'),(5,'Yun Pal Tum','Japan','1955-05-22','1999-09-11'),(6,'Kruchev Valentin Sergeevich','China','1963-08-25','0000-00-00'),(7,'Lyao Dzen Mee','Japan','1983-09-27','0000-00-00'),(8,'Miklov Vicktor Gregorevich','Russian Federation','2000-03-21','0000-00-00'),(9,'Garlo Malko Tulko','Mexico','1955-04-22','2011-12-02'),(10,'Semenov Mihail Pavlovich','USSR','1933-10-05','1999-01-12'),(11,'Ivanov Gregorii Ivanovich','USSR','1945-11-07','1994-03-22'),(12,'Jan Jekii Chan','China','1965-11-05','0000-00-00'),(13,'Junk Meen Lan','China','1969-02-05','0000-00-00'),(14,'Hami Lany Pann','India','1958-03-07','2012-10-10'),(15,'Tulna Mangi Ganni','India','1983-03-19','0000-00-00'),(16,'Mutko Igor Tavnaeevich','Ukraine','1985-07-08','0000-00-00'),(17,'Galaiko Vadim Timofeevich','Ukraine','1988-05-18','0000-00-00'),(18,'Gdanovna Olga Petrovna','Ukraine','1975-04-28','0000-00-00'),(19,'Vandi Mikela Balovna','Mexico','1976-11-20','0000-00-00'),(20,'Kilan Adgard Nakach','Mexico','1996-03-26','0000-00-00'),(21,'Kamrov Tiikn Palov','Mexico','1983-04-16','0000-00-00'),(22,'Janklod Van Dam','USA','1988-12-20','0000-00-00'),(23,'Trueman Mike Dimov','USA','1948-10-23','2000-10-20'),(24,'Lunfish Kate Nikel','USA','1968-03-25','2014-09-29'),(25,'Jan Jak Migel','France','1988-08-09','0000-00-00'),(26,'Mi Laura Aunti','France','1982-10-19','0000-00-00'),(27,'Per Del Tun','France','1962-10-19','2010-10-25'),(28,'Shahmet Lui Tong','Egept','1969-12-29','0000-00-00'),(29,'Shooli Milay Youg','Egept','1999-02-22','0000-00-00'),(30,'Naomi Luisa Ken','UAR','1979-02-13','0000-00-00'),(31,'Ranefskay Faina Gregorevna','USSR','1896-08-27','1984-07-19');
/*!40000 ALTER TABLE `persons` ENABLE KEYS */;
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
