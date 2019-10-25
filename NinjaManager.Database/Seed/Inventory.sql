SET IDENTITY_INSERT dbo.Inventory ON;

MERGE INTO dbo.Inventory AS Target
USING (VALUES
	(1, 1, 1)
)
AS Source (Id, NinjaId, EquipmentId)
ON Target.Id = Source.Id
WHEN MATCHED THEN
	UPDATE SET 
		NinjaId = Source.NinjaId,
		EquipmentId = Source.EquipmentId
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, NinjaId, EquipmentId)
	VALUES (Id, NinjaId, EquipmentId)
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT dbo.Inventory OFF;
