USE [DBRecruitment]
GO
/****** Object:  Table [dbo].[DataCalonKaryawan]    Script Date: 01/06/2023 16:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataCalonKaryawan](
	[id_calonKaryawan] [int] IDENTITY(1,1) NOT NULL,
	[Nama] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
 CONSTRAINT [PK_DataCalonKaryawan] PRIMARY KEY CLUSTERED 
(
	[id_calonKaryawan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataPelamar]    Script Date: 01/06/2023 16:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataPelamar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nama] [varchar](255) NULL,
	[NIK] [varchar](255) NULL,
	[Gender] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Phone] [varchar](255) NULL,
	[Alamat] [varchar](255) NULL,
	[TempatLahir] [varchar](255) NULL,
	[TanggalLahir] [datetime] NULL,
	[Agama] [varchar](255) NULL,
	[Pendidikan] [varchar](255) NULL,
	[NamaPerguruan] [varchar](255) NULL,
	[Jurusan] [varchar](255) NULL,
	[TahunLulus] [varchar](255) NULL,
	[id_calonKaryawan] [int] NULL,
	[id_pengumuman] [int] NULL,
	[id_user] [int] NULL,
 CONSTRAINT [PK_DataPelamar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pengumuman]    Script Date: 01/06/2023 16:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pengumuman](
	[id_pengumuman] [int] IDENTITY(1,1) NOT NULL,
	[Nama] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Phone] [varchar](255) NULL,
	[Status] [varchar](255) NULL,
 CONSTRAINT [PK_Pengumuman] PRIMARY KEY CLUSTERED 
(
	[id_pengumuman] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 01/06/2023 16:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](255) NULL,
	[Password] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[rolle] [varchar](255) NULL,
	[Nama] [varbinary](50) NULL,
	[NamaUser] [varchar](255) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DataPelamar]  WITH CHECK ADD  CONSTRAINT [FK_DataPelamar_DataCalonKaryawan] FOREIGN KEY([id_calonKaryawan])
REFERENCES [dbo].[DataCalonKaryawan] ([id_calonKaryawan])
GO
ALTER TABLE [dbo].[DataPelamar] CHECK CONSTRAINT [FK_DataPelamar_DataCalonKaryawan]
GO
ALTER TABLE [dbo].[DataPelamar]  WITH CHECK ADD  CONSTRAINT [FK_DataPelamar_Pengumuman] FOREIGN KEY([id_pengumuman])
REFERENCES [dbo].[Pengumuman] ([id_pengumuman])
GO
ALTER TABLE [dbo].[DataPelamar] CHECK CONSTRAINT [FK_DataPelamar_Pengumuman]
GO
ALTER TABLE [dbo].[DataPelamar]  WITH CHECK ADD  CONSTRAINT [FK_DataPelamar_User] FOREIGN KEY([id_user])
REFERENCES [dbo].[User] ([id_user])
GO
ALTER TABLE [dbo].[DataPelamar] CHECK CONSTRAINT [FK_DataPelamar_User]
GO
