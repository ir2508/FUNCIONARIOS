using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeFuncionarios.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_FUNCIONARIO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    salario = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    cargo = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    experiencia = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    departamento = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FUNCIONARIO", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_FUNCIONARIO");
        }
    }
}
