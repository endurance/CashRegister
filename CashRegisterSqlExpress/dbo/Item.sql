﻿CREATE TABLE [dbo].[Item]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NCHAR(500) NOT NULL, 
    [Description] NCHAR(500) NOT NULL, 
    [CompanyName] NCHAR(500) NULL 
)
