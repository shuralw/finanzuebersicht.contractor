CREATE TABLE [dbo].[StartSalden] (
    [Id]					UNIQUEIDENTIFIER NOT NULL,
	[EmailUserId]			UNIQUEIDENTIFIER UNIQUE NOT NULL,
	[Betrag]				DECIMAL(8,2)     NOT NULL,
	[AmDatum]				DATETIME         NOT NULL,
    CONSTRAINT [PK_StartSalden_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StartSalden_EmailUserId] FOREIGN KEY ([EmailUserId]) REFERENCES [dbo].[AdminEmailUsers] ([Id]),
);

GO
