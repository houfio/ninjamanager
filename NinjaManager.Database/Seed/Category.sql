MERGE INTO dbo.Category AS Target
USING (VALUES
	('Head', 0),
	('Shoulders', 1),
	('Chest', 2),
	('Belt', 3),
	('Legs', 4),
	('Boots', 5)
)
AS Source (Name, [Order])
ON Target.Name = Source.Name
WHEN MATCHED THEN
	UPDATE SET 
		Name = Source.Name,
		[Order] = Source.[Order]
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Name, [Order])
	VALUES (Name, [Order])
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;
