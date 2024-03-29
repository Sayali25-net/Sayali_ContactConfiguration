USE [master]
GO
/****** Object:  Database [ContactConfiguration]    Script Date: 16-08-2019 21:06:05 ******/
CREATE DATABASE [ContactConfiguration] ON  PRIMARY 
( NAME = N'ContactConfiguration', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\ContactConfiguration.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ContactConfiguration_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\ContactConfiguration_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ContactConfiguration] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContactConfiguration].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ContactConfiguration] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ContactConfiguration] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ContactConfiguration] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ContactConfiguration] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ContactConfiguration] SET ARITHABORT OFF 
GO
ALTER DATABASE [ContactConfiguration] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ContactConfiguration] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ContactConfiguration] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ContactConfiguration] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ContactConfiguration] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ContactConfiguration] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ContactConfiguration] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ContactConfiguration] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ContactConfiguration] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ContactConfiguration] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ContactConfiguration] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ContactConfiguration] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ContactConfiguration] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ContactConfiguration] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ContactConfiguration] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ContactConfiguration] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ContactConfiguration] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ContactConfiguration] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ContactConfiguration] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ContactConfiguration] SET  MULTI_USER 
GO
ALTER DATABASE [ContactConfiguration] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ContactConfiguration] SET DB_CHAINING OFF 
GO
USE [ContactConfiguration]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 16-08-2019 21:06:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](10) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_ContactPerson] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [ContactConfiguration] SET  READ_WRITE 
GO
