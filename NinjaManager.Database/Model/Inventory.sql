CREATE TABLE [dbo].[Inventory]
(
    [NinjaId] INT NOT NULL, 
    [EquipmentId] INT NOT NULL, 
    CONSTRAINT [FK_InventoryItem_Ninja] FOREIGN KEY ([NinjaId]) REFERENCES [Ninja]([Id]), 
    CONSTRAINT [FK_InventoryItem_Equipment] FOREIGN KEY ([EquipmentId]) REFERENCES [Equipment]([Id]), 
    CONSTRAINT [PK_Inventory] PRIMARY KEY ([EquipmentId], [NinjaId])
)
