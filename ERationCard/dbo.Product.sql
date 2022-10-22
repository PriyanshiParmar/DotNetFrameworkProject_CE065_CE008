CREATE TABLE [dbo].[Product] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (20) NOT NULL,
    [Price] NUMERIC (3)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

