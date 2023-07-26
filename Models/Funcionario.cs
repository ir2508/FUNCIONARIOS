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
}