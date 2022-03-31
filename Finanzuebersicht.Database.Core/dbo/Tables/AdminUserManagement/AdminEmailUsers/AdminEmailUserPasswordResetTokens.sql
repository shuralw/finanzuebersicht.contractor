CREATE TABLE [dbo].[AdminEmailUserPasswordResetTokens]
(
    [Token]             NVARCHAR (64)    NOT NULL,
    [AdminEmailUserId]   UNIQUEIDENTIFIER NOT NULL,
    [ExpiresOn]         DATETIME         NOT NULL,
    CONSTRAINT [PK_AdminEmailUserPasswordResetToken_Token] PRIMARY KEY CLUSTERED ([Token] ASC),
    CONSTRAINT [FK_AdminEmailUserPasswordResetToken_AdminEmailUserId] FOREIGN KEY ([AdminEmailUserId]) REFERENCES [dbo].[AdminEmailUsers] ([Id]) ON DELETE CASCADE
)
