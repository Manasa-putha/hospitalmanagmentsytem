
export interface User {
  token?: string;
  refreshToken?: string;
  refreshTokenExpiryTime?: string; 
}

export interface Patient extends User {
  patientId: number;
  userName: string;
  phoneNumber: string;
  email?: string; 
  age: number;
  sex: string;
  address?: string; 
  city?: string; 
  pinCode?: string; 
  diagnoses?: string; 
  medicalNotes?: string; 
  testResults?: string; 
  password: string; 
  appointments?: Appointment[]; 
  medicalRecords?: MedicalRecord[]; 
  createdAt: string; 
  updatedAt: string; 
}

export interface Staff extends User {
  staffId: number;
  fullName: string;
  employeeId: string;
  password: string; 
  role: string; 
  specialization?: string;  
  email?: string; 
  createdAt: string; 
  updatedAt: string; 
  doctorAvailabilities?: DoctorAvailability[]; 
  appointments?: Appointment[]; 
  medicalRecords?: MedicalRecord[]; 
}

export interface DoctorAvailability {
  availabilities: DoctorAvailability[]; 
  doctor: Doctor; 
  availabilityId: number;
  staffId: number; 
  availableDate: string; 
  timeSlot: string; 
  specialization: string;
  isAvailable?: boolean; 
  createdAt: string; 
  updatedAt: string; 
  staff: Staff; 
}
export interface Staff {
  staffId: number;
  fullName: string;
  employeeId: string;
  role: string;
  specialization?: string;
  phoneNumber: string;
  email?: string;
  createdAt: string;
  updatedAt: string;
}

export interface DoctorAvailability {
  availabilityId: number;
  availableDate: string; 
  timeSlot: string; 
  specialization: string;
  isAvailable?: boolean; 
  staff: Staff; 
}

export enum AppointmentStatus {
  Pending = 'Pending',
  Confirmed = 'Confirmed',
  Cancelled = 'Cancelled',
  Completed = 'Completed'
}

export interface Doctor {
  staffId: number;
  fullName: string;
  specialization: string;
  availabilities: DoctorAvailability[]; 
  
}
export interface DoctorDto {
  doctorId: number;
  fullName: string;
  specialization: string;
  phoneNumber?: string;
  email?: string;
}

export interface Appointment {

  appointmentId: number;
  patientId: number; 
  // doctorId: number;
  staffId: number; 
  appointmentDate: string; 
  timeSlot: string; 
  status?: string; 
  createdAt: string; 
  updatedAt: string; 
  doctor?: Doctor;
  fullName?: string;          
  specialization?: string;    
}

export interface MedicalRecord {
  recordId: number;
  patientId: number; 
  staffId: number;  
  diagnoses?: string; 
  treatment?: string; 
  testResults?: string; 
  recordDate: string; 
  createdAt: string; 
  updatedAt: string; 
}
