using System.ComponentModel.DataAnnotations;

namespace HMSFE.Models
{
    public class DoctorAvailability
    {
        [Key]
        public int AvailabilityId { get; set; }

        [Required]
        public int StaffId { get; set; }  
        public HospitalStaff? Staff { get; set; }
        public string? FullName { get; set; }

        [Required]
        public DateTime AvailableDate { get; set; }

        [Required]
        public string TimeSlot { get; set; } = string.Empty; // Example: 09:00 AM - 11:00 AM

        [Required]
        public string Specialization { get; set; } = string.Empty;

       
        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

}
