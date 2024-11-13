namespace HMSFE.DTOS
{
    public class PatientLoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }



    //public class AppointmentDto
    //{
    //    public int AppointmentId { get; set; }
    //    public int PatientId { get; set; }
    //    public int StaffId { get; set; }
    //    public DateTime AppointmentDate { get; set; }
    //    public string TimeSlot { get; set; } = string.Empty;
    //    public string Status { get; set; } = "Booked";
    //}

    //public class MedicalRecordDto
    //{
    //    public int RecordId { get; set; }
    //    public int PatientId { get; set; }
    //    public int StaffId { get; set; }
    //    public string Diagnoses { get; set; }
    //    public string Treatment { get; set; }
    //    public string TestResults { get; set; }
    //    public DateTime RecordDate { get; set; }
    //}



}
