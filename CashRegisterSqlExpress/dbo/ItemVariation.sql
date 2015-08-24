CREATE TABLE [dbo].[ItemVariation]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Sku] VARCHAR(50) NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    [Ordinal] INT NOT NULL, 
    [Price] MONEY NOT NULL, 
    [ItemId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_ItemVariation_To_Item] FOREIGN KEY ([ItemId]) REFERENCES [Item]([Id]) 
)
