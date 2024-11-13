using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMSFE.Migrations
{
    public partial class removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_HospitalStaffs_StaffId",
                table: "MedicalRecords");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "MedicalRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                table: "HospitalStaffs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_HospitalStaffs_StaffId",
                table: "MedicalRecords",
                column: "StaffId",
                principalTable: "HospitalStaffs",
                principalColumn: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_HospitalStaffs_StaffId",
                table: "MedicalRecords");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "MedicalRecords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                table: "HospitalStaffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_HospitalStaffs_StaffId",
                table: "MedicalRecords",
                column: "StaffId",
                principalTable: "HospitalStaffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
