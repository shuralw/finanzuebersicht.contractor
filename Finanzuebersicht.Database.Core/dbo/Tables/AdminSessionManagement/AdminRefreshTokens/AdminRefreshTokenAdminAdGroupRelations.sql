CREATE TABLE [dbo].[AdminRefreshTokenAdminAdGroupRelations] (
    [AdminRefreshTokenId]    UNIQUEIDENTIFIER NOT NULL,
    [AdminAdGroupId]         UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_AdminRefreshTokenAdminAdGroupRelations_AdminRefreshTokenId_AdminAdGroupId] PRIMARY KEY CLUSTERED ([AdminRefreshTokenId] ASC, [AdminAdGroupId] ASC),
    CONSTRAINT [FK_AdminRefreshTokenAdminAdGroupRelations_AdminRefreshTokenId] FOREIGN KEY ([AdminRefreshTokenId]) REFERENCES [dbo].[AdminRefreshTokens] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AdminRefreshTokenAdminAdGroupRelations_AdminAdGroupId] FOREIGN KEY ([AdminAdGroupId]) REFERENCES [dbo].[AdminAdGroups] ([Id]) ON DELETE CASCADE
);


