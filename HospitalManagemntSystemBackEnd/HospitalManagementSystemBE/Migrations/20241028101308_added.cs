using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMSFE.Migrations
{
    public partial class added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "DoctorAvailabilities",
                keyColumn: "AvailabilityId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Specialization", "StaffId", "TimeSlot" },
                values: new object[] { new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "General Practitioner", 3, "10:30 AM - 1:00 PM" });

            migrationBuilder.InsertData(
                table: "DoctorAvailabilities",
                columns: new[] { "AvailabilityId", "AvailableDate", "CreatedAt", "FullName", "IsAvailable", "Specialization", "StaffId", "TimeSlot", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Neurologist", 1, "11:00 AM - 12:00 AM", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "HospitalStaffs",
                columns: new[] { "StaffId", "CreatedAt", "Email", "EmployeeId", "FullName", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiryTime", "Role", "Specialization", "Token", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ragu@hospital.com", "E1004", "Dr. Ragu", "doctor1234", "1122334455", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Cardiologist", null, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vendra@hospital.com", "E1005", "Dr. Ragevenra Reddy", "doctor12345", "1122334455", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "General Practitioner", null, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "DoctorAvailabilities",
                keyColumn: "AvailabilityId",
                keyValue: 3,
                column: "StaffId",
                value: 4);

            migrationBuilder.InsertData(
                table: "DoctorAvailabilities",
                columns: new[] { "AvailabilityId", "AvailableDate", "CreatedAt", "FullName", "IsAvailable", "Specialization", "StaffId", "TimeSlot", "UpdatedAt" },
                values: new object[] { 4, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Neurologist", 5, "11:00 AM - 12:00 AM", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorAvailabilities",
                keyColumn: "AvailabilityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DoctorAvailabilities",
                keyColumn: "AvailabilityId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HospitalStaffs",
                keyColumn: "StaffId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HospitalStaffs",
                keyColumn: "StaffId",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DoctorAvailabilities",
                keyColumn: "AvailabilityId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Specialization", "StaffId", "TimeSlot" },
                values: new object[] { new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cardiologist", 1, "10:00 AM - 11:00 AM" });

            migrationBuilder.UpdateData(
                table: "DoctorAvailabilities",
                keyColumn: "AvailabilityId",
                keyValue: 3,
                column: "StaffId",
                value: 1);
        }
    }
}
