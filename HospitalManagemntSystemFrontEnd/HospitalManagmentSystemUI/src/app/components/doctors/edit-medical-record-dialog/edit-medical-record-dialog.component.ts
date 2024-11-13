import { Component, Inject, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PatientServiceService } from 'src/app/services/patient-service.service';
import { ToasterService } from 'src/app/services/toaster.service';

@Component({
  selector: 'app-edit-medical-record-dialog',
  templateUrl: './edit-medical-record-dialog.component.html',
  styleUrls: ['./edit-medical-record-dialog.component.css']
})
export class EditMedicalRecordDialogComponent implements OnInit {

  patientForm!: FormGroup;
    medicalRecordForm: FormGroup;
  
    constructor(
      public dialogRef: MatDialogRef<EditMedicalRecordDialogComponent>,
      @Inject(MAT_DIALOG_DATA) public data: any,
      private fb: FormBuilder,
      private patientService: PatientServiceService, 
      private toastr: ToasterService 
    ) {
      this.medicalRecordForm = this.fb.group({
        userName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['',Validators.required],
      age: ['', [Validators.required, Validators.min(1)]],
      sex: ['',[Validators.required]],
      medicalRecords: this.fb.array([]) 
      });
    }
  
    ngOnInit(): void {
      if (this.data?.medicalRecords) {
        this.data.medicalRecords.forEach((record: any) => {
          this.addMedicalRecord(record);
        });
      }
    }
    get medicalRecords(): FormArray {
      return this.medicalRecordForm.get('medicalRecords') as FormArray;
    }
    
    onSave(): void {
      if (this.medicalRecordForm.valid) {
        const patientData = this.medicalRecordForm.value;
        
        this.patientService.addPatient(patientData).subscribe(
          (response) => {
            this.toastr.showSuccess('Patient added successfully!', 'Success');
            this.dialogRef.close(response); 
          },
          (error) => {
            this.toastr.showError('Failed to add patient. Try again.', 'Error');
            console.error(error); 
          }
        );
      } else {
        this.toastr.showInfo('Please fill all required fields.', 'Form Incomplete');
      }
    }
  
    onSubmit(): void {
      if (this.medicalRecordForm.valid) {
        this.dialogRef.close(this.medicalRecordForm.value);
      }
    }
    onCancel(): void {
      this.dialogRef.close();
    }
   
    addMedicalRecord(record?: any): void {
      const medicalRecordGroup = this.fb.group({
        diagnoses: [record?.diagnoses || '', Validators.required],
        treatment: [record?.treatment || ''],
        testResults: [record?.testResults || '']
      });
      this.medicalRecords.push(medicalRecordGroup);
    }
    removeMedicalRecord(index: number): void {
      this.medicalRecords.removeAt(index);
    }
    
  }
  

