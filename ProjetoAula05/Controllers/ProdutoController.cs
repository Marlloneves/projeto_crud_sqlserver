using ProjetoAula05.Entities;
using ProjetoAula05.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Controllers
{
    public class ProdutoController
    {
        //Método para capturar os dados de um produto informado pelo usuário do DOS e através do repositório, gravá-lo no banco de dados
        public void CadastrarProduto()
        {
            try
            {
                var produto = new Produto();
                Console.WriteLine("\n***CADASTRO DE PRODUTO***\n");
                produto.IdProduto = Guid.NewGuid();
                produto.DataCadastro = DateTime.Now;
                Console.Write("Digite o nome do produto.......: ");
                produto.Nome = Console.ReadLine();
                Console.Write("Digite o preço do produto......: ");
                produto.Preco = decimal.Parse(Console.ReadLine());
                Console.Write("Digite a quantidade do produto.: ");
                produto.Quantidade = int.Parse(Console.ReadLine());

                //Cadastrar no banco de dados

                var produtoRepository = new ProdutoRepository();
                produtoRepository.Create(produto);

                Console.WriteLine("\nProduto cadastrado com sucesso no banco de dados.");
            }catch (Exception ex)
            {
                Console.WriteLine($"\n Falha ao cadastrar produto: {ex.Message}");
            }
        }
        //Método para atualizar os dados de um produto informado pelo usuário
        public void AtualizarProduto()
        {
            try
            {
                Console.WriteLine("\n***ATUALIZAÇÃO DE PRODUTO***\n");

                Console.Write("Entre com o ID do Produto desejado...:");
                var idProduto = Guid.Parse(Console.ReadLine());

                var produtoRespository = new ProdutoRepository();
                var produto = produtoRespository.GetById(idProduto);

                //Verificar se o produto foi encontrado
                if(produto != null)
                {
                    Console.WriteLine("Entre com o novo nome do produto:");
                    produto.Nome = Console.ReadLine();

                    Console.WriteLine("Entre com o novo preço do produto:");
                    produto.Preco = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Entre com a nova quantidade do produto:");
                    produto.Quantidade = int.Parse(Console.ReadLine());

                    produtoRespository.Update(produto);

                    Console.WriteLine("\nPRODUTO ATUALIZADO COM SUCESSO NO BANCO DE DADOS!\n");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado, verifique o ID informado.");
                }
            }catch (Exception ex)
            {
                Console.WriteLine($"\nFalha ao atualizar o produto: {ex.Message}");
            }
        }
        //Método para excluir um produto do banco de dados
        public void ExcluirProduto()
        {
            try
            {
                Console.Write("Entre com o ID do produto que deseja excluir: ");
                var idProduto = Guid.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(idProduto);

                if( produto != null)
                {
                    produtoRepository.Delete(produto);

                    Console.WriteLine("\nPRODUTO EXCLUÍDO COM SUCESSO DO BANCO DE DADOS!");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado, verifique o ID informado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nFalha ao excluir produto: {ex.Message}");
            }
        }

        //Método para consultar todos os produtos no banco de dados

        public void ConsultarProdutos()
        {
            try
            {
                Console.WriteLine("\n***Consulta de produtos***\n");
                var produtoRepository = new ProdutoRepository();
                var produtos = produtoRepository.GetAll();

                foreach (var produto in produtos)
                {
                    Console.WriteLine($"Id do Produto..........: {produto.IdProduto}");
                    Console.WriteLine($"Nome do Produto........: {produto.Nome}");
                    Console.WriteLine($"Quantidade do Produto..: {produto.Quantidade}");
                    Console.WriteLine($"Preço do Produto.......: {produto.Preco}");
                    Console.WriteLine($"Data/Hora de cadastro..: {produto.DataCadastro}");
                    Console.WriteLine("........");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nFalha ao consultar os produtos: {ex.Message}.");
            }
        }
    }
}
