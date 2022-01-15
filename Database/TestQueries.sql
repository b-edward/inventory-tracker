USE inventory;

SELECT * FROM `Product`;
SELECT * FROM `Item`;
SELECT * FROM `Warehouse`;
SELECT * FROM `WarehouseItem`;

INSERT INTO `Product` (`productName`, `isActive`) VALUES ('USS Defiant', 1), ('USS Ganges', 1), ('Odo Bucket', 1);

SELECT * FROM `Product` WHERE `isActive`=1;

INSERT INTO `Product` (`productName`, `isActive`) VALUES ('Defiant', 1); 
    
UPDATE `Product` SET productName='Self-Sealing Stem Bolt' WHERE productID=2;

DELETE from `Warehouse` WHERE warehouseID > 4;

-- Inventory Table = ItemID, ProductName, WarehouseCity, WarehouseID
SELECT Item.itemID, Product.productName, Warehouse.city, Warehouse.warehouseID FROM Item
LEFT JOIN Product ON Item.productID = Product.productID
LEFT JOIN WarehouseItem ON Item.itemID = WarehouseItem.itemID
LEFT JOIN Warehouse ON WarehouseItem.warehouseID = Warehouse.warehouseID;

-- RDB Exam sample
SELECT players.firstName AS `Player First Name`, players.lastName AS `Player Last Name`,
players.position AS `Player Position`, players.skillLevel AS `Player Skill Level`, 
teams.teamName AS `Team Name`, CONCAT(coaches.firstName, " ", coaches.lastName) AS `Team Coach`
FROM teams
LEFT JOIN teamplayers ON teams.teamID = teamplayers.teamID
LEFT JOIN players ON teamplayers.playerID = players.playerID
LEFT JOIN coaches ON teams.coachID = coaches.coachID;


use quiz;
SELECT QuestionAnswers.questionID, QuestionAnswers.answerID, QuestionAnswers.isCorrect, Answers.answerText FROM Answers 
LEFT JOIN QuestionAnswers ON Answers.answerID = QuestionAnswers.answerID WHERE questionID=3;