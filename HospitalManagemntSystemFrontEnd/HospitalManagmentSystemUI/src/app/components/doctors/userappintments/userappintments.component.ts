import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Appointment, Doctor } from 'src/app/models/models';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-userappintments',
  templateUrl: './userappintments.component.html',
  styleUrls: ['./userappintments.component.css']
})
export class UserappintmentsComponent implements OnInit {
  doctors!: Doctor[];
  filterForm: FormGroup;
  patientFilterForm!: FormGroup;
  constructor(private fb: FormBuilder, private appointmentService:  AuthService) {
    this.filterForm = this.fb.group({
      specialization: [''],
      date: [''],
      timeSlot: ['']
    });
  }

  ngOnInit(): void {}

  onSubmit(): void {
    const filters = this.filterForm.value;
    this.appointmentService.filterAppointments(filters).subscribe();
  }

  onReset(): void {
    this.filterForm.reset();
    this.appointmentService.getAllAppointments().subscribe(); 
  }
}