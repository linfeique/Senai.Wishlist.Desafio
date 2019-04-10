/* Arquivo de criação de dados*/


create database senaiWishlistDesafio;

create table USUARIOS (
	ID int identity primary key
	,EMAIL varchar(250) not null unique
	,SENHA varchar(250) not null
);

create table DESEJOS (
	ID int identity primary key
	,DESEJO varchar(250) not null
	,DATA_CRIACAO date not null
	,ID_USUARIO int foreign key references USUARIOS(ID)
);

