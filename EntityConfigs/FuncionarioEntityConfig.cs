using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeFuncionarios.Models;

namespace SistemaDeFuncionarios.EntityConfigs;

public class FuncionarioEntityConfig : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        // Nome da tabela no banco de dados
        builder
            .ToTable("TB_FUNCIONARIO");

        // Coluna do id do funcionário
        builder
            .Property(funcionarios => funcionarios.Id)
            .HasColumnName("id")
            .HasColumnType("int");

        // Definindo o Id como Chave Primária
        builder
            .HasKey(funcionarios => funcionarios.Id);

        // Coluna do nome do funcionário
        builder
            .Property(funcionarios => funcionarios.Nome)
            .HasColumnName("nome")
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        // Coluna do cpf do funcionário
        builder
            .Property(funcionarios => funcionarios.Cpf)
            .HasColumnName("cpf")
            .HasColumnType("nvarchar(20)")
            .IsRequired();

        // Coluna do salário do funcionário
        builder
            .Property(funcionarios => funcionarios.Salario)
            .HasColumnName("salario")
            .HasColumnType("decimal")
            .IsRequired();

        // Coluna do cargo do funcionário
        builder
            .Property(funcionarios => funcionarios.Cargo)
            .HasColumnName("cargo")
            .HasColumnType("nvarchar(50)")
            .IsRequired();

        // Coluna do nível de experiência do funcionário
        builder
            .Property(funcionarios => funcionarios.NivelExperiencia)
            .HasColumnName("experiencia")
            .HasColumnType("nvarchar(10)")
            .IsRequired();

        // Coluna do departamento do funcionário
        builder
            .Property(funcionarios => funcionarios.Departamento)
            .HasColumnName("departamento")
            .HasColumnType("nvarchar(50)")
            .IsRequired();
    }
}