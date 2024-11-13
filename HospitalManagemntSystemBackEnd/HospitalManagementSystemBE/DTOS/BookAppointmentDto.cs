namespace HMSFE.Models.DTOS
{
    public class BookAppointmentDto
    {
        public int PatientId { get; set; }
        public int StaffId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string TimeSlot { get; set; } = string.Empty;
    }
}
