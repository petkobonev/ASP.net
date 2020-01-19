CREATE TABLE [dbo].[Model] (
    [ID]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (MAX) NOT NULL,
    [Brand] INT            NOT NULL,
    CONSTRAINT [PK_Models] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Models_Brand] FOREIGN KEY ([Brand]) REFERENCES [dbo].[Brand] ([ID]) ON DELETE CASCADE
);

