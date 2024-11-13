import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { PageNotFoundComponent } from './components/dashboard/page-not-found/page-not-found.component';
import { AddUpdateDetailsComponent } from './components/doctors/add-update-details/add-update-details.component';
import { MedicalhistoryComponent } from './components/doctors/medicalhistory/medicalhistory.component';
import { UpdatePteintComponent } from './components/doctors/update-pateint/update-pteint.component';
import { UserappintmentsComponent } from './components/doctors/userappintments/userappintments.component';
import { AppointmentsComponent } from './components/users/appointments/appointments.component';
import { UsersloggingComponent } from './components/users/userslogging/userslogging.component';
import { adminGuard } from './guards/admin.guard';
import { authGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: 'doctors', pathMatch: 'full' },
  {path:'doctors',component:UsersloggingComponent},
   {path:'login',component:LoginComponent},
 {path:'signup',component:RegisterComponent},
  {path:'bookAppiontment',component:AppointmentsComponent,canActivate: [authGuard]},
  {path:'booked',component:UserappintmentsComponent},
  {path:'appointments',component:MedicalhistoryComponent,canActivate: [authGuard,adminGuard]},
  {path:'update',component:UpdatePteintComponent,canActivate: [authGuard,adminGuard]},
  {path:'AddUpdate',component:AddUpdateDetailsComponent,canActivate: [authGuard,adminGuard]},
  

  { path: '**', component:PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
