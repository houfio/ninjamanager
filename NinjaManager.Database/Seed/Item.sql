SET IDENTITY_INSERT dbo.Item ON;

MERGE INTO dbo.Item AS Target
USING (VALUES
	(1, 'Sword', 300, 10, 0, 0, 1),
	(2, 'Chestplate', 500, 0, 10, 0, 2),
	(3, 'Pants', 200, 0, 0, 10, 3)
)
AS Source (Id, Name, Price, Strength, Intelligence, Agility, CategoryId)
ON Target.Id = Source.Id
WHEN MATCHED THEN
	UPDATE SET 
		Name = Source.Name,
		Price = Source.Price,
		Strength = Source.Strength,
		Intelligence = Source.Intelligence,
		Agility = Source.Agility,
		CategoryId = Source.CategoryId
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, Name, Price, Strength, Intelligence, Agility, CategoryId)
	VALUES (Id, Name, Price, Strength, Intelligence, Agility, CategoryId)
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT dbo.Item OFF;
