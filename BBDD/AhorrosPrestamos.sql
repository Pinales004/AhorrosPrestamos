USE [master]
GO
/****** Object:  Database [AhorrosPrestamos]    Script Date: 21/06/2022 17:28:36 ******/
CREATE DATABASE [AhorrosPrestamos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AhorrosPrestamos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AhorrosPrestamos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AhorrosPrestamos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AhorrosPrestamos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AhorrosPrestamos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AhorrosPrestamos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AhorrosPrestamos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET ARITHABORT OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [AhorrosPrestamos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AhorrosPrestamos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AhorrosPrestamos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AhorrosPrestamos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AhorrosPrestamos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AhorrosPrestamos] SET  MULTI_USER 
GO
ALTER DATABASE [AhorrosPrestamos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AhorrosPrestamos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AhorrosPrestamos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AhorrosPrestamos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AhorrosPrestamos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AhorrosPrestamos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AhorrosPrestamos] SET QUERY_STORE = OFF
GO
USE [AhorrosPrestamos]
GO
/****** Object:  Table [dbo].[CLIENTES]    Script Date: 21/06/2022 17:28:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTES](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [varchar](100) NULL,
	[nombre] [varchar](100) NULL,
	[apellido] [varchar](100) NULL,
	[direccion] [varchar](255) NULL,
	[telefono] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUENTA_BANCARIA]    Script Date: 21/06/2022 17:28:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUENTA_BANCARIA](
	[id_cuenta] [int] IDENTITY(1,1) NOT NULL,
	[numero_cuenta] [bigint] NULL,
	[banco] [varchar](255) NULL,
	[tipo_cuenta] [varchar](100) NULL,
	[id_cliente] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUOTAS_PRESTAMO]    Script Date: 21/06/2022 17:28:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUOTAS_PRESTAMO](
	[id_cuota] [int] IDENTITY(1,1) NOT NULL,
	[Cuotas] [int] NULL,
	[fecha_planificada_pago] [date] NULL,
	[Cuota_Mensual] [float] NULL,
	[Intereses] [float] NULL,
	[Monto_Pagado] [float] NULL,
	[Deuda_Capital] [float] NULL,
	[fecha_efectiva_pago] [date] NULL,
	[Abono]  AS ([Monto_Pagado]-[Cuota_Mensual]),
	[modalidad_pago] [varchar](100) NULL,
	[id_prestamo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cuota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GARANTIA]    Script Date: 21/06/2022 17:28:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GARANTIA](
	[id_garantia] [int] IDENTITY(1,1) NOT NULL,
	[codigo_garantia] [int] NULL,
	[tipo_garantia] [varchar](100) NOT NULL,
	[descripcion] [varchar](300) NULL,
	[valor_garantia] [decimal](10, 2) NULL,
	[ubicacion_garantia] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_garantia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INTERMEDIA_CLIENTE_ROL]    Script Date: 21/06/2022 17:28:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INTERMEDIA_CLIENTE_ROL](
	[id_intermedia_cliente_rol] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente_intermedia] [int] NULL,
	[id_rol_cliente_intermedia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_intermedia_cliente_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INVERSIONES]    Script Date: 21/06/2022 17:28:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INVERSIONES](
	[id_inversion] [int] IDENTITY(1,1) NOT NULL,
	[monto_inversion] [float] NULL,
	[tipo_inversion] [varchar](100) NULL,
	[tasa_inversion_interes] [float] NULL,
	[fecha_realizada_inversion] [date] NULL,
	[fecha_termino_inversion] [date] NULL,
	[vigente] [bit] NULL,
	[id_cliente] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_inversion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAGO_INVERSION]    Script Date: 21/06/2022 17:28:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAGO_INVERSION](
	[id_cuota_inversion] [int] IDENTITY(1,1) NOT NULL,
	[fecha_planificada_pago] [date] NULL,
	[fecha_efectiva_pago] [date] NULL,
	[Monto_Pagado] [float] NULL,
	[modalidad_pago] [varchar](100) NULL,
	[comprobante_pago] [int] NULL,
	[id_inversion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cuota_inversion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRESTAMOS]    Script Date: 21/06/2022 17:28:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRESTAMOS](
	[id_prestamo] [int] IDENTITY(1,1) NOT NULL,
	[cliente_prestatario] [int] NULL,
	[cliente_fiador] [int] NULL,
	[fecha_solicitud_prestamo] [date] NULL,
	[fecha_aprobacion] [date] NULL,
	[fecha_inicio] [date] NULL,
	[fecha_termino] [date] NULL,
	[monto_prestamo] [float] NULL,
	[tasa_interes] [float] NULL,
	[Tiempo_Amortizacion_Meses] [int] NULL,
	[Total_Prestamo]  AS (([monto_prestamo]*[tasa_interes])/(100)+[monto_prestamo]),
	[aprovado] [bit] NULL,
	[id_garantia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_prestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReporteAtraso]    Script Date: 21/06/2022 17:28:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReporteAtraso](
	[id_reporte] [int] IDENTITY(1,1) NOT NULL,
	[tasa_interes] [float] NULL,
	[monto_pago] [float] NULL,
	[dias_atraso] [int] NULL,
	[interes_mora]  AS ((([tasa_interes]*[monto_pago])/(360))*[dias_atraso]),
	[id_cuota_prestamo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_reporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROL_CLIENTES]    Script Date: 21/06/2022 17:28:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROL_CLIENTES](
	[id_rol_cliente] [int] IDENTITY(1,1) NOT NULL,
	[tipo_rol] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_rol_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 21/06/2022 17:28:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIOS](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre_usuario] [varchar](100) NULL,
	[apellido_usuario] [varchar](100) NULL,
	[cedula_usuario] [varchar](100) NULL,
	[puesto_usuario] [varchar](100) NULL,
	[usuario] [varchar](100) NULL,
	[clave] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CUOTAS_PRESTAMO] ADD  DEFAULT (getdate()) FOR [fecha_planificada_pago]
GO
ALTER TABLE [dbo].[CUOTAS_PRESTAMO] ADD  DEFAULT (getdate()) FOR [fecha_efectiva_pago]
GO
ALTER TABLE [dbo].[INVERSIONES] ADD  DEFAULT (getdate()) FOR [fecha_realizada_inversion]
GO
ALTER TABLE [dbo].[INVERSIONES] ADD  DEFAULT ((0)) FOR [vigente]
GO
ALTER TABLE [dbo].[PRESTAMOS] ADD  DEFAULT (getdate()) FOR [fecha_solicitud_prestamo]
GO
ALTER TABLE [dbo].[PRESTAMOS] ADD  DEFAULT (getdate()) FOR [fecha_inicio]
GO
ALTER TABLE [dbo].[PRESTAMOS] ADD  DEFAULT (getdate()) FOR [fecha_termino]
GO
ALTER TABLE [dbo].[PRESTAMOS] ADD  DEFAULT ((0)) FOR [aprovado]
GO
ALTER TABLE [dbo].[CUENTA_BANCARIA]  WITH CHECK ADD FOREIGN KEY([id_cliente])
REFERENCES [dbo].[CLIENTES] ([id_cliente])
GO
ALTER TABLE [dbo].[CUOTAS_PRESTAMO]  WITH CHECK ADD FOREIGN KEY([id_prestamo])
REFERENCES [dbo].[PRESTAMOS] ([id_prestamo])
GO
ALTER TABLE [dbo].[INTERMEDIA_CLIENTE_ROL]  WITH CHECK ADD FOREIGN KEY([id_cliente_intermedia])
REFERENCES [dbo].[CLIENTES] ([id_cliente])
GO
ALTER TABLE [dbo].[INTERMEDIA_CLIENTE_ROL]  WITH CHECK ADD FOREIGN KEY([id_rol_cliente_intermedia])
REFERENCES [dbo].[ROL_CLIENTES] ([id_rol_cliente])
GO
ALTER TABLE [dbo].[INVERSIONES]  WITH CHECK ADD FOREIGN KEY([id_cliente])
REFERENCES [dbo].[CLIENTES] ([id_cliente])
GO
ALTER TABLE [dbo].[PAGO_INVERSION]  WITH CHECK ADD FOREIGN KEY([id_inversion])
REFERENCES [dbo].[INVERSIONES] ([id_inversion])
GO
ALTER TABLE [dbo].[PRESTAMOS]  WITH CHECK ADD FOREIGN KEY([cliente_prestatario])
REFERENCES [dbo].[CLIENTES] ([id_cliente])
GO
ALTER TABLE [dbo].[PRESTAMOS]  WITH CHECK ADD FOREIGN KEY([cliente_fiador])
REFERENCES [dbo].[CLIENTES] ([id_cliente])
GO
ALTER TABLE [dbo].[PRESTAMOS]  WITH CHECK ADD FOREIGN KEY([id_garantia])
REFERENCES [dbo].[GARANTIA] ([id_garantia])
GO
ALTER TABLE [dbo].[ReporteAtraso]  WITH CHECK ADD FOREIGN KEY([id_cuota_prestamo])
REFERENCES [dbo].[CUOTAS_PRESTAMO] ([id_cuota])
GO
ALTER TABLE [dbo].[GARANTIA]  WITH CHECK ADD CHECK  (([tipo_garantia]='Vehiculo' OR [tipo_garantia]='Inmueble'))
GO
USE [master]
GO
ALTER DATABASE [AhorrosPrestamos] SET  READ_WRITE 
GO
