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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-05-22 22:41:44
