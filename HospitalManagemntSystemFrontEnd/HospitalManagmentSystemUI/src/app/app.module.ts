import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { BrowserAnimationsModule, provideAnimations } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { provideToastr, ToastrModule } from 'ngx-toastr';
import { TokenInterceptor } from './Interceptors/token.interceptor';
import { PageFooterComponent } from './components/dashboard/page-footer/page-footer.component';
import { PageHeaderComponent } from './components/dashboard/page-header/page-header.component';
import { PageNotFoundComponent } from './components/dashboard/page-not-found/page-not-found.component';
import { PageSideNavComponent } from './components/dashboard/page-side-nav/page-side-nav.component';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { UsersloggingComponent } from './components/users/userslogging/userslogging.component';
import { AppointmentsComponent } from './components/users/appointments/appointments.component';
import { UserappintmentsComponent } from './components/doctors/userappintments/userappintments.component';
import { ManagementComponent } from './components/doctors/management/management.component';
import { MedicalhistoryComponent } from './components/doctors/medicalhistory/medicalhistory.component';
import { UpdatePteintComponent } from './components/doctors/update-pateint/update-pteint.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { AddUpdateDetailsComponent } from './components/doctors/add-update-details/add-update-details.component';
import { EditPatientDialogComponentComponent } from './components/doctors/edit-patient-dialog-component/edit-patient-dialog-component.component';
import { EditMedicalRecordDialogComponent } from './components/doctors/edit-medical-record-dialog/edit-medical-record-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    PageFooterComponent,
    PageHeaderComponent,
    PageNotFoundComponent,
    PageSideNavComponent,
    LoginComponent,
    RegisterComponent,
    UsersloggingComponent,
    AppointmentsComponent,
    UserappintmentsComponent,
    ManagementComponent,
    MedicalhistoryComponent,
    UpdatePteintComponent,
    AddUpdateDetailsComponent,
    EditPatientDialogComponentComponent,
    EditMedicalRecordDialogComponent,
   
  ],
  imports: [
    BrowserModule,
    FormsModule, 
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    MaterialModule,
    ReactiveFormsModule, 
    HttpClientModule,
    ToastrModule.forRoot({ positionClass: 'inline' }),
    MatExpansionModule,
    MatTableModule,
    MatInputModule, 
    MatFormFieldModule, 
    MatButtonModule,
  ],
  providers: [provideAnimations(), 

    provideToastr({
      timeOut: 5000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
    }),{
    provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptor,
    multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
