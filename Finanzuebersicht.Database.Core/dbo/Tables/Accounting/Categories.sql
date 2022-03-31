CREATE TABLE [dbo].[Categories] (
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
	[EmailUserId]	   UNIQUEIDENTIFIER NOT NULL,
	[SuperCategoryId]      UNIQUEIDENTIFIER NULL,
	[Title]                NVARCHAR (200)   NOT NULL,
	[Color]                NVARCHAR (30)   NOT NULL,
    CONSTRAINT [PK_Categories_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Categories_EmailUserId] FOREIGN KEY ([EmailUserId]) REFERENCES [dbo].[AdminEmailUsers] ([Id]),
    CONSTRAINT [FK_Categories_SuperCategoryId] FOREIGN KEY ([SuperCategoryId]) REFERENCES [dbo].[Categories] ([Id]),
);

GO
