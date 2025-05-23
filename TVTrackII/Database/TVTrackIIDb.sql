USE [master]
GO
/****** Object:  Database [TVTrackIIDb]    Script Date: 4/17/2025 12:11:59 PM ******/
CREATE DATABASE [TVTrackIIDb];

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TVTrackIIDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TVTrackIIDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TVTrackIIDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TVTrackIIDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TVTrackIIDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TVTrackIIDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TVTrackIIDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TVTrackIIDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TVTrackIIDb] SET  MULTI_USER 
GO
ALTER DATABASE [TVTrackIIDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TVTrackIIDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TVTrackIIDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TVTrackIIDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TVTrackIIDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TVTrackIIDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TVTrackIIDb] SET QUERY_STORE = OFF
GO
USE [TVTrackIIDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/17/2025 12:11:59 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calificaciones]    Script Date: 4/17/2025 12:11:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContenidoId] [int] NOT NULL,
	[Puntuacion] [int] NOT NULL,
 CONSTRAINT [PK_Calificaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comentarios]    Script Date: 4/17/2025 12:11:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[ContenidoId] [int] NOT NULL,
	[Texto] [nvarchar](300) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Comentarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contenidos]    Script Date: 4/17/2025 12:11:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contenidos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NULL,
	[Genero] [nvarchar](max) NULL,
	[VecesVisto] [int] NOT NULL,
 CONSTRAINT [PK_Contenidos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialVisualizacion]    Script Date: 4/17/2025 12:11:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialVisualizacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[ContenidoId] [int] NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_HistorialVisualizacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 4/17/2025 12:11:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Correo] [nvarchar](max) NULL,
	[Contrasena] [nvarchar](max) NULL,
	[Rol] [nvarchar](max) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250417005024_Init', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250417034831_AddComentarios', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250417145333_AgregarFechaHistorial', N'8.0.0')
GO
SET IDENTITY_INSERT [dbo].[Contenidos] ON 

INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (1, N'Contenido 1', N'Aventura', 500)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (2, N'Contenido 2', N'Drama', 39)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (3, N'Contenido 3', N'Terror', 433)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (4, N'Contenido 4', N'Ciencia Ficción', 849)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (5, N'Contenido 5', N'Acción', 735)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (6, N'Contenido 6', N'Aventura', 722)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (7, N'Contenido 7', N'Drama', 167)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (8, N'Contenido 8', N'Romance', 593)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (9, N'Contenido 9', N'Comedia', 263)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (10, N'Contenido 10', N'Acción', 953)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (11, N'Contenido 11', N'Comedia', 294)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (12, N'Contenido 12', N'Romance', 98)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (13, N'Contenido 13', N'Drama', 258)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (14, N'Contenido 14', N'Aventura', 186)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (15, N'Contenido 15', N'Ciencia Ficción', 107)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (16, N'Contenido 16', N'Drama', 951)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (17, N'Contenido 17', N'Acción', 531)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (18, N'Contenido 18', N'Romance', 970)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (19, N'Contenido 19', N'Ciencia Ficción', 43)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (20, N'Contenido 20', N'Drama', 386)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (21, N'Contenido 21', N'Acción', 215)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (22, N'Contenido 22', N'Drama', 83)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (23, N'Contenido 23', N'Terror', 274)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (24, N'Contenido 24', N'Documental', 634)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (25, N'Contenido 25', N'Documental', 36)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (26, N'Contenido 26', N'Ciencia Ficción', 587)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (27, N'Contenido 27', N'Comedia', 209)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (28, N'Contenido 28', N'Aventura', 502)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (29, N'Contenido 29', N'Aventura', 772)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (30, N'Contenido 30', N'Terror', 704)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (31, N'Contenido 31', N'Acción', 807)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (32, N'Contenido 32', N'Aventura', 139)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (33, N'Contenido 33', N'Acción', 215)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (34, N'Contenido 34', N'Drama', 964)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (35, N'Contenido 35', N'Terror', 149)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (36, N'Contenido 36', N'Terror', 24)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (37, N'Contenido 37', N'Romance', 765)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (38, N'Contenido 38', N'Romance', 165)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (39, N'Contenido 39', N'Terror', 860)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (40, N'Contenido 40', N'Documental', 245)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (41, N'Contenido 41', N'Documental', 839)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (42, N'Contenido 42', N'Ciencia Ficción', 938)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (43, N'Contenido 43', N'Documental', 939)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (44, N'Contenido 44', N'Terror', 382)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (45, N'Contenido 45', N'Acción', 98)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (46, N'Contenido 46', N'Acción', 941)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (47, N'Contenido 47', N'Comedia', 695)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (48, N'Contenido 48', N'Aventura', 976)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (49, N'Contenido 49', N'Romance', 780)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (50, N'Contenido 50', N'Comedia', 12)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (51, N'Contenido 51', N'Aventura', 626)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (52, N'Contenido 52', N'Documental', 183)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (53, N'Contenido 53', N'Comedia', 835)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (54, N'Contenido 54', N'Romance', 294)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (55, N'Contenido 55', N'Terror', 533)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (56, N'Contenido 56', N'Romance', 522)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (57, N'Contenido 57', N'Drama', 861)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (58, N'Contenido 58', N'Terror', 273)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (59, N'Contenido 59', N'Documental', 114)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (60, N'Contenido 60', N'Documental', 183)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (61, N'Contenido 61', N'Aventura', 959)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (62, N'Contenido 62', N'Drama', 948)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (63, N'Contenido 63', N'Terror', 85)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (64, N'Contenido 64', N'Comedia', 849)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (65, N'Contenido 65', N'Ciencia Ficción', 673)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (66, N'Contenido 66', N'Terror', 419)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (67, N'Contenido 67', N'Aventura', 704)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (68, N'Contenido 68', N'Drama', 391)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (69, N'Contenido 69', N'Romance', 825)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (70, N'Contenido 70', N'Ciencia Ficción', 955)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (71, N'Contenido 71', N'Ciencia Ficción', 489)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (72, N'Contenido 72', N'Terror', 744)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (73, N'Contenido 73', N'Drama', 749)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (74, N'Contenido 74', N'Drama', 292)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (75, N'Contenido 75', N'Ciencia Ficción', 270)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (76, N'Contenido 76', N'Drama', 222)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (77, N'Contenido 77', N'Ciencia Ficción', 561)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (78, N'Contenido 78', N'Aventura', 208)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (79, N'Contenido 79', N'Acción', 631)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (80, N'Contenido 80', N'Acción', 522)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (81, N'Contenido 81', N'Romance', 708)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (82, N'Contenido 82', N'Drama', 773)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (83, N'Contenido 83', N'Terror', 730)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (84, N'Contenido 84', N'Documental', 92)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (85, N'Contenido 85', N'Acción', 651)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (86, N'Contenido 86', N'Documental', 168)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (87, N'Contenido 87', N'Romance', 4)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (88, N'Contenido 88', N'Ciencia Ficción', 650)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (89, N'Contenido 89', N'Ciencia Ficción', 650)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (90, N'Contenido 90', N'Ciencia Ficción', 423)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (91, N'Contenido 91', N'Documental', 540)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (92, N'Contenido 92', N'Ciencia Ficción', 571)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (93, N'Contenido 93', N'Terror', 689)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (94, N'Contenido 94', N'Documental', 357)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (95, N'Contenido 95', N'Acción', 763)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (96, N'Contenido 96', N'Romance', 146)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (97, N'Contenido 97', N'Terror', 638)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (98, N'Contenido 98', N'Acción', 486)
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (99, N'Contenido 99', N'Ciencia Ficción', 366)
GO
INSERT [dbo].[Contenidos] ([Id], [Titulo], [Genero], [VecesVisto]) VALUES (100, N'Contenido 100', N'Comedia', 709)
SET IDENTITY_INSERT [dbo].[Contenidos] OFF
GO
SET IDENTITY_INSERT [dbo].[HistorialVisualizacion] ON 

INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (1, 10, 2, CAST(N'2025-04-17T08:55:21.4302960' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (2, 10, 3, CAST(N'2025-04-17T08:55:23.4511546' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (3, 10, 1, CAST(N'2025-04-17T08:55:24.4579288' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (4, 9, 5, CAST(N'2025-04-17T08:56:56.9835189' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (5, 9, 4, CAST(N'2025-04-17T09:02:00.0344277' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (6, 9, 3, CAST(N'2025-04-17T09:02:01.1279811' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (7, 9, 12, CAST(N'2025-04-17T09:02:11.5414748' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (8, 9, 14, CAST(N'2025-04-17T09:02:12.8144630' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (9, 9, 22, CAST(N'2025-04-17T09:02:25.8186994' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (10, 6, 1, CAST(N'2025-04-17T09:12:37.2390790' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (11, 6, 8, CAST(N'2025-04-17T09:12:41.7431224' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (12, 3, 3, CAST(N'2025-04-17T09:25:48.4217049' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (13, 3, 4, CAST(N'2025-04-17T09:25:49.4578864' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (14, 9, 10, CAST(N'2025-04-17T09:57:49.7337719' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (15, 9, 16, CAST(N'2025-04-17T09:59:34.8006042' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (16, 9, 20, CAST(N'2025-04-17T10:01:05.9603809' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (17, 8, 20, CAST(N'2025-04-17T10:15:05.4190558' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (18, 8, 13, CAST(N'2025-04-17T10:15:49.8387948' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (19, 7, 1, CAST(N'2025-04-17T10:19:16.8390960' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (20, 5, 2, CAST(N'2025-04-17T10:24:27.8142635' AS DateTime2))
INSERT [dbo].[HistorialVisualizacion] ([Id], [UsuarioId], [ContenidoId], [Fecha]) VALUES (21, 12, 2, CAST(N'2025-04-17T11:20:04.3433839' AS DateTime2))
SET IDENTITY_INSERT [dbo].[HistorialVisualizacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (1, N'Admin', N'admin@admin.com', N'admin', N'Administrador')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (2, N'Usuario1', N'usuario1@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (3, N'Usuario2', N'usuario2@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (4, N'Usuario3', N'usuario3@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (5, N'Usuario4', N'usuario4@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (6, N'Usuario5', N'usuario5@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (7, N'Usuario6', N'usuario6@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (8, N'Usuario7', N'usuario7@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (9, N'Usuario8', N'usuario8@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (10, N'Usuario9', N'usuario9@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (11, N'Usuario10', N'usuario10@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (12, N'Usuario11', N'usuario11@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (13, N'Usuario12', N'usuario12@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (14, N'Usuario13', N'usuario13@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (15, N'Usuario14', N'usuario14@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (16, N'Usuario15', N'usuario15@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (17, N'Usuario16', N'usuario16@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (18, N'Usuario17', N'usuario17@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (19, N'Usuario18', N'usuario18@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (20, N'Usuario19', N'usuario19@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (21, N'Usuario20', N'usuario20@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (22, N'Usuario21', N'usuario21@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (23, N'Usuario22', N'usuario22@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (24, N'Usuario23', N'usuario23@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (25, N'Usuario24', N'usuario24@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (26, N'Usuario25', N'usuario25@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (27, N'Usuario26', N'usuario26@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (28, N'Usuario27', N'usuario27@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (29, N'Usuario28', N'usuario28@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (30, N'Usuario29', N'usuario29@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (31, N'Usuario30', N'usuario30@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (32, N'Usuario31', N'usuario31@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (33, N'Usuario32', N'usuario32@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (34, N'Usuario33', N'usuario33@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (35, N'Usuario34', N'usuario34@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (36, N'Usuario35', N'usuario35@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (37, N'Usuario36', N'usuario36@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (38, N'Usuario37', N'usuario37@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (39, N'Usuario38', N'usuario38@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (40, N'Usuario39', N'usuario39@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (41, N'Usuario40', N'usuario40@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (42, N'Usuario41', N'usuario41@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (43, N'Usuario42', N'usuario42@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (44, N'Usuario43', N'usuario43@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (45, N'Usuario44', N'usuario44@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (46, N'Usuario45', N'usuario45@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (47, N'Usuario46', N'usuario46@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (48, N'Usuario47', N'usuario47@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (49, N'Usuario48', N'usuario48@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (50, N'Usuario49', N'usuario49@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (51, N'Usuario50', N'usuario50@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (52, N'Usuario51', N'usuario51@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (53, N'Usuario52', N'usuario52@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (54, N'Usuario53', N'usuario53@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (55, N'Usuario54', N'usuario54@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (56, N'Usuario55', N'usuario55@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (57, N'Usuario56', N'usuario56@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (58, N'Usuario57', N'usuario57@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (59, N'Usuario58', N'usuario58@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (60, N'Usuario59', N'usuario59@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (61, N'Usuario60', N'usuario60@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (62, N'Usuario61', N'usuario61@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (63, N'Usuario62', N'usuario62@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (64, N'Usuario63', N'usuario63@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (65, N'Usuario64', N'usuario64@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (66, N'Usuario65', N'usuario65@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (67, N'Usuario66', N'usuario66@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (68, N'Usuario67', N'usuario67@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (69, N'Usuario68', N'usuario68@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (70, N'Usuario69', N'usuario69@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (71, N'Usuario70', N'usuario70@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (72, N'Usuario71', N'usuario71@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (73, N'Usuario72', N'usuario72@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (74, N'Usuario73', N'usuario73@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (75, N'Usuario74', N'usuario74@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (76, N'Usuario75', N'usuario75@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (77, N'Usuario76', N'usuario76@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (78, N'Usuario77', N'usuario77@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (79, N'Usuario78', N'usuario78@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (80, N'Usuario79', N'usuario79@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (81, N'Usuario80', N'usuario80@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (82, N'Usuario81', N'usuario81@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (83, N'Usuario82', N'usuario82@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (84, N'Usuario83', N'usuario83@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (85, N'Usuario84', N'usuario84@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (86, N'Usuario85', N'usuario85@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (87, N'Usuario86', N'usuario86@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (88, N'Usuario87', N'usuario87@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (89, N'Usuario88', N'usuario88@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (90, N'Usuario89', N'usuario89@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (91, N'Usuario90', N'usuario90@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (92, N'Usuario91', N'usuario91@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (93, N'Usuario92', N'usuario92@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (94, N'Usuario93', N'usuario93@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (95, N'Usuario94', N'usuario94@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (96, N'Usuario95', N'usuario95@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (97, N'Usuario96', N'usuario96@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (98, N'Usuario97', N'usuario97@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (99, N'Usuario98', N'usuario98@hotmail.com', N'1234', N'Usuario')
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (100, N'Usuario99', N'usuario99@hotmail.com', N'1234', N'Usuario')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Contrasena], [Rol]) VALUES (101, N'Usuario100', N'usuario100@hotmail.com', N'1234', N'Usuario')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
/****** Object:  Index [IX_Calificaciones_ContenidoId]    Script Date: 4/17/2025 12:11:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_Calificaciones_ContenidoId] ON [dbo].[Calificaciones]
(
	[ContenidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comentarios_ContenidoId]    Script Date: 4/17/2025 12:11:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_Comentarios_ContenidoId] ON [dbo].[Comentarios]
(
	[ContenidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comentarios_UsuarioId]    Script Date: 4/17/2025 12:11:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_Comentarios_UsuarioId] ON [dbo].[Comentarios]
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HistorialVisualizacion_ContenidoId]    Script Date: 4/17/2025 12:11:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_HistorialVisualizacion_ContenidoId] ON [dbo].[HistorialVisualizacion]
(
	[ContenidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HistorialVisualizacion_UsuarioId]    Script Date: 4/17/2025 12:11:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_HistorialVisualizacion_UsuarioId] ON [dbo].[HistorialVisualizacion]
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comentarios] ADD  DEFAULT (N'') FOR [Texto]
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Calificaciones_Contenidos_ContenidoId] FOREIGN KEY([ContenidoId])
REFERENCES [dbo].[Contenidos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Calificaciones] CHECK CONSTRAINT [FK_Calificaciones_Contenidos_ContenidoId]
GO
ALTER TABLE [dbo].[Comentarios]  WITH CHECK ADD  CONSTRAINT [FK_Comentarios_Contenidos_ContenidoId] FOREIGN KEY([ContenidoId])
REFERENCES [dbo].[Contenidos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comentarios] CHECK CONSTRAINT [FK_Comentarios_Contenidos_ContenidoId]
GO
ALTER TABLE [dbo].[Comentarios]  WITH CHECK ADD  CONSTRAINT [FK_Comentarios_Usuarios_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comentarios] CHECK CONSTRAINT [FK_Comentarios_Usuarios_UsuarioId]
GO
ALTER TABLE [dbo].[HistorialVisualizacion]  WITH CHECK ADD  CONSTRAINT [FK_HistorialVisualizacion_Contenidos_ContenidoId] FOREIGN KEY([ContenidoId])
REFERENCES [dbo].[Contenidos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HistorialVisualizacion] CHECK CONSTRAINT [FK_HistorialVisualizacion_Contenidos_ContenidoId]
GO
ALTER TABLE [dbo].[HistorialVisualizacion]  WITH CHECK ADD  CONSTRAINT [FK_HistorialVisualizacion_Usuarios_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HistorialVisualizacion] CHECK CONSTRAINT [FK_HistorialVisualizacion_Usuarios_UsuarioId]
GO
USE [master]
GO
ALTER DATABASE [TVTrackIIDb] SET  READ_WRITE 
GO
