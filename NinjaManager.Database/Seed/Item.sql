SET IDENTITY_INSERT Item ON

MERGE INTO dbo.Item AS Target  
USING (values 
	(1, 'Sword', 300, 1),
	(2, 'Chestplate', 500, 2),
	(3, 'Pants', 200, 3)
) AS Source (Id, Name, Price, CategoryId)  
ON Target.Id = Source.Id  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (Id, Name, Price, CategoryId)  
	VALUES (Id, Name, Price, CategoryId)  
WHEN MATCHED THEN
	UPDATE SET
		Name = Source.Name,
		Price = Source.Price,
		CategoryId = Source.CategoryId;

SET IDENTITY_INSERT Ninja OFF
