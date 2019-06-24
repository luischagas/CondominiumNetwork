using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominiumNetwork.Infrastructure.DataAcess.Migrations
{
    public partial class Photos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ContainerName = table.Column<string>(type: "varchar(500)", nullable: true),
                    FileName = table.Column<string>(type: "varchar(500)", nullable: true),
                    Url = table.Column<string>(type: "varchar(500)", nullable: true),
                    ContentType = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });
         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {       
            migrationBuilder.DropTable(
                name: "Photos");
  
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
