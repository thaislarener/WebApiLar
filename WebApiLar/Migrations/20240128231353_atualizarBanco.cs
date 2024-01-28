using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiLar.Migrations
{
    /// <inheritdoc />
    public partial class atualizarBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Pessoa_PessoaModelCpf",
                table: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Telefone_PessoaModelCpf",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "PessoaModelCpf",
                table: "Telefone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PessoaModelCpf",
                table: "Telefone",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_PessoaModelCpf",
                table: "Telefone",
                column: "PessoaModelCpf");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Pessoa_PessoaModelCpf",
                table: "Telefone",
                column: "PessoaModelCpf",
                principalTable: "Pessoa",
                principalColumn: "Cpf");
        }
    }
}
