CREATE TABLE [dbo].[Supplier]
(
	[SupplierId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [SupplierName] VARCHAR(200) NOT NULL, 
    [SupplierDescription] VARCHAR(200) NULL, 
    [SupplierAddress1] VARCHAR(200) NULL, 
    [SupplierAddress2] VARCHAR(200) NOT NULL, 
    [SuppierMainPhoneNumber] VARCHAR(25) NULL, 
    [SupplierAlternatePhoneNumber] VARCHAR(25) NOT NULL
)
