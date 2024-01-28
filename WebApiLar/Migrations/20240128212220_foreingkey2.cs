using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiLar.Migrations
{
    /// <inheritdoc />
    public partial class foreingkey2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
               name: "CpfPessoa",
               table: "Telefone",
               column: "CpfPessoa",
               principalTable: "Pessoa",
               principalColumn: "Cpf",
               onUpdate: ReferentialAction.NoAction,
               onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
