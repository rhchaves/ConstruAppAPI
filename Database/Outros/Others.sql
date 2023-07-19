--dotnet ef dbcontext scaffold "User Id=CONSTRUAPP;Password=construapp;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)))" Oracle.EntityFrameworkCore -o Entities -n ConstruAppAPI.Models

--adicionais ao comando de criação
---n NomeDoNameSpace (atribui o namespace)
---t tab1, tab2 (carregar apenas as tabelas desejadas)

----    //"DefaultConnection": "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));User Id=CONSTRUAPP;Password=construapp;",

------  Configura a sessão para o pluggable database XEPDB1
----*/

----ALTER SESSION SET CONTAINER = XEPDB1;

----/*
----  Remove a conta do usuário CONSTRUAPP e remove todos os seus objetos em cascata
----*/
----DROP USER CONSTRUAPP CASCADE;

----/*
----  Cria a conta do usuário CONSTRUAPP com a senha hr e concede os privilégios
----*/

----CREATE USER CONSTRUAPP 
----IDENTIFIED BY construapp
----QUOTA unlimited on users
----QUOTA 0 on system;

----GRANT CONNECT, RESOURCE TO CONSTRUAPP;

----GRANT CREATE SESSION, CREATE VIEW, CREATE TABLE, ALTER SESSION, CREATE SEQUENCE, CREATE PROCEDURE, CREATE TRIGGER TO CONSTRUAPP;
----GRANT CREATE SYNONYM, CREATE DATABASE LINK, UNLIMITED TABLESPACE TO CONSTRUAPP;

------GRANT ALL PRIVILEGES TO CONSTRUAPP;

----COMMIT;

---- retorna valores que iniciam com 'Fer' seguido por qualquer caracter
----SELECT * FROM CATEGORIES WHERE LABEL LIKE 'Fer%'; 

---- retorna valores com 1º caracter qualquer (representado por '_'), segunda letra 'e' minusculo e seguido por qualquer caracter
----SELECT * FROM CATEGORIES WHERE LABEL LIKE '_e%';

-------- Remoção das sequências
----DROP SEQUENCE CategorySeq;
----DROP SEQUENCE ProductSeq;


-------- Criação das sequências
----CREATE SEQUENCE CategorySeq START WITH 1 INCREMENT BY 1;
----CREATE SEQUENCE ProductSeq START WITH 1 INCREMENT BY 1;
----    Category_Id INT DEFAULT CategorySeq.NEXTVAL PRIMARY KEY,
----    Product_Id INT DEFAULT ProductSeq.NEXTVAL PRIMARY KEY,


