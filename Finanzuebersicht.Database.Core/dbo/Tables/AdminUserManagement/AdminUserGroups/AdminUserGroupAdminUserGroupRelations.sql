CREATE TABLE [dbo].[AdminUserGroupAdminUserGroupRelations] (
    [MemberId] UNIQUEIDENTIFIER NOT NULL,
    [ParentId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_AdminUserGroupAdminUserGroupRelation_MemberId_ParentId] PRIMARY KEY CLUSTERED ([MemberId] ASC, [ParentId] ASC),
    CONSTRAINT [FK_AdminUserGroupAdminUserGroupRelation_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[AdminUserGroups] ([Id]),
    CONSTRAINT [FK_AdminUserGroupAdminUserGroupRelation_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[AdminUserGroups] ([Id])
);
GO

-- Da es ist nicht möglich Cascading Deletion auf many-to-many-Relationships der selben Tabelle zu erzeugen, hier dieser Trigger.
CREATE TRIGGER [dbo].[AdminUserGroupAdminUserGroupRelationsOnMemberDelete]
ON [AdminUserGroups]
FOR DELETE
AS
	DECLARE	@AdminUserGroupToDeleteId UNIQUEIDENTIFIER
	SELECT	@AdminUserGroupToDeleteId = Id
	FROM	Deleted

	DELETE FROM [AdminUserGroupAdminUserGroupRelations]
	WHERE  MemberId = @AdminUserGroupToDeleteId
	OR  ParentId = @AdminUserGroupToDeleteId
GO

