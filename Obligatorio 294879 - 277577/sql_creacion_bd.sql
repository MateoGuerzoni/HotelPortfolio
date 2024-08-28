--Creacion BD
CREATE DATABASE HotelObligatorio
GO

USE HotelObligatorio
GO

CREATE TABLE [dbo].[Cabanias](
	[numHabitacion] [int] NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[TieneJacuzzi] [bit] NOT NULL,
	[Estado] [bit] NOT NULL,
	[MaxHuespedes] [int] NOT NULL,
	[Foto] [nvarchar](max) NOT NULL,
	[TipoId] [int] NOT NULL,
 CONSTRAINT [PK_Cabanias] PRIMARY KEY CLUSTERED 
(
	[numHabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cabanias] ADD  DEFAULT ((0)) FOR [TipoId]
GO

ALTER TABLE [dbo].[Cabanias]  WITH CHECK ADD  CONSTRAINT [FK_Cabanias_Tipos_TipoId] FOREIGN KEY([TipoId])
REFERENCES [dbo].[Tipos] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Cabanias] CHECK CONSTRAINT [FK_Cabanias_Tipos_TipoId]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Mantenimientos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Costo] [float] NOT NULL,
	[NombreFuncionario] [nvarchar](max) NOT NULL,
	[CabaniaId] [int] NOT NULL,
 CONSTRAINT [PK_Mantenimientos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Mantenimientos]  WITH CHECK ADD  CONSTRAINT [FK_Mantenimientos_Cabanias_CabaniaId] FOREIGN KEY([CabaniaId])
REFERENCES [dbo].[Cabanias] ([numHabitacion])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Mantenimientos] CHECK CONSTRAINT [FK_Mantenimientos_Cabanias_CabaniaId]
GO

/****** Object:  Table [dbo].[Tipos]    Script Date: 6/22/2023 6:18:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tipos](
	[Nombre] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[CostoPorHuesped] [float] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Tipos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 6/22/2023 6:19:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
