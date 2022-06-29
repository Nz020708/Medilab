using Microsoft.EntityFrameworkCore.Migrations;

namespace Medilab.Migrations
{
    public partial class DeleteColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Doctors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
