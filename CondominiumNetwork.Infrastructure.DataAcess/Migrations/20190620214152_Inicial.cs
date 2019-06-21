using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominiumNetwork.Infrastructure.DataAcess.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    BlockApartment = table.Column<string>(type: "varchar(50)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ocurrences",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PublishDateTime = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(type: "varchar(600)", nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocurrences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocurrences_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warnings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false),
                    PublishDateTime = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warnings_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PublishDateTime = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(type: "varchar(500)", nullable: false),
                    OcurrenceId = table.Column<Guid>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Ocurrences_OcurrenceId",
                        column: x => x.OcurrenceId,
                        principalTable: "Ocurrences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_OcurrenceId",
                table: "Answers",
                column: "OcurrenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ProfileId",
                table: "Answers",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocurrences_ProfileId",
                table: "Ocurrences",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Warnings_ProfileId",
                table: "Warnings",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Warnings");

            migrationBuilder.DropTable(
                name: "Ocurrences");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
