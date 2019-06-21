using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominiumNetwork.Infrastructure.DataAcess.Migrations
{
    public partial class AlterOcurrence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Ocurrences",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Ocurrences");
        }
    }
}
