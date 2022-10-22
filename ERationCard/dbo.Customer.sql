CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Gender] NVARCHAR(10) NOT NULL, 
    [DOB] DATETIME NOT NULL, 
    [Address] NVARCHAR(50) NOT NULL, 
    [contactNo] NUMERIC(10) NOT NULL, 
    [city] NVARCHAR(50) NOT NULL
)
