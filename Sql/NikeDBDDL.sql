-- Create DB
CREATE DATABASE IF NOT EXISTS nike;
USE nike;

-- Create country Table
CREATE TABLE `country` (
  `id` INT AUTO_INCREMENT,
  `Name` VARCHAR(50) UNIQUE NOT NULL,
  CONSTRAINT PK_country PRIMARY KEY (`id`)
);

-- Create department Table
CREATE TABLE `department` (
  `Id` INT AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `fkIdCountry` INT(11) NOT NULL,
  CONSTRAINT PK_department PRIMARY KEY (`Id`),
  CONSTRAINT FK_counDepar FOREIGN KEY (`fkIdCountry`) REFERENCES `country`(`id`)
);

-- Create city Table
CREATE TABLE `city` (
  `id` INT AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `fkIdDepartment` INT(11) NOT NULL,
  CONSTRAINT PK_city PRIMARY KEY (`id`),
  CONSTRAINT FK_deparCity FOREIGN KEY (`fkIdDepartment`) REFERENCES `department`(`Id`)
);

-- Create prodCategory Table
CREATE TABLE `prodCategory` (
  `id` INT AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  CONSTRAINT PK_prodCategory PRIMARY KEY (`id`)
);

-- Create prodColor Table
CREATE TABLE `prodColor` (
  `id` INT AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  CONSTRAINT PK_prodColor PRIMARY KEY (`id`)
);

-- Create genderType Table
CREATE TABLE `genderType` (
  `id` INT AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  CONSTRAINT PK_genderType PRIMARY KEY (`id`)
);

-- Create product Table
CREATE TABLE `product` (
  `id` INT AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  `fkIdProdCategory` INT(11) NOT NULL,
  `fkIdColor` INT(11) NOT NULL,
  `fkIdtGenderType` INT(11) NOT NULL,
  `fkIdOrderDetail` INT(11) NOT NULL,
  CONSTRAINT PK_product PRIMARY KEY (`id`),
  CONSTRAINT FK_prodCate FOREIGN KEY (`fkIdProdCategory`) REFERENCES `prodCategory`(`id`),
  CONSTRAINT FK_pordColor FOREIGN KEY (`fkIdColor`) REFERENCES `prodColor`(`id`),
  CONSTRAINT FK_prodGenderType FOREIGN KEY (`fkIdtGenderType`) REFERENCES `genderType`(`id`)
);

-- Create contactType Table
CREATE TABLE `contactType` (
  `id` INT AUTO_INCREMENT,
  `Name` VARCHAR(50) UNIQUE NOT NULL,
  CONSTRAINT PK_contactType PRIMARY KEY (`id`)
);

-- Create contact Table
CREATE TABLE `contact` (
  `id` INT AUTO_INCREMENT,
  `number` VARCHAR(30) NOT NULL,
  `fkIdContactType` INT(11) NOT NULL,
  CONSTRAINT PK_contact PRIMARY KEY (`id`),
  CONSTRAINT FK_contConType FOREIGN KEY (`fkIdContactType`) REFERENCES `contactType`(`id`)
);

-- Create addressType Table
CREATE TABLE `addressType` (
  `id` INT AUTO_INCREMENT,
  `name` VARCHAR(50) UNIQUE NOT NULL,
  CONSTRAINT PK_addressType PRIMARY KEY (`id`)
);

-- Create address Table
CREATE TABLE `address` (
  `id` INT AUTO_INCREMENT,
  `description` VARCHAR(50) NOT NULL,
  `complement` VARCHAR(50) NULL,
  `fkIdAddressType` INT(11) NOT NULL,
  `IkIdCity` INT(11) NOT NULL,
  CONSTRAINT PK_address PRIMARY KEY (`id`),
  CONSTRAINT FK_addressAddreType FOREIGN KEY (`fkIdAddressType`) REFERENCES `addressType`(`id`),
  CONSTRAINT FK_addressCity FOREIGN KEY (`IkIdCity`) REFERENCES `city`(`id`)
);

