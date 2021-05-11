using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class createLibrarianTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Librarian",
                table: "Library");

            migrationBuilder.AddColumn<Guid>(
                name: "LibrarianId",
                table: "Library",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Librarian",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    LibrarianNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librarian", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Library_LibrarianId",
                table: "Library",
                column: "LibrarianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Library_Librarian_LibrarianId",
                table: "Library",
                column: "LibrarianId",
                principalTable: "Librarian",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Library_Librarian_LibrarianId",
                table: "Library");

            migrationBuilder.DropTable(
                name: "Librarian");

            migrationBuilder.DropIndex(
                name: "IX_Library_LibrarianId",
                table: "Library");

            migrationBuilder.DropColumn(
                name: "LibrarianId",
                table: "Library");

            migrationBuilder.AddColumn<string>(
                name: "Librarian",
                table: "Library",
                nullable: true);
        }
    }
}
