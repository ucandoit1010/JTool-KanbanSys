USE [KBS]
GO
/****** Object:  Table [dbo].[Chart]    Script Date: 2020/1/2 下午 07:47:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChartProperty]    Script Date: 2020/1/2 下午 07:47:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChartProperty](
	[CPId] [int] IDENTITY(1,1) NOT NULL,
	[ChartId] [tinyint] NOT NULL,
	[CPName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ChartProperty] PRIMARY KEY CLUSTERED 
(
	[CPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Conn]    Script Date: 2020/1/2 下午 07:47:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conn](
	[CId] [int] IDENTITY(1,1) NOT NULL,
	[DBType] [nvarchar](20) NOT NULL,
	[ConnStr] [varchar](500) NOT NULL,
	[AliasName] [nvarchar](50) NOT NULL,
	[IsEnable] [bit] NOT NULL,
 CONSTRAINT [PK_Conn_1] PRIMARY KEY CLUSTERED 
(
	[CId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CurrencyJPY]    Script Date: 2020/1/2 下午 07:47:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CurrencyJPY](
	[CId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Mon] [varchar](10) NOT NULL,
	[Currency] [decimal](10, 4) NOT NULL,
	[CurrencyType] [varchar](8) NOT NULL,
 CONSTRAINT [PK_CurrencyJPY] PRIMARY KEY CLUSTERED 
(
	[CId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CurrencyTest]    Script Date: 2020/1/2 下午 07:47:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CurrencyTest](
	[Mon] [varchar](10) NOT NULL,
	[Currency] [decimal](10, 4) NOT NULL,
	[CurrencyType] [varchar](8) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KBProject]    Script Date: 2020/1/2 下午 07:47:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KBProject](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](50) NOT NULL,
	[ProjectSQL] [varchar](max) NOT NULL,
	[CId] [int] NOT NULL,
	[IsEnable] [bit] NOT NULL,
	[ChartId] [tinyint] NOT NULL,
	[Url] [varchar](50) NULL,
 CONSTRAINT [PK_KBProject] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectMapping]    Script Date: 2020/1/2 下午 07:47:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProjectMapping](
	[PMId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[PropertyName] [varchar](40) NOT NULL,
	[CPId] [int] NOT NULL,
 CONSTRAINT [PK_ProjectMapping] PRIMARY KEY CLUSTERED 
(
	[PMId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Chart] ON 

INSERT [dbo].[Chart] ([ChartId], [ChartType], [ChartScript]) VALUES (1, N'Line', N'var chart = c3.generate(@Content);')
INSERT [dbo].[Chart] ([ChartId], [ChartType], [ChartScript]) VALUES (2, N'Bar', N'var chart = c3.generate(@Content);')
SET IDENTITY_INSERT [dbo].[Chart] OFF
SET IDENTITY_INSERT [dbo].[ChartProperty] ON 

INSERT [dbo].[ChartProperty] ([CPId], [ChartId], [CPName]) VALUES (1, 1, N'@Data')
INSERT [dbo].[ChartProperty] ([CPId], [ChartId], [CPName]) VALUES (2, 1, N'@Catalog')
INSERT [dbo].[ChartProperty] ([CPId], [ChartId], [CPName]) VALUES (3, 2, N'@Data')
INSERT [dbo].[ChartProperty] ([CPId], [ChartId], [CPName]) VALUES (4, 2, N'@Catalog')
SET IDENTITY_INSERT [dbo].[ChartProperty] OFF
SET IDENTITY_INSERT [dbo].[Conn] ON 

INSERT [dbo].[Conn] ([CId], [DBType], [ConnStr], [AliasName], [IsEnable]) VALUES (1, N'1', N'data source=(local);initial catalog=KBS;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework', N'SQLServerCurrency', 1)
INSERT [dbo].[Conn] ([CId], [DBType], [ConnStr], [AliasName], [IsEnable]) VALUES (3, N'2', N'ddd123', N'OOO123', 1)
SET IDENTITY_INSERT [dbo].[Conn] OFF
SET IDENTITY_INSERT [dbo].[CurrencyJPY] ON 

INSERT [dbo].[CurrencyJPY] ([CId], [Mon], [Currency], [CurrencyType]) VALUES (1, N'2019-12', CAST(3.6300 AS Decimal(10, 4)), N'JPY')
INSERT [dbo].[CurrencyJPY] ([CId], [Mon], [Currency], [CurrencyType]) VALUES (2, N'2019-11', CAST(3.5400 AS Decimal(10, 4)), N'JPY')
INSERT [dbo].[CurrencyJPY] ([CId], [Mon], [Currency], [CurrencyType]) VALUES (3, N'2019-10', CAST(3.4700 AS Decimal(10, 4)), N'JPY')
INSERT [dbo].[CurrencyJPY] ([CId], [Mon], [Currency], [CurrencyType]) VALUES (4, N'2019-09', CAST(3.3800 AS Decimal(10, 4)), N'JPY')
INSERT [dbo].[CurrencyJPY] ([CId], [Mon], [Currency], [CurrencyType]) VALUES (5, N'2019-08', CAST(3.4900 AS Decimal(10, 4)), N'JPY')
SET IDENTITY_INSERT [dbo].[CurrencyJPY] OFF
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-09', CAST(30.5510 AS Decimal(10, 4)), N'USD')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-09', CAST(6.8814 AS Decimal(10, 4)), N'RMB')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-09', CAST(113.4200 AS Decimal(10, 4)), N'JPY')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-09', CAST(1109.3000 AS Decimal(10, 4)), N'WON')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-09', CAST(1.3673 AS Decimal(10, 4)), N'SGD')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-09', CAST(1.1619 AS Decimal(10, 4)), N'EUR')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-09', CAST(1.3061 AS Decimal(10, 4)), N'GBR')
INSERT [dbo].[CurrencyTest] ([Mon], [Currency], [CurrencyType]) VALUES (N'2018-09', CAST(0.7218 AS Decimal(10, 4)), N'AUS')
SET IDENTITY_INSERT [dbo].[KBProject] ON 

INSERT [dbo].[KBProject] ([ProjectId], [ProjectName], [ProjectSQL], [CId], [IsEnable], [ChartId], [Url]) VALUES (1, N'exchange', N'SELECT [Mon]
      ,[Currency]
      ,[CurrencyType]
  FROM [KBS].[dbo].[CurrencyTest]', 1, 1, 1, N'XPlw5Iex883')
SET IDENTITY_INSERT [dbo].[KBProject] OFF
SET IDENTITY_INSERT [dbo].[ProjectMapping] ON 

INSERT [dbo].[ProjectMapping] ([PMId], [ProjectId], [PropertyName], [CPId]) VALUES (1, 1, N'Currency', 1)
INSERT [dbo].[ProjectMapping] ([PMId], [ProjectId], [PropertyName], [CPId]) VALUES (3, 1, N'Mon', 2)
SET IDENTITY_INSERT [dbo].[ProjectMapping] OFF
ALTER TABLE [dbo].[Conn] ADD  CONSTRAINT [DF_Conn_IsEnable]  DEFAULT ((1)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[KBProject] ADD  CONSTRAINT [DF_KBProject_IsEnable]  DEFAULT ((1)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[ChartProperty]  WITH CHECK ADD  CONSTRAINT [FK_ChartProperty_ChartProperty] FOREIGN KEY([ChartId])
REFERENCES [dbo].[Chart] ([ChartId])
GO
ALTER TABLE [dbo].[ChartProperty] CHECK CONSTRAINT [FK_ChartProperty_ChartProperty]
GO
ALTER TABLE [dbo].[KBProject]  WITH NOCHECK ADD  CONSTRAINT [FK_KBProject_Conn] FOREIGN KEY([CId])
REFERENCES [dbo].[Conn] ([CId])
GO
ALTER TABLE [dbo].[KBProject] NOCHECK CONSTRAINT [FK_KBProject_Conn]
GO
ALTER TABLE [dbo].[KBProject]  WITH CHECK ADD  CONSTRAINT [FK_KBProject_KBProject] FOREIGN KEY([ChartId])
REFERENCES [dbo].[Chart] ([ChartId])
GO
ALTER TABLE [dbo].[KBProject] CHECK CONSTRAINT [FK_KBProject_KBProject]
GO
ALTER TABLE [dbo].[ProjectMapping]  WITH CHECK ADD  CONSTRAINT [FK_ProjectMapping_KBProject] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[KBProject] ([ProjectId])
GO
ALTER TABLE [dbo].[ProjectMapping] CHECK CONSTRAINT [FK_ProjectMapping_KBProject]
GO
