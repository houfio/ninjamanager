CREATE TABLE [dbo].[Inventory]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NinjaId] INT NOT NULL, 
    [EquipmentId] INT NOT NULL, 
    CONSTRAINT [FK_InventoryItem_Ninja] FOREIGN KEY ([NinjaId]) REFERENCES [Ninja]([Id]), 
    CONSTRAINT [FK_InventoryItem_Equipment] FOREIGN KEY ([EquipmentId]) REFERENCES [Equipment]([Id])
)
