CREATE TABLE [dbo].[Item]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NCHAR(500) NOT NULL, 
    [Description] NCHAR(500) NOT NULL, 
    [Variations] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Item_To_ItemVariation] FOREIGN KEY ([Variations]) REFERENCES [ItemVariation]([Id])
)
