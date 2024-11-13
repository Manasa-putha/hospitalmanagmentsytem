namespace HMSFE.Models.DTOS
{
    public class MedicalRecordDto
    {
        public int RecordId { get; set; }
        public int PatientId { get; set; }
        public int StaffId { get; set; }
        public string? Diagnoses { get; set; }
        public string? Treatment { get; set; }
        public string? TestResults { get; set; }
        public DateTime RecordDate { get; set; }
    }

}
