﻿CREATE TABLE [dbo].[Services]
(
	[ServiceId] INT NOT NULL PRIMARY KEY, 
    [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]), 
    [Name] NCHAR(10) NULL, 
    [Description] NVARCHAR(100) NULL, 
    [Duration] NCHAR(10) NULL, 
    [Pricing] DECIMAL NULL,
    [Deleted] BIT NOT NULL DEFAULT 0, 
    [DateDeleted] DATETIME2 NULL , 
    CONSTRAINT FK_Services_TenantID FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)
)
