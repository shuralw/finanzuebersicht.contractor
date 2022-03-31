EXEC sp_MSForEachTable 'DISABLE TRIGGER ALL ON ?'
GO
EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
GO
EXEC sp_MSForEachTable 'SET QUOTED_IDENTIFIER ON; DELETE FROM ?'
GO
EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'
GO
EXEC sp_MSForEachTable 'ENABLE TRIGGER ALL ON ?'
GO

INSERT INTO [dbo].[AdminEmailUsers] ([Id], [Email], [PasswordHash], [PasswordSalt]) 
	VALUES (N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', N'admin@example.org', N'F+UttZvg6gtCAQlEJ7RBihdu+TVD2LXHj5VHYgNObWMmjo6pfEoYRLsf6UUQzC9F92tt/lNxJUpA8D64cNpt6A==', N'50000.u46XvXpDWWpj+VmiH4H7HPgCKgFCwAMXTCygako4vze7dA==');

INSERT INTO [dbo].[AdminEmailUserPermissions] ([AdminEmailUserId], [Benutzerverwaltung], [BerichteBearbeiten], [BerichteLesen], [BetriebBearbeiten], [BetriebLesen], [DokumenteBearbeiten], [DokumenteLesen], [GebietskoerperschaftBearbeiten], [GebietskoerperschaftLesen], [GrundDatenBearbeiten], [GrundDatenLesen], [HilfetextBearbeiten], [HilfetextLesen], [ImportExportSchemataBearbeiten], [ImportExportSchemataLesen], [LoginAlsBetrieb], [LoginAlsGebietskoerperschaft], [LoginAlsSchule], [LoginAlsSchulkind], [NachrichtenBearbeiten], [NachrichtenLesen], [NewsletterBearbeiten], [NewsletterLesen], [SchuleBearbeiten], [SchuleLesen], [SchulkindBearbeiten], [SchulkindLesen], [SchulsystemBearbeiten], [SchulsystemLesen], [StatistikenBearbeiten], [StatistikenLesen]) 
	VALUES (N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)));

INSERT INTO [dbo].[AdminUserGroups] ([Id], [Name]) 
	VALUES (N'90671da2-a763-409b-92c2-5a2005cdbac8', N'Global Admins')

INSERT INTO [dbo].[AdminUserGroupPermissions] ([AdminUserGroupId], [Benutzerverwaltung], [BerichteBearbeiten], [BerichteLesen], [BetriebBearbeiten], [BetriebLesen], [DokumenteBearbeiten], [DokumenteLesen], [GebietskoerperschaftBearbeiten], [GebietskoerperschaftLesen], [GrundDatenBearbeiten], [GrundDatenLesen], [HilfetextBearbeiten], [HilfetextLesen], [ImportExportSchemataBearbeiten], [ImportExportSchemataLesen], [LoginAlsBetrieb], [LoginAlsGebietskoerperschaft], [LoginAlsSchule], [LoginAlsSchulkind], [NachrichtenBearbeiten], [NachrichtenLesen], [NewsletterBearbeiten], [NewsletterLesen], [SchuleBearbeiten], [SchuleLesen], [SchulkindBearbeiten], [SchulkindLesen], [SchulsystemBearbeiten], [SchulsystemLesen], [StatistikenBearbeiten], [StatistikenLesen]) 
	VALUES (N'90671da2-a763-409b-92c2-5a2005cdbac8', CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)), CAST(1 AS Decimal(1, 0)))

INSERT INTO [dbo].[Categories] ([Id] ,[EmailUserId] ,[SuperCategoryId] ,[Title] ,[Color]) 
	VALUES (N'6927b5c0-8681-43de-8ca8-1e5814aaae9a', N'8DD8A19F-1F5E-4C58-B22D-B637068A2DB1', null, 'Fitnessstudio', '#008dd2')

INSERT INTO [dbo].[Categories] ([Id] ,[EmailUserId] ,[SuperCategoryId] ,[Title] ,[Color]) 
	VALUES (N'52727d89-f503-4524-9916-523ec883801c', N'8DD8A19F-1F5E-4C58-B22D-B637068A2DB1', null, 'Internet', '#7FFFD4')

INSERT INTO [dbo].[Categories] ([Id] ,[EmailUserId] ,[SuperCategoryId] ,[Title] ,[Color]) 
	VALUES (N'f369029a-6a9a-4406-8a07-e0a915c73af6', N'8DD8A19F-1F5E-4C58-B22D-B637068A2DB1', N'52727d89-f503-4524-9916-523ec883801c', 'Amazon', '#FF9900')

INSERT INTO [dbo].[Categories] ([Id] ,[EmailUserId] ,[SuperCategoryId] ,[Title] ,[Color]) 
	VALUES (N'79ac9a99-2999-453e-a35e-cdd1bf3fb9da', N'8DD8A19F-1F5E-4C58-B22D-B637068A2DB1', N'52727d89-f503-4524-9916-523ec883801c', 'Spotify', '#1ed761')

INSERT INTO [dbo].[Categories] ([Id] ,[EmailUserId] ,[SuperCategoryId] ,[Title] ,[Color]) 
	VALUES (N'86f4b6cf-8540-40cc-a611-1c79b1b5c3ef', N'8DD8A19F-1F5E-4C58-B22D-B637068A2DB1', null, 'Wocheneinkauf', '#be4d25')

INSERT INTO [dbo].[Categories] ([Id] ,[EmailUserId] ,[SuperCategoryId] ,[Title] ,[Color]) 
	VALUES (N'839efef3-875b-4cde-9601-578796b7db1a', N'8DD8A19F-1F5E-4C58-B22D-B637068A2DB1', N'86f4b6cf-8540-40cc-a611-1c79b1b5c3ef', 'Edeka', '#f8ec00')

INSERT INTO [dbo].[AccountingEntries] ([Id] ,[EmailUserId] ,[CategoryId] ,[Auftragskonto] ,[Buchungsdatum] ,[ValutaDatum] ,[Buchungstext] ,[Verwendungszweck] ,[GlaeubigerId] ,[Mandatsreferenz] ,[Sammlerreferenz] ,[LastschriftUrsprungsbetrag] ,[AuslagenersatzRuecklastschrift] ,[Beguenstigter] ,[IBAN] ,[BIC] ,[Betrag] ,[Waehrung] ,[Info])
	VALUES (N'e0372026-f24c-47b5-abce-5909c81ea480',N'8DD8A19F-1F5E-4C58-B22D-B637068A2DB1',N'6927b5c0-8681-43de-8ca8-1e5814aaae9a','DE90482501100009896432', CONVERT(DATETIME, '21.03.2022',105), CONVERT(DATETIME, '21.03.2022',105), 'FOLGELASTSCHRIFT','1--0383-0000133 zSchuelervertrag 16,6 21.03.22-03.04.22 ','DE30ZZZ00000411582','MLREF102214','1--0383-0000133',null,'','Buena Vista Fitnessclub GmbH','DE12482501100008032526','WELADED1LEM',-16.6,'EUR','Umsatz gebucht')