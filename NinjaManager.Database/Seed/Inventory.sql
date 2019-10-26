MERGE INTO dbo.Inventory AS Target
USING (VALUES
	(1, 1),
	(1, 11),
	(2, 6),
	(2, 16),
	(2, 17),
	(3, 9)
)
AS Source (NinjaId, EquipmentId)
ON Target.NinjaId = Source.NinjaId AND Target.EquipmentId = Source.EquipmentId
WHEN NOT MATCHED BY TARGET THEN
	INSERT (NinjaId, EquipmentId)
	VALUES (NinjaId, EquipmentId)
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;
