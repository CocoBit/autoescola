delimiter $$

CREATE DATABASE `autoescoladb` /*!40100 DEFAULT CHARACTER SET latin1 */$$

delimiter $$

CREATE TABLE `empresa` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CNPJ` varchar(14) NOT NULL,
  `RazaoSocial` varchar(50) NOT NULL,
  `NomeFantasia` varchar(50) DEFAULT NULL,
  `Telefone` varchar(10) DEFAULT NULL,
  `Email` varchar(50) NOT NULL,
  `Site` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1$$

