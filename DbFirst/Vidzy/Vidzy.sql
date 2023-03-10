USE [master]
GO
/****** Object:  Database [Vidzy]    Script Date: 12/04/2018 03:39:36 p.m. ******/
CREATE DATABASE [Vidzy] ON  PRIMARY 
( NAME = N'Vidzy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Vidzy.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Vidzy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Vidzy_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Vidzy] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Vidzy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Vidzy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Vidzy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Vidzy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Vidzy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Vidzy] SET ARITHABORT OFF 
GO
ALTER DATABASE [Vidzy] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Vidzy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Vidzy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Vidzy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Vidzy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Vidzy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Vidzy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Vidzy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Vidzy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Vidzy] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Vidzy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Vidzy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Vidzy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Vidzy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Vidzy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Vidzy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Vidzy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Vidzy] SET RECOVERY FULL 
GO
ALTER DATABASE [Vidzy] SET  MULTI_USER 
GO
ALTER DATABASE [Vidzy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Vidzy] SET DB_CHAINING OFF 
GO
USE [Vidzy]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 12/04/2018 03:39:36 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [tinyint] NOT NULL,
	[Name] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Videos]    Script Date: 12/04/2018 03:39:36 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Videos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[ReleaseDate] [datetime] NOT NULL,
	[GenreId] [tinyint] NOT NULL,
	[Classification] [tinyint] NOT NULL,
 CONSTRAINT [PK_Videos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Comedy')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (2, N'Action')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (3, N'Horror')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (4, N'Thriller')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (5, N'Family')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (6, N'Romance')
SET IDENTITY_INSERT [dbo].[Videos] ON 

INSERT [dbo].[Videos] ([Id], [Name], [ReleaseDate], [GenreId], [Classification]) VALUES (1, N'The Dark Knight', CAST(N'2008-07-17T00:00:00.000' AS DateTime), 2, 1)
INSERT [dbo].[Videos] ([Id], [Name], [ReleaseDate], [GenreId], [Classification]) VALUES (2, N'Transformers', CAST(N'2007-07-19T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Videos] ([Id], [Name], [ReleaseDate], [GenreId], [Classification]) VALUES (4, N'Schindler''s List', CAST(N'1994-02-24T00:00:00.000' AS DateTime), 4, 3)
SET IDENTITY_INSERT [dbo].[Videos] OFF
ALTER TABLE [dbo].[Videos] ADD  CONSTRAINT [DF_Videos_Classification]  DEFAULT ((1)) FOR [Classification]
GO
ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_Genres] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_Genres]
GO
/****** Object:  StoredProcedure [dbo].[spAddVideo]    Script Date: 12/04/2018 03:39:36 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAddVideo]
(
	@Name varchar(255),
	@ReleaseDate datetime,
	@Genre varchar(255),
	@Classification tinyint
)
AS

	DECLARE @GenreId tinyint
	SET @GenreId = (SELECT Id FROM Genres WHERE Name = @Genre)

	INSERT INTO Videos (Name, ReleaseDate, GenreId, Classification)
	VALUES (@Name, @ReleaseDate, @GenreId, @Classification)

GO
USE [master]
GO
ALTER DATABASE [Vidzy] SET  READ_WRITE 
GO
