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

}