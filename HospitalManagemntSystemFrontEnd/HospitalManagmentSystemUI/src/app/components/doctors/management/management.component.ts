import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Patient } from 'src/app/models/models';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-management',
  templateUrl: './management.component.html',
  styleUrls: ['./management.component.css']
})
export class ManagementComponent {
  historyFilterForm: FormGroup;
  patientFilterForm!: FormGroup;
  patients!: Patient; 
  constructor(private fb: FormBuilder, private patientService: AuthService) {
    this.historyFilterForm = this.fb.group({
      patientId: [''],
      startDate: [''],
      endDate: ['']
    });
  }

  ngOnInit(): void {}

  onSubmit(): void {
    const filters = this.historyFilterForm.value;
    this.patientService.filterPatientHistory(filters).subscribe();
  }

  onReset(): void {
    this.historyFilterForm.reset();
   // this.patientService.getAllPatientHistory().subscribe();
  }
  onPatientSubmit(): void {
    
  }

  onResetPatientFilter(): void {
    this.patientFilterForm.reset();
    
  }
}
