using HMSFE.Models;
using Microsoft.EntityFrameworkCore;

namespace HMSFE.Data
{
    public class Context :  DbContext
    {
   
            public DbSet<Patient> Users { get; set; }
            public DbSet<HospitalStaff> HospitalStaffs { get; set; }
            public DbSet<DoctorAvailability> DoctorAvailabilities { get; set; }
            public DbSet<Appointment> Appointments { get; set; }
            public DbSet<MedicalRecord> MedicalRecords { get; set; }

            public Context(DbContextOptions<Context> options) : base(options)
            {
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relationships
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Staff)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.StaffId);

            modelBuilder.Entity<DoctorAvailability>()
                .HasOne(da => da.Staff)
                .WithMany(s => s.DoctorAvailabilities)
                .HasForeignKey(da => da.StaffId);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(mr => mr.Patient)
                .WithMany(p => p.MedicalRecords)
                .HasForeignKey(mr => mr.PatientId);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(mr => mr.Staff)
                .WithMany(s => s.MedicalRecords)
                .HasForeignKey(mr => mr.StaffId);

        
            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    PatientId = 1,
                    userName = "John Doe",
                    PhoneNumber = "1234567890",
                    Email = "john.doe@gmail.com",
                    Age = 30,
                    Sex = "Male",
                    Address = "123 Main Street",
                    City = "New York",
                    PinCode = "10001",
                    Diagnoses = "Hypertension",
                    MedicalNotes = "Patient advised to reduce salt intake",
                    CreatedAt = new DateTime(2024, 01, 10),
                    UpdatedAt = new DateTime(2024, 01, 20),
                    Password = "john1234"
                },
                new Patient
                {
                    PatientId = 2,
                    userName = "Jane Smith",
                    PhoneNumber = "0987654321",
                    Email = "jane.smith@gmail.com",
                    Age = 25,
                    Sex = "Female",
                    Address = "456 Oak Street",
                    City = "Chicago",
                    PinCode = "60601",
                    Diagnoses = "Asthma",
                    MedicalNotes = "Prescribed inhaler",
                    CreatedAt = new DateTime(2024, 02, 15),
                    UpdatedAt = new DateTime(2024, 02, 25),
                    Password = "jane1234"
                },
                   new Patient
                   {
                       PatientId = 3,
                       userName = "Manasa",
                       PhoneNumber = "0987654321",
                       Email = "manu@gmail.com",
                       Age = 25,
                       Sex = "Female",
                       Address = "456 Oak Street",
                       City = "Vizag",
                       PinCode = "60601",
                       Diagnoses = "Asthma",
                       MedicalNotes = "Prescribed inhaler",
                       CreatedAt = new DateTime(2024, 02, 15),
                       UpdatedAt = new DateTime(2024, 02, 25),
                       Password="manu1234"
                   },
                      new Patient
                      {
                          PatientId = 4,
                          userName = "Sai",
                          PhoneNumber = "0987654321",
                          Email = "sai@gmail.com",
                          Age = 20,
                          Sex = "Female",
                          Address = "456 Oak Street",
                          City = "Ongole",
                          PinCode = "5162",
                          Diagnoses = "Asthma",
                          MedicalNotes = "Prescribed inhaler",
                          CreatedAt = new DateTime(2024, 02, 15),
                          UpdatedAt = new DateTime(2024, 02, 25),
                          Password = "sai1234",
                      },
                         new Patient
                         {
                             PatientId = 5,
                             userName = "Ramu",
                             PhoneNumber = "0987654321",
                             Email = "ramu@gmail.com",
                             Age = 10,
                             Sex = "Male",
                             Address = "456 Ongole Street",
                             City = "Ongoel",
                             PinCode = "606",
                             Diagnoses = "Thyriod",
                             MedicalNotes = "Prescribed ",
                             CreatedAt = new DateTime(2024, 02, 15),
                             UpdatedAt = new DateTime(2024, 02, 25),
                             Password = "ramu1234"
                         }
            );

            
            modelBuilder.Entity<HospitalStaff>().HasData(
                new HospitalStaff
                {
                    StaffId = 1,
                    FullName = "Dr. Emily Wilson",
                    EmployeeId = "E1001",
                    Password = "doctor123",
                    Role = "Doctor",
                    Specialization = "Cardiologist",
                    PhoneNumber = "1122334455",
                    Email = "emily.wilson@hospital.com",
                    CreatedAt = new DateTime(2024, 03, 01),
                    UpdatedAt = new DateTime(2024, 03, 10)
                },
                new HospitalStaff
                {
                    StaffId = 2,
                    FullName = "Nurse Mark Davis",
                    EmployeeId = "N2001",
                    Password = "nurse123",
                    Role = "Nurse",
                    Specialization = "Neurolist",
                    PhoneNumber = "5566778899",
                    Email = "mark.davis@hospital.com",
                    CreatedAt = new DateTime(2024, 04, 05),
                    UpdatedAt = new DateTime(2024, 04, 15)
                },
                  new HospitalStaff
                  {
                      StaffId = 3,
                      FullName = "Dr. Bushan",
                      EmployeeId = "E1003",
                      Password = "doctor123",
                      Role = "Doctor",
                      Specialization = "Cardiologist",
                      PhoneNumber = "1122334455",
                      Email = "emily.wilson@hospital.com",
                      CreatedAt = new DateTime(2024, 03, 01),
                      UpdatedAt = new DateTime(2024, 03, 10)
                  },
                   new HospitalStaff
                   {
                       StaffId = 4,
                       FullName = "Dr. Ragu",
                       EmployeeId = "E1004",
                       Password = "doctor1234",
                       Role = "Doctor",
                       Specialization = "Cardiologist",
                       PhoneNumber = "1122334455",
                       Email = "ragu@hospital.com",
                       CreatedAt = new DateTime(2024, 03, 01),
                       UpdatedAt = new DateTime(2024, 03, 10)
                   },
                    new HospitalStaff
                    {
                        StaffId = 5,
                        FullName = "Dr. Ragevenra Reddy",
                        EmployeeId = "E1005",
                        Password = "doctor12345",
                        Role = "Doctor",
                        Specialization = "General Practitioner",
                        PhoneNumber = "1122334455",
                        Email = "vendra@hospital.com",
                        CreatedAt = new DateTime(2024, 03, 01),
                        UpdatedAt = new DateTime(2024, 03, 10)
                    }
            );

          
            modelBuilder.Entity<DoctorAvailability>().HasData(
                new DoctorAvailability
                {
                    AvailabilityId = 1,
                    StaffId = 1,
                    AvailableDate = new DateTime(2024, 10, 15),
                    TimeSlot = "09:00 AM - 11:00 AM",
                    Specialization = "Cardiologist",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2024, 09, 01),
                    UpdatedAt = new DateTime(2024, 09, 10)
                },
                 new DoctorAvailability
                 {
                     AvailabilityId = 2,
                     StaffId = 3,
                     AvailableDate = new DateTime(2024, 10, 15),
                     TimeSlot = "10:30 AM - 1:00 PM",
                     Specialization = "General Practitioner",
                     IsAvailable = true,
                     CreatedAt = new DateTime(2024, 09, 10),
                     UpdatedAt = new DateTime(2024, 09, 10)
                 },
                  new DoctorAvailability
                  {
                      AvailabilityId = 3,
                      StaffId = 4,
                      AvailableDate = new DateTime(2024, 10, 15),
                      TimeSlot = "11:00 AM - 12:00 AM",
                      Specialization = "Neurologist",
                      IsAvailable = true,
                      CreatedAt = new DateTime(2024, 09, 01),
                      UpdatedAt = new DateTime(2024, 09, 10)
                  },
                      new DoctorAvailability
                      {
                          AvailabilityId = 4,
                          StaffId = 5,
                          AvailableDate = new DateTime(2024, 10, 15),
                          TimeSlot = "11:00 AM - 12:00 AM",
                          Specialization = "Neurologist",
                          IsAvailable = true,
                          CreatedAt = new DateTime(2024, 09, 01),
                          UpdatedAt = new DateTime(2024, 09, 10)
                      },
                          new DoctorAvailability
                          {
                              AvailabilityId = 5,
                              StaffId = 1,
                              AvailableDate = new DateTime(2024, 10, 15),
                              TimeSlot = "11:00 AM - 12:00 AM",
                              Specialization = "Neurologist",
                              IsAvailable = true,
                              CreatedAt = new DateTime(2024, 09, 01),
                              UpdatedAt = new DateTime(2024, 09, 10)
                          }
            );

            
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    AppointmentId = 1,
                    PatientId = 1,
                    StaffId = 1,
                    AppointmentDate = new DateTime(2024, 10, 20),
                    TimeSlot = "10:00 AM - 10:30 AM",
                    Status = "Booked",
                    CreatedAt = new DateTime(2024, 10, 01),
                    UpdatedAt = new DateTime(2024, 10, 05)
                },
                new Appointment
                {
                    AppointmentId = 2,
                    PatientId = 2,
                    StaffId = 1,
                    AppointmentDate = new DateTime(2024, 10, 22),
                    TimeSlot = "11:00 AM - 11:30 AM",
                    Status = "Booked",
                    CreatedAt = new DateTime(2024, 10, 05),
                    UpdatedAt = new DateTime(2024, 10, 07)
                },
                   new Appointment
                   {
                       AppointmentId = 3,
                       PatientId = 1,
                       StaffId = 1,
                       AppointmentDate = new DateTime(2024, 10, 20),
                       TimeSlot = "11:00 AM - 11:30 AM",
                       Status = "Booked",
                       CreatedAt = new DateTime(2024, 10, 01),
                       UpdatedAt = new DateTime(2024, 10, 05)
                   }
            );

            modelBuilder.Entity<MedicalRecord>().HasData(
                new MedicalRecord
                {
                    RecordId = 1,
                    PatientId = 1,
                    StaffId = 1,
                    Diagnoses = "Hypertension",
                    Treatment = "Prescribed medication for blood pressure control",
                    TestResults = "Blood Pressure: 150/90 mmHg",
                    RecordDate = new DateTime(2024, 10, 10),
                    CreatedAt = new DateTime(2024, 10, 10),
                    UpdatedAt = new DateTime(2024, 10, 15)
                },
                new MedicalRecord
                {
                    RecordId = 2,
                    PatientId = 2,
                    StaffId = 1,
                    Diagnoses = "Asthma",
                    Treatment = "Prescribed inhaler",
                    TestResults = "Lung Function Test: 80% capacity",
                    RecordDate = new DateTime(2024, 10, 12),
                    CreatedAt = new DateTime(2024, 10, 12),
                    UpdatedAt = new DateTime(2024, 10, 17)
                }
            );
        }
            



protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
            {
            
            //configurationBuilder.Properties<UserType>().HaveConversion<string>();
        }
        }
    }



