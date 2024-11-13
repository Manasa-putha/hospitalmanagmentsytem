namespace HMSFE.Models.DTOS
{

    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int StaffId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string TimeSlot { get; set; } = string.Empty;
        public string? Status { get; set; } = "Booked";
        // New properties for doctor details
        public string? fullName { get; set; } = string.Empty;
        public string? specialization { get; set; } = string.Empty;
    }
}
