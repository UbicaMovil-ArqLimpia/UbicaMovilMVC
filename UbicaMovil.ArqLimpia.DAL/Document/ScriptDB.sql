Create database UbicaMovil
go
use  UbicaMovil
go

create table Categorias(
Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
Nombre varchar(100) NOT NULL
)
go
create table Empresas(
Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
Nombre varchar(100) NOT NULL,
Direccion varchar(Max)NOT NULL,
Telefono varchar (10)NOT NULL,
HorarioEntrada varchar(8) NOT NULL,
HorarioSalida varchar(8) NOT NULL,
Latitud decimal NOT NULL,
Longitud decimal NOT NULL,
IdCategoria int NOT NULL,

constraint FK_empresas_categorias foreign key(IdCategoria) references Categorias(Id)
)