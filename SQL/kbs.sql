USE [KBS]
GO
/****** Object:  Table [dbo].[Card]    Script Date: 2019/12/10 下午 10:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Card](
	[CardId] [smallint] NOT NULL,
	[CatId] [smallint] NOT NULL,
	[CardName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED 
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CardCatalog]    Script Date: 2019/12/10 下午 10:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardCatalog](
	[CatId] [smallint] IDENTITY(1,1) NOT NULL,
	[CatalogName] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Catalog] PRIMARY KEY CLUSTERED 
(
	[CatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chart]    Script Date: 2019/12/10 下午 10:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chart](
	[ChartId] [tinyint] IDENTITY(1,1) NOT NULL,
	[ChartType] [varchar](20) NOT NULL,
	[ChartScript] [nvarchar](800) NOT NULL,
 CONSTRAINT [PK_Chart] PRIMARY KEY CLUSTERED 
(
	[ChartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conn]    Script Date: 2019/12/10 下午 10:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conn](
	[CId] [int] IDENTITY(1,1) NOT NULL,
	[DBType] [nvarchar](20) NOT NULL,
	[ConnStr] [varchar](500) NOT NULL,
	[AliasName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Conn_1] PRIMARY KEY CLUSTERED 
(
	[CId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurrencyTest]    Script Date: 2019/12/10 下午 10:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrencyTest](
	[Mon] [varchar](10) NOT NULL,
	[Currency] [decimal](10, 4) NOT NULL,
	[CurrencyType] [varchar](8) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KBProject]    Script Date: 2019/12/10 下午 10:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KBProject](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](50) NOT NULL,
	[ProjectSQL] [varchar](max) NOT NULL,
	[CId] [int] NOT NULL,
	[IsEnable] [bit] NOT NULL,
 CONSTRAINT [PK_KBProject] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Chart] ON 

INSERT [dbo].[Chart] ([ChartId], [ChartType], [ChartScript]) VALUES (1, N'Line', N'var chart = c3.generate({ data: { columns: [[@Data]],type: ''line'' }, transition: { duration: 1200 }, grid: { x: { show: true }, y: { show: true } }, axis: { x: { type: ''category'', categories: [@Catelog] } } });')
INSERT [dbo].[Chart] ([ChartId], [ChartType], [ChartScript]) VALUES (2, N'Bar', N'var chart = c3.generate({ data: { type: ''bar'' }, bar: { width: { ratio: 0.5 } }, grid: { x: { show: true }, y: { show: true }}});')
SET IDENTITY_INSERT [dbo].[Chart] OFF
SET IDENTITY_INSERT [dbo].[Conn] ON 

INSERT [dbo].[Conn] ([CId], [DBType], [ConnStr], [AliasName]) VALUES (1, N'SQLServer', N'data source=(local);initial catalog=KBS;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework', N'SQLTest')
SET IDENTITY_INSERT [dbo].[Conn] OFF
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-09', CAST(30.5510 AS Decimal(10, 4)), N'USD')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-09', CAST(6.8814 AS Decimal(10, 4)), N'RMB')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-09', CAST(113.4200 AS Decimal(10, 4)), N'JPY')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-09', CAST(1109.3000 AS Decimal(10, 4)), N'WON')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-09', CAST(1.3673 AS Decimal(10, 4)), N'SGD')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-09', CAST(1.1619 AS Decimal(10, 4)), N'EUR')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-09', CAST(1.3061 AS Decimal(10, 4)), N'GBR')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-09', CAST(0.7218 AS Decimal(10, 4)), N'AUS')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-10', CAST(30.9680 AS Decimal(10, 4)), N'USD')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-10', CAST(6.9734 AS Decimal(10, 4)), N'RMB')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-10', CAST(113.1900 AS Decimal(10, 4)), N'JPY')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-10', CAST(1139.6000 AS Decimal(10, 4)), N'WON')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-10', CAST(1.3855 AS Decimal(10, 4)), N'SGD')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-10', CAST(1.1349 AS Decimal(10, 4)), N'EUR')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-10', CAST(1.2725 AS Decimal(10, 4)), N'GBR')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-10', CAST(0.7084 AS Decimal(10, 4)), N'AUS')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-11', CAST(30.8500 AS Decimal(10, 4)), N'USD')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-11', CAST(6.9436 AS Decimal(10, 4)), N'RMB')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-11', CAST(113.4700 AS Decimal(10, 4)), N'JPY')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-11', CAST(1121.2000 AS Decimal(10, 4)), N'WON')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-11', CAST(1.3705 AS Decimal(10, 4)), N'SGD')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-11', CAST(1.1381 AS Decimal(10, 4)), N'EUR')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-11', CAST(1.2777 AS Decimal(10, 4)), N'GBR')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-11', CAST(0.7312 AS Decimal(10, 4)), N'AUS')
ALTER TABLE [dbo].[KBProject] ADD  CONSTRAINT [DF_KBProject_IsEnable]  DEFAULT ((1)) FOR [IsEnable]
GO
