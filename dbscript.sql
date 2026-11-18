USE [HotelDB]
GO
/****** Object:  Table [dbo].[Amenities]    Script Date: 11/18/2026 12:25:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amenities](
	[AmenityID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](255) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](100) NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AmenityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 11/18/2026 12:25:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CountryCode] [nvarchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 11/18/2026 12:25:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Position] [nvarchar](200) NULL,
	[Salary] [decimal](18, 0) NULL,
	[GenderId] [int] NULL,
	[DeptId] [int] NULL,
	[DesignationId] [int] NULL,
	[Status_Id] [int] NULL,
	[FirstNameEn] [nvarchar](50) NULL,
	[FirstNameAr] [nvarchar](50) NULL,
	[CivilIDNo] [nvarchar](50) NULL,
	[PhotoPath] [nvarchar](255) NULL,
	[DocumentPaths] [varchar](max) NULL,
	[DateOfBirth] [date] NULL,
	[CountryNameEn] [nvarchar](50) NULL,
	[DeptName] [nvarchar](50) NULL,
	[DesignationName] [nvarchar](50) NULL,
	[GenderName] [nvarchar](50) NULL,
	[NameAr] [nvarchar](50) NULL,
	[NameEn] [nvarchar](50) NULL,
	[SelectedSubjectIds] [nvarchar](50) NULL,
	[StatusId] [int] NULL,
	[Status_Name] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[UniBranchNameEn] [nvarchar](50) NULL,
	[CountryID] [int] NULL,
	[StateID] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAPIKey]    Script Date: 11/18/2026 12:25:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAPIKey](
	[id] [int] NULL,
	[api_userkey] [nvarchar](50) NULL,
	[api_passkey] [nvarchar](50) NULL,
	[flag] [varchar](1) NULL,
	[branch_id] [int] NULL,
	[ipaddress] [nvarchar](500) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Amenities] ON 

INSERT [dbo].[Amenities] ([AmenityID], [Name], [Description], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Wi-Fi', N'High-speed wireless internet access', 1, N'System', CAST(N'2025-02-23T13:38:38.390' AS DateTime), N'System', NULL)
INSERT [dbo].[Amenities] ([AmenityID], [Name], [Description], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'Pool', N'Outdoor swimming pool with lifeguard', 1, N'System', CAST(N'2025-02-23T13:38:38.390' AS DateTime), N'System', NULL)
INSERT [dbo].[Amenities] ([AmenityID], [Name], [Description], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'SPA', N'Full-service spa and wellness center', 1, N'System', CAST(N'2025-02-23T13:38:38.390' AS DateTime), N'System', NULL)
INSERT [dbo].[Amenities] ([AmenityID], [Name], [Description], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Fitness Center', N'Gym with modern equipment', 1, N'System', CAST(N'2025-02-23T13:38:38.390' AS DateTime), N'System', NULL)
SET IDENTITY_INSERT [dbo].[Amenities] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Name], [CountryCode]) VALUES (1, N'India', N'1')
INSERT [dbo].[Countries] ([Id], [Name], [CountryCode]) VALUES (2, N'USA', N'2')
INSERT [dbo].[Countries] ([Id], [Name], [CountryCode]) VALUES (3, N'UK', N'3')
INSERT [dbo].[Countries] ([Id], [Name], [CountryCode]) VALUES (4, N'Oman', N'4')
INSERT [dbo].[Countries] ([Id], [Name], [CountryCode]) VALUES (5, N'Philipines', N'5')
INSERT [dbo].[Countries] ([Id], [Name], [CountryCode]) VALUES (6, N'Argentina', N'6')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [Name], [Position], [Salary], [GenderId], [DeptId], [DesignationId], [Status_Id], [FirstNameEn], [FirstNameAr], [CivilIDNo], [PhotoPath], [DocumentPaths], [DateOfBirth], [CountryNameEn], [DeptName], [DesignationName], [GenderName], [NameAr], [NameEn], [SelectedSubjectIds], [StatusId], [Status_Name], [Title], [UniBranchNameEn], [CountryID], [StateID]) VALUES (1, N'test name 1', N'Software Developer (SD)', CAST(6 AS Decimal(18, 0)), 1, 2, 4, 2, N'test name 1', N'test name 1', N'11122', N'', N'0', CAST(N'2018-02-05' AS Date), N'0', N'0', N'0', N'0', N'0', N'0', N'0', 0, N'0', N'0', N'0', NULL, NULL)
INSERT [dbo].[Employees] ([Id], [Name], [Position], [Salary], [GenderId], [DeptId], [DesignationId], [Status_Id], [FirstNameEn], [FirstNameAr], [CivilIDNo], [PhotoPath], [DocumentPaths], [DateOfBirth], [CountryNameEn], [DeptName], [DesignationName], [GenderName], [NameAr], [NameEn], [SelectedSubjectIds], [StatusId], [Status_Name], [Title], [UniBranchNameEn], [CountryID], [StateID]) VALUES (18, N'test name 2', N'Software Developer (SD)', CAST(1 AS Decimal(18, 0)), 1, 2, 0, 1, N'test name 2', N'test name 2', N'112', N'', N'0', CAST(N'2018-02-05' AS Date), N'0', N'0', N'0', N'0', N'0', N'0', N'0', 0, N'0', N'0', N'0', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
INSERT [dbo].[tblAPIKey] ([id], [api_userkey], [api_passkey], [flag], [branch_id], [ipaddress]) VALUES (1, N'yourusername', N'yourpassword', N'1', 1, NULL)
GO
ALTER TABLE [dbo].[Amenities] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Amenities] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_CountryNameEn]  DEFAULT ((0)) FOR [CountryNameEn]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_DeptName]  DEFAULT ((0)) FOR [DeptName]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_DesignationName]  DEFAULT ((0)) FOR [DesignationName]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_GenderName]  DEFAULT ((0)) FOR [GenderName]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_NameAr]  DEFAULT ((0)) FOR [NameAr]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_NameEn]  DEFAULT ((0)) FOR [NameEn]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_SelectedSubjectIds]  DEFAULT ((0)) FOR [SelectedSubjectIds]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_StatusId]  DEFAULT ((0)) FOR [StatusId]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_Status_Name]  DEFAULT ((0)) FOR [Status_Name]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_Title]  DEFAULT ((0)) FOR [Title]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_UniBranchNameEn]  DEFAULT ((0)) FOR [UniBranchNameEn]
GO
