-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.7.3-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para tip
CREATE DATABASE IF NOT EXISTS `tip` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_spanish_ci */;
USE `tip`;

-- Volcando estructura para tabla tip.department
CREATE TABLE IF NOT EXISTS `department` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `created_by` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  `created_date` datetime NOT NULL DEFAULT current_timestamp(),
  `modified_by` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  `modified_date` datetime NOT NULL DEFAULT current_timestamp(),
  `status` bit(1) NOT NULL DEFAULT b'1',
  `description` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  `name` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  `phone` varchar(32) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  `id_enterprise` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_enterp_department` (`id_enterprise`),
  CONSTRAINT `fk_enterp_department` FOREIGN KEY (`id_enterprise`) REFERENCES `enterprise` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- Volcando datos para la tabla tip.department: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` (`id`, `created_by`, `created_date`, `modified_by`, `modified_date`, `status`, `description`, `name`, `phone`, `id_enterprise`) VALUES
	(1, 'guido.guerrero', '2022-03-07 15:42:38', 'guido.guerrero', '2022-03-07 15:42:42', b'1', 'Dept 1', 'Department 1', '593', 1);
/*!40000 ALTER TABLE `department` ENABLE KEYS */;

-- Volcando estructura para tabla tip.department_employee
CREATE TABLE IF NOT EXISTS `department_employee` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `created_by` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  `created_date` datetime NOT NULL DEFAULT current_timestamp(),
  `modified_by` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  `modified_date` datetime NOT NULL DEFAULT current_timestamp(),
  `status` bit(1) NOT NULL DEFAULT b'1',
  `id_department` int(11) NOT NULL,
  `id_employee` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_dept_deptemployee` (`id_department`),
  KEY `fk_emp_deptemployee` (`id_employee`),
  CONSTRAINT `fk_dept_deptemployee` FOREIGN KEY (`id_department`) REFERENCES `department` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_emp_deptemployee` FOREIGN KEY (`id_employee`) REFERENCES `employee` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- Volcando datos para la tabla tip.department_employee: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `department_employee` DISABLE KEYS */;
INSERT INTO `department_employee` (`id`, `created_by`, `created_date`, `modified_by`, `modified_date`, `status`, `id_department`, `id_employee`) VALUES
	(1, 'guido.guerrero', '2022-03-07 15:46:06', 'guido.guerrero', '2022-03-07 15:46:11', b'1', 1, 1);
/*!40000 ALTER TABLE `department_employee` ENABLE KEYS */;

-- Volcando estructura para tabla tip.employee
CREATE TABLE IF NOT EXISTS `employee` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `created_by` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  `created_date` datetime NOT NULL DEFAULT current_timestamp(),
  `modified_by` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  `modified_date` datetime NOT NULL DEFAULT current_timestamp(),
  `status` bit(1) NOT NULL DEFAULT b'1',
  `birth_date` datetime NOT NULL,
  `email` varchar(64) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  `name` varchar(64) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  `surname` varchar(64) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  `position` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- Volcando datos para la tabla tip.employee: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` (`id`, `created_by`, `created_date`, `modified_by`, `modified_date`, `status`, `birth_date`, `email`, `name`, `surname`, `position`) VALUES
	(1, 'guido.guerrero', '2022-03-07 15:45:06', 'guido.guerrero', '2022-03-07 15:45:11', b'1', '2001-03-07 15:45:14', 'guido_guerrero_d@hotmail.com', 'Guido', 'Guerrero', 'FS Dev');
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;

-- Volcando estructura para tabla tip.enterprise
CREATE TABLE IF NOT EXISTS `enterprise` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `created_by` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  `created_date` datetime NOT NULL DEFAULT current_timestamp(),
  `modified_by` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  `modified_date` datetime NOT NULL DEFAULT current_timestamp(),
  `status` bit(1) NOT NULL DEFAULT b'1',
  `address` varchar(256) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  `name` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  `phone` varchar(32) COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- Volcando datos para la tabla tip.enterprise: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `enterprise` DISABLE KEYS */;
INSERT INTO `enterprise` (`id`, `created_by`, `created_date`, `modified_by`, `modified_date`, `status`, `address`, `name`, `phone`) VALUES
	(1, 'guido.guerrero', '2022-03-07 15:41:41', 'guido.guerrero', '2022-03-07 15:41:51', b'1', 'Home', 'Enterprise 1', '593 2589453215'),
	(2, 'guido.guerrero', '2022-03-08 15:41:41', 'guido.guerrero', '2022-03-08 15:41:51', b'1', 'Quito', 'Enterprise 2', '593 '),
	(3, 'gguerrero', '2022-03-09 23:35:38', 'gguerrero', '2022-03-09 23:35:38', b'1', 'Ambato', 'Sede matrix', '234234');
/*!40000 ALTER TABLE `enterprise` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
