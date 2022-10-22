CREATE TABLE [dbo].[Shopkeeper] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (50) NOT NULL,
    [Address]          NVARCHAR (50) NOT NULL,
    [mobileNo]         NUMERIC(10)  NOT NULL,
    [City]             NVARCHAR (20) NOT NULL,
    [Password]         NVARCHAR (8)  NOT NULL,
    [HasResetPassword] BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

