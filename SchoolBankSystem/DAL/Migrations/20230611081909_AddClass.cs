using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClassId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Class_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Class_ClassId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Students");
        }
    }
}
