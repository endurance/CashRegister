CREATE TABLE [dbo].[Item]
(
	[ItemId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
	[ItemCompanyName] NCHAR(500) NULL, 
    [ItemBrandName] NCHAR(500) NOT NULL, 
    [ItemDescription] NCHAR(500) NOT NULL
    
)
