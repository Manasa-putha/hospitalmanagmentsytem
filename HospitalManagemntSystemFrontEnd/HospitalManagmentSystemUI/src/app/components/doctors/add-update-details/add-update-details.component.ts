import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MedicalRecord, Patient } from 'src/app/models/models';
import { PatientServiceService } from 'src/app/services/patient-service.service';
import { ToasterService } from 'src/app/services/toaster.service';
import { EditMedicalRecordDialogComponent } from '../edit-medical-record-dialog/edit-medical-record-dialog.component';
import { EditPatientDialogComponentComponent } from '../edit-patient-dialog-component/edit-patient-dialog-component.component';

@Component({
  selector: 'app-add-update-details',
  templateUrl: './add-update-details.component.html',
  styleUrls: ['./add-update-details.component.css']
})
export class AddUpdateDetailsComponent implements OnInit {

  patients: Patient[] = [];
  patientsDataSource = new MatTableDataSource<Patient>();
  patientsList: Patient[] = [];
  displayedColumns: string[] = ['id', 'name', 'email','phoneNumber','age','sex','diagnoses', 'actions'];
  selectedPatient: Patient | null = null;
  editPatientForm: FormGroup;
  editMedicalRecordForm: FormGroup;
  constructor(
    private patientService: PatientServiceService,
    private fb: FormBuilder,
    public dialog: MatDialog,
    public toaste:ToasterService,
  ) {
    this.editPatientForm = this.fb.group({
      name: [''],
      email: [''],
      phoneNumber: [''],
      age: [0],
      sex: [''],
      medicalRecords: this.fb.array([])
    });

    this.editMedicalRecordForm = this.fb.group({
      condition: [''],
      treatment: [''],
      testResults: ['']
    });
  }

  ngOnInit(): void {
    this.getPatients();
  }

  // Fetch all patients
  getPatients(): void {
    this.patientService.getPatients().subscribe((data: Patient[]) => {
      this.patients = data;
      this.patientsDataSource.data = this.patientsList;
    });
  }

  editPatient(patient: Patient): void {
    this.selectedPatient = patient;
    // this.editPatientForm.patchValue(patient);
    this.editPatientForm.patchValue({
      userName: patient.userName,
      email: patient.email,
      phoneNumber: patient.phoneNumber,
      age: patient.age,
      sex: patient.sex
    });
    const medicalRecordsArray = this.editPatientForm.get('medicalRecords') as FormArray;
    medicalRecordsArray.clear();
    patient.medicalRecords?.forEach(record => {
      medicalRecordsArray.push(this.fb.group({
        diagnoses: record.diagnoses,
        treatment: record.treatment,
        testResults: record.testResults
      }));
    });
    const dialogRef = this.dialog.open(EditPatientDialogComponentComponent, {
      width: '400px',
      data: { ...patient}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // this.onSubmitPatient();
        const index = this.patients.findIndex(p => p.patientId === result.patientId);
        if (index !== -1) {
          this.patients[index] = result; 
          this.patients = this.patients;
          this.getPatients();
        }
      }
    });
  }


  onSubmitPatient(): void {
   
  }
  
  // Add/Edit Medical Record
  onSubmitMedicalRecord(): void {
    if (this.selectedPatient) {
      const newRecord: MedicalRecord = this.editMedicalRecordForm.value;
      this.patientService.addMedicalRecord(this.selectedPatient.patientId, newRecord).subscribe(() => {
        this.getPatients();
        this.toaste.showInfo('Medical record added successfully', 'Close');
        this.dialog.closeAll();
        
      });
    }
  }
  addMedicalRecord(): void {
    // this.selectedPatient = patient;
    this.editMedicalRecordForm.reset();
    
    const dialogRef = this.dialog.open(EditMedicalRecordDialogComponent, {
      width: '400px',
      data: { form: this.editMedicalRecordForm, }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.onSubmitMedicalRecord();
      }
    });
  }
  deletePatient(id: number): void {
    this.patientService.deletePatient(id).subscribe(() => {
      this.getPatients();
      this.toaste.showSuccess('Patient deleted successfully', 'Close');
    });
  }
  addNewPatient(): void {
    const dialogRef = this.dialog.open(EditMedicalRecordDialogComponent, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
       
          this.getPatients();
          //this.toaste.showSuccess('New patient added successfully', 'Close');
        
      }
    });
  }
}
