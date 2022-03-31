CREATE TABLE [dbo].[AdminAdUserAdminUserGroupRelations] (
    [MemberId] UNIQUEIDENTIFIER NOT NULL,
    [ParentId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_AdminAdUserAdminUserGroupRelation_MemberId_ParentId] PRIMARY KEY CLUSTERED ([MemberId] ASC, [ParentId] ASC),
    CONSTRAINT [FK_AdminAdUserAdminUserGroupRelation_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[AdminAdUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AdminAdUserAdminUserGroupRelation_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[AdminUserGroups] ([Id]) ON DELETE CASCADE
);


