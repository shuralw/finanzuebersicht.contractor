USE [master]
GO
/****** Object:  Database [FinanzuebersichtCore]    Script Date: 31.03.2022 18:43:20 ******/
CREATE DATABASE [FinanzuebersichtCore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FinanzuebersichtCore', FILENAME = N'C:\Users\lukas\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\FinanzuebersichtCore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FinanzuebersichtCore_log', FILENAME = N'C:\Users\lukas\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\FinanzuebersichtCore.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [FinanzuebersichtCore] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FinanzuebersichtCore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FinanzuebersichtCore] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [FinanzuebersichtCore] SET ANSI_NULLS ON 
GO
ALTER DATABASE [FinanzuebersichtCore] SET ANSI_PADDING ON 
GO
ALTER DATABASE [FinanzuebersichtCore] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [FinanzuebersichtCore] SET ARITHABORT ON 
GO
ALTER DATABASE [FinanzuebersichtCore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FinanzuebersichtCore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FinanzuebersichtCore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FinanzuebersichtCore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FinanzuebersichtCore] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [FinanzuebersichtCore] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [FinanzuebersichtCore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FinanzuebersichtCore] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [FinanzuebersichtCore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FinanzuebersichtCore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FinanzuebersichtCore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FinanzuebersichtCore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FinanzuebersichtCore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FinanzuebersichtCore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FinanzuebersichtCore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FinanzuebersichtCore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FinanzuebersichtCore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FinanzuebersichtCore] SET RECOVERY FULL 
GO
ALTER DATABASE [FinanzuebersichtCore] SET  MULTI_USER 
GO
ALTER DATABASE [FinanzuebersichtCore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FinanzuebersichtCore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FinanzuebersichtCore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FinanzuebersichtCore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FinanzuebersichtCore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FinanzuebersichtCore] SET QUERY_STORE = OFF
GO
USE [FinanzuebersichtCore]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [FinanzuebersichtCore]
GO
/****** Object:  Table [dbo].[AccountingEntries]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountingEntries](
	[Id] [uniqueidentifier] NOT NULL,
	[EmailUserId] [uniqueidentifier] NOT NULL,
	[CategoryId] [uniqueidentifier] NULL,
	[Auftragskonto] [nvarchar](30) NOT NULL,
	[Buchungsdatum] [datetime] NOT NULL,
	[ValutaDatum] [datetime] NOT NULL,
	[Buchungstext] [nvarchar](300) NOT NULL,
	[Verwendungszweck] [nvarchar](4000) NOT NULL,
	[GlaeubigerId] [nvarchar](100) NULL,
	[Mandatsreferenz] [nvarchar](100) NULL,
	[Sammlerreferenz] [nvarchar](100) NULL,
	[LastschriftUrsprungsbetrag] [decimal](8, 2) NULL,
	[AuslagenersatzRuecklastschrift] [nvarchar](1000) NULL,
	[Beguenstigter] [nvarchar](2000) NOT NULL,
	[IBAN] [nvarchar](50) NOT NULL,
	[BIC] [nvarchar](50) NOT NULL,
	[Betrag] [decimal](8, 2) NOT NULL,
	[Waehrung] [nvarchar](10) NOT NULL,
	[Info] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_AccountingEntries_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminAccessTokenAdminAdGroupRelations]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminAccessTokenAdminAdGroupRelations](
	[AdminAccessTokenId] [uniqueidentifier] NOT NULL,
	[AdminAdGroupId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AdminAccessTokenAdminAdGroupRelations_Token_AdminAdGroupId] PRIMARY KEY CLUSTERED 
(
	[AdminAccessTokenId] ASC,
	[AdminAdGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminAccessTokenCachedPermissions]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminAccessTokenCachedPermissions](
	[AdminAccessTokenId] [uniqueidentifier] NOT NULL,
	[Benutzerverwaltung] [numeric](1, 0) NOT NULL,
	[BerichteBearbeiten] [numeric](1, 0) NOT NULL,
	[BerichteLesen] [numeric](1, 0) NOT NULL,
	[BetriebBearbeiten] [numeric](1, 0) NOT NULL,
	[BetriebLesen] [numeric](1, 0) NOT NULL,
	[DokumenteBearbeiten] [numeric](1, 0) NOT NULL,
	[DokumenteLesen] [numeric](1, 0) NOT NULL,
	[GebietskoerperschaftBearbeiten] [numeric](1, 0) NOT NULL,
	[GebietskoerperschaftLesen] [numeric](1, 0) NOT NULL,
	[GrundDatenBearbeiten] [numeric](1, 0) NOT NULL,
	[GrundDatenLesen] [numeric](1, 0) NOT NULL,
	[HilfetextBearbeiten] [numeric](1, 0) NOT NULL,
	[HilfetextLesen] [numeric](1, 0) NOT NULL,
	[ImportExportSchemataBearbeiten] [numeric](1, 0) NOT NULL,
	[ImportExportSchemataLesen] [numeric](1, 0) NOT NULL,
	[LoginAlsBetrieb] [numeric](1, 0) NOT NULL,
	[LoginAlsGebietskoerperschaft] [numeric](1, 0) NOT NULL,
	[LoginAlsSchule] [numeric](1, 0) NOT NULL,
	[LoginAlsSchulkind] [numeric](1, 0) NOT NULL,
	[NachrichtenBearbeiten] [numeric](1, 0) NOT NULL,
	[NachrichtenLesen] [numeric](1, 0) NOT NULL,
	[NewsletterBearbeiten] [numeric](1, 0) NOT NULL,
	[NewsletterLesen] [numeric](1, 0) NOT NULL,
	[SchuleBearbeiten] [numeric](1, 0) NOT NULL,
	[SchuleLesen] [numeric](1, 0) NOT NULL,
	[SchulkindBearbeiten] [numeric](1, 0) NOT NULL,
	[SchulkindLesen] [numeric](1, 0) NOT NULL,
	[SchulsystemBearbeiten] [numeric](1, 0) NOT NULL,
	[SchulsystemLesen] [numeric](1, 0) NOT NULL,
	[StatistikenBearbeiten] [numeric](1, 0) NOT NULL,
	[StatistikenLesen] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_AdminAccessTokenCachedPermissions_AdminAccessTokenId] PRIMARY KEY CLUSTERED 
(
	[AdminAccessTokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminAccessTokens]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminAccessTokens](
	[Id] [uniqueidentifier] NOT NULL,
	[AdminRefreshTokenId] [uniqueidentifier] NOT NULL,
	[AdminEmailUserId] [uniqueidentifier] NULL,
	[AdminAdUserId] [uniqueidentifier] NULL,
	[Username] [nvarchar](256) NOT NULL,
	[ExpiresOn] [datetime] NOT NULL,
 CONSTRAINT [PK_AdminAccessTokens_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminAdGroupAdminUserGroupRelations]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminAdGroupAdminUserGroupRelations](
	[MemberId] [uniqueidentifier] NOT NULL,
	[ParentId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AdminAdGroupAdminUserGroupRelation_MemberId_ParentId] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminAdGroupPermissions]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminAdGroupPermissions](
	[AdminAdGroupId] [uniqueidentifier] NOT NULL,
	[Benutzerverwaltung] [numeric](1, 0) NOT NULL,
	[BerichteBearbeiten] [numeric](1, 0) NOT NULL,
	[BerichteLesen] [numeric](1, 0) NOT NULL,
	[BetriebBearbeiten] [numeric](1, 0) NOT NULL,
	[BetriebLesen] [numeric](1, 0) NOT NULL,
	[DokumenteBearbeiten] [numeric](1, 0) NOT NULL,
	[DokumenteLesen] [numeric](1, 0) NOT NULL,
	[GebietskoerperschaftBearbeiten] [numeric](1, 0) NOT NULL,
	[GebietskoerperschaftLesen] [numeric](1, 0) NOT NULL,
	[GrundDatenBearbeiten] [numeric](1, 0) NOT NULL,
	[GrundDatenLesen] [numeric](1, 0) NOT NULL,
	[HilfetextBearbeiten] [numeric](1, 0) NOT NULL,
	[HilfetextLesen] [numeric](1, 0) NOT NULL,
	[ImportExportSchemataBearbeiten] [numeric](1, 0) NOT NULL,
	[ImportExportSchemataLesen] [numeric](1, 0) NOT NULL,
	[LoginAlsBetrieb] [numeric](1, 0) NOT NULL,
	[LoginAlsGebietskoerperschaft] [numeric](1, 0) NOT NULL,
	[LoginAlsSchule] [numeric](1, 0) NOT NULL,
	[LoginAlsSchulkind] [numeric](1, 0) NOT NULL,
	[NachrichtenBearbeiten] [numeric](1, 0) NOT NULL,
	[NachrichtenLesen] [numeric](1, 0) NOT NULL,
	[NewsletterBearbeiten] [numeric](1, 0) NOT NULL,
	[NewsletterLesen] [numeric](1, 0) NOT NULL,
	[SchuleBearbeiten] [numeric](1, 0) NOT NULL,
	[SchuleLesen] [numeric](1, 0) NOT NULL,
	[SchulkindBearbeiten] [numeric](1, 0) NOT NULL,
	[SchulkindLesen] [numeric](1, 0) NOT NULL,
	[SchulsystemBearbeiten] [numeric](1, 0) NOT NULL,
	[SchulsystemLesen] [numeric](1, 0) NOT NULL,
	[StatistikenBearbeiten] [numeric](1, 0) NOT NULL,
	[StatistikenLesen] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_AdminAdGroupPermissions_AdminAdGroupId] PRIMARY KEY CLUSTERED 
(
	[AdminAdGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminAdGroups]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminAdGroups](
	[Id] [uniqueidentifier] NOT NULL,
	[DN] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_AdminAdGroups_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminAdUserAdminUserGroupRelations]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminAdUserAdminUserGroupRelations](
	[MemberId] [uniqueidentifier] NOT NULL,
	[ParentId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AdminAdUserAdminUserGroupRelation_MemberId_ParentId] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminAdUserPermissions]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminAdUserPermissions](
	[AdminAdUserId] [uniqueidentifier] NOT NULL,
	[Benutzerverwaltung] [numeric](1, 0) NOT NULL,
	[BerichteBearbeiten] [numeric](1, 0) NOT NULL,
	[BerichteLesen] [numeric](1, 0) NOT NULL,
	[BetriebBearbeiten] [numeric](1, 0) NOT NULL,
	[BetriebLesen] [numeric](1, 0) NOT NULL,
	[DokumenteBearbeiten] [numeric](1, 0) NOT NULL,
	[DokumenteLesen] [numeric](1, 0) NOT NULL,
	[GebietskoerperschaftBearbeiten] [numeric](1, 0) NOT NULL,
	[GebietskoerperschaftLesen] [numeric](1, 0) NOT NULL,
	[GrundDatenBearbeiten] [numeric](1, 0) NOT NULL,
	[GrundDatenLesen] [numeric](1, 0) NOT NULL,
	[HilfetextBearbeiten] [numeric](1, 0) NOT NULL,
	[HilfetextLesen] [numeric](1, 0) NOT NULL,
	[ImportExportSchemataBearbeiten] [numeric](1, 0) NOT NULL,
	[ImportExportSchemataLesen] [numeric](1, 0) NOT NULL,
	[LoginAlsBetrieb] [numeric](1, 0) NOT NULL,
	[LoginAlsGebietskoerperschaft] [numeric](1, 0) NOT NULL,
	[LoginAlsSchule] [numeric](1, 0) NOT NULL,
	[LoginAlsSchulkind] [numeric](1, 0) NOT NULL,
	[NachrichtenBearbeiten] [numeric](1, 0) NOT NULL,
	[NachrichtenLesen] [numeric](1, 0) NOT NULL,
	[NewsletterBearbeiten] [numeric](1, 0) NOT NULL,
	[NewsletterLesen] [numeric](1, 0) NOT NULL,
	[SchuleBearbeiten] [numeric](1, 0) NOT NULL,
	[SchuleLesen] [numeric](1, 0) NOT NULL,
	[SchulkindBearbeiten] [numeric](1, 0) NOT NULL,
	[SchulkindLesen] [numeric](1, 0) NOT NULL,
	[SchulsystemBearbeiten] [numeric](1, 0) NOT NULL,
	[SchulsystemLesen] [numeric](1, 0) NOT NULL,
	[StatistikenBearbeiten] [numeric](1, 0) NOT NULL,
	[StatistikenLesen] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_AdminAdUserPermissions_AdminAdUserId] PRIMARY KEY CLUSTERED 
(
	[AdminAdUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminAdUsers]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminAdUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[DN] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_AdminAdUsers_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminEmailUserAdminUserGroupRelations]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminEmailUserAdminUserGroupRelations](
	[MemberId] [uniqueidentifier] NOT NULL,
	[ParentId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AdminEmailUserAdminUserGroupRelation_MemberId_ParentId] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminEmailUserFailedLoginAttempts]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminEmailUserFailedLoginAttempts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdminEmailUserId] [uniqueidentifier] NOT NULL,
	[OccurredAt] [datetime] NOT NULL,
 CONSTRAINT [PK_AdminEmailUserFailedLoginAttempts_AdminEmailUserId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminEmailUserPasswordResetTokens]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminEmailUserPasswordResetTokens](
	[Token] [nvarchar](64) NOT NULL,
	[AdminEmailUserId] [uniqueidentifier] NOT NULL,
	[ExpiresOn] [datetime] NOT NULL,
 CONSTRAINT [PK_AdminEmailUserPasswordResetToken_Token] PRIMARY KEY CLUSTERED 
(
	[Token] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminEmailUserPermissions]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminEmailUserPermissions](
	[AdminEmailUserId] [uniqueidentifier] NOT NULL,
	[Benutzerverwaltung] [numeric](1, 0) NOT NULL,
	[BerichteBearbeiten] [numeric](1, 0) NOT NULL,
	[BerichteLesen] [numeric](1, 0) NOT NULL,
	[BetriebBearbeiten] [numeric](1, 0) NOT NULL,
	[BetriebLesen] [numeric](1, 0) NOT NULL,
	[DokumenteBearbeiten] [numeric](1, 0) NOT NULL,
	[DokumenteLesen] [numeric](1, 0) NOT NULL,
	[GebietskoerperschaftBearbeiten] [numeric](1, 0) NOT NULL,
	[GebietskoerperschaftLesen] [numeric](1, 0) NOT NULL,
	[GrundDatenBearbeiten] [numeric](1, 0) NOT NULL,
	[GrundDatenLesen] [numeric](1, 0) NOT NULL,
	[HilfetextBearbeiten] [numeric](1, 0) NOT NULL,
	[HilfetextLesen] [numeric](1, 0) NOT NULL,
	[ImportExportSchemataBearbeiten] [numeric](1, 0) NOT NULL,
	[ImportExportSchemataLesen] [numeric](1, 0) NOT NULL,
	[LoginAlsBetrieb] [numeric](1, 0) NOT NULL,
	[LoginAlsGebietskoerperschaft] [numeric](1, 0) NOT NULL,
	[LoginAlsSchule] [numeric](1, 0) NOT NULL,
	[LoginAlsSchulkind] [numeric](1, 0) NOT NULL,
	[NachrichtenBearbeiten] [numeric](1, 0) NOT NULL,
	[NachrichtenLesen] [numeric](1, 0) NOT NULL,
	[NewsletterBearbeiten] [numeric](1, 0) NOT NULL,
	[NewsletterLesen] [numeric](1, 0) NOT NULL,
	[SchuleBearbeiten] [numeric](1, 0) NOT NULL,
	[SchuleLesen] [numeric](1, 0) NOT NULL,
	[SchulkindBearbeiten] [numeric](1, 0) NOT NULL,
	[SchulkindLesen] [numeric](1, 0) NOT NULL,
	[SchulsystemBearbeiten] [numeric](1, 0) NOT NULL,
	[SchulsystemLesen] [numeric](1, 0) NOT NULL,
	[StatistikenBearbeiten] [numeric](1, 0) NOT NULL,
	[StatistikenLesen] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_AdminEmailUserPermissions_AdminEmailUserId] PRIMARY KEY CLUSTERED 
(
	[AdminEmailUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminEmailUsers]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminEmailUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[PasswordHash] [nvarchar](88) NOT NULL,
	[PasswordSalt] [nvarchar](54) NOT NULL,
 CONSTRAINT [PK_AdminEmailUsers_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminLogs]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MachineName] [nvarchar](50) NOT NULL,
	[Logged] [datetime] NOT NULL,
	[Level] [nvarchar](20) NOT NULL,
	[Logger] [nvarchar](256) NULL,
	[Callsite] [nvarchar](256) NULL,
	[IP] [nvarchar](20) NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Username] [nvarchar](256) NULL,
	[Exception] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminRefreshTokenAdminAdGroupRelations]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminRefreshTokenAdminAdGroupRelations](
	[AdminRefreshTokenId] [uniqueidentifier] NOT NULL,
	[AdminAdGroupId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AdminRefreshTokenAdminAdGroupRelations_AdminRefreshTokenId_AdminAdGroupId] PRIMARY KEY CLUSTERED 
(
	[AdminRefreshTokenId] ASC,
	[AdminAdGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminRefreshTokens]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminRefreshTokens](
	[Id] [uniqueidentifier] NOT NULL,
	[AdminEmailUserId] [uniqueidentifier] NULL,
	[AdminAdUserId] [uniqueidentifier] NULL,
	[Username] [nvarchar](256) NOT NULL,
	[ExpiresOn] [datetime] NOT NULL,
 CONSTRAINT [PK_AdminRefreshTokens_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminUserGroupAdminUserGroupRelations]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminUserGroupAdminUserGroupRelations](
	[MemberId] [uniqueidentifier] NOT NULL,
	[ParentId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AdminUserGroupAdminUserGroupRelation_MemberId_ParentId] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminUserGroupPermissions]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminUserGroupPermissions](
	[AdminUserGroupId] [uniqueidentifier] NOT NULL,
	[Benutzerverwaltung] [numeric](1, 0) NOT NULL,
	[BerichteBearbeiten] [numeric](1, 0) NOT NULL,
	[BerichteLesen] [numeric](1, 0) NOT NULL,
	[BetriebBearbeiten] [numeric](1, 0) NOT NULL,
	[BetriebLesen] [numeric](1, 0) NOT NULL,
	[DokumenteBearbeiten] [numeric](1, 0) NOT NULL,
	[DokumenteLesen] [numeric](1, 0) NOT NULL,
	[GebietskoerperschaftBearbeiten] [numeric](1, 0) NOT NULL,
	[GebietskoerperschaftLesen] [numeric](1, 0) NOT NULL,
	[GrundDatenBearbeiten] [numeric](1, 0) NOT NULL,
	[GrundDatenLesen] [numeric](1, 0) NOT NULL,
	[HilfetextBearbeiten] [numeric](1, 0) NOT NULL,
	[HilfetextLesen] [numeric](1, 0) NOT NULL,
	[ImportExportSchemataBearbeiten] [numeric](1, 0) NOT NULL,
	[ImportExportSchemataLesen] [numeric](1, 0) NOT NULL,
	[LoginAlsBetrieb] [numeric](1, 0) NOT NULL,
	[LoginAlsGebietskoerperschaft] [numeric](1, 0) NOT NULL,
	[LoginAlsSchule] [numeric](1, 0) NOT NULL,
	[LoginAlsSchulkind] [numeric](1, 0) NOT NULL,
	[NachrichtenBearbeiten] [numeric](1, 0) NOT NULL,
	[NachrichtenLesen] [numeric](1, 0) NOT NULL,
	[NewsletterBearbeiten] [numeric](1, 0) NOT NULL,
	[NewsletterLesen] [numeric](1, 0) NOT NULL,
	[SchuleBearbeiten] [numeric](1, 0) NOT NULL,
	[SchuleLesen] [numeric](1, 0) NOT NULL,
	[SchulkindBearbeiten] [numeric](1, 0) NOT NULL,
	[SchulkindLesen] [numeric](1, 0) NOT NULL,
	[SchulsystemBearbeiten] [numeric](1, 0) NOT NULL,
	[SchulsystemLesen] [numeric](1, 0) NOT NULL,
	[StatistikenBearbeiten] [numeric](1, 0) NOT NULL,
	[StatistikenLesen] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_AdminUserGroupPermissions_AdminUserGroupId] PRIMARY KEY CLUSTERED 
(
	[AdminUserGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminUserGroups]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminUserGroups](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_AdminUserGroups_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [uniqueidentifier] NOT NULL,
	[EmailUserId] [uniqueidentifier] NOT NULL,
	[SuperCategoryId] [uniqueidentifier] NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Color] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Categories_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategorySearchTerms]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategorySearchTerms](
	[Id] [uniqueidentifier] NOT NULL,
	[EmailUserId] [uniqueidentifier] NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[Term] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_CategorySearchTerms_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StartSalden]    Script Date: 31.03.2022 18:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StartSalden](
	[Id] [uniqueidentifier] NOT NULL,
	[EmailUserId] [uniqueidentifier] NOT NULL,
	[Betrag] [decimal](8, 2) NOT NULL,
	[AmDatum] [datetime] NOT NULL,
 CONSTRAINT [PK_StartSalden_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AccountingEntries] ([Id], [EmailUserId], [CategoryId], [Auftragskonto], [Buchungsdatum], [ValutaDatum], [Buchungstext], [Verwendungszweck], [GlaeubigerId], [Mandatsreferenz], [Sammlerreferenz], [LastschriftUrsprungsbetrag], [AuslagenersatzRuecklastschrift], [Beguenstigter], [IBAN], [BIC], [Betrag], [Waehrung], [Info]) VALUES (N'0e5ab1fc-816f-4f7f-9633-0dfa232f8281', N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', NULL, N'DEXXXXXXXXXXXXXXXXXXXX', CAST(N'2022-03-06T23:00:00.000' AS DateTime), CAST(N'2022-03-06T23:00:00.000' AS DateTime), N'FOLGELASTSCHRIFT', N'Mein toller Fitnessstudio Vertrag', N'DEYYYYYYYYYYYYYYYY', N'MLREF102214', N'', NULL, N'', N'Buena Vista Fitnessclub GmbH', N'DE12345678912345678912', N'WELADED1LEM', CAST(-12.34 AS Decimal(8, 2)), N'EUR', N'Umsatz gebucht')
INSERT [dbo].[AccountingEntries] ([Id], [EmailUserId], [CategoryId], [Auftragskonto], [Buchungsdatum], [ValutaDatum], [Buchungstext], [Verwendungszweck], [GlaeubigerId], [Mandatsreferenz], [Sammlerreferenz], [LastschriftUrsprungsbetrag], [AuslagenersatzRuecklastschrift], [Beguenstigter], [IBAN], [BIC], [Betrag], [Waehrung], [Info]) VALUES (N'68babd6d-3f1e-4445-9713-7034f36fdc30', N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', NULL, N'DEXXXXXXXXXXXXXXXXXXXX', CAST(N'2022-03-09T23:00:00.000' AS DateTime), CAST(N'2022-03-09T23:00:00.000' AS DateTime), N'FOLGELASTSCHRIFT', N'AMZN Mktp DE', N'DEYYYYYYYYYYYYYYYY', N't7pR0GfolsD(Ldi?Q5DKiA4r5eHkpB', N'', NULL, N'', N'AMAZON PAYMENTS EUROPE S.C.A.', N'DE12345678912345678912', N'TUBDDEDD', CAST(-54.32 AS Decimal(8, 2)), N'EUR', N'Umsatz gebucht')
INSERT [dbo].[AccountingEntries] ([Id], [EmailUserId], [CategoryId], [Auftragskonto], [Buchungsdatum], [ValutaDatum], [Buchungstext], [Verwendungszweck], [GlaeubigerId], [Mandatsreferenz], [Sammlerreferenz], [LastschriftUrsprungsbetrag], [AuslagenersatzRuecklastschrift], [Beguenstigter], [IBAN], [BIC], [Betrag], [Waehrung], [Info]) VALUES (N'6eb1272f-86f5-43c7-b7de-833d9b9b4c80', N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', NULL, N'DEXXXXXXXXXXXXXXXXXXXX', CAST(N'2022-03-20T23:00:00.000' AS DateTime), CAST(N'2022-03-20T23:00:00.000' AS DateTime), N'FOLGELASTSCHRIFT', N'Mein toller Fitnessstudio Vertrag', N'DEYYYYYYYYYYYYYYYY', N'MLREF102214', N'', NULL, N'', N'Buena Vista Fitnessclub GmbH', N'DE88888888888888888886', N'WELADED1LEM', CAST(-12.34 AS Decimal(8, 2)), N'EUR', N'Umsatz gebucht')
INSERT [dbo].[AccountingEntries] ([Id], [EmailUserId], [CategoryId], [Auftragskonto], [Buchungsdatum], [ValutaDatum], [Buchungstext], [Verwendungszweck], [GlaeubigerId], [Mandatsreferenz], [Sammlerreferenz], [LastschriftUrsprungsbetrag], [AuslagenersatzRuecklastschrift], [Beguenstigter], [IBAN], [BIC], [Betrag], [Waehrung], [Info]) VALUES (N'fd77354b-048d-4dc3-b99b-bc90a81b5b89', N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', NULL, N'DEXXXXXXXXXXXXXXXXXXXX', CAST(N'2022-03-13T23:00:00.000' AS DateTime), CAST(N'2022-03-13T23:00:00.000' AS DateTime), N'KARTENZAHLUNG', N'Debitkartenzahlung', N'', N'', N'', NULL, N'', N'ALDI SAGT DANKE', N'DEZZZZZZZZZZZZZ', N'WELADEDDXXX', CAST(-9.99 AS Decimal(8, 2)), N'EUR', N'Umsatz gebucht')
INSERT [dbo].[AccountingEntries] ([Id], [EmailUserId], [CategoryId], [Auftragskonto], [Buchungsdatum], [ValutaDatum], [Buchungstext], [Verwendungszweck], [GlaeubigerId], [Mandatsreferenz], [Sammlerreferenz], [LastschriftUrsprungsbetrag], [AuslagenersatzRuecklastschrift], [Beguenstigter], [IBAN], [BIC], [Betrag], [Waehrung], [Info]) VALUES (N'a5457536-614a-4f04-84d4-e1f66fb78346', N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', NULL, N'DEXXXXXXXXXXXXXXXXXXXX', CAST(N'2022-03-13T23:00:00.000' AS DateTime), CAST(N'2022-03-13T23:00:00.000' AS DateTime), N'KARTENZAHLUNG', N'Gehaltszahlung für März 2022. Dies ist ein sehr langer Verwendungszweck der nach 40 Zeichen abgeschnitten wird in der Listenansicht.', N'', N'', N'', NULL, N'', N'Irgendetwas', N'DEZZZZZZZZZZZZZ', N'WELADEDDXXX', CAST(4321.00 AS Decimal(8, 2)), N'EUR', N'Umsatz gebucht')
GO
INSERT [dbo].[AdminAccessTokenCachedPermissions] ([AdminAccessTokenId], [Benutzerverwaltung], [BerichteBearbeiten], [BerichteLesen], [BetriebBearbeiten], [BetriebLesen], [DokumenteBearbeiten], [DokumenteLesen], [GebietskoerperschaftBearbeiten], [GebietskoerperschaftLesen], [GrundDatenBearbeiten], [GrundDatenLesen], [HilfetextBearbeiten], [HilfetextLesen], [ImportExportSchemataBearbeiten], [ImportExportSchemataLesen], [LoginAlsBetrieb], [LoginAlsGebietskoerperschaft], [LoginAlsSchule], [LoginAlsSchulkind], [NachrichtenBearbeiten], [NachrichtenLesen], [NewsletterBearbeiten], [NewsletterLesen], [SchuleBearbeiten], [SchuleLesen], [SchulkindBearbeiten], [SchulkindLesen], [SchulsystemBearbeiten], [SchulsystemLesen], [StatistikenBearbeiten], [StatistikenLesen]) VALUES (N'5466b7d9-a93b-4bc8-bb67-a676b128d1eb', CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)))
GO
INSERT [dbo].[AdminAccessTokens] ([Id], [AdminRefreshTokenId], [AdminEmailUserId], [AdminAdUserId], [Username], [ExpiresOn]) VALUES (N'5466b7d9-a93b-4bc8-bb67-a676b128d1eb', N'56573b32-edb1-4d76-b438-cc75c7c03ba4', N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', NULL, N'test@test.de', CAST(N'2022-04-01T02:06:56.397' AS DateTime))
GO
INSERT [dbo].[AdminEmailUserPermissions] ([AdminEmailUserId], [Benutzerverwaltung], [BerichteBearbeiten], [BerichteLesen], [BetriebBearbeiten], [BetriebLesen], [DokumenteBearbeiten], [DokumenteLesen], [GebietskoerperschaftBearbeiten], [GebietskoerperschaftLesen], [GrundDatenBearbeiten], [GrundDatenLesen], [HilfetextBearbeiten], [HilfetextLesen], [ImportExportSchemataBearbeiten], [ImportExportSchemataLesen], [LoginAlsBetrieb], [LoginAlsGebietskoerperschaft], [LoginAlsSchule], [LoginAlsSchulkind], [NachrichtenBearbeiten], [NachrichtenLesen], [NewsletterBearbeiten], [NewsletterLesen], [SchuleBearbeiten], [SchuleLesen], [SchulkindBearbeiten], [SchulkindLesen], [SchulsystemBearbeiten], [SchulsystemLesen], [StatistikenBearbeiten], [StatistikenLesen]) VALUES (N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)))
GO
INSERT [dbo].[AdminEmailUsers] ([Id], [Email], [PasswordHash], [PasswordSalt]) VALUES (N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', N'test@test.de', N'F+UttZvg6gtCAQlEJ7RBihdu+TVD2LXHj5VHYgNObWMmjo6pfEoYRLsf6UUQzC9F92tt/lNxJUpA8D64cNpt6A==', N'50000.u46XvXpDWWpj+VmiH4H7HPgCKgFCwAMXTCygako4vze7dA==')
GO
INSERT [dbo].[AdminRefreshTokens] ([Id], [AdminEmailUserId], [AdminAdUserId], [Username], [ExpiresOn]) VALUES (N'56573b32-edb1-4d76-b438-cc75c7c03ba4', N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', NULL, N'test@test.de', CAST(N'2022-04-01T08:06:56.287' AS DateTime))
GO
INSERT [dbo].[AdminUserGroupPermissions] ([AdminUserGroupId], [Benutzerverwaltung], [BerichteBearbeiten], [BerichteLesen], [BetriebBearbeiten], [BetriebLesen], [DokumenteBearbeiten], [DokumenteLesen], [GebietskoerperschaftBearbeiten], [GebietskoerperschaftLesen], [GrundDatenBearbeiten], [GrundDatenLesen], [HilfetextBearbeiten], [HilfetextLesen], [ImportExportSchemataBearbeiten], [ImportExportSchemataLesen], [LoginAlsBetrieb], [LoginAlsGebietskoerperschaft], [LoginAlsSchule], [LoginAlsSchulkind], [NachrichtenBearbeiten], [NachrichtenLesen], [NewsletterBearbeiten], [NewsletterLesen], [SchuleBearbeiten], [SchuleLesen], [SchulkindBearbeiten], [SchulkindLesen], [SchulsystemBearbeiten], [SchulsystemLesen], [StatistikenBearbeiten], [StatistikenLesen]) VALUES (N'90671da2-a763-409b-92c2-5a2005cdbac8', CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)), CAST(1 AS Numeric(1, 0)))
GO
INSERT [dbo].[AdminUserGroups] ([Id], [Name]) VALUES (N'90671da2-a763-409b-92c2-5a2005cdbac8', N'Global Admins')
GO
INSERT [dbo].[Categories] ([Id], [EmailUserId], [SuperCategoryId], [Title], [Color]) VALUES (N'0715be47-5aa3-4204-8dc7-036234fe0e79', N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', NULL, N'Wocheneinkauf', N'#993333')
INSERT [dbo].[Categories] ([Id], [EmailUserId], [SuperCategoryId], [Title], [Color]) VALUES (N'b7509f03-6ade-46bf-a8ed-6429f0d1170a', N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', NULL, N'Amazon', N'#FF9900')
INSERT [dbo].[Categories] ([Id], [EmailUserId], [SuperCategoryId], [Title], [Color]) VALUES (N'9bab243d-bdd1-4707-8606-9f8af4924aa5', N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', NULL, N'Fitnessstudio', N'#669900')
INSERT [dbo].[Categories] ([Id], [EmailUserId], [SuperCategoryId], [Title], [Color]) VALUES (N'5c9c765f-06e8-4e1c-b9b5-a37df702c6a5', N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', NULL, N'Gehalt', N'#99FF00')
GO
INSERT [dbo].[CategorySearchTerms] ([Id], [EmailUserId], [CategoryId], [Term]) VALUES (N'0fa8a0b4-7b09-4584-a3de-3fb2b466cbcf', N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', N'0715be47-5aa3-4204-8dc7-036234fe0e79', N'aldi')
INSERT [dbo].[CategorySearchTerms] ([Id], [EmailUserId], [CategoryId], [Term]) VALUES (N'3d24557c-554d-49db-8551-b8a5263e3415', N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', N'b7509f03-6ade-46bf-a8ed-6429f0d1170a', N'Amazon')
INSERT [dbo].[CategorySearchTerms] ([Id], [EmailUserId], [CategoryId], [Term]) VALUES (N'938282d9-4df9-4fff-9cef-c23afa41dd05', N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', N'9bab243d-bdd1-4707-8606-9f8af4924aa5', N'Buena Vista Fitnessclub')
INSERT [dbo].[CategorySearchTerms] ([Id], [EmailUserId], [CategoryId], [Term]) VALUES (N'ac73c213-16ce-4505-9608-c89dc1ab634c', N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', N'5c9c765f-06e8-4e1c-b9b5-a37df702c6a5', N'Gehaltszahlung')
GO
INSERT [dbo].[StartSalden] ([Id], [EmailUserId], [Betrag], [AmDatum]) VALUES (N'b2381462-1315-4376-983b-6c9417cae7c5', N'8dd8a19f-1f5e-4c58-b22d-b637068a2db1', CAST(12345.67 AS Decimal(8, 2)), CAST(N'2022-03-30T00:00:00.000' AS DateTime))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [AdminEmailUsersEmailUnique]    Script Date: 31.03.2022 18:43:20 ******/
CREATE UNIQUE NONCLUSTERED INDEX [AdminEmailUsersEmailUnique] ON [dbo].[AdminEmailUsers]
(
	[Email] ASC
)
WHERE ([Email] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__StartSal__2AD5FBA2E24162E4]    Script Date: 31.03.2022 18:43:20 ******/
ALTER TABLE [dbo].[StartSalden] ADD UNIQUE NONCLUSTERED 
(
	[EmailUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccountingEntries]  WITH CHECK ADD  CONSTRAINT [FK_AccountingEntries_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[AccountingEntries] CHECK CONSTRAINT [FK_AccountingEntries_CategoryId]
GO
ALTER TABLE [dbo].[AccountingEntries]  WITH CHECK ADD  CONSTRAINT [FK_AccountingEntries_EmailUserId] FOREIGN KEY([EmailUserId])
REFERENCES [dbo].[AdminEmailUsers] ([Id])
GO
ALTER TABLE [dbo].[AccountingEntries] CHECK CONSTRAINT [FK_AccountingEntries_EmailUserId]
GO
ALTER TABLE [dbo].[AdminAccessTokenAdminAdGroupRelations]  WITH CHECK ADD  CONSTRAINT [FK_AdminAccessTokenAdminAdGroupRelations_AdminAccessTokenId] FOREIGN KEY([AdminAccessTokenId])
REFERENCES [dbo].[AdminAccessTokens] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminAccessTokenAdminAdGroupRelations] CHECK CONSTRAINT [FK_AdminAccessTokenAdminAdGroupRelations_AdminAccessTokenId]
GO
ALTER TABLE [dbo].[AdminAccessTokenAdminAdGroupRelations]  WITH CHECK ADD  CONSTRAINT [FK_AdminAccessTokenAdminAdGroupRelations_AdminAdGroupId] FOREIGN KEY([AdminAdGroupId])
REFERENCES [dbo].[AdminAdGroups] ([Id])
GO
ALTER TABLE [dbo].[AdminAccessTokenAdminAdGroupRelations] CHECK CONSTRAINT [FK_AdminAccessTokenAdminAdGroupRelations_AdminAdGroupId]
GO
ALTER TABLE [dbo].[AdminAccessTokenCachedPermissions]  WITH CHECK ADD  CONSTRAINT [FK_AdminAccessTokenCachedPermissions_AdminAccessTokenId] FOREIGN KEY([AdminAccessTokenId])
REFERENCES [dbo].[AdminAccessTokens] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminAccessTokenCachedPermissions] CHECK CONSTRAINT [FK_AdminAccessTokenCachedPermissions_AdminAccessTokenId]
GO
ALTER TABLE [dbo].[AdminAccessTokens]  WITH CHECK ADD  CONSTRAINT [FK_AdminAccessTokens_AdminAdUserId] FOREIGN KEY([AdminAdUserId])
REFERENCES [dbo].[AdminAdUsers] ([Id])
GO
ALTER TABLE [dbo].[AdminAccessTokens] CHECK CONSTRAINT [FK_AdminAccessTokens_AdminAdUserId]
GO
ALTER TABLE [dbo].[AdminAccessTokens]  WITH CHECK ADD  CONSTRAINT [FK_AdminAccessTokens_AdminEmailUserId] FOREIGN KEY([AdminEmailUserId])
REFERENCES [dbo].[AdminEmailUsers] ([Id])
GO
ALTER TABLE [dbo].[AdminAccessTokens] CHECK CONSTRAINT [FK_AdminAccessTokens_AdminEmailUserId]
GO
ALTER TABLE [dbo].[AdminAccessTokens]  WITH CHECK ADD  CONSTRAINT [FK_AdminAccessTokens_AdminRefreshTokenId] FOREIGN KEY([AdminRefreshTokenId])
REFERENCES [dbo].[AdminRefreshTokens] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminAccessTokens] CHECK CONSTRAINT [FK_AdminAccessTokens_AdminRefreshTokenId]
GO
ALTER TABLE [dbo].[AdminAdGroupAdminUserGroupRelations]  WITH CHECK ADD  CONSTRAINT [FK_AdminAdGroupAdminUserGroupRelation_MemberId] FOREIGN KEY([MemberId])
REFERENCES [dbo].[AdminAdGroups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminAdGroupAdminUserGroupRelations] CHECK CONSTRAINT [FK_AdminAdGroupAdminUserGroupRelation_MemberId]
GO
ALTER TABLE [dbo].[AdminAdGroupAdminUserGroupRelations]  WITH CHECK ADD  CONSTRAINT [FK_AdminAdGroupAdminUserGroupRelation_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[AdminUserGroups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminAdGroupAdminUserGroupRelations] CHECK CONSTRAINT [FK_AdminAdGroupAdminUserGroupRelation_ParentId]
GO
ALTER TABLE [dbo].[AdminAdGroupPermissions]  WITH CHECK ADD  CONSTRAINT [FK_AdminAdGroupPermissions_AdminAdGroupId] FOREIGN KEY([AdminAdGroupId])
REFERENCES [dbo].[AdminAdGroups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminAdGroupPermissions] CHECK CONSTRAINT [FK_AdminAdGroupPermissions_AdminAdGroupId]
GO
ALTER TABLE [dbo].[AdminAdUserAdminUserGroupRelations]  WITH CHECK ADD  CONSTRAINT [FK_AdminAdUserAdminUserGroupRelation_MemberId] FOREIGN KEY([MemberId])
REFERENCES [dbo].[AdminAdUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminAdUserAdminUserGroupRelations] CHECK CONSTRAINT [FK_AdminAdUserAdminUserGroupRelation_MemberId]
GO
ALTER TABLE [dbo].[AdminAdUserAdminUserGroupRelations]  WITH CHECK ADD  CONSTRAINT [FK_AdminAdUserAdminUserGroupRelation_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[AdminUserGroups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminAdUserAdminUserGroupRelations] CHECK CONSTRAINT [FK_AdminAdUserAdminUserGroupRelation_ParentId]
GO
ALTER TABLE [dbo].[AdminAdUserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_AdminAdUserPermissions_AdminAdUserId] FOREIGN KEY([AdminAdUserId])
REFERENCES [dbo].[AdminAdUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminAdUserPermissions] CHECK CONSTRAINT [FK_AdminAdUserPermissions_AdminAdUserId]
GO
ALTER TABLE [dbo].[AdminEmailUserAdminUserGroupRelations]  WITH CHECK ADD  CONSTRAINT [FK_AdminEmailUserAdminUserGroupRelation_MemberId] FOREIGN KEY([MemberId])
REFERENCES [dbo].[AdminEmailUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminEmailUserAdminUserGroupRelations] CHECK CONSTRAINT [FK_AdminEmailUserAdminUserGroupRelation_MemberId]
GO
ALTER TABLE [dbo].[AdminEmailUserAdminUserGroupRelations]  WITH CHECK ADD  CONSTRAINT [FK_AdminEmailUserAdminUserGroupRelation_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[AdminUserGroups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminEmailUserAdminUserGroupRelations] CHECK CONSTRAINT [FK_AdminEmailUserAdminUserGroupRelation_ParentId]
GO
ALTER TABLE [dbo].[AdminEmailUserFailedLoginAttempts]  WITH CHECK ADD  CONSTRAINT [FK_AdminEmailUserFailedLoginAttempts_AdminEmailUserId] FOREIGN KEY([AdminEmailUserId])
REFERENCES [dbo].[AdminEmailUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminEmailUserFailedLoginAttempts] CHECK CONSTRAINT [FK_AdminEmailUserFailedLoginAttempts_AdminEmailUserId]
GO
ALTER TABLE [dbo].[AdminEmailUserPasswordResetTokens]  WITH CHECK ADD  CONSTRAINT [FK_AdminEmailUserPasswordResetToken_AdminEmailUserId] FOREIGN KEY([AdminEmailUserId])
REFERENCES [dbo].[AdminEmailUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminEmailUserPasswordResetTokens] CHECK CONSTRAINT [FK_AdminEmailUserPasswordResetToken_AdminEmailUserId]
GO
ALTER TABLE [dbo].[AdminEmailUserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_AdminEmailUserPermissions_AdminEmailUserId] FOREIGN KEY([AdminEmailUserId])
REFERENCES [dbo].[AdminEmailUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminEmailUserPermissions] CHECK CONSTRAINT [FK_AdminEmailUserPermissions_AdminEmailUserId]
GO
ALTER TABLE [dbo].[AdminRefreshTokenAdminAdGroupRelations]  WITH CHECK ADD  CONSTRAINT [FK_AdminRefreshTokenAdminAdGroupRelations_AdminAdGroupId] FOREIGN KEY([AdminAdGroupId])
REFERENCES [dbo].[AdminAdGroups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminRefreshTokenAdminAdGroupRelations] CHECK CONSTRAINT [FK_AdminRefreshTokenAdminAdGroupRelations_AdminAdGroupId]
GO
ALTER TABLE [dbo].[AdminRefreshTokenAdminAdGroupRelations]  WITH CHECK ADD  CONSTRAINT [FK_AdminRefreshTokenAdminAdGroupRelations_AdminRefreshTokenId] FOREIGN KEY([AdminRefreshTokenId])
REFERENCES [dbo].[AdminRefreshTokens] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminRefreshTokenAdminAdGroupRelations] CHECK CONSTRAINT [FK_AdminRefreshTokenAdminAdGroupRelations_AdminRefreshTokenId]
GO
ALTER TABLE [dbo].[AdminRefreshTokens]  WITH CHECK ADD  CONSTRAINT [FK_AdminRefreshTokens_AdminAdUserId] FOREIGN KEY([AdminAdUserId])
REFERENCES [dbo].[AdminAdUsers] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[AdminRefreshTokens] CHECK CONSTRAINT [FK_AdminRefreshTokens_AdminAdUserId]
GO
ALTER TABLE [dbo].[AdminRefreshTokens]  WITH CHECK ADD  CONSTRAINT [FK_AdminRefreshTokens_AdminEmailUserId] FOREIGN KEY([AdminEmailUserId])
REFERENCES [dbo].[AdminEmailUsers] ([Id])
GO
ALTER TABLE [dbo].[AdminRefreshTokens] CHECK CONSTRAINT [FK_AdminRefreshTokens_AdminEmailUserId]
GO
ALTER TABLE [dbo].[AdminUserGroupAdminUserGroupRelations]  WITH CHECK ADD  CONSTRAINT [FK_AdminUserGroupAdminUserGroupRelation_MemberId] FOREIGN KEY([MemberId])
REFERENCES [dbo].[AdminUserGroups] ([Id])
GO
ALTER TABLE [dbo].[AdminUserGroupAdminUserGroupRelations] CHECK CONSTRAINT [FK_AdminUserGroupAdminUserGroupRelation_MemberId]
GO
ALTER TABLE [dbo].[AdminUserGroupAdminUserGroupRelations]  WITH CHECK ADD  CONSTRAINT [FK_AdminUserGroupAdminUserGroupRelation_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[AdminUserGroups] ([Id])
GO
ALTER TABLE [dbo].[AdminUserGroupAdminUserGroupRelations] CHECK CONSTRAINT [FK_AdminUserGroupAdminUserGroupRelation_ParentId]
GO
ALTER TABLE [dbo].[AdminUserGroupPermissions]  WITH CHECK ADD  CONSTRAINT [FK_AdminUserGroupPermissions_AdminUserGroupId] FOREIGN KEY([AdminUserGroupId])
REFERENCES [dbo].[AdminUserGroups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminUserGroupPermissions] CHECK CONSTRAINT [FK_AdminUserGroupPermissions_AdminUserGroupId]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_EmailUserId] FOREIGN KEY([EmailUserId])
REFERENCES [dbo].[AdminEmailUsers] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_EmailUserId]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_SuperCategoryId] FOREIGN KEY([SuperCategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_SuperCategoryId]
GO
ALTER TABLE [dbo].[CategorySearchTerms]  WITH CHECK ADD  CONSTRAINT [FK_CategorySearchTerms_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[CategorySearchTerms] CHECK CONSTRAINT [FK_CategorySearchTerms_CategoryId]
GO
ALTER TABLE [dbo].[CategorySearchTerms]  WITH CHECK ADD  CONSTRAINT [FK_CategorySearchTerms_EmailUserId] FOREIGN KEY([EmailUserId])
REFERENCES [dbo].[AdminEmailUsers] ([Id])
GO
ALTER TABLE [dbo].[CategorySearchTerms] CHECK CONSTRAINT [FK_CategorySearchTerms_EmailUserId]
GO
ALTER TABLE [dbo].[StartSalden]  WITH CHECK ADD  CONSTRAINT [FK_StartSalden_EmailUserId] FOREIGN KEY([EmailUserId])
REFERENCES [dbo].[AdminEmailUsers] ([Id])
GO
ALTER TABLE [dbo].[StartSalden] CHECK CONSTRAINT [FK_StartSalden_EmailUserId]
GO
USE [master]
GO
ALTER DATABASE [FinanzuebersichtCore] SET  READ_WRITE 
GO
