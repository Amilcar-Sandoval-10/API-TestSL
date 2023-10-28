use master
go
IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE NAME = 'API')
CREATE DATABASE API

GO 

USE API

GO
--************************  TABLAS ************************--


---------Cliente

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Cliente')
create table Cliente(
IdCliente int primary key identity(1,1),
Cedula varchar(60),
Nombres varchar(60),
Telefono int,
Correo varchar(60),
Ciudad varchar(60),
)

go

---------Proveedor


if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Proveedor')
create table Proveedor(
IdProveedor int primary key identity(1,1),
Cedula varchar(60),
Nombres varchar(60),
Telefono int,
Correo varchar(60),
Ciudad varchar(60),
)

go



---------Inventario


if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Inventario')
create table Inventario(
IdInventario int primary key identity(1,1),
Nombre varchar(60),
Precio varchar(60),
Stock int,
Proveedor int foreign key references Proveedor (IdProveedor) 
)

go



---------ventas 
create table Venta
(
Id_venta int primary key identity (1,1) not null,
Rut_Cliente int foreign key references Cliente (IdCliente) not null,
Id_producto int foreign key references Inventario (IdInventario) not null,
Cantidad int ,
Fecha nvarchar (20) not null,
Descuento float not null,
total float not null
)
go




--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--

---------Cliente

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_registrarCliente')
DROP PROCEDURE usp_registrarCliente

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_modificarCliente')
DROP PROCEDURE usp_modificarCliente

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_obtenerCliente')
DROP PROCEDURE usp_obtenerCliente

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_listarCliente')
DROP PROCEDURE usp_obtenerCliente

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_eliminarCliente')
DROP PROCEDURE usp_eliminarCliente

go



---------Proveedor 

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_registrarProveedor')
DROP PROCEDURE usp_registrarProveedor

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_modificarProveedor')
DROP PROCEDURE usp_modificarProveedor

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_obtenerProveedor')
DROP PROCEDURE usp_obtenerProveedor

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_listarProveedor')
DROP PROCEDURE usp_listarProveedor

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_eliminarProveedor')
DROP PROCEDURE usp_eliminarProveedor

go




---------Inventario 

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_registrarInventario')
DROP PROCEDURE usp_registrarInventario

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_modificarInventario')
DROP PROCEDURE usp_modificarInventario

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_obtenerInventario')
DROP PROCEDURE usp_obtenerInventario

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_listarInventario')
DROP PROCEDURE usp_listarInventario

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_eliminarInventario')
DROP PROCEDURE usp_eliminarInventario

go


--************************  PROCEDIMIENTOS ALMACENADOS ************************--



---------Cliente

----Agregar
go
create procedure usp_registrarCliente(
@Cedula varchar(60),
@Nombres varchar(60),
@Telefono int,
@Correo varchar(60),
@Ciudad varchar(60)
)
as
begin

insert into Cliente(Cedula,Nombres,Telefono,Correo,Ciudad)
values
(
@Cedula,
@Nombres ,
@telefono,
@Correo,
@Ciudad
)

end

----Modificar
go

create procedure usp_modificarCliente(
@IdCliente int,
@Cedula varchar(60),
@Nombres varchar(60),
@Telefono int,
@Correo varchar(60),
@Ciudad varchar(60)
)
as
begin

update Cliente set 
Cedula = @Cedula,
Nombres = @Nombres,
Telefono = @Telefono,
Correo = @Correo,
Ciudad = @Ciudad

where IdCliente  = @IdCliente

end



----Obtener
go

create procedure usp_obtenerCliente(@IdCliente int)
as
begin

select * from Cliente where IdCliente = @IdCliente
end


----Lista
go
create procedure usp_listarCliente
as
begin

select * from Cliente
end


go
----Eliminar
create procedure usp_eliminarCliente(
@IdCliente int
)
as
begin

delete from Cliente where IdCliente = @IdCliente

end






---------Proveedor

----Agregar
go
create procedure usp_registrarProveedor(
@Cedula varchar(60),
@Nombres varchar(60),
@Telefono int,
@Correo varchar(60),
@Ciudad varchar(60)
)
as
begin

insert into Proveedor(Cedula,Nombres,Telefono,Correo,Ciudad)
values
(
@Cedula,
@Nombres ,
@telefono,
@Correo,
@Ciudad
)

end


----Modificar

go

create procedure usp_modificarProveedor(
@IdProveedor int,
@Cedula varchar(60),
@Nombres varchar(60),
@Telefono int,
@Correo varchar(60),
@Ciudad varchar(60)
)
as
begin

update Proveedor set 
Cedula = @Cedula,
Nombres = @Nombres,
Telefono = @Telefono,
Correo = @Correo,
Ciudad = @Ciudad

