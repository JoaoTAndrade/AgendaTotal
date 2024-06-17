USE [master]
GO
/****** Object:  Database [AgendaTotalTeste]    Script Date: 17/06/2024 12:41:19 ******/
CREATE DATABASE [AgendaTotalTeste]
 
USE [AgendaTotalTeste]
GO
/****** Object:  Table [dbo].[tb_usuarios]    Script Date: 17/06/2024 12:41:20 ******/

CREATE TABLE [dbo].[tb_usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[email] [varchar](80) NOT NULL,
	[senha] [varchar](80) NOT NULL,
	[pais] [varchar](30) NOT NULL,
	[status_] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tb_usuarios] ON 
GO
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [email], [senha], [pais], [status_]) VALUES (1, N'Alex ', N'alexfurtoso@gmail.com', N'alex', N'Brasil', 1)
GO
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [email], [senha], [pais], [status_]) VALUES (13, N'Douglas Sao Paulino', N'douglinhasxd@hotmail.com', N'douglas', N'Colombia', 1)
GO
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [email], [senha], [pais], [status_]) VALUES (14, N'Abel Ferreira', N'abelaocheiodepaixao@gmail.com', N'abel', N'Portugal', 0)
GO
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [email], [senha], [pais], [status_]) VALUES (18, N'Edson', N'edsonshow@hotmail.com', N'edson', N'Brasil', 1)
GO
SET IDENTITY_INSERT [dbo].[tb_usuarios] OFF
GO
