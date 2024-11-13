import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { Appointment, DoctorAvailability, MedicalRecord, Patient, User } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class PatientServiceService {

 
 
  private baseUrl1: string = 'https://localhost:7275/api/Staff/';
  private baseUrl2: string = 'https://localhost:7275/api/Patient/';

  private userPayload:any;
  private jwtHelper = new JwtHelperService();
  constructor(
    // private jwt: JwtHelperService,
    private http:HttpClient,
     private router: Router) { 
      // this.userPayload = this.decodedToken();
      // this.userStatus.next(this.getRoleFromToken());
  }
  
  
  getDoctors(): Observable<DoctorAvailability[]> {
    return this.http.get<DoctorAvailability[]>(`${this.baseUrl1}doctors`); // Adjust the endpoint as necessary
  }
  
 

cancelAppointment(id: any): Observable<any> {
  return this.http.delete(`${this.baseUrl1}appointment/${id}`);
}
bookAppointment(appointment: Appointment): Observable<Appointment> {
  return this.http.post<Appointment>(`${this.baseUrl1}appointments`, appointment);
}


getAppointments(patientId: number): Observable<Appointment[]> {
  return this.http.get<Appointment[]>(`${this.baseUrl1}appointments/patient/${patientId}`);
}


getMedicalRecords(patientId: number): Observable<MedicalRecord[]> {
  return this.http.get<MedicalRecord[]>(`${this.baseUrl1}medicalrecords/patient/${patientId}`);
}
addMedicalRecord(patientId: number, record: MedicalRecord): Observable<any> {
  return this.http.post(this.baseUrl2+`/patients/${patientId}/records`, record); 
}

getPreviousAppointments(patientId: number): Observable<Appointment[]> {
  return this.http.get<Appointment[]>(`${this.baseUrl1}appointments/patient/${patientId}/previous`);
}


getUpcomingAppointments(patientId: number): Observable<Appointment[]> {
  return this.http.get<Appointment[]>(`${this.baseUrl1}appointments/patient/${patientId}/upcoming`);
}
//Method to get appointments based on filters
  // getAppointments(filters: any): Observable<Appointment[]> {
  //   return this.http.post<Appointment[]>('/api/appointments/filter', filters);
  // }


  getPatients(): Observable<Patient[]> {
    return this.http.get<Patient[]>(this.baseUrl2+'patients/filter');
  }
 
  // Method to update patient details
  // updatePatient(patientId: number,patientData: any): Observable<any> {
  //   return this.http.put(this.baseUrl1+'patients/${patientId}', patientData);
  // }
updatePatient(patientId: number, patientData: any): Observable<any> {
  return this.http.put(`${this.baseUrl1}patients/${patientId}`, patientData);
}

  // getAppointments(page: number, size: number): Observable<any> {
  //   return this.http.get<any>(`${this.baseUrl}?page=${page}&size=${size}`);
  // }

  filterAppointments(filterValues: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl1}filter`, filterValues);
  }
  addPatient(patientData: any): Observable<any> {
    return this.http.post<any>(this.baseUrl1+"patients", patientData);
  }

  // updatePatient(patientId: string, patientData: any): Observable<any> {
  //   return this.http.put<any>(`${this.baseUrl}/${patientId}`, patientData);
  // }

  getPatientById(patientId: string): Observable<any> {
    return this.http.get<any>(`${this.baseUrl1}${patientId}`);
  }

  filterPatientHistory(filterValues: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl1}history/filter`, filterValues);
  }
  getAllAppointments(): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(`${this.baseUrl1}appointments`);
  }
  deletePatient(id:any):Observable<any>{
    return this.http.delete(`${this.baseUrl1}details/${id}`);
  }
 
}
