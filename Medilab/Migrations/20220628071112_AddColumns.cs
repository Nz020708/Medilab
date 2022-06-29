using Microsoft.EntityFrameworkCore.Migrations;

namespace Medilab.Migrations
{
    public partial class AddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonImg",
                table: "Doctors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonName",
                table: "Doctors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Doctors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonImg",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PersonName",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Doctors");
        }
    }
}
