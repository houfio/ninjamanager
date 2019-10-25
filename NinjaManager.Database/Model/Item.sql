CREATE TABLE [dbo].[Item]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Price] INT NOT NULL, 
    [Strength] INT NOT NULL, 
    [Intelligence] INT NOT NULL, 
    [Agility] INT NOT NULL, 
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [FK_Item_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]) 
)
