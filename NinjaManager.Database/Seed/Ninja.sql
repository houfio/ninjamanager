SET IDENTITY_INSERT Ninja ON

MERGE INTO dbo.Ninja AS Target  
USING (values 
	(1, 'Mik Rijer', 1000 ),
	(2, 'Ser Garis', 1000),
	(3, 'Sartijn Muurmans', 1000)
) AS Source (Id, Name, Gold)  
ON Target.Id = Source.Id  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (Id, Name, Gold)  
	VALUES (Id, Name, Gold)  
WHEN MATCHED THEN
	UPDATE SET
		Name = Source.Name;

SET IDENTITY_INSERT Ninja OFF
