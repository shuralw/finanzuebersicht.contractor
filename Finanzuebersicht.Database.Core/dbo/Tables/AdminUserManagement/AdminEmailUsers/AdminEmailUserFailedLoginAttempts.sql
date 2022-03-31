CREATE TABLE [dbo].[AdminEmailUserFailedLoginAttempts] (
    [Id]                INT              IDENTITY (1, 1) NOT NULL,
    [AdminEmailUserId]       UNIQUEIDENTIFIER NOT NULL,
    [OccurredAt]        DATETIME         NOT NULL,
    CONSTRAINT [PK_AdminEmailUserFailedLoginAttempts_AdminEmailUserId] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AdminEmailUserFailedLoginAttempts_AdminEmailUserId] FOREIGN KEY ([AdminEmailUserId]) REFERENCES [dbo].[AdminEmailUsers] ([Id]) ON DELETE CASCADE
);


