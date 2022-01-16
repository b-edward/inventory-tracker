CREATE DATABASE IF NOT EXISTS inventory;
USE inventory;

-- Reset tables

DROP TABLE IF EXISTS `WarehouseItem`;
DROP TABLE IF EXISTS `Warehouse`;
DROP TABLE IF EXISTS `Item`;
DROP TABLE IF EXISTS `Product`;

-- Create new tables

CREATE TABLE IF NOT EXISTS `Product` (
  `productID` INT NOT NULL AUTO_INCREMENT,
  `productName` VARCHAR(255) NOT NULL,
  `isActive` TINYINT NOT NULL DEFAULT 1,
  PRIMARY KEY (`productID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS `Item` (
  `itemID` INT NOT NULL AUTO_INCREMENT,
  `productID` INT NOT NULL,
  `isAssigned` TINYINT NOT NULL DEFAULT 0,
  `isSold` TINYINT NOT NULL DEFAULT 0, 
  PRIMARY KEY (`itemID`),
  FOREIGN KEY (`productID`) REFERENCES `Product` (`productID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS `Warehouse` (
  `warehouseID` INT NOT NULL AUTO_INCREMENT,
  `streetAndNo` VARCHAR(255) NOT NULL UNIQUE,
  `city` VARCHAR(255) NOT NULL,
  `provinceOrState` VARCHAR(255) NOT NULL,
  `country` VARCHAR(255) NOT NULL,
  `postalCode` VARCHAR(255) NOT NULL,
  `isActive` TINYINT NOT NULL DEFAULT 0,
  PRIMARY KEY (`warehouseID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

  CREATE TABLE IF NOT EXISTS `WarehouseItem` (
  `warehouseID` INT NOT NULL,  
  `itemID` INT NOT NULL,
  PRIMARY KEY (`warehouseID`, `itemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


  

-- Insert initial data  
    
INSERT INTO `Product` (`productName`, `isActive`) VALUES
	('Yamok Sauce', 1),    
	('Self-sealing stem bolt', 1),    
	('Bajoran dirt', 1),    
	('Latinum', 0),    
	('Noh-Jay coffee mug', 1);

INSERT INTO `Item` (`productID`, `isAssigned`) VALUES
	(1, 1),    
	(2, 1),    
	(3, 1),    
	(2, 1),    
	(5, 1),
	(1, 1),
	(1, 1),
	(1, 1),
	(1, 0),
	(1, 0);
    
INSERT INTO `Warehouse` (`streetAndNo`, `city`, `provinceOrState`, `country`, `postalCode`, `isActive`) VALUES
	('9 Alpha Street', 'Jalanda City', 'DK', 'Bajor', 'STDS9', '1'),
	('5 Yonge Street', 'Toronto', 'ON', 'Canada', 'M5E 1J1', '0'),
	('108 University Avenue', 'Waterloo', 'ON', 'Canada', 'N2J 2W2', '1'), 
	('1280 Main Street West', 'Hamilton', 'ON', 'Canada', 'L8S 4K1', '1'),
	('183 Thompson St', 'New York', 'NY', 'USA', '10012', '1');
    
INSERT INTO `WarehouseItem` (`warehouseID`, `itemID`) VALUES
	(1, 1),    
	(5, 2),    
	(3, 3),    
	(4, 4),    
	(5, 5),
	(1, 6),
	(1, 7),
	(3, 8),
	(9, 9),
	(10, 10);
    
    

