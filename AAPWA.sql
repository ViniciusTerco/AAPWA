-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: buffetdb
-- ------------------------------------------------------
-- Server version	5.7.24

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
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` char(36) NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4,
  `ClaimValue` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroles` (
  `Id` char(36) NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` char(36) NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4,
  `ClaimValue` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ProviderKey` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4,
  `UserId` char(36) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` char(36) NOT NULL,
  `RoleId` char(36) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `Id` char(36) NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4,
  `SecurityStamp` longtext CHARACTER SET utf8mb4,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4,
  `PhoneNumber` longtext CHARACTER SET utf8mb4,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('08d91a6f-5ce6-4619-8e0b-248aa70f4af4','vinicius.terco@viannasempre.com.br','VINICIUS.TERCO@VIANNASEMPRE.COM.BR','vinicius.terco@viannasempre.com.br','VINICIUS.TERCO@VIANNASEMPRE.COM.BR',0,'AQAAAAEAACcQAAAAEJAbdbwQ8zdlmSSEUQnRB4ml5jlD1YhBQFWFChe/92EMlYoFrhgoRItE+DqU/4TQiA==','3ESPG6U7WTMTDBCWCQUOL35MS42QIODK','23e71771-4d2a-4716-b168-b0b62bd18b1d',NULL,0,0,NULL,1,0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` char(36) NOT NULL,
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `idCliente` int(11) NOT NULL AUTO_INCREMENT,
  `tipo` varchar(45) DEFAULT NULL,
  `documento` int(11) DEFAULT NULL,
  `dataNascimento` datetime DEFAULT NULL,
  `nome` varchar(45) DEFAULT NULL,
  `endereco` varchar(45) DEFAULT NULL,
  `observacao` varchar(200) DEFAULT NULL,
  `dataInclusao` datetime DEFAULT NULL,
  `dataModificacao` datetime DEFAULT NULL,
  `idEvento` int(11) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idCliente`),
  KEY `idEvento_idx` (`idEvento`),
  CONSTRAINT `idEvento` FOREIGN KEY (`idEvento`) REFERENCES `evento` (`idevento`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientetipo`
--

DROP TABLE IF EXISTS `clientetipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientetipo` (
  `idclienteTipo` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idclienteTipo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientetipo`
--

LOCK TABLES `clientetipo` WRITE;
/*!40000 ALTER TABLE `clientetipo` DISABLE KEYS */;
/*!40000 ALTER TABLE `clientetipo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `convidado`
--

DROP TABLE IF EXISTS `convidado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `convidado` (
  `idconvidado` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `documento` int(11) DEFAULT NULL,
  `dataNascimento` datetime DEFAULT NULL,
  `idEvento` int(11) DEFAULT NULL,
  `idConvidadoSituacao` int(11) DEFAULT NULL,
  `observacao` varchar(200) DEFAULT NULL,
  `dataInclusao` datetime DEFAULT NULL,
  `dataModificacao` datetime DEFAULT NULL,
  PRIMARY KEY (`idconvidado`),
  KEY `idEvento_idx` (`idEvento`),
  KEY `idConvidadoSituacao_idx` (`idConvidadoSituacao`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `convidado`
--

LOCK TABLES `convidado` WRITE;
/*!40000 ALTER TABLE `convidado` DISABLE KEYS */;
/*!40000 ALTER TABLE `convidado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `convidadosituacao`
--

DROP TABLE IF EXISTS `convidadosituacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `convidadosituacao` (
  `idconvidadosituacao` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idconvidadosituacao`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `convidadosituacao`
--

LOCK TABLES `convidadosituacao` WRITE;
/*!40000 ALTER TABLE `convidadosituacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `convidadosituacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `evento`
--

DROP TABLE IF EXISTS `evento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `evento` (
  `idevento` int(11) NOT NULL AUTO_INCREMENT,
  `idEventoTipo` int(11) DEFAULT NULL,
  `descricao` varchar(45) DEFAULT NULL,
  `dataInicio` datetime DEFAULT NULL,
  `dataFim` datetime DEFAULT NULL,
  `horaInicial` varchar(45) DEFAULT NULL,
  `horaFinal` varchar(45) DEFAULT NULL,
  `idEventoSituacao` int(11) DEFAULT NULL,
  `descricaolocal` varchar(45) DEFAULT NULL,
  `endereco` varchar(45) DEFAULT NULL,
  `observacao` varchar(45) DEFAULT NULL,
  `dataInclusao` datetime DEFAULT NULL,
  `dataModificacao` datetime DEFAULT NULL,
  PRIMARY KEY (`idevento`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evento`
--

LOCK TABLES `evento` WRITE;
/*!40000 ALTER TABLE `evento` DISABLE KEYS */;
/*!40000 ALTER TABLE `evento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventosituacao`
--

DROP TABLE IF EXISTS `eventosituacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `eventosituacao` (
  `ideventosituacao` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ideventosituacao`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventosituacao`
--

LOCK TABLES `eventosituacao` WRITE;
/*!40000 ALTER TABLE `eventosituacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `eventosituacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventotipo`
--

DROP TABLE IF EXISTS `eventotipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `eventotipo` (
  `ideventotipo` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ideventotipo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventotipo`
--

LOCK TABLES `eventotipo` WRITE;
/*!40000 ALTER TABLE `eventotipo` DISABLE KEYS */;
/*!40000 ALTER TABLE `eventotipo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'buffetdb'
--

--
-- Dumping routines for database 'buffetdb'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-05-19 22:02:30
