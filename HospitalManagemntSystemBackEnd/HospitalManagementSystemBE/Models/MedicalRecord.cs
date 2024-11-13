using System.ComponentModel.DataAnnotations;

namespace HMSFE.Models
{

    public class MedicalRecord
    {
        [Key]
        public int RecordId { get; set; }

        [Required]
        public int PatientId { get; set; }  
        public Patient? Patient { get; set; }

  
        public int? StaffId { get; set; } 
        public HospitalStaff? Staff { get; set; }

        public string? Diagnoses { get; set; }

        public string? Treatment { get; set; }

        public string? TestResults { get; set; }

        public DateTime RecordDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

}
