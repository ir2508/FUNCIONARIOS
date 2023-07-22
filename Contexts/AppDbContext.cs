using Microsoft.EntityFrameworkCore;
using SistemaDeFuncionarios.EntityConfigs;
using SistemaDeFuncionarios.Models;

namespace SistemaDeFuncionarios.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Funcionario> Funcionario => Set<Funcionario>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=Localhost;Database=DBFuncionarios;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .ApplyConfiguration<Funcionario>(new FuncionarioEntityConfig());

    }


}