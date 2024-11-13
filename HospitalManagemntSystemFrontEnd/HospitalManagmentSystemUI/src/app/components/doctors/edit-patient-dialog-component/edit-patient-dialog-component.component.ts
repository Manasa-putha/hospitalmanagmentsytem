import { Component, Inject, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PatientServiceService } from 'src/app/services/patient-service.service';
import { ToasterService } from 'src/app/services/toaster.service';

@Component({
  selector: 'app-edit-patient-dialog-component',
  templateUrl: './edit-patient-dialog-component.component.html',
  styleUrls: ['./edit-patient-dialog-component.component.css']
})
export class EditPatientDialogComponentComponent  implements OnInit {
  patientForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<EditPatientDialogComponentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private patientservice:PatientServiceService,
    private toaster:ToasterService
  ) {
    this.patientForm = this.fb.group({
      patientId: [data.patientId || 0],
      userName: [data.userName || '', Validators.required],
      email: [data.email || '', [Validators.required, Validators.email]],
      phoneNumber: [data.phoneNumber || ''],
      age: [data.age || 0],
      sex: [data.sex || ''],
      medicalRecords: this.fb.array(data.medicalRecords.map((record: { diagnoses: any; treatment: any; testResults: any; }) => this.fb.group({
        diagnoses: [record.diagnoses],
        treatment: [record.treatment],
        testResults: [record.testResults]
      })))
    });
  }
  ngOnInit(): void {}
  get medicalRecords(): FormArray {
    return this.patientForm.get('medicalRecords') as FormArray;
  }
  onSave(): void {
    // if (this.patientForm.valid) {
    //   this.dialogRef.close(this.patientForm.value);
    // }
    if (this.patientForm.valid) {
      this.patientservice.updatePatient(this.patientForm.value.patientId, this.patientForm.value)
        .subscribe(
          response => {
            console.log('Patient updated successfully', response);
            this.toaster.showSuccess('Patient updated successfully!', 'Success');
            this.dialogRef.close(response);
            this.toaster.showSuccess(response);
          },
          error => {
            console.error('Error updating patient', error);
            this.toaster.showError(error);
          }
        );
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }
  addMedicalRecord(): void {
    const newRecord = this.fb.group({
      diagnoses: [''],
      treatment: [''],
      testResults: ['']
    });
    this.medicalRecords.push(newRecord);
  }
  
}
