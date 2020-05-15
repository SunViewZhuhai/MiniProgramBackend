-- MySQL dump 10.13  Distrib 5.7.25, for Win64 (x86_64)
--
-- Host: localhost    Database: miniprogram
-- ------------------------------------------------------
-- Server version	5.7.25-log

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
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `OrderDate` datetime DEFAULT NULL,
  `Amount` double DEFAULT NULL,
  `PrepayerId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  KEY `order_user_fk_idx` (`PrepayerId`),
  CONSTRAINT `order_user_fk` FOREIGN KEY (`PrepayerId`) REFERENCES `user` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=68 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES (63,'2020-05-09 11:49:36',0,1),(64,'2020-05-11 13:49:57',0,1),(65,'2020-05-12 13:49:59',0,1),(66,'2020-05-13 13:50:00',0,1),(67,'2020-05-14 13:50:01',0,1);
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_item`
--

DROP TABLE IF EXISTS `order_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_item` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `OrderItemName` varchar(255) DEFAULT NULL,
  `Price` double DEFAULT NULL,
  `ConsumerId` int(11) DEFAULT NULL,
  `OrderId` int(11) NOT NULL,
  `CategoryId` int(11) DEFAULT NULL,
  `IsPay` tinyint(1) unsigned zerofill DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  KEY `order_item_order_fk` (`OrderId`) USING BTREE,
  KEY `order_item_user_fk` (`ConsumerId`) USING BTREE,
  KEY `order_item_category_fk` (`CategoryId`) USING BTREE,
  CONSTRAINT `order_item_category_fk` FOREIGN KEY (`CategoryId`) REFERENCES `order_item_category` (`Id`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `order_item_order_fk` FOREIGN KEY (`OrderId`) REFERENCES `order` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `order_item_user_fk` FOREIGN KEY (`ConsumerId`) REFERENCES `user` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_item`
--

LOCK TABLES `order_item` WRITE;
/*!40000 ALTER TABLE `order_item` DISABLE KEYS */;
INSERT INTO `order_item` VALUES (1,'',23,1,63,1,0),(2,'',17,1,63,2,0),(3,'',29,1,64,1,0),(4,'',17,1,64,2,0),(5,'',23,1,65,1,0),(6,'',21,1,66,1,0),(7,'',20,1,66,2,0),(8,'',3.5,1,66,3,0),(9,'',21,1,67,1,0),(10,'',17,1,67,2,0);
/*!40000 ALTER TABLE `order_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_item_category`
--

DROP TABLE IF EXISTS `order_item_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_item_category` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Category` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_item_category`
--

LOCK TABLES `order_item_category` WRITE;
/*!40000 ALTER TABLE `order_item_category` DISABLE KEYS */;
INSERT INTO `order_item_category` VALUES (1,'餐食'),(2,'饮料'),(3,'其他'),(4,'测试');
/*!40000 ALTER TABLE `order_item_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Signature` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'user1',''),(2,'user2',''),(3,'user3',''),(4,'user4','');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-15 13:57:17
