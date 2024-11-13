using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMSFE.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Patients_PatientId",
                table: "MedicalRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "userName");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "HospitalStaffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "HospitalStaffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "HospitalStaffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "PatientId");

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "AppointmentDate", "CreatedAt", "PatientId", "StaffId", "Status", "TimeSlot", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Booked", "11:00 AM - 11:30 AM", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DoctorAvailabilities",
                columns: new[] { "AvailabilityId", "AvailableDate", "CreatedAt", "IsAvailable", "Specialization", "StaffId", "TimeSlot", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cardiologist", 1, "10:00 AM - 11:00 AM", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Neurologist", 1, "11:00 AM - 12:00 AM", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "HospitalStaffs",
                columns: new[] { "StaffId", "CreatedAt", "Email", "EmployeeId", "FullName", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiryTime", "Role", "Specialization", "Token", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.wilson@hospital.com", "E1003", "Dr. Bushan", "doctor123", "1122334455", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Cardiologist", null, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "PatientId", "Address", "Age", "City", "CreatedAt", "Diagnoses", "Email", "MedicalNotes", "Password", "PhoneNumber", "PinCode", "RefreshToken", "RefreshTokenExpiryTime", "Sex", "TestResults", "Token", "UpdatedAt", "userName" },
                values: new object[,]
                {
                    { 3, "456 Oak Street", 25, "Vizag", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asthma", "manu@gmail.com", "Prescribed inhaler", "", "0987654321", "60601", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", null, null, new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manasa" },
                    { 4, "456 Oak Street", 20, "Ongole", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asthma", "sai@gmail.com", "Prescribed inhaler", "", "0987654321", "5162", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", null, null, new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sai" },
                    { 5, "456 Ongole Street", 10, "Ongoel", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thyriod", "ramu@gmail.com", "Prescribed ", "", "0987654321", "606", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", null, null, new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ramu" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Users",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Users_PatientId",
                table: "MedicalRecords",
                column: "PatientId",
                principalTable: "Users",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Users_PatientId",
                table: "MedicalRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DoctorAvailabilities",
                keyColumn: "AvailabilityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DoctorAvailabilities",
                keyColumn: "AvailabilityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HospitalStaffs",
                keyColumn: "StaffId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "PatientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "PatientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "PatientId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "HospitalStaffs");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "HospitalStaffs");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "HospitalStaffs");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Patients");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Patients",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Patients_PatientId",
                table: "MedicalRecords",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
