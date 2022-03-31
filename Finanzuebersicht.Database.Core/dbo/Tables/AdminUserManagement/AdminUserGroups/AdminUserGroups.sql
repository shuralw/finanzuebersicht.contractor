CREATE TABLE [dbo].[AdminUserGroups] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Name]         NVARCHAR (256)   NOT NULL,
    CONSTRAINT [PK_AdminUserGroups_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
);