-- Create client Table
CREATE TABLE `client` (
  `id` INT AUTO_INCREMENT,
  `code` VARCHAR(30) NOT NULL UNIQUE,
  `name` VARCHAR(50) NOT NULL,
  `lastName` VARCHAR(50) NOT NULL,
  `age` SMALLINT NOT NULL,
  `email` VARCHAR(50) NOT NULL,
  `creationDate` DATETIME NOT NULL,
  `fkIdContact` INT(11) NOT NULL,
  `fkIdAddress` INT(11) NOT NULL UNIQUE,
  CONSTRAINT PK_client PRIMARY KEY (`id`),
  CONSTRAINT FK_clientContact FOREIGN KEY (`fkIdContact`) REFERENCES `contact`(`id`),
  CONSTRAINT FK_clientAddress FOREIGN KEY (`fkIdAddress`) REFERENCES `address`(`id`)
);

-- Create orderStatus Table
CREATE TABLE `orderStatus` (
  `id` INT AUTO_INCREMENT,
  `Name` VARCHAR(50) UNIQUE NOT NULL,
  CONSTRAINT PK_orderStatus PRIMARY KEY (`id`)
);

-- Create paymentType Table
CREATE TABLE `paymentType` (
  `id` INT AUTO_INCREMENT,
  `Name` VARCHAR(50) UNIQUE NOT NULL,
  CONSTRAINT PK_paymentType PRIMARY KEY (`id`)
);

-- Create order Table
CREATE TABLE `order` (
  `id` INT AUTO_INCREMENT,
  `creationDate` DATETIME NOT NULL,
  `fkIdClient` INT(11) NOT NULL,
  `fkIdStatus` INT(11) NOT NULL,
  `fkIdPaymentType` INT(11) NOT NULL,
  CONSTRAINT PK_order PRIMARY KEY (`id`),
  CONSTRAINT FK_orderClient FOREIGN KEY (`fkIdClient`) REFERENCES `client`(`id`),
  CONSTRAINT FK_orderStatus FOREIGN KEY (`fkIdStatus`) REFERENCES `orderStatus`(`id`),
  CONSTRAINT FK_orderPayType FOREIGN KEY (`fkIdPaymentType`) REFERENCES `paymentType`(`id`)
);

-- Create orderDetail Table
CREATE TABLE `orderDetail` (
  `id` INT AUTO_INCREMENT,
  `fkIdOrder` INT(11) NOT NULL,
  `fkIdProduct` INT(11) NOT NULL,
  CONSTRAINT PK_orderDetail PRIMARY KEY (`id`),
  CONSTRAINT FK_ordeDetProd FOREIGN KEY (`fkIdProduct`) REFERENCES `product`(`id`),
  CONSTRAINT FK_ordeDetOrder FOREIGN KEY (`fkIdOrder`) REFERENCES `order`(`id`)
);

-- Create userRol Table
CREATE TABLE `userRol` (
  `id` INT AUTO_INCREMENT,
  `Name` VARCHAR(50) UNIQUE NOT NULL,
  CONSTRAINT PK_userRol PRIMARY KEY (`id`)
);

-- Create user Table
CREATE TABLE `user` (
  `id` INT AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  `password` VARCHAR(30) NOT NULL,
  `creationDate` DATETIME NOT NULL,
  `fkIdRol` INT(11) NOT NULL,
  `fkIdClient` INT(11) NULL,
  CONSTRAINT PK_user PRIMARY KEY (`id`),
  CONSTRAINT FK_userRol FOREIGN KEY (`fkIdRol`) REFERENCES `userRol`(`id`),
  CONSTRAINT FK_userClient FOREIGN KEY (`fkIdClient`) REFERENCES `client`(`id`)
);

-- Create token Table
CREATE TABLE `token` (
  `id` INT AUTO_INCREMENT,
  `code` VARCHAR(70) NOT NULL UNIQUE,
  `creationDate` DATETIME NOT NULL,
  `fkIdUser` INT(11) NOT NULL ,
  CONSTRAINT PK_token PRIMARY KEY (`id`),
  CONSTRAINT FK_tokenUser FOREIGN KEY (`fkIdUser`) REFERENCES `user`(`id`)
);

