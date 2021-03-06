USE [master]
GO
/****** Object:  Database [Portal]    Script Date: 7/23/2021 2:41:03 PM ******/
CREATE DATABASE [Portal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Portal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Portal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Portal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Portal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Portal] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Portal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Portal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Portal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Portal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Portal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Portal] SET ARITHABORT OFF 
GO
ALTER DATABASE [Portal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Portal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Portal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Portal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Portal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Portal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Portal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Portal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Portal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Portal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Portal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Portal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Portal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Portal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Portal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Portal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Portal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Portal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Portal] SET  MULTI_USER 
GO
ALTER DATABASE [Portal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Portal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Portal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Portal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Portal] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Portal] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Portal] SET QUERY_STORE = OFF
GO
USE [Portal]
GO
/****** Object:  Table [dbo].[Agency]    Script Date: 7/23/2021 2:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Agency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusinessUnit]    Script Date: 7/23/2021 2:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessUnit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_BusinessUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Campaign]    Script Date: 7/23/2021 2:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campaign](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Campaign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 7/23/2021 2:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientBusinessUnit]    Script Date: 7/23/2021 2:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientBusinessUnit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[BusinessUnitId] [int] NOT NULL,
 CONSTRAINT [PK_ClientBusinessUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currency]    Script Date: 7/23/2021 2:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 7/23/2021 2:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Reference] [nvarchar](250) NULL,
	[ClientId] [int] NOT NULL,
	[AgencyId] [int] NOT NULL,
	[CampaignId] [int] NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[InvoiceNumber] [nvarchar](150) NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[InvoiceStatusId] [int] NOT NULL,
	[InvoiceStatusColor] [nvarchar](150) NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Agency] ON 

INSERT [dbo].[Agency] ([Id], [Name]) VALUES (1, N'My Agency')
INSERT [dbo].[Agency] ([Id], [Name]) VALUES (2, N'My Agency')
SET IDENTITY_INSERT [dbo].[Agency] OFF
GO
SET IDENTITY_INSERT [dbo].[BusinessUnit] ON 

INSERT [dbo].[BusinessUnit] ([Id], [Name]) VALUES (1, N'CC')
INSERT [dbo].[BusinessUnit] ([Id], [Name]) VALUES (2, N'CBU Digital')
SET IDENTITY_INSERT [dbo].[BusinessUnit] OFF
GO
SET IDENTITY_INSERT [dbo].[Campaign] ON 

INSERT [dbo].[Campaign] ([Id], [Name]) VALUES (1, N'Summer Festival')
SET IDENTITY_INSERT [dbo].[Campaign] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [Name]) VALUES (2, N'STC')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientBusinessUnit] ON 

INSERT [dbo].[ClientBusinessUnit] ([Id], [ClientId], [BusinessUnitId]) VALUES (1, 2, 1)
INSERT [dbo].[ClientBusinessUnit] ([Id], [ClientId], [BusinessUnitId]) VALUES (2, 2, 2)
SET IDENTITY_INSERT [dbo].[ClientBusinessUnit] OFF
GO
SET IDENTITY_INSERT [dbo].[Currency] ON 

INSERT [dbo].[Currency] ([Id], [Name]) VALUES (1, N'USD')
INSERT [dbo].[Currency] ([Id], [Name]) VALUES (2, N'AED')
SET IDENTITY_INSERT [dbo].[Currency] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoice] ON 

INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (29, N'4DD5BE9E-42EA-473C-8084-67EA2C2053B9', 2, 2, 1, 1, N'INV-202102-01', CAST(N'2021-02-01T00:00:00.000' AS DateTime), CAST(1500.00 AS Decimal(18, 2)), 2, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (30, N'0B393654-9A50-416D-8AE3-B794B8EE6D42', 2, 2, 1, 1, N'INV-202103-01', CAST(N'2021-03-01T00:00:00.000' AS DateTime), CAST(8520.00 AS Decimal(18, 2)), 2, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (31, N'1549A0C1-4354-49E4-B4BF-C57E949D3C83', 2, 2, 1, 1, N'INV-202104-01', CAST(N'2021-04-01T00:00:00.000' AS DateTime), CAST(700.00 AS Decimal(18, 2)), 2, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (32, N'652AFD1A-73EB-4441-BA34-37C8D49C5B1E', 2, 2, 1, 1, N'INV-202105-01', CAST(N'2021-05-01T00:00:00.000' AS DateTime), CAST(350.00 AS Decimal(18, 2)), 2, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (33, N'7DE57158-04B3-4209-B045-4B27F61F9124', 2, 2, 1, 1, N'INV-202106-01', CAST(N'2021-06-01T00:00:00.000' AS DateTime), CAST(2500.00 AS Decimal(18, 2)), 2, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (34, N'6F0B6F52-7063-4C49-A127-362F7A8FD42E', 2, 2, 1, 1, N'INV-202107-01', CAST(N'2021-07-01T00:00:00.000' AS DateTime), CAST(3200.00 AS Decimal(18, 2)), 2, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (35, N'3AC40032-91C4-432F-B358-FF319EA2134B', 2, 2, 1, 1, N'INV-202108-01', CAST(N'2021-08-01T00:00:00.000' AS DateTime), CAST(5500.00 AS Decimal(18, 2)), 2, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (36, N'75A9C054-4841-4A9F-99BC-D199B30B5262', 2, 2, 1, 1, N'INV-202109-01', CAST(N'2021-09-01T00:00:00.000' AS DateTime), CAST(6800.00 AS Decimal(18, 2)), 2, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (37, N'FA4019B8-A76F-459B-BFB8-BC2B0B4A07A9', 2, 2, 1, 1, N'INV-202110-01', CAST(N'2021-10-01T00:00:00.000' AS DateTime), CAST(1500.00 AS Decimal(18, 2)), 2, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (38, N'54DBBA2D-6065-4653-A7F4-88DA390B6005', 2, 2, 1, 1, N'INV-202111-01', CAST(N'2021-11-01T00:00:00.000' AS DateTime), CAST(3000.00 AS Decimal(18, 2)), 2, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (39, N'', 2, 2, 1, 1, N'07775000', CAST(N'2021-06-18T00:00:00.000' AS DateTime), CAST(1000.00 AS Decimal(18, 2)), 1, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (40, N'00000000-0000-0000-0000-000000000000', 2, 2, 1, 2, N'zxzxzx', CAST(N'2021-06-14T00:00:00.000' AS DateTime), CAST(333.00 AS Decimal(18, 2)), 1, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (41, N'3e13f07c-e28a-4acc-b4a0-8bfaad1618ca', 2, 2, 1, 1, N'inv 2021-06-15', CAST(N'2021-06-15T00:00:00.000' AS DateTime), CAST(500.00 AS Decimal(18, 2)), 2, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (42, N'f6d7f8f8-2bab-4aed-9480-69f534b62eea', 2, 2, 1, 1, N'okok', CAST(N'2021-06-16T00:00:00.000' AS DateTime), CAST(10.00 AS Decimal(18, 2)), 1, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (43, N'c8b5c5a7-3cf3-4214-a48d-149f73a2a1bf', 2, 2, 1, 1, N'okok', CAST(N'2021-06-16T00:00:00.000' AS DateTime), CAST(10.00 AS Decimal(18, 2)), 1, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (44, N'bf6ee017-ffc6-4e6a-b2bc-5e1ca3ffd684', 2, 2, 1, 1, N'okokok', CAST(N'2021-06-16T00:00:00.000' AS DateTime), CAST(10000.00 AS Decimal(18, 2)), 1, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (45, N'3edbdf6a-eeae-45a4-93dd-db41a9388e4d', 2, 2, 1, 1, N'test', CAST(N'2021-06-18T00:00:00.000' AS DateTime), CAST(123123.00 AS Decimal(18, 2)), 1, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (46, N'da888c40-d47f-4e59-90d4-10a373216c63', 2, 2, 1, 1, N'TEST-12345678', CAST(N'2021-06-19T00:00:00.000' AS DateTime), CAST(2000.00 AS Decimal(18, 2)), 1, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (47, N'5f135b61-10ce-4136-a488-a19cde849963', 2, 2, 1, 1, N'TEST - 45678', CAST(N'2021-06-18T00:00:00.000' AS DateTime), CAST(2000.00 AS Decimal(18, 2)), 1, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (48, N'fef1f059-b00b-4b4e-9d32-a7110f687b8f', 2, 2, 1, 1, N'Test yb', CAST(N'2021-06-18T00:00:00.000' AS DateTime), CAST(1200.00 AS Decimal(18, 2)), 1, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (49, N'ec9fed0e-6fff-4d65-80e8-ca095d2fc367', 2, 2, 1, 1, N'666', CAST(N'2021-06-18T00:00:00.000' AS DateTime), CAST(1500.00 AS Decimal(18, 2)), 1, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (50, N'9cadf115-25d2-496e-bd96-58c0741d4402', 2, 2, 1, 1, N'ka', CAST(N'2021-06-18T00:00:00.000' AS DateTime), CAST(123.00 AS Decimal(18, 2)), 1, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (51, N'efa1c1f8-fffc-4ec0-8566-a26114aaa7f0', 2, 2, 1, 1, N'final', CAST(N'2021-06-18T00:00:00.000' AS DateTime), CAST(20.00 AS Decimal(18, 2)), 1, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (52, N'79f605f8-e2bc-4c98-b46c-3b2b661dd58c', 2, 2, 1, 1, N'test', CAST(N'2021-06-18T00:00:00.000' AS DateTime), CAST(1900.00 AS Decimal(18, 2)), 1, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (53, N'd41113f3-3812-4aee-8ad5-5939921db7cd', 2, 2, 1, 1, N'INV-20210619', CAST(N'2021-06-19T00:00:00.000' AS DateTime), CAST(1500.00 AS Decimal(18, 2)), 1, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (54, N'04c92451-b21d-4897-b7e3-cd9c104b95d6', 2, 2, 1, 1, N'INV-20210619', CAST(N'2021-06-19T00:00:00.000' AS DateTime), CAST(1500.00 AS Decimal(18, 2)), 2, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (55, N'4fa7b1e6-a957-4b6e-bb57-b5bc668abc52', 2, 2, 1, 1, N'123', CAST(N'2021-06-19T00:00:00.000' AS DateTime), CAST(1230.00 AS Decimal(18, 2)), 2, N'#13A2DD')
INSERT [dbo].[Invoice] ([Id], [Reference], [ClientId], [AgencyId], [CampaignId], [CurrencyId], [InvoiceNumber], [InvoiceDate], [Amount], [InvoiceStatusId], [InvoiceStatusColor]) VALUES (56, N'2922332c-d54d-468a-9b9d-ffd6db78299a', 2, 2, 1, 1, N'12345', CAST(N'2021-06-22T00:00:00.000' AS DateTime), CAST(2000.00 AS Decimal(18, 2)), 1, N'#13A2DD')
SET IDENTITY_INSERT [dbo].[Invoice] OFF
GO
ALTER TABLE [dbo].[ClientBusinessUnit]  WITH CHECK ADD  CONSTRAINT [FK_ClientBusinessUnit_BusinessUnit] FOREIGN KEY([BusinessUnitId])
REFERENCES [dbo].[BusinessUnit] ([Id])
GO
ALTER TABLE [dbo].[ClientBusinessUnit] CHECK CONSTRAINT [FK_ClientBusinessUnit_BusinessUnit]
GO
ALTER TABLE [dbo].[ClientBusinessUnit]  WITH CHECK ADD  CONSTRAINT [FK_ClientBusinessUnit_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[ClientBusinessUnit] CHECK CONSTRAINT [FK_ClientBusinessUnit_Client]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Agency] FOREIGN KEY([AgencyId])
REFERENCES [dbo].[Agency] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Agency]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Campaign] FOREIGN KEY([CampaignId])
REFERENCES [dbo].[Campaign] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Campaign]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Client]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Currency] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Currency]
GO
/****** Object:  StoredProcedure [dbo].[SP_LatestBilling]    Script Date: 7/23/2021 2:41:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_LatestBilling]
@Page INT = 1 , 
@Size INT = 10,
@Sort nvarchar(50)= 'Desc'
AS 
BEGIN

select 
MONTH([InvoiceDate]) as MonthNo,
 FORMAT([InvoiceDate],'MMMM')  as InvoiceMonth ,
year( [InvoiceDate]) as InvoiceYear ,
sum(amount) as TotalBilling,
0 as TotalApproved,
0 as TotalPaid,
COUNT(*) OVER() AS TotalCount 

from [dbo].[Invoice]  group by FORMAT([InvoiceDate],'MMMM'),MONTH([InvoiceDate]),year( [InvoiceDate])

order by
CASE WHEN @Sort = 'ASC' THEN MONTH([InvoiceDate])END ASC
 , CASE WHEN @Sort = 'DESC' THEN  MONTH([InvoiceDate])END DESC 

   OFFSET (@Page -1) * @Size ROWS 
           FETCH NEXT @Size ROWS ONLY END
GO
USE [master]
GO
ALTER DATABASE [Portal] SET  READ_WRITE 
GO
