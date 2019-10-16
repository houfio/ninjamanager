CREATE TABLE [dbo].[InventoryItem]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [NinjaId] INT NOT NULL, 
    [ItemId] INT NOT NULL, 
    CONSTRAINT [FK_InventoryItem_Ninja] FOREIGN KEY ([NinjaId]) REFERENCES [Ninja]([Id]), 
    CONSTRAINT [FK_InventoryItem_Item] FOREIGN KEY ([ItemId]) REFERENCES [Item]([Id])
)
