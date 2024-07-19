USE [sistemaBiblioteca]
GO
/****** Object:  Table [dbo].[ADMINISTRADOR]    Script Date: 15/03/2024 11:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADMINISTRADOR](
	[id_administrador] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NULL,
	[apellido_paterno] [varchar](255) NULL,
	[apellido_materno] [varchar](255) NULL,
	[fecha_acceso] [datetime] NULL,
	[correo] [varchar](255) NULL,
	[contrasena] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_administrador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ESTUDIANTE]    Script Date: 15/03/2024 11:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTUDIANTE](
	[id_estudiante] [int] NOT NULL,
	[nombre] [varchar](255) NULL,
	[apellido_paterno] [varchar](255) NULL,
	[apellido_materno] [varchar](255) NULL,
	[telefono] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_estudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LIBRO]    Script Date: 15/03/2024 11:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LIBRO](
	[id_libro] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](255) NULL,
	[editorial] [varchar](255) NULL,
	[fecha_carga] [datetime] NULL,
	[estado_libro] [varchar](20) NULL,
	[cantidad] [int] NULL,
	[nombre_autor] [varchar](255) NULL,
	[apellido_paterno] [varchar](255) NULL,
	[apellido_materno] [varchar](255) NULL,
	[categoria] [varchar](18) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_libro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRESTAMO]    Script Date: 15/03/2024 11:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRESTAMO](
	[id_prestamo] [int] IDENTITY(1,1) NOT NULL,
	[estado] [varchar](255) NULL,
	[id_estudiante] [int] NULL,
	[id_libro] [int] NULL,
	[fecha_prestamo] [date] NULL,
	[fecha_devolucion] [date] NULL,
	[id_administrador] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_prestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[REGISTRO]    Script Date: 15/03/2024 11:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REGISTRO](
	[id_registro] [int] IDENTITY(1,1) NOT NULL,
	[id_estudiante] [int] NULL,
	[id_administrador] [int] NULL,
	[fecha_ingreso] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_registro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PRESTAMO] ADD  DEFAULT (getdate()) FOR [fecha_prestamo]
GO
ALTER TABLE [dbo].[REGISTRO] ADD  DEFAULT (getdate()) FOR [fecha_ingreso]
GO
ALTER TABLE [dbo].[PRESTAMO]  WITH CHECK ADD FOREIGN KEY([id_administrador])
REFERENCES [dbo].[ADMINISTRADOR] ([id_administrador])
GO
ALTER TABLE [dbo].[PRESTAMO]  WITH CHECK ADD FOREIGN KEY([id_estudiante])
REFERENCES [dbo].[ESTUDIANTE] ([id_estudiante])
GO
ALTER TABLE [dbo].[PRESTAMO]  WITH CHECK ADD FOREIGN KEY([id_libro])
REFERENCES [dbo].[LIBRO] ([id_libro])
GO
ALTER TABLE [dbo].[REGISTRO]  WITH CHECK ADD FOREIGN KEY([id_administrador])
REFERENCES [dbo].[ADMINISTRADOR] ([id_administrador])
GO
ALTER TABLE [dbo].[REGISTRO]  WITH CHECK ADD FOREIGN KEY([id_estudiante])
REFERENCES [dbo].[ESTUDIANTE] ([id_estudiante])
GO
/****** Object:  StoredProcedure [dbo].[sp_ConsultarLibros]    Script Date: 15/03/2024 11:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[sp_ConsultarLibros] 
AS
SELECT 
	id_libro, 
	titulo, 
	editorial, 
	estado_libro, 
	cantidad, 
	categoria, 
	nombre_autor, 
	apellido_paterno, 
	apellido_materno 
FROM 
	LIBRO 
ORDER BY
	id_libro
GO
/****** Object:  StoredProcedure [dbo].[sp_Estudiante_all]    Script Date: 15/03/2024 11:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[sp_Estudiante_all] 
AS
SELECT
	id_estudiante, 
	nombre,
	apellido_materno,
	apellido_paterno,
	telefono
FROM
	ESTUDIANTE
ORDER BY
	nombre
GO
/****** Object:  StoredProcedure [dbo].[sp_Estudiantes_all]    Script Date: 15/03/2024 11:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[sp_Estudiantes_all] 
AS
SELECT
    E.id_estudiante AS CodigoEstu,
    E.nombre AS Nombre,
    CONCAT(E.apellido_paterno, ' ',  E.apellido_materno) AS Apellidos
FROM
    ESTUDIANTE E
WHERE
    NOT EXISTS (
        SELECT 1
        FROM REGISTRO R
        WHERE E.id_estudiante = R.id_estudiante
        AND CAST(R.fecha_ingreso AS DATE) = CAST(GETDATE() AS DATE)
    )
ORDER BY
    nombre;
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarLibros]    Script Date: 15/03/2024 11:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_ListarLibros]
AS
BEGIN
    SELECT
        id_libro AS CodigoLibro,
        titulo,
        editorial,
        fecha_carga,
        estado_libro AS Estado,
        cantidad,
        categoria AS Categoria,
        nombre_autor AS NombreAutor,
        apellido_paterno AS ApellidoPaternoAutor,
        apellido_materno AS ApellidoMaternoAutor
    FROM
        LIBRO;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Prestamos]    Script Date: 15/03/2024 11:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[sp_Prestamos]
@Tipo VARCHAR(11)
AS
BEGIN
    IF @Tipo = 'Devueltos'
    BEGIN
        SELECT
            id_prestamo AS Codigo,
            estado AS Estado,
            id_administrador AS codigoAdmin,
            id_estudiante AS CodigoEstudiante,
            id_libro AS CodigoLibro,
            fecha_prestamo AS F_Prestamo,
            fecha_devolucion AS Fecha_Devolución
        FROM
            PRESTAMO
        WHERE
            fecha_devolucion IS NOT NULL
        ORDER BY
            id_prestamo;
    END
    ELSE IF @Tipo = 'NoDevueltos'
		BEGIN
			SELECT
				id_prestamo AS Codigo,
				estado AS Estado,
				id_administrador AS codigoAdmin,
				id_estudiante AS CodigoEstudiante,
				id_libro AS CodigoLibro,
				fecha_prestamo AS F_Prestamo,
				fecha_devolucion AS Fecha_Devolución
			FROM
				PRESTAMO
			WHERE
				fecha_devolucion IS NULL
			ORDER BY
				id_prestamo;
		END
    ELSE
		BEGIN
			SELECT
				id_prestamo AS Codigo,
				estado AS Estado,
				id_administrador AS codigoAdmin,
				id_estudiante AS CodigoEstudiante,
				id_libro AS CodigoLibro,
				fecha_prestamo AS F_Prestamo,
				fecha_devolucion AS Fecha_Devolución
			FROM
				PRESTAMO
			ORDER BY
				id_prestamo;
		END
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Prestamos_Devueltos]    Script Date: 15/03/2024 11:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[sp_Prestamos_Devueltos]
AS
SELECT
	id_prestamo AS Codigo,
	estado AS Estado,
	id_administrador AS codigoAdmin,
	id_estudiante AS CodigoEstudiante,
	id_libro AS CodigoLibro,
	fecha_prestamo AS F_Prestamo,
	fecha_devolucion AS Fecha_Devolución
FROM
	PRESTAMO
WHERE
	fecha_devolucion IS NOT NULL
ORDER BY
	1
GO
/****** Object:  StoredProcedure [dbo].[sp_Prestamos_NoD]    Script Date: 15/03/2024 11:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[sp_Prestamos_NoD]
AS
SELECT
	id_prestamo AS Codigo,
	estado AS Estado,
	id_administrador AS codigoAdmin,
	id_estudiante AS CodigoEstudiante,
	id_libro AS CodigoLibro,
	fecha_prestamo AS F_Prestamo,
	fecha_devolucion AS Fecha_Devolución
FROM
	PRESTAMO
WHERE
	fecha_devolucion  IS NULL
ORDER BY
	1
GO
