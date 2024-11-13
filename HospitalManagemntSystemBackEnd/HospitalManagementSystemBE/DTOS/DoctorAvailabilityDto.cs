namespace HMSFE.Models.DTOS
{
    public class DoctorAvailabilityDto
    {
        public int AvailabilityId { get; set; }
        public DateTime AvailableDate { get; set; }
        public string TimeSlot { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        //public List<HospitalStaff>? staff { get; set; }
        public HospitalStaffDto? Staff { get; set; }
    }
}
