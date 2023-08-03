using SistemaDeFuncionarios.Contexts;

namespace SistemaDeFuncionarios.Models;

public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public decimal Salario { get; set; }
    public string Cargo { get; set; } = string.Empty;
    public string NivelExperiencia { get; set; } = string.Empty;
    public string Departamento { get; set; } = string.Empty;

    public Funcionario(string nome, string cpf, decimal salario, string cargo, string nivelExperiencia, string departamento)
    {
        Nome = nome;
        Cpf = cpf;
        Salario = salario;
        Cargo = cargo;
        NivelExperiencia = nivelExperiencia;
        Departamento = departamento;
    }

    public static void CadastrarFuncionario()
    {
        var db = new AppDbContext();

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
    }

    public static void RemoverFuncionario()
    {
        var db = new AppDbContext();
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
    }

    public static void AtualizarFuncionario()
    {
        var db = new AppDbContext();

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
        try
        {
            funcAtualizar.Salario = Convert.ToDecimal(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Salário inválido... Tente novamente");
        }

        Console.Write("Informe o cargo: ");
        funcAtualizar.Cargo = Console.ReadLine();

        Console.Write("Informe o nível: ");
        funcAtualizar.NivelExperiencia = Console.ReadLine();

        Console.Write("Informe o departamento: ");
        funcAtualizar.Departamento = Console.ReadLine();
    }

    public static void PesquisarFuncionario()
    {
        var db = new AppDbContext();

        string funcionarioPesquisar;
        Console.WriteLine("\n====================================");
        Console.Write("Informe o nome do funcionário que deseja buscar: ");
        funcionarioPesquisar = Console.ReadLine();

        Console.WriteLine("\n====================================");
        foreach (var funcionario in db.Funcionario.ToList().Where(f => f.Nome.ToLower().Contains(funcionarioPesquisar.ToLower())))
        {
            Console.WriteLine($"Id: {funcionario.Id} | Nome: {funcionario.Nome} | CPF: {funcionario.Cpf} | Cargo: {funcionario.Cargo} | Nível: {funcionario.NivelExperiencia} | Departamento: {funcionario.Departamento} | Salário: R$ {funcionario.Salario}");
        }
    }

    public static void ListarFuncionarios()
    {
        var db = new AppDbContext();

        int ordem;
        Console.WriteLine("\n===== FUNCIONÁRIOS CADASTRADOS =====");
        Console.WriteLine("\n===== ORDENAR POR =====");
        Console.WriteLine("[1] Funcionário | [2] Departamento | [3] Salário");
        Console.Write("Informe a opção desejada: ");
        ordem = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("\n====================================");
        switch (ordem)
        {
            case 1:
                foreach (var funcionario in db.Funcionario.ToList<Funcionario>().OrderBy(f => f.Nome))
                {
                    Console.WriteLine($"Id: {funcionario.Id} | Nome: {funcionario.Nome} | CPF: {funcionario.Cpf} | Cargo: {funcionario.Cargo} | Nível: {funcionario.NivelExperiencia} | Departamento: {funcionario.Departamento} | Salário: R$ {funcionario.Salario}");
                }
                break;

            case 2:
                foreach (var funcionario in db.Funcionario.ToList<Funcionario>().OrderBy(f => f.Departamento))
                {
                    Console.WriteLine($"Id: {funcionario.Id} | Nome: {funcionario.Nome} | CPF: {funcionario.Cpf} | Cargo: {funcionario.Cargo} | Nível: {funcionario.NivelExperiencia} | Departamento: {funcionario.Departamento} | Salário: R$ {funcionario.Salario}");
                }
                break;

            case 3:
                foreach (var funcionario in db.Funcionario.ToList<Funcionario>().OrderBy(f => f.Salario))
                {
                    Console.WriteLine($"Id: {funcionario.Id} | Nome: {funcionario.Nome} | CPF: {funcionario.Cpf} | Cargo: {funcionario.Cargo} | Nível: {funcionario.NivelExperiencia} | Departamento: {funcionario.Departamento} | Salário: R$ {funcionario.Salario}");
                }
                break;

            default:
                foreach (var funcionario in db.Funcionario.ToList<Funcionario>())
                {
                    Console.WriteLine($"Id: {funcionario.Id} | Nome: {funcionario.Nome} | CPF: {funcionario.Cpf} | Cargo: {funcionario.Cargo} | Nível: {funcionario.NivelExperiencia} | Departamento: {funcionario.Departamento} | Salário: R$ {funcionario.Salario}");
                }
                break;
        }
    }
}