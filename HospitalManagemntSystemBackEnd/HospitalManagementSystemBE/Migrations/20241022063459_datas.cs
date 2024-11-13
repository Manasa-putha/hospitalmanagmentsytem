using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMSFE.Migrations
{
    public partial class datas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "Password",
                value: "john1234");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "Password",
                value: "jane1234");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "PatientId",
                keyValue: 3,
                column: "Password",
                value: "manu1234");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "PatientId",
                keyValue: 4,
                column: "Password",
                value: "sai1234");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "PatientId",
                keyValue: 5,
                column: "Password",
                value: "ramu1234");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "Password",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "Password",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "PatientId",
                keyValue: 3,
                column: "Password",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "PatientId",
                keyValue: 4,
                column: "Password",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "PatientId",
                keyValue: 5,
                column: "Password",
                value: "");
        }
    }
}
