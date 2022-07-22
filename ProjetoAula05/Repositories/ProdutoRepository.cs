using Dapper;
using ProjetoAula05.Configurations;
using ProjetoAula05.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Repositories
{
    public class ProdutoRepository
    {
        //Método para cadastrar um produto no banco de dados
        public void Create(Produto produto)
        {
            //Comando sql para inserir produtos no meu banco de dados
            var sql = @"
                INSERT INTO PRODUTO(
                    IDPRODUTO,
                    NOME,
                    PRECO,
                    QUANTIDADE,
                    DATACADASTRO)
                VALUES(
                    @IdProduto,
                    @Nome,
                    @Preco,
                    @Quantidade,
                    @DataCadastro)
             ";

            //Conectar no banco de dados
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                //executando o comando SQL no banco de dados
                //Esse .Execute é do Dapper
                //Quero que execute o var sql e pegue os dados do produto
                connection.Execute(sql, produto);
            }
        }
        //Método para atualizar um produto no banco de dados
        public void Update(Produto produto)
        {
            //Esse set é o que quero atualizar no banco de dados
            //Esse where eu vou dizer qual (somente) produto quero atualizar, se n atualizar todo o banco de dados
            var sql = @"
                UPDATE PRODUTO
                SET
                    NOME = @Nome,
                    PRECO = @Preco,
                    QUANTIDADE = @Quantidade,
                WHERE
                    IDPRODUTO = @IdProduto
            ";
            //Conectar ao banco de dados
            using(var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                connection.Execute(sql, produto);
            }
        }
        //Método para deletar um produto no banco de dados
        public void Delete(Produto produto)
        {
            var sql = @"
                DELETE FROM PRODUTO
                WHERE IDPRODUTO = @IdProduto
            ";
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                connection.Execute(sql, produto);
            }
        }
        //Método para retornar uma lista com todos os produtos que estiverem cadastro no banco de dados
        public List<Produto> GetAll()
        {
            var sql = @"
                SELECT * FROM PRODUTO
                ORDER BY NOME
            ";
            //Quando for um select do Sql eu tenho que usar o Query, dps dizer o tipo <>
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                return connection.Query<Produto>(sql).ToList();
            }
        }
        //Método para retornar 1 produto baseado no ID
        public Produto GetById(Guid idProduto)
        {
            var sql = @"
                SELECT * FROM PRODUTO
                WHERE IDPRODUTO = @idProduto
            ";

            using(var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                return connection.Query<Produto>(sql, new { idProduto }).FirstOrDefault();
            }
        }
    }
}
