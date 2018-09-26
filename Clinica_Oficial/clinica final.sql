create database Clinica_Veterinaria2
go
use Clinica_Veterinaria2
go

create table veterinario(
codVeterinario int not null identity(1,1) primary key,
nombre varchar (100),
apellido varchar (100),
dui varchar(10) unique,
telefono varchar(14),
sexo varchar (10),
direccion varchar(150)
)
go
create table rol(
id int not null identity(1,1) primary key,
rol varchar(50)
)
go
create table usuario (
id int not null identity(1,1) primary key, 
usuario varchar(100) unique,
pass varchar(100),
id_rol int not null constraint fkrol references rol
)
go
create table propietario_Mascota(
codpropietario int not null identity(1,1) primary key,
nombre varchar (100),
apellido varchar (100),
dui varchar(10) unique,
sexo varchar(10),
telefono varchar(10),
direccion varchar(150)
)
go
create table tipo_mascota(
codtipo  int not null identity(1,1) primary key,
especie varchar(100)
)
go
create table mascota(
codmascota  int not null identity(1,1) primary key,
codpropietario int not null constraint fkmascota references propietario_Mascota,
codtipo int not null constraint fktipo references tipo_mascota,
nombre varchar(100),
peso varchar(100),
sexo varchar (10),
fechanacimiento date,
)

go
create table estado(
codestado  int not null identity(1,1) primary key,
estado varchar(50)
)
go
create table cita(
codcita  int not null identity(1,1) primary key,
codusuario int not null constraint fkcita1 references usuario,
codmascota int not null constraint fkcita2 references mascota,
codveterinario int not null constraint fkcita3 references veterinario,
fecha varchar(12),
hora varchar(8),
codestado int not null constraint fkcita4 references estado,
)
go
create table consulta (
codconsulta  int not null identity(1,1) primary key,
diagnostico varchar(150),
observaciones varchar(150),
codcita int  not null constraint fkcodcita  references cita 
)
go
create table receta(
codreceta  int not null identity(1,1) primary key,
codconsulta int not null constraint fkreceta references consulta,
descripcion varchar(250),
dosis varchar(50)
)

