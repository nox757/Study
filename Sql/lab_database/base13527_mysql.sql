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
-- Temporary view structure for view `comedii`
--

DROP TABLE IF EXISTS `comedii`;
/*!50001 DROP VIEW IF EXISTS `comedii`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `comedii` AS SELECT 
 1 AS `NAME`,
 1 AS `COUNTRY`,
 1 AS `YEAR`,
 1 AS `TIME`*/;
SET character_set_client = @saved_cs_client;

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

--
-- Table structure for table `genres`
--

DROP TABLE IF EXISTS `genres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `genres` (
  `genre` char(30) NOT NULL,
  PRIMARY KEY (`genre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genres`
--

LOCK TABLES `genres` WRITE;
/*!40000 ALTER TABLE `genres` DISABLE KEYS */;
INSERT INTO `genres` VALUES ('adventure'),('biography'),('comedy'),('detective'),('drama'),('family'),('fantasy'),('horor'),('musical'),('science'),('sports'),('triller');
/*!40000 ALTER TABLE `genres` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Temporary view structure for view `regiser_player`
--

DROP TABLE IF EXISTS `regiser_player`;
/*!50001 DROP VIEW IF EXISTS `regiser_player`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `regiser_player` AS SELECT 
 1 AS `FIO`,
 1 AS `FILM`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `statistic_genre`
--

DROP TABLE IF EXISTS `statistic_genre`;
/*!50001 DROP VIEW IF EXISTS `statistic_genre`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `statistic_genre` AS SELECT 
 1 AS `genre`,
 1 AS `cntru`,
 1 AS `cntnoru`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `comedii`
--

/*!50001 DROP VIEW IF EXISTS `comedii`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `comedii` AS select `films`.`NameFilm` AS `NAME`,`films`.`Country` AS `COUNTRY`,`films`.`Year` AS `YEAR`,`films`.`Time` AS `TIME` from `films` where (`films`.`Genre` = 'comedy') */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `regiser_player`
--

/*!50001 DROP VIEW IF EXISTS `regiser_player`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `regiser_player` AS select `p`.`fio` AS `FIO`,`f`.`NameFilm` AS `FILM` from ((`base13527`.`films` `f` join `base13527`.`persons` `p`) join (select `cr`.`person` AS `person`,`cr`.`film` AS `film` from `base13527`.`creators` `cr` where exists(select 1 from `base13527`.`creators` `cr2` where ((`cr2`.`film` = `cr`.`film`) and (`cr2`.`person` = `cr`.`person`) and (`cr2`.`charact` = 'regiser') and (`cr`.`charact` = 'player')))) `two`) where ((`two`.`person` = `p`.`id`) and (`two`.`film` = `f`.`id`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `statistic_genre`
--

/*!50001 DROP VIEW IF EXISTS `statistic_genre`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `statistic_genre` AS select `g`.`genre` AS `genre`,(select count(0) from `films` `f` where ((`f`.`Genre` = `g`.`genre`) and (`f`.`Country` = 'Russian Federation'))) AS `cntru`,(select count(0) from `films` `f2` where ((`f2`.`Genre` = `g`.`genre`) and (`f2`.`Country` <> 'Russian Federation'))) AS `cntnoru` from `genres` `g` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-01-04 13:59:57
