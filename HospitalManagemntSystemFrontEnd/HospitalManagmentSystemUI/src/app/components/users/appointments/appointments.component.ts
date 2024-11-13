import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Appointment, Doctor, DoctorAvailability, MedicalRecord } from 'src/app/models/models';
import { AuthService } from 'src/app/services/auth.service';
import { PatientServiceService } from 'src/app/services/patient-service.service';
import { ToasterService } from 'src/app/services/toaster.service';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent implements OnInit {


  appointments: Appointment[] = [];
  upcomingAppointments: Appointment[] = [];
  pastAppointments: Appointment[] = [];
  selectedDoctor: Doctor | null = null;
  appointmentDate!: string;
  appointmentTime!: string;
  doctors: Doctor[] = [];
  medicalRecords: MedicalRecord[] = [];
  loading: boolean = true;

  constructor(
    private http: HttpClient,
    private authService: AuthService,
    private apiService:PatientServiceService,
    private toaster: ToasterService
  ) {}

  ngOnInit(): void {
    const user = this.authService.getCurrentUser(); 
    this.loadAppointments(user); 
    console.log(user);
    if (user) {
      console.log(user);
      console.log(user);
      this.loadAppointments(user); 
      this.loadMedicalRecords(user); 
      this.loadDoctors();
    }
  }


  // loadAppointments(patientId: number): void {
  //   this.apiService.getAppointments(patientId).subscribe(response => {
  //     this.appointments = response;
  //     const currentDate = new Date();
  //     this.upcomingAppointments = this.appointments.filter(a => new Date(a.appointmentDate) >= currentDate);
  //     this.pastAppointments = this.appointments.filter(a => new Date(a.appointmentDate) < currentDate);
  //     this.loading = false;
  //   });
  // }
  loadAppointments(patientId: number): void {
    this.apiService.getAppointments(patientId).subscribe({
      next: (response: Appointment[]) => {
        this.appointments = response;
        const currentDate = new Date();
        this.upcomingAppointments = this.appointments.filter(a => new Date(a.appointmentDate) >= currentDate);
        this.pastAppointments = this.appointments.filter(a => new Date(a.appointmentDate) < currentDate);
        this.loading = false; 
      },
      error: (error) => {
        console.error('Error fetching appointments', error);
        this.appointments = []; 
        this.loading = false; 
      }
    });
  }
  
  getDoctorName(staffId: number): string {
    const doctor = this.doctors.find(doc => doc.staffId === staffId);
    return doctor ? doctor.fullName : 'Unknown Doctor';
  }
  
  // Load the list of available doctors
  // loadDoctors(): void {
  //   this.authService.getDoctors().subscribe(response => {
  //     this.doctors = response;
  //   });
  // }
  loadDoctors(): void {
    this.apiService.getDoctors().subscribe((availabilities: DoctorAvailability[]) => {
    
      this.doctors = availabilities.map(availability => {
        const staff = availability.staff;
        return {
          staffId: staff.staffId,
          fullName: staff.fullName,
          specialization: availability.specialization,
          availabilities: [availability] 
        };
      });
    });
  }

  loadMedicalRecords(patientId: number): void {
    this.apiService.getMedicalRecords(patientId).subscribe(response => {
      this.medicalRecords = response;
    });
  }

  bookAppointment(): void {
    if (!this.selectedDoctor || !this.appointmentDate || !this.appointmentTime) {
      this.toaster.showError('Please fill in all required fields.');
      return;
    }

    const appointmentData: Appointment = {
      appointmentId: 0,
      appointmentDate: this.appointmentDate,
      timeSlot: this.appointmentTime,
      staffId: this.selectedDoctor.staffId,
      patientId: this.authService.getCurrentUser(),
      createdAt: new Date().toISOString(),
      updatedAt: new Date().toISOString(),
    };
    console.log(appointmentData);
    this.apiService.bookAppointment(appointmentData).subscribe(() => {
      this.toaster.showSuccess('Appointment booked successfully!');
      this.loadAppointments(this.authService.getCurrentUser()); 
      this.resetForm();
    });
  }

  rebookAppointment(appointment: Appointment): void {
    this.selectedDoctor = this.doctors.find(d => d.staffId === appointment.staffId) || null;
    this.appointmentDate = appointment.appointmentDate;
    this.appointmentTime = appointment.timeSlot;
  }


  cancelAppointment(appointment: Appointment): void {
    this.apiService.cancelAppointment(appointment.appointmentId).subscribe(() => {
      this.toaster.showSuccess('Appointment canceled successfully!');
      this.loadAppointments(this.authService.getCurrentUser()); // Reload appointments after cancellation
      console.log( this.loadAppointments(this.authService.getCurrentUser()));
    });
  }


  resetForm(): void {
    this.selectedDoctor = null;
    this.appointmentDate = '';
    this.appointmentTime = '';
  }
}

