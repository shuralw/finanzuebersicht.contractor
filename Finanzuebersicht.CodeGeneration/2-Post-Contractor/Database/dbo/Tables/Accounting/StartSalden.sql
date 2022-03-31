CREATE TABLE [dbo].[StartSalden] (
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
	[EmailUserId]	   UNIQUEIDENTIFIER NOT NULL,
	[Betrag]               FLOAT            NOT NULL,
	[DatumAm]              DATETIME         NOT NULL,
    CONSTRAINT [PK_StartSalden_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StartSalden_EmailUserId] FOREIGN KEY ([EmailUserId]) REFERENCES [dbo].[EmailUsers] ([Id]),
);

GO
