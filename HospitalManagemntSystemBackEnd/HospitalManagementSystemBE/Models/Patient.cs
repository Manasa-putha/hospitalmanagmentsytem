using System.ComponentModel.DataAnnotations;

namespace HMSFE.Models
{
    public class Patient : User
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        public string userName { get; set; } = string.Empty;

        //[Required]
        public string? PhoneNumber { get; set; } = string.Empty;

        public string? Email { get; set; }

        [Required]
        public int Age { get; set; }

        //[Required]
        public string? Sex { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? PinCode { get; set; }

        public string? Diagnoses { get; set; }

        public string? MedicalNotes { get; set; }
        // public string? Token { get; set; }
        //public string? RefreshToken { get; set; }
        //public DateTime RefreshTokenExpiryTime { get; set; }
        public string? TestResults { get; set; }
        public string Password { get; set; } = string.Empty;

        // Relationships
        public ICollection<Appointment>? Appointments { get; set; }

        public ICollection<MedicalRecord>? MedicalRecords { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

}
