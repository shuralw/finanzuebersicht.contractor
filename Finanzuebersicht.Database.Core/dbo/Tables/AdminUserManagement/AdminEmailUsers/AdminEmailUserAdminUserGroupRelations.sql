CREATE TABLE [dbo].[AdminEmailUserAdminUserGroupRelations] (
    [MemberId] UNIQUEIDENTIFIER NOT NULL,
    [ParentId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_AdminEmailUserAdminUserGroupRelation_MemberId_ParentId] PRIMARY KEY CLUSTERED ([MemberId] ASC, [ParentId] ASC),
    CONSTRAINT [FK_AdminEmailUserAdminUserGroupRelation_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[AdminEmailUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AdminEmailUserAdminUserGroupRelation_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[AdminUserGroups] ([Id]) ON DELETE CASCADE
);


