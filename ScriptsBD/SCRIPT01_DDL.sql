--Projeto de wishlist (lista de desejos)
--Atividade do curso técnico Desenvolvimento de Sistemas
--Senai Informática São Paulo - 2019
--DDL - LINGUAGEM DE CRIAÇÃO DE DADOS

--CRIA BANCO DE DADOS DO PROGRAMA
create database senaiWishlistDesafio;

--CRIA A TABELA DE USUARIOS
create table USUARIOS (
	-- COLUNA TIPO_DADOS CARACTERÍSTICAS CHAVE
	ID int identity primary key
	,EMAIL varchar(250) not null unique
	,SENHA varchar(250) not null
);

--CRIA A TABELA DE DESEJOS
create table DESEJOS (
	-- COLUNA TIPO_DADOS CARACTERÍSTICAS CHAVE
	ID int identity primary key
	,DESEJO varchar(250) not null
	,DATA_CRIACAO date not null
	,ID_USUARIO int foreign key references USUARIOS(ID)
);