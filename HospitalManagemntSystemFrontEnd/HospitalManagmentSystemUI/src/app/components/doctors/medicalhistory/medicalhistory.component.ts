import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { Appointment, Doctor, DoctorAvailability } from 'src/app/models/models';
import { AuthService } from 'src/app/services/auth.service';
import { PatientServiceService } from 'src/app/services/patient-service.service';
import { ToasterService } from 'src/app/services/toaster.service';

@Component({
  selector: 'app-medicalhistory',
  templateUrl: './medicalhistory.component.html',
  styleUrls: ['./medicalhistory.component.css']
})
export class MedicalhistoryComponent {
  timeInput: string = '';
  appointments: Appointment[] = [];
  displayedColumns: string[] = ['appointmentDate', 'timeSlot', 'doctor', 'specialization','patientId','actions'];
  selectedAppointment: Appointment | null = null; 
  editAppointmentForm!: FormGroup;
  doctors: DoctorAvailability[] = [];
  specialties: string[] = ['Cardiologist', 'Neurologist', 'General Practitioner']; 

  loading = true;
  isAdmin = true;
  filterDate!: Date;
  filterTime: string = '';
  filterDoctor: string = '';
  filterSpecialty: string = '';
  filteredAppointments: Appointment[] = [];
  selectedDate!: Date;
  selectedTime!: string;
  selectedDoctor!: string;
  selectedSpecialty!: string;

  constructor(private appointmentService: AuthService,private fb: FormBuilder,private patientservice:PatientServiceService,private toaste:ToasterService) {
    this.editAppointmentForm = this.fb.group({
      appointmentDate: [''],
      timeSlot: ['']
    });
  }

  ngOnInit(): void {
    this.loadAppointments();
    this.loadDoctors();
    console.log( this.loadDoctors());
    this.filteredAppointments = [...this.appointments]; 
    
   // this.loading = false; 
  }

  loadAppointments(): void {
   
    this.appointmentService.getAllAppointments().subscribe((data: Appointment[]) => {
      this.appointments = data;
      console.log(this.appointments);
    
     
      this.filteredAppointments = [...this.appointments];
    });
  }
  editAppointment(appointment: Appointment): void {
    this.selectedAppointment = appointment;
    this.editAppointmentForm.patchValue({
      appointmentDate: appointment.appointmentDate,
      timeSlot: appointment.timeSlot
    });
  }
  loadDoctors(): void {
    // this.appointmentService.getDoctors().subscribe((data: Doctor[]) => {
    //   this.doctors = data;
    // });
    this.appointmentService.getDoctors().subscribe(
      (data: DoctorAvailability[]) => {
        this.doctors = data;
        console.log(data);
      },
      (error) => {
        console.error('Error fetching doctor availability', error);
      }
    );
  }
  

filterByDate(date: Date) {
   this.filterDate = date;
  //this.filterDate = date ? date.toDateString() : '';
  this.applyFilters();
}

filterByTime(time: string) {
  this.filterTime = time;
  this.applyFilters();
}
filterByDoctor(doctor: string) {
  console.log('Selected doctor:', doctor); 
  this.filterDoctor = doctor;
  this.applyFilters();
}


filterBySpecialty(specialty: string) {
  this.filterSpecialty = specialty;
  this.applyFilters();
}

deleteAppointment(id: number): void {
  this.patientservice.cancelAppointment(id).subscribe(() => {
    this.loadAppointments();
    this.toaste.showSuccess('Patient deleted successfully', 'Close');
  });
}


  viewDetails(appointment: Appointment) {
  
    console.log('Viewing details for:', appointment);
  }


applyFilters() {
  this.filteredAppointments = this.appointments.filter(appointment => {
    const matchesDate = !this.filterDate || 
      new Date(appointment.appointmentDate).toDateString() === new Date(this.filterDate).toDateString();

    const matchesTime = !this.filterTime || appointment.timeSlot === this.filterTime;


      const matchesDoctor = !this.filterDoctor || 
      (appointment.fullName && appointment.fullName.toLowerCase().includes(this.filterDoctor.toLowerCase()));
    const matchesSpecialty = !this.filterSpecialty || 
      (appointment.specialization && appointment.specialization.toLowerCase().includes(this.filterSpecialty.toLowerCase()));
      console.log('Appointment:', appointment, 'Matches:', matchesDate, matchesTime, matchesDoctor, matchesSpecialty);

    return matchesDate && matchesTime && matchesDoctor && matchesSpecialty;
  });
}

onSubmit(): void {
  if (this.editAppointmentForm.valid) {
    const updatedAppointment = {
      ...this.selectedAppointment,
      ...this.editAppointmentForm.value
    };
    
  }
}



}