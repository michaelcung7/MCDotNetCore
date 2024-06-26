USE [master]
GO
/****** Object:  Database [DotnetTrainingBatch4]    Script Date: 4/29/2024 7:39:46 PM ******/
CREATE DATABASE [DotnetTrainingBatch4] ON  PRIMARY 
( NAME = N'DotnetTrainingBatch4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DotnetTrainingBatch4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DotnetTrainingBatch4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DotnetTrainingBatch4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DotnetTrainingBatch4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DotnetTrainingBatch4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET ARITHABORT OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET  MULTI_USER 
GO
ALTER DATABASE [DotnetTrainingBatch4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DotnetTrainingBatch4] SET DB_CHAINING OFF 
GO
USE [DotnetTrainingBatch4]
GO
/****** Object:  Table [dbo].[tbl_blog]    Script Date: 4/29/2024 7:39:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [varchar](50) NOT NULL,
	[BlogAuthor] [varchar](50) NOT NULL,
	[BlogContent] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_blog] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_blog] ON 

INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (1, N'title', N'author', N'content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (2, N'Blog Title', N'Blog Author', N'Blog Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (3, N'Blog Title', N'Blog Author', N'Blog Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (4, N'Blog Title', N'Blog Author', N'Blog Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (6, N'title', N'author', N'content')
SET IDENTITY_INSERT [dbo].[tbl_blog] OFF
GO
USE [master]
GO
ALTER DATABASE [DotnetTrainingBatch4] SET  READ_WRITE 
GO
