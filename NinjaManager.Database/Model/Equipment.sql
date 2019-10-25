CREATE TABLE [dbo].[Equipment]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Price] INT NOT NULL, 
    [Strength] INT NOT NULL, 
    [Intelligence] INT NOT NULL, 
    [Agility] INT NOT NULL, 
    [Category] NVARCHAR(50) NOT NULL 
)
