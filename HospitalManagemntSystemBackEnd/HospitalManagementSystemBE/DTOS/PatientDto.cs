namespace HMSFE.Models.DTOS
{
    public class PatientDto
    {
        public int PatientId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PinCode { get; set; }
        public string? Diagnoses { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<MedicalRecordDto>? MedicalRecords { get; set; }
    }
}
