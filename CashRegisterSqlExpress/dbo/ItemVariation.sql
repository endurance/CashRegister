CREATE TABLE [dbo].[ItemVariation]
(
	[VariationId]		UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
	[ItemId]			UNIQUEIDENTIFIER NOT NULL, 
    [SupplierId]		UNIQUEIDENTIFIER NULL, 
    [VariationSku]		VARCHAR(50) NOT NULL, 
    [VariationName]		VARCHAR(50) NOT NULL, 
    [VariationOrdinal]	INT NOT NULL, 
    [VariationPrice]	MONEY NOT NULL,  
    CONSTRAINT [FK_ItemVariation_To_Item] FOREIGN KEY ([ItemId]) REFERENCES [Item]([ItemId]) 
)
