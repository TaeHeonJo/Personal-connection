USE [personal connection]
GO
/****** Object:  Table [dbo].[content]    Script Date: 2018-04-22 오전 11:00:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[content](
	[no] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NOT NULL,
	[content] [nchar](10) NULL,
	[pn_no] [int] NOT NULL,
 CONSTRAINT [PK_content] PRIMARY KEY CLUSTERED 
(
	[no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[people name]    Script Date: 2018-04-22 오전 11:00:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[people name](
	[no] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NOT NULL,
 CONSTRAINT [PK_people name] PRIMARY KEY CLUSTERED 
(
	[no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[content] ON 

INSERT [dbo].[content] ([no], [name], [content], [pn_no]) VALUES (1, N'조태헌       ', N'안녕하세요     ', 1)
INSERT [dbo].[content] ([no], [name], [content], [pn_no]) VALUES (4, N'조태헌       ', N' 반갑습니다    ', 1)
SET IDENTITY_INSERT [dbo].[content] OFF
SET IDENTITY_INSERT [dbo].[people name] ON 

INSERT [dbo].[people name] ([no], [name]) VALUES (1, N'조태헌       ')
INSERT [dbo].[people name] ([no], [name]) VALUES (4, N'조수인       ')
SET IDENTITY_INSERT [dbo].[people name] OFF
