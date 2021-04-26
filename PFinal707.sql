create database Pfinal707
use Pfinal707
Create table usuarios (
usua varchar(50),
pass varchar (50)
)
insert into usuarios values ('admin', '1234');
create table tiposocio (
IDtiposocio int primary key identity,
Descripcion nvarchar(50) NOT NULL)

insert into tiposocio values ('Corporativo')
insert into tiposocio values ('Diplomatico')
insert into tiposocio values ('Especiales')
insert into tiposocio values ('Fundador')
insert into tiposocio values ('NO residentes')
insert into tiposocio values ('Numeral')
insert into tiposocio values ('Propietario')
insert into tiposocio values ('NO Residente Propietario')
insert into tiposocio values ('NO Residente Numeral')
go
select * from tiposocio
go
create table socios (
ID int primary key identity,
IDSOCIO nvarchar (255) null, 
ITiposocio int foreign key references tiposocio(IDtiposocio),
Nombre nvarchar(75) null,
Apellido nvarchar(75) null, 
Nombrecompleto nvarchar(255) null,
sexo nvarchar(1) null, 
Cedula nvarchar(15) null, 
FechaIngreso date null, 
FechaNac date null, 
Direccion nvarchar(255) null,
Telefono nvarchar(15) null,
Celular nvarchar(15) null,
Email nvarchar(100) null,
Estatus int null
CONSTRAINT CEDULA UNIQUE (cedula)
)

drop table socios 

select * from socios
go
create procedure logear
@user varchar(50),
@passw varchar(50)
as 
begin
select * from usuarios where usua=@user and pass=@passw
end
go 

drop procedure insertarS

Create procedure insertarS
@idsocio NVARCHAR(50),
@tiposocio int,
@nombre NVARCHAR(50),
@apellido NVARCHAR(50),
@FullName NVARCHAR(50),
@sexo NVARCHAR (50),
@cedula NVARCHAR (50),
@Fechaing Date, 
@fechanac Date,
@direccion NVARCHAR (50),
@telefono NVARCHAR (50),
@Celular NVARCHAR (50),
@email NVARCHAR (50),
@estatus int
as
insert into socios values(@idsocio,@tiposocio,@nombre,@apellido,@FullName,@sexo,@cedula,
@Fechaing, @fechanac, @direccion, @telefono, @Celular, @email,@estatus)
GO

EXEC insertarS '1', 7, 'Juan', 'Pere', 'juan perez', 'F', '5852655', '2021-04-15','2021-04-15', 
'LEJO', '695555', '54555', 'JUAN@GMAIL.COM', 1
EXEC insertarS '1', 6, 'Juan', 'Pere', 'juan perez', 'F', '4455776', '2021-04-15','2021-04-15', 
'LEJO', '695555', '54555', 'JUAN@GMAIL.COM', 0

INSERT INTO SOCIOS VALUES('1', 7, 'Juan', 'Pere', 'juan perez', 'F', '5852656', '2021-04-15 12:48:08.963','2021-04-15 12:48:08.963', 
'LEJO', '695555', '54555', 'JUAN@GMAIL.COM', 1)

drop procedure ActualizarS
go 

Create procedure ActualizarS
@idsocio NVARCHAR(50),
@tiposocio int,
@nombre NVARCHAR(50),
@apellido NVARCHAR(50),
@FullName NVARCHAR(50),
@sexo NVARCHAR (50),
@cedula NVARCHAR (50),
@Fechaing Datetime, 
@fechanac Datetime,
@direccion NVARCHAR (50),
@telefono NVARCHAR (50),
@Celular NVARCHAR (50),
@email NVARCHAR (50),
@estatus int
as
update socios set IDSOCIO = @idsocio, ITiposocio= @tiposocio, Nombre= @nombre, apellido =@apellido,
Nombrecompleto= @FullName,sexo= @sexo,FechaIngreso= @Fechaing, 
FechaNac= @fechanac,Direccion= @direccion, Telefono= @telefono, Celular = @Celular, Email= @email, Estatus= @estatus 
where cedula= @cedula
GO
create procedure Cargar
as
begin
select *from socios
end 
go

exec cargar 
create procedure buscars
@Busque varchar(50)
as
begin
select * from socios
where cedula = @Busque
end

go 

drop PROCEDURE BorrarS
CREATE PROCEDURE BorrarS
@cedula NVarchar(50)
AS
DELETE FROM SOCIOS
WHERE CEDULA = @cedula


Create procedure insertarTS
@tiposocio NVARCHAR (50)
as
insert into tiposocio values(@tiposocio)
GO
Create procedure ActualizarTS
@descripcion NVARCHAR(50),
@idtipo int
as
update Tiposocio set Descripcion= @descripcion 
where IDtiposocio=  @idtipo
GO

create procedure CargarTS
as
begin
select *from tiposocio
end 
go

-----------------------------
--PROCEDIMIENTOS ALMACENADOS DE LOS REPORTES

--SP_SOCIOS_ACTIVOS
GO
CREATE PROC SP_SOCIOS_ACTIVOS
@Estatus int
AS
SELECT * FROM socios
WHERE Estatus=@Estatus
GO

EXEC SP_SOCIOS_ACTIVOS 1
--SP_SOCIOS_PROPIETARIOS
GO
 
ALTER PROCEDURE SP_SOCIOS_PROPIETARIOS
@IDTiposocio INT
AS
SELECT * FROM SOCIOS 
WHERE IDTiposocio=7

EXEC SP_SOCIOS_PROPIETARIOS 7

--SP_SOCIOS_NUMERALES

GO
ALTER PROCEDURE SP_SOCIOS_NUMERALES
@IDTiposocio INT
AS
SELECT * FROM SOCIOS 
WHERE IDTiposocio=6

EXEC SP_SOCIOS_NUMERALES 6

go

create procedure leerts 
@buscar NVARCHAR(50)
as 
select so.cedula, so.Nombrecompleto, so.sexo, ti.descripcion, so.FechaIngreso, so.direccion, 
so.telefono, so.estatus 
from socios as so
join tiposocio as ti
on so.itiposocio = [idtiposocio]
where so.itiposocio = @buscar

