# Projeto C# .NET Console Application / SqlServer
CRUD com SqlServer e Dapper

## Requisitos necessários:

* VisualStudio 2022
* SqlServer

## Script do banco de dados:
É necessário criar um banco de dados no SqlServer e incluir a sua connectionstring no projeto. Segue o script da tabela de produtos:

```sql
	CREATE TABLE PRODUTO(
		IDPRODUTO	UNIQUEIDENTIFIER	NOT NULL,
		NOME		NVARCHAR(150)		NOT NULL,
		PRECO		DECIMAL(18,2)		NOT NULL,
		QUANTIDADE	INTEGER			NOT NULL,
		DATACADASTRO	DATETIME		NOT NULL,
		PRIMARY KEY(IDPRODUTO))
	GO
```
