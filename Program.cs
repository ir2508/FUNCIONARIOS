using System.Net.WebSockets;
using SistemaDeFuncionarios.Contexts;
using SistemaDeFuncionarios.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        int opcao;

        var db = new AppDbContext();
        do
        {

            Console.WriteLine("\n===== BEM-VINDO AO SISTEMA DE FUNCIONÁRIOS =====");
            Console.WriteLine("[1] Ver Todos Funcionários | [2] Pesquisar Funcionário | [3] Cadastrar Funcionário | [4] Editar Funcionário | [5] Excluir Funcionário | [-1] Sair");
            Console.Write("Informe a opção desejada: ");
            opcao = Convert.ToInt16(Console.ReadLine());

            if (opcao == -1)
            {
                Console.WriteLine("==============================================");
                Console.WriteLine("Obrigado por utilizar nosso sistema. Até mais!");
                Console.WriteLine("==============================================");
                break;
            }

            switch (opcao)
            {
                case 1:
                    Funcionario.ListarFuncionarios();
                    break;

                case 2:
                    Funcionario.PesquisarFuncionario();
                    break;

                case 3:
                    Funcionario.CadastrarFuncionario();
                    break;

                case 4:
                    Funcionario.AtualizarFuncionario();
                    break;

                case 5:
                    Funcionario.RemoverFuncionario();
                    break;
            }

            db.SaveChanges();
        } while (opcao != -1);
    }
}