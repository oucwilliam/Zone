USE [qqZone]
GO
/****** Object:  Table [dbo].[Friends]    Script Date: 2017/12/10 22:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friends](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Friends] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Friends] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FriendsSure]    Script Date: 2017/12/10 22:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FriendsSure](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Friends] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FriendsSure] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Introduction]    Script Date: 2017/12/10 22:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Introduction](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Sex] [nchar](1) NULL,
	[Age] [int] NULL,
	[Blood] [nvarchar](50) NULL,
	[Constellation] [nvarchar](50) NULL,
	[Occupation] [nvarchar](50) NULL,
	[Birthday] [date] NULL,
 CONSTRAINT [PK_Introduction] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 2017/12/10 22:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Contents] [text] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Message]    Script Date: 2017/12/10 22:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MessageId] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Friends] [nvarchar](50) NOT NULL,
	[Contents] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[qqZoneUsers]    Script Date: 2017/12/10 22:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[qqZoneUsers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IdCard] [nchar](18) NOT NULL,
 CONSTRAINT [PK_qqZoneUsers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Friends] ON 

INSERT [dbo].[Friends] ([id], [UserName], [Friends]) VALUES (5, N'william', N'xiaohong')
INSERT [dbo].[Friends] ([id], [UserName], [Friends]) VALUES (6, N'william', N'xiaoming')
INSERT [dbo].[Friends] ([id], [UserName], [Friends]) VALUES (9, N'xiaohong', N'william')
INSERT [dbo].[Friends] ([id], [UserName], [Friends]) VALUES (10, N'xiaoming', N'william')
INSERT [dbo].[Friends] ([id], [UserName], [Friends]) VALUES (12, N'xiaogang', N'william')
INSERT [dbo].[Friends] ([id], [UserName], [Friends]) VALUES (13, N'william', N'xiaogang')
INSERT [dbo].[Friends] ([id], [UserName], [Friends]) VALUES (14, N'xiaogang', N'william')
SET IDENTITY_INSERT [dbo].[Friends] OFF
SET IDENTITY_INSERT [dbo].[Introduction] ON 

INSERT [dbo].[Introduction] ([id], [UserName], [Sex], [Age], [Blood], [Constellation], [Occupation], [Birthday]) VALUES (1, N'william', N'M', 0, N'', N'', N'', CAST(0x74220B00 AS Date))
SET IDENTITY_INSERT [dbo].[Introduction] OFF
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([id], [UserName], [Title], [Date], [Contents]) VALUES (1, N'william', N'Hello', CAST(0xA03D0B00 AS Date), N'Hello world!')
INSERT [dbo].[Logs] ([id], [UserName], [Title], [Date], [Contents]) VALUES (2, N'william', N'2', CAST(0xA03D0B00 AS Date), N'hahaha')
INSERT [dbo].[Logs] ([id], [UserName], [Title], [Date], [Contents]) VALUES (3, N'william', N'789', CAST(0x9D3D0B00 AS Date), N'asdasda')
INSERT [dbo].[Logs] ([id], [UserName], [Title], [Date], [Contents]) VALUES (4, N'william', N'123123', CAST(0xA03D0B00 AS Date), N'1111')
INSERT [dbo].[Logs] ([id], [UserName], [Title], [Date], [Contents]) VALUES (5, N'xiaoming', N'111', CAST(0xA03D0B00 AS Date), N'564864sdf')
INSERT [dbo].[Logs] ([id], [UserName], [Title], [Date], [Contents]) VALUES (6, N'xiaoming', N'23412', CAST(0xA03D0B00 AS Date), N'8564asd')
SET IDENTITY_INSERT [dbo].[Logs] OFF
SET IDENTITY_INSERT [dbo].[Message] ON 

INSERT [dbo].[Message] ([id], [MessageId], [UserName], [Friends], [Contents]) VALUES (1, 0, N'william', N'william', N'123')
INSERT [dbo].[Message] ([id], [MessageId], [UserName], [Friends], [Contents]) VALUES (2, 1, N'william', N'xiaoming', N'233')
INSERT [dbo].[Message] ([id], [MessageId], [UserName], [Friends], [Contents]) VALUES (3, 0, N'william', N'xiaohong', N'520')
INSERT [dbo].[Message] ([id], [MessageId], [UserName], [Friends], [Contents]) VALUES (4, 3, N'william', N'william', N'520')
INSERT [dbo].[Message] ([id], [MessageId], [UserName], [Friends], [Contents]) VALUES (7, 0, N'william', N'william', N'ddd')
SET IDENTITY_INSERT [dbo].[Message] OFF
SET IDENTITY_INSERT [dbo].[qqZoneUsers] ON 

INSERT [dbo].[qqZoneUsers] ([id], [UserName], [Password], [Phone], [Name], [IdCard]) VALUES (1, N'william', N'123456', N'18950157498', N'林威', N'350204199811241017')
INSERT [dbo].[qqZoneUsers] ([id], [UserName], [Password], [Phone], [Name], [IdCard]) VALUES (2, N'xiaoming', N'123456', N'11111111111', N'小明', N'350204199811241001')
INSERT [dbo].[qqZoneUsers] ([id], [UserName], [Password], [Phone], [Name], [IdCard]) VALUES (3, N'xiaohong', N'123456', N'22222222222', N'小红', N'350204199911110022')
INSERT [dbo].[qqZoneUsers] ([id], [UserName], [Password], [Phone], [Name], [IdCard]) VALUES (4, N'xiaogang', N'123456', N'33333333333', N'小刚', N'111111111111111111')
SET IDENTITY_INSERT [dbo].[qqZoneUsers] OFF
