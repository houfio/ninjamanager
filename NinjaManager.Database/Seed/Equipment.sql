SET IDENTITY_INSERT dbo.Equipment ON;

MERGE INTO dbo.Equipment AS Target
USING (VALUES
	(1, 'Paper Mask', 300, 10, 10, 20, 'Head'),
	(2, 'Fabric Cap', 600, 20, 20, 15, 'Head'),
	(3, 'Plastic Helmet', 1200, 50, 25, 10, 'Head'),
	(4, 'Fabric Cape', 250, 5, 15, -10, 'Shoulders'),
	(5, 'Fabric Brace', 500, 15, 15, 20, 'Shoulders'),
	(6, 'Leather Armor', 900, 35, 20, 10, 'Shoulders'),
	(7, 'Leather Jacket', 400, 25, -5, 15, 'Chest'),
	(8, 'Fabric Suit', 700, 30, 20, 10, 'Chest'),
	(9, 'Chainmail', 1300, 70, 25, -10, 'Chest'),
	(10, 'Fanny Pack', 100, 10, -20, 15, 'Belt'),
	(11, 'Toolbelt', 300, 15, 5, 25, 'Belt'),
	(12, 'Leather Belt', 600, 25, 10, 20, 'Belt'),
	(13, 'Fabric Joggers', 400, 10, 0, 25, 'Legs'),
	(15, 'Leather Jeans', 600, 20, 20, 20, 'Legs'),
	(16, 'Cargo Pants', 1200, 50, 25, 10, 'Legs'),
	(17, 'Flip Flops', 100, 0, 10, -10, 'Boots'),
	(18, 'Plastic Boots', 300, 20, 10, 5, 'Boots'),
	(19, 'Sport Shoes', 900, 20, 10, 40, 'Boots')
)
AS Source (Id, Name, Price, Strength, Intelligence, Agility, Category)
ON Target.Id = Source.Id
WHEN MATCHED THEN
	UPDATE SET 
		Name = Source.Name,
		Price = Source.Price,
		Strength = Source.Strength,
		Intelligence = Source.Intelligence,
		Agility = Source.Agility,
		Category = Source.Category
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, Name, Price, Strength, Intelligence, Agility, Category)
	VALUES (Id, Name, Price, Strength, Intelligence, Agility, Category)
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT dbo.Equipment OFF;
