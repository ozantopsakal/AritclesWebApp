/****** Object:  Database [ArticlesWebApp]    Script Date: 25.9.2019 01:48:50 ******/
CREATE DATABASE [ArticlesWebApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ArticlesWebApp', FILENAME = N'C:\Users\Dalkhy\ArticlesWebApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ArticlesWebApp_log', FILENAME = N'C:\Users\Dalkhy\ArticlesWebApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ArticlesWebApp] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ArticlesWebApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ArticlesWebApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ArticlesWebApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ArticlesWebApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ArticlesWebApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ArticlesWebApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ArticlesWebApp] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ArticlesWebApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ArticlesWebApp] SET  MULTI_USER 
GO
ALTER DATABASE [ArticlesWebApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ArticlesWebApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ArticlesWebApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ArticlesWebApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ArticlesWebApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ArticlesWebApp] SET QUERY_STORE = OFF
GO
USE [ArticlesWebApp]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [ArticlesWebApp]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25.9.2019 01:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 25.9.2019 01:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 25.9.2019 01:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[PostedAt] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[SubTitle] [nvarchar](max) NULL,
	[AllowsComments] [bit] NULL,
	[ThumbnailPhoto] [nvarchar](350) NULL,
	[Photo] [nvarchar](350) NULL,
	[Language] [nvarchar](2) NULL,
	[UserId] [int] NULL,
	[Active] [bit] NULL,
	[CategoryId] [int] NULL,
	[Name] [nvarchar](150) NULL,
	[Email] [nvarchar](50) NULL,
	[Ip] [nvarchar](max) NULL,
	[ArticleId] [int] NULL,
	[ParentId] [int] NULL,
	[Comments_Active] [bit] NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 25.9.2019 01:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Language] [nvarchar](2) NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TagsArticles]    Script Date: 25.9.2019 01:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagsArticles](
	[TagsId] [int] NOT NULL,
	[ArticlesId] [int] NOT NULL,
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_TagsArticles] PRIMARY KEY CLUSTERED 
(
	[TagsId] ASC,
	[ArticlesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25.9.2019 01:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[CreatedAt] [nvarchar](max) NULL,
	[Photo] [nvarchar](350) NULL,
	[Bio] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Token] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190923220600_InitialMigration', N'2.2.6-servicing-10079')
GO
SET IDENTITY_INSERT [dbo].[Posts] ON 
GO
INSERT [dbo].[Posts] ([Id], [Title], [Text], [PostedAt], [Discriminator], [SubTitle], [AllowsComments], [ThumbnailPhoto], [Photo], [Language], [UserId], [Active], [CategoryId], [Name], [Email], [Ip], [ArticleId], [ParentId], [Comments_Active]) VALUES (1, N'Article 1', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', N'22.09.2019', N'Articles', N'Lorem ipsum dolor sit amet', 1, N'', N'', N'tr', 1, 1, 1, N'Anonymous 1', N'anonym@test.com', N'::1', 1, 0, 1)
GO
INSERT [dbo].[Posts] ([Id], [Title], [Text], [PostedAt], [Discriminator], [SubTitle], [AllowsComments], [ThumbnailPhoto], [Photo], [Language], [UserId], [Active], [CategoryId], [Name], [Email], [Ip], [ArticleId], [ParentId], [Comments_Active]) VALUES (3, N'Comment2', N'This is a comment for Article 1', N'', N'Comments', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Anonymous 1', N'anonym@test.com', N'::1', 1, 0, 1)
GO
INSERT [dbo].[Posts] ([Id], [Title], [Text], [PostedAt], [Discriminator], [SubTitle], [AllowsComments], [ThumbnailPhoto], [Photo], [Language], [UserId], [Active], [CategoryId], [Name], [Email], [Ip], [ArticleId], [ParentId], [Comments_Active]) VALUES (4, N'Comment2', N'This is a comment for Article 1', N'', N'Comments', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Anonymous 1', N'anonym@test.com	', N'::1', 1, 0, 1)
GO
INSERT [dbo].[Posts] ([Id], [Title], [Text], [PostedAt], [Discriminator], [SubTitle], [AllowsComments], [ThumbnailPhoto], [Photo], [Language], [UserId], [Active], [CategoryId], [Name], [Email], [Ip], [ArticleId], [ParentId], [Comments_Active]) VALUES (5, N'Comment3', N'This is a comment for Article 1', N'', N'Comments', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Anonymous 1', N'anonym@test.com	', N'::1', 1, 0, 1)
GO
INSERT [dbo].[Posts] ([Id], [Title], [Text], [PostedAt], [Discriminator], [SubTitle], [AllowsComments], [ThumbnailPhoto], [Photo], [Language], [UserId], [Active], [CategoryId], [Name], [Email], [Ip], [ArticleId], [ParentId], [Comments_Active]) VALUES (7, N'Comment4', N'This is a comment for Article 1', N'', N'Comments', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Anonymous 1', N'anonym@test.com	', N'::1', 1, 4, 1)
GO
INSERT [dbo].[Posts] ([Id], [Title], [Text], [PostedAt], [Discriminator], [SubTitle], [AllowsComments], [ThumbnailPhoto], [Photo], [Language], [UserId], [Active], [CategoryId], [Name], [Email], [Ip], [ArticleId], [ParentId], [Comments_Active]) VALUES (8, N'Comment7', N'This is a comment for Article 1', N'', N'Comments', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Anonymous 1', N'anonym@test.com	', N'::1', 1, 4, 0)
GO
INSERT [dbo].[Posts] ([Id], [Title], [Text], [PostedAt], [Discriminator], [SubTitle], [AllowsComments], [ThumbnailPhoto], [Photo], [Language], [UserId], [Active], [CategoryId], [Name], [Email], [Ip], [ArticleId], [ParentId], [Comments_Active]) VALUES (9, N'Comment7', N'This is a comment for Article 1', N'', N'Comments', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Anonymous 1', N'anonym@test.com	', N'::1', 1, 4, 1)
GO
SET IDENTITY_INSERT [dbo].[Posts] OFF
GO
SET IDENTITY_INSERT [dbo].[Tags] ON 
GO
INSERT [dbo].[Tags] ([Id], [Title], [Language]) VALUES (1, N'Tag1', N'tr')
GO
INSERT [dbo].[Tags] ([Id], [Title], [Language]) VALUES (2, N'Tag2', N'tr')
GO
SET IDENTITY_INSERT [dbo].[Tags] OFF
GO
INSERT [dbo].[TagsArticles] ([TagsId], [ArticlesId], [Id]) VALUES (1, 1, 0)
GO
INSERT [dbo].[TagsArticles] ([TagsId], [ArticlesId], [Id]) VALUES (2, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [UserName], [Password], [Name], [CreatedAt], [Photo], [Bio], [Active], [Email], [Token]) VALUES (2, N'admin', N'@dM!n123', N'Administrator', N'', N'', N'', 1, N'admin@articleswebapp.com', N'')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_TagsArticles_ArticlesId]    Script Date: 25.9.2019 01:48:50 ******/
CREATE NONCLUSTERED INDEX [IX_TagsArticles_ArticlesId] ON [dbo].[TagsArticles]
(
	[ArticlesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TagsArticles]  WITH CHECK ADD  CONSTRAINT [FK_TagsArticles_Posts_ArticlesId] FOREIGN KEY([ArticlesId])
REFERENCES [dbo].[Posts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TagsArticles] CHECK CONSTRAINT [FK_TagsArticles_Posts_ArticlesId]
GO
ALTER TABLE [dbo].[TagsArticles]  WITH CHECK ADD  CONSTRAINT [FK_TagsArticles_Tags_TagsId] FOREIGN KEY([TagsId])
REFERENCES [dbo].[Tags] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TagsArticles] CHECK CONSTRAINT [FK_TagsArticles_Tags_TagsId]
GO
USE [master]
GO
ALTER DATABASE [ArticlesWebApp] SET  READ_WRITE 
GO
