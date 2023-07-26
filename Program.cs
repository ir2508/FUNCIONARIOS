using SistemaDeFuncionarios.Contexts;
using SistemaDeFuncionarios.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        string opcao;

        var db = new AppDbContext();

        Console.WriteLine("===== BEM-VINDO AO SISTEMA DE FUNCIONÁRIOS =====");
        Console.WriteLine("[1] Ver Funcionários | [2] Cadastrar Funcionário | [3] Editar Funcionário | [4] Excluir Funcionário");
        opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                Console.WriteLine("===== FUNCIONÁRIOS CADASTRADOS =====");
                
                foreach (var funcionario in db.Funcionario.ToList<Funcionario>())
                {
                    Console.WriteLine($"Id: { funcionario.Id } | Nome: { funcionario.Nome } | CPF: { funcionario.Cpf } | Cargo: { funcionario.Cargo } | Nível: { funcionario.NivelExperiencia } | Departamento: { funcionario.Departamento } | Salário: R$ { funcionario.Salario}");
                }
                break;

            case "2":
                // bool novoCadastro = false;
                // do 
                // {
                string nome, cpf, cargo, nivelExperiencia, departamento;
                decimal salario;

                Console.WriteLine("===== NOVO CADASTRO =====");
                Console.WriteLine("Informe o nome:");
                nome = Console.ReadLine();

                Console.WriteLine("Informe o cpf:");
                cpf = Console.ReadLine();

                Console.WriteLine("Informe o salário:");
                salario = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Informe o cargo:");
                cargo = Console.ReadLine();

                Console.WriteLine("Informe o nível:");
                nivelExperiencia = Console.ReadLine();

                Console.WriteLine("Informe o departamento:");
                departamento = Console.ReadLine();

                Funcionario func = new Funcionario(nome, cpf, salario, cargo, nivelExperiencia, departamento);
                db.Add<Funcionario>(func);
                // Console.WriteLine("Deseja realizar novo cadastro?");
                // novoCadastro = Convert.ToBoolean(Console.ReadLine());

                // } while(novoCadastro);
                db.SaveChanges();
                break;
        }
    }
}