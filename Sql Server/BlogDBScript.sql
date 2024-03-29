USE [master]
GO
/****** Object:  Database [BlogDB]    Script Date: 18.7.2016 г. 1:09:18 ******/
CREATE DATABASE [BlogDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BlogDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BlogDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BlogDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BlogDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BlogDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlogDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlogDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlogDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlogDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlogDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlogDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlogDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BlogDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlogDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlogDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlogDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlogDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlogDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlogDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlogDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlogDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BlogDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlogDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlogDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlogDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlogDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlogDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BlogDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlogDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BlogDB] SET  MULTI_USER 
GO
ALTER DATABASE [BlogDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlogDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlogDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlogDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BlogDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BlogDB] SET QUERY_STORE = OFF
GO
USE [BlogDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BlogDB]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 18.7.2016 г. 1:09:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[PostID] [int] NOT NULL,
	[AuthorID] [int] NULL,
	[AuthorName] [nvarchar](100) NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Posts]    Script Date: 18.7.2016 г. 1:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Body] [ntext] NOT NULL,
	[Date] [datetime] NOT NULL,
	[AuthorID] [int] NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Posts_Tags]    Script Date: 18.7.2016 г. 1:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts_Tags](
	[PostID] [int] NOT NULL,
	[TagID] [int] NOT NULL,
 CONSTRAINT [PK_Posts_Tags] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC,
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 18.7.2016 г. 1:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 18.7.2016 г. 1:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[PasswordHash] [varbinary](64) NULL,
	[FullName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([ID], [Text], [PostID], [AuthorID], [AuthorName], [Date]) VALUES (2, N'I like Java 8!', 1, NULL, N'Sahil Jai', CAST(N'2016-07-11T12:32:56.000' AS DateTime))
INSERT [dbo].[Comments] ([ID], [Text], [PostID], [AuthorID], [AuthorName], [Date]) VALUES (3, N'Great Java article.', 1, 3, NULL, CAST(N'2016-06-25T07:03:23.000' AS DateTime))
INSERT [dbo].[Comments] ([ID], [Text], [PostID], [AuthorID], [AuthorName], [Date]) VALUES (5, N'Can this run on Linux?', 2, NULL, N'Jahil Diab', CAST(N'2016-07-05T12:51:58.000' AS DateTime))
INSERT [dbo].[Comments] ([ID], [Text], [PostID], [AuthorID], [AuthorName], [Date]) VALUES (6, N'Try also Spring MVC', 7, 2, NULL, CAST(N'2016-07-17T11:53:54.000' AS DateTime))
INSERT [dbo].[Comments] ([ID], [Text], [PostID], [AuthorID], [AuthorName], [Date]) VALUES (8, N'I prefer Spring Framework', 7, NULL, N'Stefa', CAST(N'2016-07-21T14:16:31.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Comments] OFF
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([ID], [Title], [Body], [Date], [AuthorID]) VALUES (1, N'Java 8', N'Java 8 is the latest Java on the market.', CAST(N'2016-07-10T15:56:00.000' AS DateTime), NULL)
INSERT [dbo].[Posts] ([ID], [Title], [Body], [Date], [AuthorID]) VALUES (2, N'C# Course', N'A new C# course starts every month at SoftUni', CAST(N'2016-06-14T12:03:00.000' AS DateTime), 2)
INSERT [dbo].[Posts] ([ID], [Title], [Body], [Date], [AuthorID]) VALUES (4, N'PHP 7', N'Join our PHP 7 webinar to learn about the new features in PHP 7', CAST(N'2016-05-29T23:51:00.000' AS DateTime), 1)
INSERT [dbo].[Posts] ([ID], [Title], [Body], [Date], [AuthorID]) VALUES (5, N'MySQL and MariaDB', N'Do you know the difference between MySQL and MariaDB?', CAST(N'2016-04-02T08:06:00.000' AS DateTime), 1)
INSERT [dbo].[Posts] ([ID], [Title], [Body], [Date], [AuthorID]) VALUES (7, N'Java EE Training', N'Welcome to the Java EE training at SoftUni', CAST(N'2016-05-19T09:55:00.000' AS DateTime), 3)
INSERT [dbo].[Posts] ([ID], [Title], [Body], [Date], [AuthorID]) VALUES (8, N'Java Web', N'Welcome to Java Web development tutorial', CAST(N'2016-06-14T11:33:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Posts] OFF
INSERT [dbo].[Posts_Tags] ([PostID], [TagID]) VALUES (1, 2)
INSERT [dbo].[Posts_Tags] ([PostID], [TagID]) VALUES (1, 6)
INSERT [dbo].[Posts_Tags] ([PostID], [TagID]) VALUES (2, 1)
INSERT [dbo].[Posts_Tags] ([PostID], [TagID]) VALUES (2, 6)
INSERT [dbo].[Posts_Tags] ([PostID], [TagID]) VALUES (4, 3)
INSERT [dbo].[Posts_Tags] ([PostID], [TagID]) VALUES (4, 6)
INSERT [dbo].[Posts_Tags] ([PostID], [TagID]) VALUES (4, 7)
INSERT [dbo].[Posts_Tags] ([PostID], [TagID]) VALUES (5, 4)
INSERT [dbo].[Posts_Tags] ([PostID], [TagID]) VALUES (5, 5)
INSERT [dbo].[Posts_Tags] ([PostID], [TagID]) VALUES (7, 2)
INSERT [dbo].[Posts_Tags] ([PostID], [TagID]) VALUES (7, 6)
INSERT [dbo].[Posts_Tags] ([PostID], [TagID]) VALUES (8, 2)
INSERT [dbo].[Posts_Tags] ([PostID], [TagID]) VALUES (8, 6)
INSERT [dbo].[Posts_Tags] ([PostID], [TagID]) VALUES (8, 7)
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([ID], [Name]) VALUES (1, N'C#')
INSERT [dbo].[Tags] ([ID], [Name]) VALUES (2, N'Java')
INSERT [dbo].[Tags] ([ID], [Name]) VALUES (3, N'PHP')
INSERT [dbo].[Tags] ([ID], [Name]) VALUES (4, N'SQL')
INSERT [dbo].[Tags] ([ID], [Name]) VALUES (5, N'databases')
INSERT [dbo].[Tags] ([ID], [Name]) VALUES (6, N'programming')
INSERT [dbo].[Tags] ([ID], [Name]) VALUES (7, N'Web')
SET IDENTITY_INSERT [dbo].[Tags] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Username], [PasswordHash], [FullName]) VALUES (1, N'admin', 0xE33843DB5524D80A04C3561E2F7D8F21A14197AF715EA5F62CA809443D106A5C, NULL)
INSERT [dbo].[Users] ([ID], [Username], [PasswordHash], [FullName]) VALUES (2, N'maria', 0x8CF109459E148DEB1A6080FE51C5020753585CBC964F65562A4EAE513A943B54, N'Maria Petrova')
INSERT [dbo].[Users] ([ID], [Username], [PasswordHash], [FullName]) VALUES (3, N'peter', NULL, N'Peter Petrov')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UK_Users_Username]    Script Date: 18.7.2016 г. 1:09:20 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UK_Users_Username] ON [dbo].[Users]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[Posts] ADD  CONSTRAINT [DF_Posts_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Posts] FOREIGN KEY([PostID])
REFERENCES [dbo].[Posts] ([ID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Posts]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Users] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Users]
GO
ALTER TABLE [dbo].[Posts_Tags]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Tags_Posts] FOREIGN KEY([PostID])
REFERENCES [dbo].[Posts] ([ID])
GO
ALTER TABLE [dbo].[Posts_Tags] CHECK CONSTRAINT [FK_Posts_Tags_Posts]
GO
ALTER TABLE [dbo].[Posts_Tags]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Tags_Tags] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tags] ([ID])
GO
ALTER TABLE [dbo].[Posts_Tags] CHECK CONSTRAINT [FK_Posts_Tags_Tags]
GO
USE [master]
GO
ALTER DATABASE [BlogDB] SET  READ_WRITE 
GO
