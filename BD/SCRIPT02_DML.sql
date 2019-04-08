--Projeto de wishlist (lista de desejos)
--Atividade do curso técnico Desenvolvimento de Sistemas
--Senai Informática São Paulo - 2019
-- DQL - LINGUAGEM DE CONSULTA DE DADOS


--INSERE DADOS NA TABELA USUARIOS
INSERT INTO USUARIOS (EMAIL, SENHA)
VALUES ('admin@admin.com', '123456'), ('matheus@hotmail.com', '654321'), ('helena@hotmail.com', '987654')

--SELECIONA OS DADOS DA TABELA USUARIOS
INSERT * FROM USUARIOS

-- INSERE DADOS NA TABELA DESEJOS
INSERT INTO DESEJOS (DESEJO, DATA_CRIACAO, ID_USUARIO)
VALEU ('Ser rico e triste', '19-04-06', '2'), ('Ter uma familia', '19-04-15', '1'), ('Não tenho desejo', '19-04-18', '3'), ('Ser pobre e feliz', '19-04-06', '2')

--SELECIONA OS DADOS DA TABELA USUARIOS
SELECT * FROM DESEJOS