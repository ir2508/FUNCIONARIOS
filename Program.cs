using SistemaDeFuncionarios.Contexts;
using SistemaDeFuncionarios.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        string opcao;

        var db = new AppDbContext();
        do
        {

            Console.WriteLine("\n===== BEM-VINDO AO SISTEMA DE FUNCIONÁRIOS =====");
            Console.WriteLine("[1] Ver Funcionários | [2] Cadastrar Funcionário | [3] Editar Funcionário | [4] Excluir Funcionário | [-1] Sair");
            Console.Write("Informe a opção desejada: ");
            opcao = Console.ReadLine();

            if (opcao == "-1")
            {
                Console.WriteLine("==============================================");
                Console.WriteLine("Obrigado por utilizar nosso sistema. Até mais!");
                Console.WriteLine("==============================================");
                break;
            }

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("\n===== FUNCIONÁRIOS CADASTRADOS =====");

                    foreach (var funcionario in db.Funcionario.ToList<Funcionario>())
                    {
                        Console.WriteLine($"Id: {funcionario.Id} | Nome: {funcionario.Nome} | CPF: {funcionario.Cpf} | Cargo: {funcionario.Cargo} | Nível: {funcionario.NivelExperiencia} | Departamento: {funcionario.Departamento} | Salário: R$ {funcionario.Salario}");
                    }
                    break;

                case "2":
                    // bool novoCadastro = false;
                    // do 
                    // {
                    string nome, cpf, cargo, nivelExperiencia, departamento;
                    decimal salario;

                    Console.WriteLine("\n===== NOVO CADASTRO =====");
                    Console.Write("Informe o nome: ");
                    nome = Console.ReadLine();

                    Console.Write("Informe o cpf: ");
                    cpf = Console.ReadLine();

                    Console.Write("Informe o salário: ");
                    salario = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Informe o cargo: ");
                    cargo = Console.ReadLine();

                    Console.Write("Informe o nível: ");
                    nivelExperiencia = Console.ReadLine();

                    Console.Write("Informe o departamento: ");
                    departamento = Console.ReadLine();

                    Funcionario func = new Funcionario(nome, cpf, salario, cargo, nivelExperiencia, departamento);
                    db.Add<Funcionario>(func);
                    // Console.WriteLine("Deseja realizar novo cadastro?");
                    // novoCadastro = Convert.ToBoolean(Console.ReadLine());

                    // } while(novoCadastro);
                    break;

                case "3":
                    int idAtualizar;
                    Console.Write("\nInforme o Id do funcionário que deseja alterar: ");
                    idAtualizar = Convert.ToInt16(Console.ReadLine());
                    Funcionario funcAtualizar = db.Find<Funcionario>(idAtualizar);
                    while (funcAtualizar == null)
                    {
                        Console.Write($"O funcionário com o Id [{idAtualizar}] não foi encontrado... Insira o Id para atualizar: ");
                        idAtualizar = Convert.ToInt16(Console.ReadLine());
                        funcAtualizar = db.Find<Funcionario>(idAtualizar);
                    }

                    Console.Write("Informe o nome: ");
                    funcAtualizar.Nome = Console.ReadLine();

                    Console.Write("Informe o cpf: ");
                    funcAtualizar.Cpf = Console.ReadLine();

                    Console.Write("Informe o salário: ");
                    funcAtualizar.Salario = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Informe o cargo: ");
                    funcAtualizar.Cargo = Console.ReadLine();

                    Console.Write("Informe o nível: ");
                    funcAtualizar.NivelExperiencia = Console.ReadLine();

                    Console.Write("Informe o departamento: ");
                    funcAtualizar.Departamento = Console.ReadLine();

                    break;

                case "4":
                    int idRemover;
                    Console.Write("\nInforme o Id do funcionário que deseja remover: ");
                    idRemover = Convert.ToInt16(Console.ReadLine());
                    Funcionario funcRemover = db.Find<Funcionario>(idRemover);

                    while (funcRemover == null)
                    {
                        Console.Write($"O funcionário com o Id [{idRemover}] não foi encontrado... Insira o Id para remoção: ");
                        idRemover = Convert.ToInt16(Console.ReadLine());
                        funcRemover = db.Find<Funcionario>(idRemover);
                    }

                    Console.WriteLine($"Removendo o funcionário {funcRemover.Nome}...");
                    db.Remove(funcRemover);
                    break;
            }
            
            db.SaveChanges();
        } while (opcao != "-1");
    }
}