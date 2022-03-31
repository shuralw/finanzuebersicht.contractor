CREATE TABLE [dbo].[AdminAccessTokens] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [AdminRefreshTokenId]    UNIQUEIDENTIFIER NOT NULL,
    [AdminEmailUserId]       UNIQUEIDENTIFIER NULL,
    [AdminAdUserId]          UNIQUEIDENTIFIER NULL,
    [Username]          NVARCHAR (256)   NOT NULL,
    [ExpiresOn]         DATETIME         NOT NULL,
    CONSTRAINT [PK_AdminAccessTokens_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AdminAccessTokens_AdminRefreshTokenId] FOREIGN KEY ([AdminRefreshTokenId]) REFERENCES [dbo].[AdminRefreshTokens] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AdminAccessTokens_AdminEmailUserId] FOREIGN KEY ([AdminEmailUserId]) REFERENCES [dbo].[AdminEmailUsers] ([Id]),
    CONSTRAINT [FK_AdminAccessTokens_AdminAdUserId] FOREIGN KEY ([AdminAdUserId]) REFERENCES [dbo].[AdminAdUsers] ([Id])
);








