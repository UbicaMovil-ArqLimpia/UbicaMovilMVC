Create database UbicaMovil
go
use  UbicaMovil
go

create table Empresa(
Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
Nombre varchar(15) NOT NULL,
Direccion varchar(Max)NOT NULL,
Telefono varchar (10)NOT NULL,
HorarioEntrada datetime NOT NULL,
HorarioSalida datetime NOT NULL,
)