CREATE TABLE [dbo].[AdminAdGroups] 
(
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [DN]           NVARCHAR (256)   NOT NULL, 
    CONSTRAINT [PK_AdminAdGroups_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
);
