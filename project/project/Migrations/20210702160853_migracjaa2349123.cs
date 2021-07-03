using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class migracjaa2349123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rooms",
                newName: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Rooms",
                newName: "Id");
        }
    }
}
