Para realizar os testes do projeto, será necessário configurar uma instância de banco de dados SQL Server, que pode ser local ou em nuvem. Siga os passos abaixo:

Criar o Banco de Dados
Crie um banco de dados chamado Todo.

Atualizar a String de Conexão
Altere a string de conexão no arquivo Constants.cs para apontar para o banco recém-criado.

Criar a Tabela Necessária
Dentro do banco de dados Todo, crie uma tabela com o seguinte esquema:

id: tipo int, NOT NULL, configurado como identidade com incremento de 1 (IDENTITY(1,1)).
title: tipo varchar(50), NOT NULL.
description: tipo varchar(MAX), NULL.
priority: tipo bit, NOT NULL.
status: tipo bit, NOT NULL.
dataStart: tipo date, NOT NULL.
dataEnd: tipo date, NULL.
Segue o script SQL para criar a tabela:

CREATE TABLE Tasks (
    id INT IDENTITY(1,1) PRIMARY KEY,
    title VARCHAR(50) NOT NULL,
    description VARCHAR(MAX) NULL,
    priority BIT NOT NULL,
    status BIT NOT NULL,
    dataStart DATE NOT NULL,
    dataEnd DATE NULL
);

Assim que o banco e a tabela estiverem configurados, os testes poderão ser realizados sem impedimentos.
