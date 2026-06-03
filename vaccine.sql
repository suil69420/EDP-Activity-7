CREATE DATABASE  IF NOT EXISTS `vaccinedb2` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci */;
USE `vaccinedb2`;
-- MariaDB dump 10.19  Distrib 10.4.32-MariaDB, for Win64 (AMD64)
--
-- Host: 127.0.0.1    Database: vaccinedb2
-- ------------------------------------------------------
-- Server version	10.4.32-MariaDB

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
-- Table structure for table `person`
--

DROP TABLE IF EXISTS `person`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `person` (
  `person_id` int(11) NOT NULL,
  `person_contact_num` varchar(45) DEFAULT NULL,
  `first_name` varchar(45) DEFAULT NULL,
  `last_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `person`
--

LOCK TABLES `person` WRITE;
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` VALUES (1,'09123456781','Juan','Dela Cruz'),(2,'09123456782','Maria','Santos'),(3,'09123456783','Jose','Rizal'),(4,'09123456784','Ana','Reyes'),(5,'09123456785','Pedro','Gomez'),(6,'09123456786','Elena','Torres'),(7,'09123456787','Lito','Pascual'),(8,'09123456788','Rosa','Villanueva'),(9,'09123456789','Ben','Aquino'),(10,'09123456710','Clara','Garcia');
/*!40000 ALTER TABLE `person` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `room`
--

DROP TABLE IF EXISTS `room`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `room` (
  `room_id` int(11) NOT NULL,
  `room_name` varchar(45) DEFAULT NULL,
  `building` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`room_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `room`
--

LOCK TABLES `room` WRITE;
/*!40000 ALTER TABLE `room` DISABLE KEYS */;
INSERT INTO `room` VALUES (1,'Room A','Main Building'),(2,'Room B','Main Building'),(3,'Room C','East Wing'),(4,'Room D','West Wing'),(5,'Room E','North Wing'),(6,'Clinic 1','Annex A'),(7,'Clinic 2','Annex A'),(8,'ER 1','Emergency Block'),(9,'Lab 1','Diagnostic Center'),(10,'Hall A','Gymnasium');
/*!40000 ALTER TABLE `room` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `staff` (
  `staff_id` int(11) NOT NULL,
  `staff_contact_num` varchar(45) DEFAULT NULL,
  `first_name` varchar(45) DEFAULT NULL,
  `last_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`staff_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES (101,'09223456701','Dr. Mark','Bautista'),(102,'09223456702','Nurse Joy','Cruz'),(103,'09223456703','Dr. Sarah','Lim'),(104,'09223456704','Nurse Lea','Mendoza'),(105,'09223456705','Dr. Sam','Perez'),(106,'09223456706','Nurse Kim','Go'),(107,'09223456707','Dr. Rico','Blanco'),(108,'09223456708','Nurse Pam','Sy'),(109,'09223456709','Dr. Vic','Sotto'),(110,'09223456710','Nurse Eva','Luna');
/*!40000 ALTER TABLE `staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vaccination_record`
--

DROP TABLE IF EXISTS `vaccination_record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vaccination_record` (
  `record_id` int(11) NOT NULL,
  `person_id` int(11) DEFAULT NULL,
  `staff_id` int(11) DEFAULT NULL,
  `vaccine_id` int(11) DEFAULT NULL,
  `vaccination_dose` varchar(45) DEFAULT NULL,
  `vaccination_date` date DEFAULT NULL,
  `room_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`record_id`),
  KEY `person_id_idx` (`person_id`),
  KEY `staff_id_idx` (`staff_id`),
  KEY `vaccine_id_idx` (`vaccine_id`),
  CONSTRAINT `person_id` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `room_id` FOREIGN KEY (`room_id`) REFERENCES `room` (`room_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `staff_id` FOREIGN KEY (`staff_id`) REFERENCES `staff` (`staff_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `vaccine_id` FOREIGN KEY (`vaccine_id`) REFERENCES `vaccine` (`vaccine_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vaccination_record`
--

LOCK TABLES `vaccination_record` WRITE;
/*!40000 ALTER TABLE `vaccination_record` DISABLE KEYS */;
INSERT INTO `vaccination_record` VALUES (1001,1,102,501,'1st Dose','2026-02-01',1),(1002,2,104,501,'1st Dose','2026-02-02',1),(1003,3,106,502,'1st Dose','2026-02-03',2),(1004,1,102,501,'2nd Dose','2026-02-22',1),(1005,4,108,503,'1st Dose','2026-02-05',3),(1006,5,110,504,'1st Dose','2026-02-06',4),(1007,6,101,505,'Single Dose','2026-02-07',5),(1008,7,103,509,'Annual','2026-02-08',6),(1009,8,105,510,'1st Dose','2026-02-09',7),(1010,9,107,502,'1st Dose','2026-02-10',2),(1011,5,102,501,'2nd Dose','2026-03-01',1);
/*!40000 ALTER TABLE `vaccination_record` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vaccine`
--

DROP TABLE IF EXISTS `vaccine`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vaccine` (
  `vaccine_id` int(11) NOT NULL,
  `vaccine_name` varchar(45) DEFAULT NULL,
  `vaccine_expiry_date` date DEFAULT NULL,
  PRIMARY KEY (`vaccine_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vaccine`
--

LOCK TABLES `vaccine` WRITE;
/*!40000 ALTER TABLE `vaccine` DISABLE KEYS */;
INSERT INTO `vaccine` VALUES (501,'Pfizer','2026-12-31'),(502,'Moderna','2026-11-15'),(503,'AstraZeneca','2026-08-20'),(504,'Sinovac','2026-05-10'),(505,'J&J','2026-03-01'),(506,'Sputnik V','2026-09-12'),(507,'Covaxin','2026-07-04'),(508,'Novavax','2026-10-25'),(509,'Flu Shot','2026-02-14'),(510,'Hep-B','2027-01-01');
/*!40000 ALTER TABLE `vaccine` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `view_patient_history`
--

DROP TABLE IF EXISTS `view_patient_history`;
/*!50001 DROP VIEW IF EXISTS `view_patient_history`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `view_patient_history` AS SELECT
 1 AS `first_name`,
  1 AS `last_name`,
  1 AS `vaccine_name`,
  1 AS `vaccination_dose`,
  1 AS `vaccination_date` */;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `view_staff_activity`
--

DROP TABLE IF EXISTS `view_staff_activity`;
/*!50001 DROP VIEW IF EXISTS `view_staff_activity`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `view_staff_activity` AS SELECT
 1 AS `first_name`,
  1 AS `last_name`,
  1 AS `total_doses` */;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `view_vaccine_inventory`
--

DROP TABLE IF EXISTS `view_vaccine_inventory`;
/*!50001 DROP VIEW IF EXISTS `view_vaccine_inventory`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `view_vaccine_inventory` AS SELECT
 1 AS `vaccine_name`,
  1 AS `vaccine_expiry_date` */;
SET character_set_client = @saved_cs_client;

--
-- Dumping routines for database 'vaccinedb2'
--
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP FUNCTION IF EXISTS `patient_dose_count` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `patient_dose_count`(p_id INT) RETURNS int(11)
    DETERMINISTIC
BEGIN
    DECLARE total INT;
    SELECT COUNT(*) INTO total 
    FROM vaccination_record 
    WHERE person_id = p_id;
    RETURN total;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `add_vaccination_record` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `add_vaccination_record`(
IN p_record_id INT, 
    IN p_person_id INT,
    IN p_staff_id INT,
    IN p_vaccine_id INT,
    IN p_dose VARCHAR(45),
    IN p_date DATE,
    IN p_room_id INT
    )
BEGIN
INSERT INTO vaccination_record ( 
        record_id, person_id, staff_id, vaccine_id, 
        vaccination_dose, vaccination_date, room_id )
        VALUES ( 
        p_record_id, p_person_id, p_staff_id, p_vaccine_id, 
        p_dose, p_date, p_room_id
    );
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `new_procedure` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `new_procedure`(
IN p_record_id INT, 
    IN p_person_id INT,
    IN p_staff_id INT,
    IN p_vaccine_id INT,
    IN p_dose VARCHAR(45),
    IN p_date DATE,
    IN p_room_id INT
    )
BEGIN
INSERT INTO vaccination_record ( 
        record_id, person_id, staff_id, vaccine_id, 
        vaccination_dose, vaccination_date, room_id )
        VALUES ( 
        p_record_id, p_person_id, p_staff_id, p_vaccine_id, 
        p_dose, p_date, p_room_id
    );
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `view_patient_history`
--

/*!50001 DROP VIEW IF EXISTS `view_patient_history`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_patient_history` AS select `p`.`first_name` AS `first_name`,`p`.`last_name` AS `last_name`,`v`.`vaccine_name` AS `vaccine_name`,`vr`.`vaccination_dose` AS `vaccination_dose`,`vr`.`vaccination_date` AS `vaccination_date` from ((`vaccination_record` `vr` join `person` `p` on(`vr`.`person_id` = `p`.`person_id`)) join `vaccine` `v` on(`vr`.`vaccine_id` = `v`.`vaccine_id`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_staff_activity`
--

/*!50001 DROP VIEW IF EXISTS `view_staff_activity`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_staff_activity` AS select `staff`.`first_name` AS `first_name`,`staff`.`last_name` AS `last_name`,count(0) AS `total_doses` from (`staff` join `vaccination_record` on(`staff`.`staff_id` = `vaccination_record`.`staff_id`)) group by `staff`.`staff_id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_vaccine_inventory`
--

/*!50001 DROP VIEW IF EXISTS `view_vaccine_inventory`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_vaccine_inventory` AS select `vaccine`.`vaccine_name` AS `vaccine_name`,`vaccine`.`vaccine_expiry_date` AS `vaccine_expiry_date` from `vaccine` order by `vaccine`.`vaccine_expiry_date` */;
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

-- Dump completed on 2026-02-25 23:33:54
