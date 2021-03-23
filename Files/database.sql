
CREATE TABLE [Satellite](
	[id] [int] NOT NULL,
	[satelliteName] [varchar](50) NULL,
	[distance] [decimal](8, 2) NULL,
	[messageArray] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Satellite] ([id], [satelliteName], [distance], [messageArray]) VALUES (1, N'kenobi', NULL, NULL)
GO
INSERT [dbo].[Satellite] ([id], [satelliteName], [distance], [messageArray]) VALUES (2, N'skywalker', NULL, NULL)
GO
INSERT [dbo].[Satellite] ([id], [satelliteName], [distance], [messageArray]) VALUES (3, N'sato', NULL, NULL)
GO
