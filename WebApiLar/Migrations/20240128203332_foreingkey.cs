using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiLar.Migrations
{
    /// <inheritdoc />
    public partial class foreingkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTelefone",
                table: "Pessoa");

            migrationBuilder.AddColumn<string>(
                name: "CpfPessoa",
                table: "Telefone",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CpfPessoa",
                table: "Telefone");

            migrationBuilder.AddColumn<string>(
                name: "IdTelefone",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
