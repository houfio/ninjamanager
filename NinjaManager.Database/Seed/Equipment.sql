SET IDENTITY_INSERT dbo.Equipment ON;

MERGE INTO dbo.Equipment AS Target
USING (VALUES
	(1, 'Helmet', 300, 10, 0, 0, 'Head'),
	(2, 'Chestplate', 500, 0, 10, 0, 'Chest'),
	(3, 'Pants', 200, 0, 0, 10, 'Legs')
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
