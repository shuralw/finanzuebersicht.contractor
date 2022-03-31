CREATE TABLE [dbo].[AdminAccessTokenAdminAdGroupRelations] (
    [AdminAccessTokenId]    UNIQUEIDENTIFIER NOT NULL,
    [AdminAdGroupId]               UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_AdminAccessTokenAdminAdGroupRelations_Token_AdminAdGroupId] PRIMARY KEY CLUSTERED ([AdminAccessTokenId] ASC, [AdminAdGroupId] ASC),
    CONSTRAINT [FK_AdminAccessTokenAdminAdGroupRelations_AdminAccessTokenId] FOREIGN KEY ([AdminAccessTokenId]) REFERENCES [dbo].[AdminAccessTokens] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AdminAccessTokenAdminAdGroupRelations_AdminAdGroupId] FOREIGN KEY ([AdminAdGroupId]) REFERENCES [dbo].[AdminAdGroups] ([Id])
);


