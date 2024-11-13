import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, catchError, Observable, throwError } from 'rxjs';
import { Appointment, Doctor, DoctorAvailability, DoctorDto, MedicalRecord, Patient, User } from '../models/models';
import { TokenApiModel } from '../models/token-api.model';
import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
 

 
  private baseUrl: string = 'https://localhost:7275/api/Auth/';
  private baseUrl1: string = 'https://localhost:7275/api/Staff/';
  private baseUrl2: string = 'https://localhost:7275/api/Patient/';
 //  userStatus: Subject<string> = new Subject();
  userStatus: BehaviorSubject<string> = new BehaviorSubject<string>(this.getUserStatus());
  private userSubject: BehaviorSubject<User | null> = new BehaviorSubject<User | null>(this.getCurrentUserFromLocalStorage());

  public currentUser = this.userStatus.asObservable();
  private userPayload:any;
  private jwtHelper = new JwtHelperService();
  constructor(
    // private jwt: JwtHelperService,
    private http:HttpClient,
     private router: Router) { 
      this.userPayload = this.decodedToken();
      this.userStatus.next(this.getRoleFromToken());
  }
  
  private getCurrentUserFromLocalStorage(): User | null {
    const userJson = localStorage.getItem('nameid');
    return userJson ? JSON.parse(userJson) : null;
  }
  private getUserStatus(): string {
    return localStorage.getItem('role') || 'loggedOff';
  }
  signUp(userobj:any): Observable<any>{
    return this.http.post<any>(`${this.baseUrl}register`,userobj)
  }
  
  getDoctors(): Observable<DoctorAvailability[]> {
    return this.http.get<DoctorAvailability[]>(`${this.baseUrl1}doctors`); // Adjust the endpoint as necessary
  }

  login(userObj: any, userType: string): Observable<any> {
    const url = userType === 'staff' ? `${this.baseUrl}login/staff` : `${this.baseUrl}login/patient`;
    return this.http.post<any>(url, userObj);
  }

  
  logOut() {
    // localStorage.removeItem('access_token');
    // // this.userInfo = null;
    // this.userStatus.next('loggedOff');
    // this.userStateService.updateTokens(0);
    this.userStatus.next('loggedOff');
    localStorage.clear();
    this.userStatus.next('loggedOff');
    this.router.navigate(['login'])
  }

  // signOut(){
  //   localStorage.clear();
  //   this.userStatus.next('loggedOff');
  //   this.router.navigate(['login'])
  // }
  

  storeToken(tokenValue: string){
    localStorage.setItem('token', tokenValue)
  }
  storeRefreshToken(tokenValue: string){
    localStorage.setItem('refreshToken', tokenValue)
  }

  getToken(){
    return localStorage.getItem('token')
  }
  getRefreshToken(){
    return localStorage.getItem('refreshToken')
  }

  isLoggedIn(): boolean {
    const token = this.getToken();
    if (token) {
      // Check if the token is expired
      return !this.jwtHelper.isTokenExpired(token);
    }
    return false;
  }

  decodedToken(){
    const jwtHelper = new JwtHelperService();
    const token = this.getToken()!;
    console.log(jwtHelper.decodeToken(token))
    return jwtHelper.decodeToken(token)
  }

  getfullNameFromToken(){
    if(this.userPayload)
    return this.userPayload.name;
  }

  getRoleFromToken(){
    if(this.userPayload)
    return this.userPayload.role;
  }

  renewToken(tokenApi : TokenApiModel){
    return this.http.post<any>(`${this.baseUrl}refresh`, tokenApi)
  }

 getCurrentUserId(): number {
  const tokenPayload = this.decodedToken();
  return tokenPayload ? parseInt(tokenPayload.nameid, 10) : 0;
}
loadCurrentUser() {
  const user = JSON.parse(localStorage.getItem('nameid') || 'null');
  if (user) {
    this.userStatus.next(user);
  }
}
// getCurrentUser(): User {
//   const user = JSON.parse(localStorage.getItem('nameid') || 'null');
//   console.log(user);
//   return user ? user : null;
// }
getCurrentUser(){
  if(this.userPayload)
  return this.userPayload.nameid;
}

getCurrentUsers(): number {
  const tokenPayload = this.decodedToken();
  return tokenPayload ? parseInt(tokenPayload.role) : 0;
}

private handleError(error: HttpErrorResponse) {
  // Handle the error based on your application's needs`
  console.error('An error occurred:', error.message);
  return throwError('Something bad happened; please try again later.');
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


getPreviousAppointments(patientId: number): Observable<Appointment[]> {
  return this.http.get<Appointment[]>(`${this.baseUrl1}appointments/patient/${patientId}/previous`);
}


getUpcomingAppointments(patientId: number): Observable<Appointment[]> {
  return this.http.get<Appointment[]>(`${this.baseUrl1}appointments/patient/${patientId}/upcoming`);
}

  getPatients(): Observable<Patient[]> {
    return this.http.get<Patient[]>(this.baseUrl2+'patients/filter');
  }
 
 
  updatePatient(patientData: any): Observable<any> {
    return this.http.put(this.baseUrl1+'patients/update', patientData);
  }
 

  filterAppointments(filterValues: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl1}filter`, filterValues);
  }
  addPatient(patientData: any): Observable<any> {
    return this.http.post<any>(this.baseUrl1, patientData);
  }

  getPatientById(patientId: string): Observable<any> {
    return this.http.get<any>(`${this.baseUrl1}${patientId}`);
  }

  filterPatientHistory(filterValues: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl1}history/filter`, filterValues);
  }
  getAllAppointments(): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(`${this.baseUrl1}appointments`);
  }
}
