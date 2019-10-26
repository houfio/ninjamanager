CREATE TABLE [dbo].[Category]
(
    [Name] NVARCHAR(50) NOT NULL, 
    [Order] INT NOT NULL, 
    CONSTRAINT [PK_Category] PRIMARY KEY ([Name])
)
