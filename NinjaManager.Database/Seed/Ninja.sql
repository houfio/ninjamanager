﻿SET IDENTITY_INSERT dbo.Ninja ON;

MERGE INTO dbo.Ninja AS Target
USING (VALUES
	(1, 'Mik Rijer', 3000),
	(2, 'Ser Garis', 2500),
	(3, 'Sartijn Muurmans', 3500)
)
AS Source (Id, Name, Gold)
ON Target.Id = Source.Id
WHEN MATCHED THEN
	UPDATE SET 
		Name = Source.Name
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, Name, Gold)
	VALUES (Id, Name, Gold)
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT dbo.Ninja OFF;
