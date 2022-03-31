CREATE TABLE [dbo].[AdminAdUsers]
(
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [DN]           NVARCHAR (256)   NOT NULL,
    CONSTRAINT [PK_AdminAdUsers_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
)
