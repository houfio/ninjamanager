SET IDENTITY_INSERT Category ON

MERGE INTO dbo.Category AS Target  
USING (values 
	(1, 'Weapon'),
	(2, 'Armor')
) AS Source (Id, Name)  
ON Target.Id = Source.Id  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (Id, Name)  
	VALUES (Id, Name)  
WHEN MATCHED THEN
	UPDATE SET
		Name = Source.Name;
SET IDENTITY_INSERT Ninja OFF
