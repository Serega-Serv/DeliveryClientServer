USE [tost_1]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 27.10.2024 18:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[order_id] [int] NOT NULL,
	[weight] [int] NULL,
	[district] [nvarchar](max) NULL,
	[firstDate] [datetime] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (1, 1, N'Москва', CAST(N'2001-12-12T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (2, 100000, N'Москва', CAST(N'2020-12-10T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (3, 100, N'Омск', CAST(N'2020-06-01T00:50:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (4, 5, N'Омск', CAST(N'2020-12-10T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (5, 5, N'Красногорск', CAST(N'2020-12-10T06:30:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (6, 5, N'Сывтывкар', CAST(N'2020-12-10T10:30:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (7, 20, N'Владивосток', CAST(N'2020-12-10T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (8, 50, N'Московская обл', CAST(N'2020-12-01T10:10:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (9, 50, N'Московская обл', CAST(N'2020-12-10T10:10:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (10, 20, N'Московская обл', CAST(N'2020-12-12T10:10:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (11, 1, N'Московская обл', CAST(N'2020-12-10T10:10:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (12, 1, N'Московская обл', CAST(N'2020-12-10T10:10:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (13, 5, N'Воронеж', CAST(N'2020-12-10T10:10:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (14, 5, N'Воронеж', CAST(N'2020-12-10T10:10:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (15, 10, N'Воронеж', CAST(N'2020-12-03T10:10:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (16, 10, N'Воронеж', CAST(N'2020-12-12T10:10:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (17, 50, N'Омск', CAST(N'2020-12-01T10:10:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (18, 10, N'Омск', CAST(N'2020-12-10T10:10:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (19, 20, N'Омск', CAST(N'2020-09-10T10:10:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (20, 10, N'Москва', CAST(N'2020-11-10T10:10:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (21, 10, N'Москва', CAST(N'2021-01-10T10:10:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (22, 100000, N'Москва', CAST(N'2020-12-10T22:00:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [weight], [district], [firstDate]) VALUES (23, 33, N'Москва', CAST(N'2020-10-10T22:00:00.000' AS DateTime))
GO
