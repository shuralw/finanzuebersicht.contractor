CREATE TABLE [dbo].[CategorySearchTerms] (
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
	[EmailUserId]	   UNIQUEIDENTIFIER NOT NULL,
	[CategoryId]           UNIQUEIDENTIFIER NOT NULL,
	[Term]                 NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_CategorySearchTerms_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CategorySearchTerms_EmailUserId] FOREIGN KEY ([EmailUserId]) REFERENCES [dbo].[AdminEmailUsers] ([Id]),
    CONSTRAINT [FK_CategorySearchTerms_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]),
);

GO
