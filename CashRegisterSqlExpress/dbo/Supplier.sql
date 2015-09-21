CREATE TABLE [dbo].[Supplier]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(200) NOT NULL, 
    [Description] VARCHAR(200) NULL, 
    [Address1] VARCHAR(200) NULL, 
    [Address2] VARCHAR(200) NOT NULL, 
    [MainPhoneNumber] VARCHAR(25) NULL, 
    [AlternatePhoneNumber] VARCHAR(25) NOT NULL
)
