using AutoMapper;
using HMSFE.Data;
using HMSFE.DTOS;
using HMSFE.Models;
using HMSFE.Models.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMSFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly Context _context; 
        private readonly IMapper _mapper;
        public PatientController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("patients/filter")]
        public async Task<IActionResult> GetPatientsWithMedicalRecords()
        {
            
            var patients = await _context.Users
                .Include(p => p.MedicalRecords) 
                .ToListAsync();

            if (patients == null || !patients.Any())
            {
                return NotFound("No patients found.");
            }

            
            var patientsWithRecordsDto = _mapper.Map<List<PatientDto>>(patients);

            return Ok(patientsWithRecordsDto);
        }

        [HttpPost("patients")]
        public async Task<ActionResult<Patient>> AddPatient(Patient patient)
        {
            _context.Users.Add(patient);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(patient), new { id = patient.PatientId }, patient);
        }

        [HttpPut("patients/{id}")]
        public async Task<IActionResult> UpdatePatient(int id, Patient patient)
        {
            if (id != patient.PatientId)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!PatientExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return NoContent();
        }

        [HttpPost("medicalRecords")]
        public async Task<ActionResult<MedicalRecord>> AddMedicalRecord(MedicalRecord record)
        {
            _context.MedicalRecords.Add(record);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Patient), new { id = record.RecordId }, record);
        }

    }
}
