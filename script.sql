USE [EXAMDB]
GO
SET IDENTITY_INSERT [dbo].[Examinations] ON 

INSERT [dbo].[Examinations] ([Id], [name], [examDate]) VALUES (1, N'Khóa thi 12/2021', CAST(N'2021-12-28 07:00:03.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Examinations] OFF
SET IDENTITY_INSERT [dbo].[Levels] ON 

INSERT [dbo].[Levels] ([Id], [name]) VALUES (1, N'A2')
INSERT [dbo].[Levels] ([Id], [name]) VALUES (2, N'B1')
SET IDENTITY_INSERT [dbo].[Levels] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [name], [gender], [bornDate], [citizenCard], [issueDate], [issuePlace], [phone], [email]) VALUES (1, N'Nguyễn Văn A', N'Nam', CAST(N'2000-05-08 00:00:00.0000000' AS DateTime2), N'052200007665', CAST(N'2021-08-26 00:00:00.0000000' AS DateTime2), N'Bình Định', N'0364117408', N'tructruong.070202@gmail.com')
INSERT [dbo].[Students] ([Id], [name], [gender], [bornDate], [citizenCard], [issueDate], [issuePlace], [phone], [email]) VALUES (2, N'Nguyễn Văn B', N'Nam', CAST(N'2000-05-08 00:00:00.0000000' AS DateTime2), N'052458754485', CAST(N'2021-05-08 00:00:00.0000000' AS DateTime2), N'An Lão', N'0325487578', N'thien@gmail.com')
INSERT [dbo].[Students] ([Id], [name], [gender], [bornDate], [citizenCard], [issueDate], [issuePlace], [phone], [email]) VALUES (3, N'Nguyễn Thị C', N'Nữ', CAST(N'2000-07-08 00:00:00.0000000' AS DateTime2), N'052487565412', CAST(N'2021-01-05 00:00:00.0000000' AS DateTime2), N'Bình Phước', N'0358475654', N'thic@gmail.com')
INSERT [dbo].[Students] ([Id], [name], [gender], [bornDate], [citizenCard], [issueDate], [issuePlace], [phone], [email]) VALUES (4, N'Nguyễn Văn D', N'Nam', CAST(N'2000-05-15 00:00:00.0000000' AS DateTime2), N'054874587412', CAST(N'2021-12-27 00:00:00.0000000' AS DateTime2), N'Bình Ðịnh', N'0364117408', N'abc@gmail.com')
INSERT [dbo].[Students] ([Id], [name], [gender], [bornDate], [citizenCard], [issueDate], [issuePlace], [phone], [email]) VALUES (5, N'Nguyễn Thị E', N'Nam', CAST(N'2000-06-13 00:00:00.0000000' AS DateTime2), N'012458745875', CAST(N'2021-11-16 00:00:00.0000000' AS DateTime2), N'Bình Duong', N'0345874585', N'abcd@gmail.com')
SET IDENTITY_INSERT [dbo].[Students] OFF
