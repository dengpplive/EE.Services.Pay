/*
MySQL Data Transfer
Source Host: localhost
Source Database: pinganpay
Target Host: localhost
Target Database: pinganpay
Date: 2016/8/12 17:02:13
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for memberinfo
-- ----------------------------
CREATE TABLE `memberinfo` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Status` bit(1) DEFAULT b'0',
  `DealStatus` int(11) DEFAULT '-1',
  `CpFlag` int(11) DEFAULT '1',
  `AcctId` varchar(32) DEFAULT NULL,
  `BankType` int(11) DEFAULT '1',
  `SBankCode` varchar(255) DEFAULT NULL,
  `MobilePhone` varchar(11) DEFAULT NULL,
  `EmailAddr` varchar(50) DEFAULT NULL,
  `RegAddress` varchar(200) DEFAULT NULL,
  `Zip` varchar(50) DEFAULT NULL,
  `ErpAddress` varchar(200) DEFAULT NULL,
  `ContactUser` varchar(20) DEFAULT NULL,
  `SerialNo` varchar(32) DEFAULT NULL,
  `SupAcctId` varchar(32) DEFAULT NULL,
  `CustAcctId` varchar(32) DEFAULT NULL,
  `CustName` varchar(120) DEFAULT NULL,
  `ThirdCustId` varchar(32) DEFAULT NULL,
  `IdType` varchar(2) DEFAULT NULL,
  `IdCode` varchar(20) DEFAULT NULL,
  `CustFlag` varchar(1) DEFAULT NULL,
  `TotalAmount` decimal(9,0) DEFAULT NULL,
  `TotalBalance` decimal(9,0) DEFAULT NULL,
  `TotalFreezeAmount` decimal(9,0) DEFAULT NULL,
  `RelatedAcctId` varchar(32) DEFAULT NULL,
  `AcctFlag` varchar(1) DEFAULT NULL,
  `TranType` varchar(1) DEFAULT NULL,
  `AcctName` varchar(120) DEFAULT NULL,
  `BankCode` varchar(12) DEFAULT NULL,
  `BankName` varchar(120) DEFAULT NULL,
  `Address` varchar(120) DEFAULT NULL,
  `OldRelatedAcctId` varchar(32) DEFAULT NULL,
  `Reserve` varchar(120) DEFAULT NULL,
  `LastOption` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

