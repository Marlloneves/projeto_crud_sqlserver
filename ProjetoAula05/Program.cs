using ProjetoAula05.Controllers;

namespace ProjetoAula05
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var produtoController = new ProdutoController();

            try
            {
                Console.WriteLine("(1) Cadastrar produto");
                Console.WriteLine("(2) Atualizar produto");
                Console.WriteLine("(3) Excluir produto");
                Console.WriteLine("(4) Consultar produtos");

                Console.Write("\nEntre com a opção desejada: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        produtoController.CadastrarProduto();
                        break;
                    case 2:
                        produtoController.AtualizarProduto();
                        break ;
                    case 3:
                        produtoController.ExcluirProduto();
                        break;
                    case 4:
                        produtoController.ConsultarProdutos();
                        break ;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.Write("Deseja continuar? (S/N)...: ");
                var escolha = Console.ReadLine();
                if(escolha == "S" || escolha == "s")
                {
                    Console.Clear();//Limpar a tela do DOS
                    Main(args); //recursividade --- Ele vai voltar a executar o método main
                }
                else
                {
                    Console.WriteLine("\nFIM DO PROGRAMA\n");
                }
            }catch (Exception ex)
            {
                Console.WriteLine($"\nERRO: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
