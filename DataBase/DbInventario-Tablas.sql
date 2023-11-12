USE [DbInventario]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 12/11/2023 11:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[Cedula] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Fecha_ingreso] [date] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Herramientas]    Script Date: 12/11/2023 11:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Herramientas](
	[Id_herramienta] [varchar](6) NOT NULL,
	[Nombre_herramienta] [varchar](20) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Prestada] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_herramienta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registros]    Script Date: 12/11/2023 11:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registros](
	[Id_movimiento] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [int] NULL,
	[Id_herramienta] [varchar](6) NULL,
	[Devuelta] [bit] NULL,
	[Fecha_prestamo] [date] NOT NULL,
	[Fecha_devuelve] [date] NOT NULL,
	[Fecha_Devolucion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_movimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Empleados] ([Cedula], [Nombre], [Apellido], [Fecha_ingreso], [Activo]) VALUES (111111111, N'FREDDY', N'CAMPOS', CAST(N'2023-05-31' AS Date), 1)
GO
INSERT [dbo].[Empleados] ([Cedula], [Nombre], [Apellido], [Fecha_ingreso], [Activo]) VALUES (222222222, N'FERNANDA', N'Cantillo', CAST(N'2023-03-02' AS Date), 1)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'ALL001', N'LLAVE ALLEN', N'Llave allen #8', 1)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'ALL002', N'LLAVE ALLEN', N'Llave allen #6', 1)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'ALL003', N'LLAVE ALLEN', N'Llave allen #10', 0)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'CRF01', N'COROFIJA', N'COROFIJA 2pulg', 0)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'CRF02', N'COROFIJA', N'COROFIJA 5pulg', 0)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'CRZ001', N'LLAVE CRUZ', N'Llave crus de 3/4', 1)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'CRZ002', N'LLAVE CRUZ', N'Llave crus de 1/2', 1)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'CRZ003', N'LLAVE CRUZ', N'Llave crus de 1/2', 0)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'FRC01', N'FRANCESA', N'FRANCESA GRANDE', 1)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'FRC02', N'FRANCESA', N'FRANCESA PEQUENIA', 1)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'GTA001', N'GATA MEDIANA', N'GATA HIDRAULICA 2 TONS', 1)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'GTA002', N'GATA MEDIANA', N'GATA HIDRAULICA 2 TONS', 1)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'GTA003', N'GATA PEQUEÑA', N'GATA HIDRAULICA 1/2 TONS', 0)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'GTA005', N'GATA HIDRAULICA', N'Gata hidraúlica de 3ton', 0)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'IMP001', N'PISTOLA DE IMPACTO', N'Pistola de impacto mediana', 0)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'IMP002', N'PISTOLA DE IMPACTO', N'Pistola de impacto pequeña', 0)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'MNT001', N'MANÓMETRO', N'manómetro marca hp', 0)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'MNT002', N'MANÓMETRO', N'manómetro marca hp', 0)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'MNT003', N'MANÓMETRO', N'manómetro marca sony', 0)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'MNT004', N'MANÓMETRO', N'manómetro marca Dell', 0)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'TLD001', N'TALADRO MEDIANO', N'Taladro Azul de baterias', 0)
GO
INSERT [dbo].[Herramientas] ([Id_herramienta], [Nombre_herramienta], [Descripcion], [Prestada]) VALUES (N'TLD003', N'TALADRO GRANDE', N'Taladro Hilti Grande', 0)
GO
SET IDENTITY_INSERT [dbo].[Registros] ON 
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (1, 111111111, N'CRF02', 1, CAST(N'2023-10-31' AS Date), CAST(N'2023-11-07' AS Date), CAST(N'2023-12-11' AS Date))
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (2, 111111111, N'FRC02', 1, CAST(N'2023-10-20' AS Date), CAST(N'2023-11-10' AS Date), CAST(N'2023-11-11' AS Date))
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (3, 111111111, N'ALL003', 1, CAST(N'2023-11-01' AS Date), CAST(N'2023-11-06' AS Date), CAST(N'2023-07-11' AS Date))
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (4, 111111111, N'ALL001', 1, CAST(N'2023-11-11' AS Date), CAST(N'2023-11-16' AS Date), CAST(N'2023-11-11' AS Date))
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (5, 111111111, N'CRF01', 1, CAST(N'2023-11-11' AS Date), CAST(N'2023-11-16' AS Date), CAST(N'2023-11-11' AS Date))
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (6, 111111111, N'CRZ001', 1, CAST(N'2023-11-11' AS Date), CAST(N'2023-11-16' AS Date), CAST(N'2023-11-11' AS Date))
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (7, 111111111, N'ALL001', 0, CAST(N'2023-11-11' AS Date), CAST(N'2023-11-16' AS Date), NULL)
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (8, 111111111, N'CRZ001', 0, CAST(N'2023-11-11' AS Date), CAST(N'2023-11-16' AS Date), NULL)
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (9, 222222222, N'ALL002', 0, CAST(N'2023-11-11' AS Date), CAST(N'2023-11-16' AS Date), NULL)
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (14, 222222222, N'CRF01', 1, CAST(N'2023-11-12' AS Date), CAST(N'2023-11-17' AS Date), CAST(N'2023-12-11' AS Date))
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (15, 222222222, N'CRF01', 1, CAST(N'2023-11-12' AS Date), CAST(N'2023-11-17' AS Date), CAST(N'2023-12-11' AS Date))
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (16, 222222222, N'ALL003', 1, CAST(N'2023-11-12' AS Date), CAST(N'2023-11-17' AS Date), CAST(N'2023-12-11' AS Date))
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (17, 111111111, N'CRF01', 1, CAST(N'2023-11-12' AS Date), CAST(N'2023-11-17' AS Date), CAST(N'2023-12-11' AS Date))
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (18, 111111111, N'ALL003', 1, CAST(N'2023-11-12' AS Date), CAST(N'2023-11-17' AS Date), CAST(N'2023-12-11' AS Date))
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (19, 111111111, N'FRC02', 1, CAST(N'2023-11-12' AS Date), CAST(N'2023-11-17' AS Date), CAST(N'2023-12-11' AS Date))
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (20, 111111111, N'GTA002', 0, CAST(N'2023-11-12' AS Date), CAST(N'2023-11-17' AS Date), NULL)
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (21, 111111111, N'GTA003', 1, CAST(N'2023-11-12' AS Date), CAST(N'2023-11-17' AS Date), CAST(N'2023-12-11' AS Date))
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (22, 111111111, N'FRC02', 0, CAST(N'2023-11-12' AS Date), CAST(N'2023-11-17' AS Date), NULL)
GO
INSERT [dbo].[Registros] ([Id_movimiento], [Cedula], [Id_herramienta], [Devuelta], [Fecha_prestamo], [Fecha_devuelve], [Fecha_Devolucion]) VALUES (23, 111111111, N'MNT002', 1, CAST(N'2023-11-12' AS Date), CAST(N'2023-11-17' AS Date), CAST(N'2023-12-11' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Registros] OFF
GO
ALTER TABLE [dbo].[Registros] ADD  DEFAULT ((0)) FOR [Devuelta]
GO
ALTER TABLE [dbo].[Registros]  WITH CHECK ADD FOREIGN KEY([Cedula])
REFERENCES [dbo].[Empleados] ([Cedula])
GO
ALTER TABLE [dbo].[Registros]  WITH CHECK ADD FOREIGN KEY([Id_herramienta])
REFERENCES [dbo].[Herramientas] ([Id_herramienta])
GO
/****** Object:  StoredProcedure [dbo].[sp_CuentaEmpleadoByCedula]    Script Date: 12/11/2023 11:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CuentaEmpleadoByCedula]	
	@Cedula int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(Cedula)
	FROM Empleados
	WHERE Cedula = @Cedula
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteEmpleado]    Script Date: 12/11/2023 11:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DeleteEmpleado]
	@cedula int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM Empleados
	WHERE Cedula = @cedula

END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarEmpleado]    Script Date: 12/11/2023 11:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertarEmpleado] 
	@cedula int,
	@nombre varchar(50),
	@apellido varchar(50),
	@fecha_ingreso date,
	--@fecha_ingreso varchar(10),
	@activo bit
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT dmy;


    INSERT INTO Empleados(cedula, nombre, apellido, fecha_ingreso, activo) VALUES (@cedula, @nombre, @apellido, convert(varchar(10),@fecha_ingreso,103) , @activo)

END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarHerramienta]    Script Date: 12/11/2023 11:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarHerramienta] 
	@Id_herramienta varchar(6),
	@Nombre_herramienta varchar(20),
	@Descripcion varchar(50),
	@Prestada bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO Herramientas(Id_herramienta, Nombre_herramienta, Descripcion, Prestada) VALUES (@Id_herramienta, @Nombre_herramienta, @Descripcion, @Prestada)

END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarRegistro]    Script Date: 12/11/2023 11:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertarRegistro]
	--@id_movimiento int,
	@cedula int,
	@id_herramienta VARCHAR(6),
	@devuelta bit,
	@fecha_prestamo DATE,
	@fecha_devuelve DATE,
	@fecha_devolucion DATE = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO Registros(cedula, id_herramienta, devuelta, fecha_prestamo, fecha_devuelve, fecha_devolucion) 
	VALUES (@cedula, @id_herramienta, @devuelta, @fecha_prestamo, @fecha_devuelve, @fecha_devolucion)

END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectHerramientaByName]    Script Date: 12/11/2023 11:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DEVUELVE HERRAMIENTAS DEL USUARIO POR CEDULA Y QUE NO HA DEVUELTO
CREATE PROCEDURE [dbo].[sp_SelectHerramientaByName]
	@Nombre_herramienta varchar(20)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET @Nombre_herramienta = '%' + @Nombre_herramienta + '%'
	

    -- Insert statements for procedure here
	SELECT * FROM Herramientas
	WHERE Nombre_herramienta LIKE @Nombre_herramienta AND Prestada = 0
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectRegistroByCedula]    Script Date: 12/11/2023 11:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DEVUELVE HERRAMIENTAS DEL USUARIO POR CEDULA Y QUE NO HA DEVUELTO
CREATE PROCEDURE [dbo].[sp_SelectRegistroByCedula]
	@Cedula int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT re.Id_movimiento,re.Cedula, re.Id_herramienta, he.Nombre_herramienta, re.Devuelta, re.Fecha_prestamo, re.Fecha_devuelve, re.Fecha_Devolucion 
	FROM Herramientas AS he
		INNER JOIN Registros AS re
	ON (he.Id_herramienta = re.Id_herramienta)
	WHERE Cedula = @Cedula AND Devuelta = 0
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateEmpleado]    Script Date: 12/11/2023 11:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateEmpleado]
	@cedula int,
	@nombre varchar(50),
	@apellido varchar(50),
	@fecha_ingreso date,
	@activo bit
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE Empleados SET nombre = @nombre, apellido = @apellido, fecha_ingreso = @fecha_ingreso, activo = @activo
	WHERE cedula = @cedula

END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateHerramienta]    Script Date: 12/11/2023 11:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateHerramienta]
	--@id_movimiento int,
	@id_herramienta VARCHAR(6)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE Herramientas SET Prestada = 1
	WHERE Id_herramienta = @id_herramienta

END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateRegistro]    Script Date: 12/11/2023 11:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateRegistro]
	@id_movimiento int,
	@fecha_devolucion DATE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result
	SET NOCOUNT ON;

    UPDATE Registros SET devuelta = 1, fecha_devolucion = CONVERT(varchar,@fecha_devolucion,103)
	WHERE Id_movimiento = @id_movimiento

END
GO
