USE inventory;

SELECT * FROM `Product`;
SELECT * FROM `Item`;
SELECT * FROM `Warehouse`;
SELECT * FROM `WarehouseItem`;


SELECT * FROM `Product` WHERE `isActive`=1;

INSERT INTO `Product` (`productName`, `isActive`) VALUES ('Jadzia', 1); 
    
UPDATE `Product` SET productName='Self-Sealing Stem Bolt' WHERE productID=2;

DELETE from `Product` WHERE productName='';