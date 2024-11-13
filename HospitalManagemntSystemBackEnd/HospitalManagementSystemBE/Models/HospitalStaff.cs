using System.ComponentModel.DataAnnotations;

namespace HMSFE.Models
{

    public class HospitalStaff : User
    {
        [Key]
        public int StaffId { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string EmployeeId { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "Doctor"; // Default to Doctor, can also be Nurse or Admin
        public string? Specialization { get; set; } 


        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        public string? Email { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        // public string? Token { get; set; }
        //public string? RefreshToken { get; set; }
        //public DateTime RefreshTokenExpiryTime { get; set; }

        public ICollection<DoctorAvailability>? DoctorAvailabilities { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<MedicalRecord>? MedicalRecords { get; set; }
    }

}
