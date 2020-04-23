/*
 Navicat Premium Data Transfer

 Source Server         : HCLjhi20
 Source Server Type    : MySQL
 Source Server Version : 50721
 Source Host           : localhost:3306
 Source Schema         : minigram

 Target Server Type    : MySQL
 Target Server Version : 50721
 File Encoding         : 65001

 Date: 23/04/2020 15:00:14
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for order
-- ----------------------------
DROP TABLE IF EXISTS `order`;
CREATE TABLE `order`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `OrderDate` datetime(0) NULL DEFAULT NULL,
  `Amount` decimal(10, 2) NULL DEFAULT NULL,
  `PrepayerId` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `order_user_fk`(`PrepayerId`) USING BTREE,
  CONSTRAINT `order_user_fk` FOREIGN KEY (`PrepayerId`) REFERENCES `user` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for order_item
-- ----------------------------
DROP TABLE IF EXISTS `order_item`;
CREATE TABLE `order_item`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `OrderItemName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Price` decimal(10, 2) NULL DEFAULT NULL,
  `ConsumerId` int(11) NULL DEFAULT NULL,
  `OrderId` int(11) NOT NULL,
  `CategoryId` int(11) NULL DEFAULT NULL,
  `IsPay` tinyint(1) UNSIGNED ZEROFILL NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `order_item_order_fk`(`OrderId`) USING BTREE,
  INDEX `order_item_user_fk`(`ConsumerId`) USING BTREE,
  INDEX `order_item_category_fk`(`CategoryId`) USING BTREE,
  CONSTRAINT `order_item_category_fk` FOREIGN KEY (`CategoryId`) REFERENCES `order_item_category` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `order_item_order_fk` FOREIGN KEY (`OrderId`) REFERENCES `order` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `order_item_user_fk` FOREIGN KEY (`ConsumerId`) REFERENCES `user` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for order_item_category
-- ----------------------------
DROP TABLE IF EXISTS `order_item_category`;
CREATE TABLE `order_item_category`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Category` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `Signature` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES (1, 'user1', '');
INSERT INTO `user` VALUES (2, 'user2', '');
INSERT INTO `user` VALUES (3, 'user3', '');
INSERT INTO `user` VALUES (4, 'user4', '');

SET FOREIGN_KEY_CHECKS = 1;
