using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMSFE.Migrations
{
    public partial class cloumnadeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "DoctorAvailabilities",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "DoctorAvailabilities");
        }
    }
}
