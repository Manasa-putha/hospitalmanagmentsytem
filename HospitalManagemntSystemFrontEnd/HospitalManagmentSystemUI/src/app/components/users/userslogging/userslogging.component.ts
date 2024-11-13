import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Appointment, Doctor, DoctorAvailability, Patient, Staff } from 'src/app/models/models';
import { AuthService } from 'src/app/services/auth.service';
import { PatientServiceService } from 'src/app/services/patient-service.service';
import { ToasterService } from 'src/app/services/toaster.service';

@Component({
  selector: 'app-userslogging',
  templateUrl: './userslogging.component.html',
  styleUrls: ['./userslogging.component.css']
})
export class UsersloggingComponent implements OnInit{

    selectedTime: string = '';
    filteredDoctors: DoctorAvailability[] = [];
    user: any = null; 
    availabilities: DoctorAvailability[] = [];
    selectedSpecialization: string = '';
    selectedDate: Date | null = null;
    specializations: string[] = ['Cardiologist', 'Neurologist', 'General Practitioner'];
    selectedSlot!: DoctorAvailability;
    doctorName: string = '';
    constructor(
      private apiService: AuthService,
      private patientService: PatientServiceService,
      private snackBar: MatSnackBar,
      private toaster: ToasterService,
      private router: Router,
    ) {}
  
    ngOnInit(): void {
      this.getDoctorAvailability();
      this.user = this.apiService.getCurrentUser(); 
    }
  
    getDoctorAvailability(): void {
      this.apiService.getDoctors().subscribe(
        (data: DoctorAvailability[]) => {
          this.availabilities = data;
          this.filteredDoctors = data;
        },
        (error) => {
          console.error('Error fetching doctor availability', error);
        }
      );
    }
  
    filterDoctors(): void {
      this.filteredDoctors = this.availabilities.filter((availability) => {
        const matchesSpecialization = !this.selectedSpecialization || availability.specialization === this.selectedSpecialization;
        const matchesDate = !this.selectedDate || new Date(availability.availableDate).toDateString() === this.selectedDate?.toDateString();
        const matchesTime = !this.selectedTime || availability.timeSlot.includes(this.selectedTime);
        const matchesDoctorName = !this.doctorName || availability.staff.fullName.toLowerCase().includes(this.doctorName.toLowerCase()); 
        return matchesSpecialization && matchesDate && matchesTime && matchesDoctorName;
      });
    }
  
    bookAppointment(availability: DoctorAvailability | null): void {
      if (!availability) {
        this.snackBar.open('Please select a time slot to book an appointment.', 'Close', { duration: 3000 });
        return;
      }
  
      // if (!this.user || !this.user.patientId) {
      //   this.toaster.showInfo('Please log in to book an appointment.', 'Close');
      //   this.apiService.getCurrentUser()
      //   this.router.navigate(['/login']); // redirect to login page
      //   return;
      // }
      const isLoggedIn = this.apiService.isLoggedIn();
  
  if (!isLoggedIn) {
    this.toaster.showInfo('Please log in to book an appointment.', 'Info');
    sessionStorage.setItem('targetRoute', '/bookAppiontment');
    this.router.navigate(['/login']);
    return;
  // } else {
   
  //   this.router.navigate(['/bookAppiontment']);
    
  }
  this.router.navigate(['/bookAppiontment']).then(() => {
  
      const appointment: Appointment = {
        appointmentId: 0,
       // patientId: this.user.patientId,
        patientId: this.apiService.getCurrentUser() || 0,
        staffId: availability.staff.staffId,
        appointmentDate: availability.availableDate,
        timeSlot: availability.timeSlot,
        createdAt: new Date().toISOString(),
        updatedAt: new Date().toISOString(),
       // doctorId: availability.doctorId
      };
  
      this.apiService.bookAppointment(appointment).subscribe({
        next: () => {
          this.toaster.showSuccess('Appointment booked successfully!', 'success');
          this.getDoctorAvailability(); 
        },
        error: () => {
          this.toaster.showError('Failed to book appointment. Please try again.', 'Close',);
        }
      });
    });
    }
  
    rebookAppointment(appointment: Appointment): void {
     // this.selectedSlot = this.availabilities.find(a => a.staff.staffId === appointment.staffId && a.timeSlot === appointment.timeSlot);
      if (this.selectedSlot) {
        this.bookAppointment(this.selectedSlot);
      }
    }
  
    getDoctorCount(): number {
      return this.filteredDoctors.length;
    }
  }