CREATE TABLE [dbo].[Car] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [Owner]      INT            NOT NULL,
    [Model]      INT            NOT NULL,
    [HorsePower] INT            NOT NULL,
    [Year]       DATE           NOT NULL,
    [Color]      NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Cars_Model] FOREIGN KEY ([Model]) REFERENCES [dbo].[Model] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Cars_User] FOREIGN KEY ([Owner]) REFERENCES [dbo].[User] ([ID]) ON DELETE CASCADE
);

