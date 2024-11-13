using AutoMapper;
using HMSFE.Data;
using HMSFE.DTOS;
using HMSFE.Models;
using HMSFE.Models.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace HMSFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {

        private readonly Context _context; // Replace with your actual DbContext
        private readonly IMapper _mapper;
        public StaffController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      

        [HttpGet("doctors")]
        public async Task<IActionResult> GetDoctorAvailability(string? specialization, DateTime? date, string? timeSlot)
        {
            try
            {
                //var query = _context.DoctorAvailabilities.AsQueryable();
                var query = _context.DoctorAvailabilities
                       .Include(d => d.Staff) // Assuming there's a Staff navigation property
                       .AsQueryable();

                if (!string.IsNullOrEmpty(specialization))
                {
                    query = query.Where(d => d.Specialization == specialization);
                }

                if (date.HasValue)
                {
                    query = query.Where(d => d.AvailableDate == date.Value);
                }

                if (!string.IsNullOrEmpty(timeSlot))
                {
                    query = query.Where(d => d.TimeSlot == timeSlot);
                }

                // Get the filtered list of available doctors
                var availabilities = await query.ToListAsync();

                if (availabilities == null || !availabilities.Any())
                {
                    return NotFound("No doctor availability found for the given filters.");
                }
                var availabilitiesDTO = _mapper.Map<List<DoctorAvailabilityDto>>(availabilities);
                return Ok(availabilitiesDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while retrieving doctor availability.", error = ex.Message });
            }
        }

      
        [HttpPost("appointments")]
        public async Task<ActionResult<AppointmentDto>> BookAppointment(BookAppointmentDto dto)
        {
            try
            {
                // Check if the Patient exists
                var patientExists = await _context.Users.AnyAsync(p => p.PatientId == dto.PatientId);

                if (!patientExists)
                {
                    return BadRequest("Patient not found. Please provide a valid PatientId.");
                }

                // Create the new appointment
                var appointment = new Appointment
                {
                    PatientId = dto.PatientId,
                    StaffId = dto.StaffId,
                    AppointmentDate = dto.AppointmentDate,
                    TimeSlot = dto.TimeSlot,
                    Status = "Booked",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                // Add and save the new appointment
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.AppointmentId }, appointment);
            }
            //catch (DbUpdateException dbEx)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while booking the appointment.", error = dbEx.Message });
            //}
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred.", error = ex.Message });
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> GetAppointmentById(int id)
        {
            try
            {
                var appointment = await _context.Appointments.FindAsync(id);
                if (appointment == null)
                {
                    return NotFound();
                }

                return Ok(new AppointmentDto
                {
                    AppointmentId = appointment.AppointmentId,
                    PatientId = appointment.PatientId,
                    StaffId = appointment.StaffId,
                    AppointmentDate = appointment.AppointmentDate,
                    TimeSlot = appointment.TimeSlot,
                    Status = appointment.Status
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while retrieving the appointment.", error = ex.Message });
            }
        }

        [HttpGet("appointments/patient/{patientId}")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsByPatientId(int patientId)
        {
            try
            {
                var appointments = await _context.Appointments
                     .Include(a => a.Staff)
                    .Where(a => a.PatientId == patientId)
                    .ToListAsync();

                if (appointments == null || !appointments.Any())
                {
                    return NotFound("No appointments found for this patient.");
                }

                return Ok(appointments.Select(a => new AppointmentDto
                {
                    AppointmentId = a.AppointmentId,
                    PatientId = a.PatientId,
                    StaffId = a.StaffId,
                    AppointmentDate = a.AppointmentDate,
                    TimeSlot = a.TimeSlot,
                    Status = a.Status,
                    fullName = a.Staff?.FullName,
                    specialization = a.Staff?.Specialization,
                })) ;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while retrieving the appointment.", error = ex.Message });
            }
        }

        [HttpGet("upcoming/{patientId}")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetUpcomingAppointments(int patientId)
        {
            var upcomingAppointments = await _context.Appointments
                .Where(a => a.PatientId == patientId && a.AppointmentDate >= DateTime.Now)
                .ToListAsync();

            return Ok(upcomingAppointments.Select(a => new AppointmentDto
            {
                AppointmentId = a.AppointmentId,
                PatientId = a.PatientId,
                StaffId = a.StaffId,
                AppointmentDate = a.AppointmentDate,
                TimeSlot = a.TimeSlot,
                Status = a.Status
            }));
        }

        [HttpGet("medicalrecords/patient/{patientId}")]
        public async Task<ActionResult<IEnumerable<MedicalRecordDto>>> GetMedicalRecordsByPatientId(int patientId)
        {
            try
            {
                var medicalRecords = await _context.MedicalRecords
                    .Where(mr => mr.PatientId == patientId)
                    .ToListAsync();

                if (medicalRecords == null || !medicalRecords.Any())
                {
                    return NotFound();
                }

                return Ok(medicalRecords.Select(mr => new MedicalRecordDto
                {
                    RecordId = mr.RecordId,
                    PatientId = mr.PatientId,
                    //StaffId = (int)mr.StaffId,
                    StaffId = mr.StaffId ?? 0,
                    Diagnoses = mr.Diagnoses,
                    Treatment = mr.Treatment,
                    TestResults = mr.TestResults,
                    RecordDate = mr.RecordDate
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred .", error = ex.Message });
            }
        }
        [HttpGet("appointments")]

        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointments(
            DateTime? date = null,
            string? time = null,
            int? doctorId = null,
            string? specialty = null)
        {
          
                var query = _context.Appointments.Include(a => a.Staff).AsQueryable();

                if (date.HasValue)
                {
                    query = query.Where(a => a.AppointmentDate.Date == date.Value.Date);
                }
                if (!string.IsNullOrEmpty(time))
                {
                    query = query.Where(a => a.TimeSlot == time);
                }
                if (doctorId.HasValue)
                {
                    query = query.Where(a => a.StaffId == doctorId.Value);
                }
                if (!string.IsNullOrEmpty(specialty))
                {
                    query = query.Where(a => a.Staff.Specialization == specialty);
                }

                //return await query.ToListAsync();
                var appointments = await query.ToListAsync();

                // Map to DTO
                var appointmentDtos = appointments.Select(a => new AppointmentDto
                {
                    AppointmentId = a.AppointmentId,
                    PatientId = a.PatientId,
                    TimeSlot = a.TimeSlot,
                    AppointmentDate = a.AppointmentDate,
                    //DoctorFullName = a.Staff?.FullName,
                    //DoctorSpecialization = a.Staff?.Specialization
                    fullName = a.Staff?.FullName ?? "N/A", // Get doctor's full name
                    specialization = a.Staff?.Specialization ?? "N/A"
                }).ToList();

                return appointmentDtos;
            }

       
        [HttpPost("patients")]
        public async Task<ActionResult<PatientDto>> AddPatient(Patient patient)
        {
            _context.Users.Add(patient);
            await _context.SaveChangesAsync();

            var patientDto = new PatientDto
            {
                //PatientId = patient.PatientId,
                UserName = patient.userName,
                Email = patient.Email,
                MedicalRecords = patient.MedicalRecords.Select(m => new MedicalRecordDto
                {
                    Diagnoses = m.Diagnoses,
                    Treatment = m.Treatment,
                    TestResults = m.TestResults
                }).ToList()
            };

            return Ok(patientDto);
        }

       
       

        [HttpPut("patients/{id}")]
        //[HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientDto updatePatientDto)
        {
            if (id != updatePatientDto.PatientId)
            {
                return BadRequest();
            }

            var patient = await _context.Users.Include(p => p.MedicalRecords)
                .FirstOrDefaultAsync(p => p.PatientId == id);

            if (patient == null)
            {
                return NotFound();
            }

            // Update patient details
            patient.userName = updatePatientDto.UserName;
            patient.Email = updatePatientDto.Email;
            patient.PhoneNumber = updatePatientDto.PhoneNumber;
            patient.Age = updatePatientDto.Age;
            patient.Sex = updatePatientDto.Sex;

            // Clear existing medical records
            patient.MedicalRecords.Clear();

            // Add new medical records
            if (updatePatientDto.MedicalRecords != null)
            {
                foreach (var record in updatePatientDto.MedicalRecords)
                {
                    patient.MedicalRecords.Add(new MedicalRecord
                    {
                        Diagnoses = record.Diagnoses,
                        Treatment = record.Treatment,
                        TestResults = record.TestResults
                    });
                }
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

       

        [HttpPost("medicalRecords")]
        public async Task<ActionResult<MedicalRecord>> AddMedicalRecord(MedicalRecord record)
        {
            _context.MedicalRecords.Add(record);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Patient), new { id = record.RecordId }, record);
        }
        [HttpDelete("appointment/{id}")]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            try
            {
                var appointment = await _context.Appointments.FindAsync(id);
                if (appointment == null)
                {
                    return NotFound();
                }

                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }
         
            [HttpDelete("details/{id}")]

            public async Task<IActionResult> DeleteDetails(int id)
            {
                try
                {
                    var details = await _context.Users.FindAsync(id);
                    if (details == null)
                    {
                        return NotFound();
                    }

                    _context.Users.Remove(details);
                    await _context.SaveChangesAsync();

                    return NoContent();

                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new
                    {
                        message = "An unexpected error occurred.",
                        error = ex.Message
                    });
                }

            }

    }
}

