import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MedicalRecord, Patient } from 'src/app/models/models';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-update-pteint',
  templateUrl: './update-pteint.component.html',
  styleUrls: ['./update-pteint.component.css']
})
export class UpdatePteintComponent  {
  patientForm: FormGroup;
  isEditMode: boolean = false;
  patientId: string | null = null;
  selectedPatient: Patient | null = null;
  medicalRecordForm!: FormGroup;
  patients: Patient[] = [];
  medicalRecords!: MedicalRecord;
  filteredPatients: Patient[] = [];
  displayedColumns: string[] = ['recordId', 'diagnoses', 'treatment', 'testResults', 'recordDate', 'actions'];
  // @ViewChild('medicalRecords') medicalRecords!: ElementRef;
  constructor(
    private fb: FormBuilder,
    private patientService: AuthService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.patientForm = this.fb.group({
      patientId: ['', Validators.required],
      name: ['', [Validators.required, Validators.minLength(2)]],
      diagnosis: ['', Validators.required],
      treatment: ['', Validators.required],
      testResults: ['', Validators.required]
    });
  }
  

  ngOnInit(): void {
    this.loadAllPatients();
    this.route.params.subscribe((params) => {
      if (params['id']) {
        this.isEditMode = true;
       // this.patientId = +params['id'];
       this.patientId = params['id'];
        
        //this.loadPatientData(this.patientId);
      }
    });
  }
  editRecord(record: MedicalRecord) {
    // Populate form with record details for editing
    this.medicalRecordForm.patchValue(record);
  }

  deleteRecord(record: MedicalRecord) {
    
    // const index = this.selectedPatient.medicalRecords.indexOf(record);
    // if (index >= 0) {
    //   this.selectedPatient.medicalRecords.splice(index, 1);
    // }
  }

  loadPatientData(id: string): void {
    this.patientService.getPatientById(id).subscribe((patient: Patient) => {
      this.patientForm.patchValue({
        patientId: patient.patientId,
        name: patient.userName,
        // diagnosis: patient.diagnosis,
        // treatment: patient.treatment,
        testResults: patient.testResults
      });
    });
  }
  scrollToMedicalRecords() {
    
    if (this.medicalRecords) {
      //this.medicalRecords.nativeElement.scrollIntoView({ behavior: 'smooth', block: 'start' });
    }
  }
  loadAllPatients(): void {
    this.patientService.getPatients().subscribe(response => {
      this.patients = response;
      this.filteredPatients = response; 
    });
  }
  // selectPatient(patient: Patient): void {
  //   this.selectedPatient = patient;
  // //this.loadPatientData();
  // }
  selectPatient(patient: Patient): void {
    this.selectedPatient = patient;
    
    // Ensure medicalRecords is an empty array if not defined
    if (!this.selectedPatient.medicalRecords) {
      this.selectedPatient.medicalRecords = [];
    }
    
    this.medicalRecordForm?.reset(); 
  }
  
  setSelectedPatient(patient: Patient): void {
    this.selectedPatient = patient;
    this.medicalRecordForm?.reset(); 
  }

  saveMedicalRecord(): void {
    // const newRecord = this.medicalRecordForm.value;

    // if (this.selectedPatient) { // Check if selectedPatient is defined
    //     // Assuming your API has an endpoint to add a medical record
    //     this.patientService.addMedicalRecord(this.selectedPatient.patientId, newRecord).subscribe(response => {
    //         // Add the new record to the selected patient's records
    //         this.selectedPatient?.medicalRecords.push(newRecord);
    //         this.medicalRecordForm.reset(); // Reset the form after saving
    //     });
    // } else {
    //     // Handle the case where selectedPatient is not defined
    //     console.error("No patient selected for updating the medical record.");
    // }
  }
  onSubmit(): void {
    if (this.patientForm.invalid) {
      return;
    }

    const patientData = this.patientForm.value;
    if (this.isEditMode) {
      this.patientService.updatePatient(this.patientId).subscribe(() => {
        this.router.navigate(['/patients']);
      });
    } else {
      this.patientService.addPatient(patientData).subscribe(() => {
        this.router.navigate(['/patients']);
      });
    }
  }
  applyFilter(searchTerm: string): void {
    searchTerm = searchTerm.toLowerCase();
    this.filteredPatients = this.patients.filter(patient =>
      patient.userName.toLowerCase().includes(searchTerm) ||
      patient.patientId.toString().includes(searchTerm)
    );
  }
  onInputChange(event: Event): void {
    const input = event.target as HTMLInputElement; 
    this.applyFilter(input.value); 
  }
  onSubmitPatient(): void{
    if (this.patientForm.invalid) {
      return;
    }

    const patientData = this.patientForm.value;
    if (this.isEditMode) {
      this.patientService.updatePatient(this.patientId).subscribe(() => {
        this.router.navigate(['/patients']);
      });
    } else {
      this.patientService.addPatient(patientData).subscribe(() => {
        this.router.navigate(['/patients']);
      });
    }
  }
  }

