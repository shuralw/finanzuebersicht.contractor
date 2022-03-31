CREATE TABLE [dbo].[AdminRefreshTokens] (
    [Id]                               UNIQUEIDENTIFIER NOT NULL,
    [AdminEmailUserId]                      UNIQUEIDENTIFIER NULL,
    [AdminAdUserId]                         UNIQUEIDENTIFIER NULL,
    [Username]                         NVARCHAR (256)   NOT NULL,
    [ExpiresOn]                        DATETIME         NOT NULL,
    CONSTRAINT [PK_AdminRefreshTokens_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AdminRefreshTokens_AdminEmailUserId] FOREIGN KEY ([AdminEmailUserId]) REFERENCES [dbo].[AdminEmailUsers] ([Id]),
    CONSTRAINT [FK_AdminRefreshTokens_AdminAdUserId] FOREIGN KEY ([AdminAdUserId]) REFERENCES [dbo].[AdminAdUsers] ([Id]) ON DELETE SET NULL
);








