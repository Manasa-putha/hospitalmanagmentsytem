﻿// <auto-generated />
using System;
using HMSFE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HMSFE.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241026180327_removed")]
    partial class removed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HMSFE.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"), 1L, 1);

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeSlot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentId");

                    b.HasIndex("PatientId");

                    b.HasIndex("StaffId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            AppointmentId = 1,
                            AppointmentDate = new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PatientId = 1,
                            StaffId = 1,
                            Status = "Booked",
                            TimeSlot = "10:00 AM - 10:30 AM",
                            UpdatedAt = new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentId = 2,
                            AppointmentDate = new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PatientId = 2,
                            StaffId = 1,
                            Status = "Booked",
                            TimeSlot = "11:00 AM - 11:30 AM",
                            UpdatedAt = new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentId = 3,
                            AppointmentDate = new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PatientId = 1,
                            StaffId = 1,
                            Status = "Booked",
                            TimeSlot = "11:00 AM - 11:30 AM",
                            UpdatedAt = new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("HMSFE.Models.DoctorAvailability", b =>
                {
                    b.Property<int>("AvailabilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvailabilityId"), 1L, 1);

                    b.Property<DateTime>("AvailableDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<string>("TimeSlot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("AvailabilityId");

                    b.HasIndex("StaffId");

                    b.ToTable("DoctorAvailabilities");

                    b.HasData(
                        new
                        {
                            AvailabilityId = 1,
                            AvailableDate = new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAvailable = true,
                            Specialization = "Cardiologist",
                            StaffId = 1,
                            TimeSlot = "09:00 AM - 11:00 AM",
                            UpdatedAt = new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AvailabilityId = 2,
                            AvailableDate = new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAvailable = true,
                            Specialization = "Cardiologist",
                            StaffId = 1,
                            TimeSlot = "10:00 AM - 11:00 AM",
                            UpdatedAt = new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AvailabilityId = 3,
                            AvailableDate = new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAvailable = true,
                            Specialization = "Neurologist",
                            StaffId = 1,
                            TimeSlot = "11:00 AM - 12:00 AM",
                            UpdatedAt = new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("HMSFE.Models.HospitalStaff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("StaffId");

                    b.ToTable("HospitalStaffs");

                    b.HasData(
                        new
                        {
                            StaffId = 1,
                            CreatedAt = new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "emily.wilson@hospital.com",
                            EmployeeId = "E1001",
                            FullName = "Dr. Emily Wilson",
                            Password = "doctor123",
                            PhoneNumber = "1122334455",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "Doctor",
                            Specialization = "Cardiologist",
                            UpdatedAt = new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            StaffId = 2,
                            CreatedAt = new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mark.davis@hospital.com",
                            EmployeeId = "N2001",
                            FullName = "Nurse Mark Davis",
                            Password = "nurse123",
                            PhoneNumber = "5566778899",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "Nurse",
                            Specialization = "Neurolist",
                            UpdatedAt = new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            StaffId = 3,
                            CreatedAt = new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "emily.wilson@hospital.com",
                            EmployeeId = "E1003",
                            FullName = "Dr. Bushan",
                            Password = "doctor123",
                            PhoneNumber = "1122334455",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "Doctor",
                            Specialization = "Cardiologist",
                            UpdatedAt = new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("HMSFE.Models.MedicalRecord", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecordId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnoses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.Property<string>("TestResults")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Treatment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("RecordId");

                    b.HasIndex("PatientId");

                    b.HasIndex("StaffId");

                    b.ToTable("MedicalRecords");

                    b.HasData(
                        new
                        {
                            RecordId = 1,
                            CreatedAt = new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Diagnoses = "Hypertension",
                            PatientId = 1,
                            RecordDate = new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StaffId = 1,
                            TestResults = "Blood Pressure: 150/90 mmHg",
                            Treatment = "Prescribed medication for blood pressure control",
                            UpdatedAt = new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RecordId = 2,
                            CreatedAt = new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Diagnoses = "Asthma",
                            PatientId = 2,
                            RecordDate = new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StaffId = 1,
                            TestResults = "Lung Function Test: 80% capacity",
                            Treatment = "Prescribed inhaler",
                            UpdatedAt = new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("HMSFE.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnoses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicalNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PinCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestResults")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            PatientId = 1,
                            Address = "123 Main Street",
                            Age = 30,
                            City = "New York",
                            CreatedAt = new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Diagnoses = "Hypertension",
                            Email = "john.doe@gmail.com",
                            MedicalNotes = "Patient advised to reduce salt intake",
                            Password = "john1234",
                            PhoneNumber = "1234567890",
                            PinCode = "10001",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Sex = "Male",
                            UpdatedAt = new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            userName = "John Doe"
                        },
                        new
                        {
                            PatientId = 2,
                            Address = "456 Oak Street",
                            Age = 25,
                            City = "Chicago",
                            CreatedAt = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Diagnoses = "Asthma",
                            Email = "jane.smith@gmail.com",
                            MedicalNotes = "Prescribed inhaler",
                            Password = "jane1234",
                            PhoneNumber = "0987654321",
                            PinCode = "60601",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Sex = "Female",
                            UpdatedAt = new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            userName = "Jane Smith"
                        },
                        new
                        {
                            PatientId = 3,
                            Address = "456 Oak Street",
                            Age = 25,
                            City = "Vizag",
                            CreatedAt = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Diagnoses = "Asthma",
                            Email = "manu@gmail.com",
                            MedicalNotes = "Prescribed inhaler",
                            Password = "manu1234",
                            PhoneNumber = "0987654321",
                            PinCode = "60601",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Sex = "Female",
                            UpdatedAt = new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            userName = "Manasa"
                        },
                        new
                        {
                            PatientId = 4,
                            Address = "456 Oak Street",
                            Age = 20,
                            City = "Ongole",
                            CreatedAt = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Diagnoses = "Asthma",
                            Email = "sai@gmail.com",
                            MedicalNotes = "Prescribed inhaler",
                            Password = "sai1234",
                            PhoneNumber = "0987654321",
                            PinCode = "5162",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Sex = "Female",
                            UpdatedAt = new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            userName = "Sai"
                        },
                        new
                        {
                            PatientId = 5,
                            Address = "456 Ongole Street",
                            Age = 10,
                            City = "Ongoel",
                            CreatedAt = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Diagnoses = "Thyriod",
                            Email = "ramu@gmail.com",
                            MedicalNotes = "Prescribed ",
                            Password = "ramu1234",
                            PhoneNumber = "0987654321",
                            PinCode = "606",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Sex = "Male",
                            UpdatedAt = new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            userName = "Ramu"
                        });
                });

            modelBuilder.Entity("HMSFE.Models.Appointment", b =>
                {
                    b.HasOne("HMSFE.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMSFE.Models.HospitalStaff", "Staff")
                        .WithMany("Appointments")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("HMSFE.Models.DoctorAvailability", b =>
                {
                    b.HasOne("HMSFE.Models.HospitalStaff", "Staff")
                        .WithMany("DoctorAvailabilities")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("HMSFE.Models.MedicalRecord", b =>
                {
                    b.HasOne("HMSFE.Models.Patient", "Patient")
                        .WithMany("MedicalRecords")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMSFE.Models.HospitalStaff", "Staff")
                        .WithMany("MedicalRecords")
                        .HasForeignKey("StaffId");

                    b.Navigation("Patient");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("HMSFE.Models.HospitalStaff", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("DoctorAvailabilities");

                    b.Navigation("MedicalRecords");
                });

            modelBuilder.Entity("HMSFE.Models.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("MedicalRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
