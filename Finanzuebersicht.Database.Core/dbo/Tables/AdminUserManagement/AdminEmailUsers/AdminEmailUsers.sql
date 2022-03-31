﻿CREATE TABLE [dbo].[AdminEmailUsers] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Email]        NVARCHAR (256)   NOT NULL,
    [PasswordHash] NVARCHAR (88)    NOT NULL,
    [PasswordSalt] NVARCHAR (54)    NOT NULL,
    CONSTRAINT [PK_AdminEmailUsers_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
);




GO

CREATE UNIQUE NONCLUSTERED INDEX [AdminEmailUsersEmailUnique]
    ON [dbo].[AdminEmailUsers]([Email] ASC) WHERE ([Email] IS NOT NULL);

