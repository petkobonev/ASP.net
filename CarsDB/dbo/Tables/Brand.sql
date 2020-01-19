CREATE TABLE [dbo].[Brand] (
    [ID]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX) NOT NULL,
    [Country] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED ([ID] ASC)
);