where IdProveedor  = @IdProveedor

end


----Obtener

go

create procedure usp_obtenerProveedor(@IdProveedor int)
as
begin

select * from Proveedor where IdProveedor= @IdProveedor
end

----Lista

go
create procedure usp_listarProveedor
as
begin

select * from Proveedor
end


----Eliminar
go
create procedure usp_eliminarProveedor(
@IdProveedor int
)
as
begin

delete from Proveedor where IdProveedor = @IdProveedor

end



---------Inventario
----Agregar

go
create procedure usp_registrarInventario(
@Nombre varchar(60),
@Precio int,
@Stock varchar(60),
@Proveedor int
)
as
begin

insert into Inventario(Nombre,Precio,Stock,Proveedor)
values
(
@Nombre ,
@Precio,
@Stock,
@Proveedor
)

end

----Modificar



go

create procedure usp_modificarInventario(
@IdInventario int,
@Nombre varchar(60),
@Precio int,
@Stock varchar(60),
@Proveedor int

)
as
begin

update Inventario set 

Nombre = @Nombre,
Precio = @Precio,
Stock = @Stock,
Proveedor = @Proveedor

where IdInventario  = @IdInventario 

end


----Obtener


go

----Listar
go
create procedure usp_obtenerInventario(@IdInvetario int)
as
begin

select * from Inventario where IdInventario = @IdInvetario
end

go
create procedure usp_listarInventario
as
begin

select * from inventario
end

----Eliminar
go
create procedure usp_eliminarInventario(
@IdInventario int
)
as
begin

delete from Inventario where IdInventario = @IdInventario

end

go

--************************  INSERTACION DE DATOS ************************--


--------CLIENTES
INSERT INTO Cliente(Cedula, Nombres, Telefono, Correo, Ciudad) VALUES
( '001-120389-1536Q', 'Carlos Macy', '78459841', 'Carlos@eratvolutpat.edu', 'Masaya'),
( '008-101098-7968D', 'Ana Trujillo', '85961039', 'AnaTrujillo.mattis@eratvolutpat.edu', 'Managua'),
( '001-250996-1032R', 'Juan Pérez ', '22365871', 'bJuan@eratvolutpat.edu', 'Managua'),
( '009-210896-1524E', 'Valentina de la Rosa', '88569654', 'Rosa.@eratvolutpat.edu', 'Masaya'),
( '008-010700-7474A', 'Óscar Mejía', '22369989', 'blanditÓscar@eratvolutpat.edu', 'Managua'),
( '002-091297-8964D', 'Matías Rincón', '77856984', 'Matmattis@eratvolutpat.edu', 'Rae Lakes'),
( '007-101299-1001A', 'Sebastián  Yepes', '88633214', 'blandit.mattis@eratvolutpat.edu', 'Masaya'),
( '001-300692-7789F', 'Ana Peña ', '89564125', 'ana.Peñas@eratvolutpat.edu', 'Masaya'),
( '001-010101-9685F', 'Mónica Macy', '77423698', 'mjMónica@eratvolutpat.edu', 'Managua'),
( '001-311295-4628A', 'Carlos Mendoza', '73126948', 'MendozaMendoza@eratvolutpat.edu', 'Managua')



--------PROVEEDOR
INSERT INTO Proveedor(Cedula, Nombres, Telefono, Correo, Ciudad) VALUES
( '008-220398-1524A', 'María del Carmen', '74569823', 'María.mattis@edu', 'Managua'),
( '003-100190-7845S', 'Camila  Cristo', '1426588', 'Camila.mattis@edu', 'Managua'),
( '001-101098-1524E', 'Jorge  Mercedes', '74589632', 'Jorge.mattis@edu', 'Masaya'),
( '001-010197-2369D', 'Patricia  Niño', '74856932', 'Patricia.mattis@edu', 'Managua'),
( '001-300580-7744A', 'Jairo  Macy', '78596412', 'Jairo.mattis@edu', 'Masaya')


--------INVENTARIO

INSERT INTO Inventario(Nombre,Precio , Stock,Proveedor ) VALUES

( 'Motherboard', '5000', 50, 1),
( 'Laptop', '10000', 50, 1),
( 'Memoria', '1500', 50, 1),
( 'Fuente de alimentación (PSU)', '3050', 50, 1),
( 'Refrigeración del sistema.', '4200', 50, 1),
( 'Mouse', '400', 50, 1),
( 'disco duro', '700', 50, 1),
( 'Monitor', '20000', 50, 1),
( 'Módem', '1000', 50, 1),
( 'Procesador ', '5000', 50, 1),
( 'Tarjeta de gráficos', '15000', 50, 1)


