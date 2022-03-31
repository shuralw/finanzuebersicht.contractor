CREATE TABLE [dbo].[AdminAdGroupAdminUserGroupRelations] (
    [MemberId] UNIQUEIDENTIFIER NOT NULL,
    [ParentId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_AdminAdGroupAdminUserGroupRelation_MemberId_ParentId] PRIMARY KEY CLUSTERED ([MemberId] ASC, [ParentId] ASC),
    CONSTRAINT [FK_AdminAdGroupAdminUserGroupRelation_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[AdminAdGroups] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AdminAdGroupAdminUserGroupRelation_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[AdminUserGroups] ([Id]) ON DELETE CASCADE
);


