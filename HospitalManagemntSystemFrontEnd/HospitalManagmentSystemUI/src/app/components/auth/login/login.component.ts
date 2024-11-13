import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import ValidateForm from 'src/app/helpers/validateform';
import { AuthService } from 'src/app/services/auth.service';
import { ToasterService } from 'src/app/services/toaster.service';
import { UserstoreService } from 'src/app/services/userstore.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  public loginForm!: FormGroup;
  type: string ="password";
  isText: boolean = false;
  eyeIcon: string ='fa-eye-slash';
  // loginForm! : FormGroup;
  usernamePlaceholder: string = "Email or Phone Number";
  constructor(
    private fb:FormBuilder,
    private auth:AuthService,
    private router:Router,
    private toastService: ToasterService,
    private userStore:UserstoreService,
  
    ){ }
  ngOnInit(): void {
    this.loginForm =this.fb.group({
      // email:['',Validators.required],
      userType: ['patient', Validators.required],
      email: ['', [Validators.required, Validators.email]], 
      //username: ['', Validators.required],
      password:['',Validators.required]
    })
    
  }
 
  onUserTypeChange() {
    const userType = this.loginForm.get('userType')?.value;
    this.usernamePlaceholder = userType === 'patient' ? 'Email or Phone Number' : 'Employee ID';
    const emailControl = this.loginForm.get('email');
    if (userType === 'patient') {
      emailControl?.setValidators([Validators.required, Validators.email]);
    } else if (userType === 'staff') {
      emailControl?.setValidators([Validators.required]);
    }
  

    emailControl?.updateValueAndValidity();
  }
  
  hideShow(){
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon="fa-eye-slash";
    this.isText ? this.type ='text':this.type ="password"
  }
  
  onLogin(){
    if (this.loginForm.valid) {
        const userType = this.loginForm.value.userType; 
        let loginPayload = {...this.loginForm.value}; 

        if (userType === 'staff') {
            loginPayload = {
                EmployeeId: this.loginForm.value.email, 
                password: this.loginForm.value.password,
            };
        } else {
            loginPayload = {
                email: this.loginForm.value.email, // Email input
                password: this.loginForm.value.password,
            };
        }

        this.auth.login(loginPayload, userType).subscribe({
            next: (res) => {
                console.log('Access Token:', res.token);
                console.log('Refresh Token:', res.refreshToken);
                console.log(res.message);
                this.loginForm.reset();
           this.auth.storeToken(res.token);
           this.auth.storeRefreshToken(res.refreshToken);
           this.auth.loadCurrentUser(); 
           const tokenPayload = this.auth.decodedToken();
          this.userStore.setFullNameForStore(tokenPayload.name);
          this.userStore.setRoleForStore(tokenPayload.role);
       sessionStorage.setItem('key', this.loginForm.value.email);
       console.log(tokenPayload.role);
        this.loginForm.reset();
        console.log(tokenPayload.role);
        if(tokenPayload.role === 'Doctor'){
          localStorage.setItem('role','Doctor');
          console.log(tokenPayload.role);
         // this.service.setAdminValue(true);
         this.auth.userStatus.next("loggedIn");
          this.router.navigateByUrl('appointments');
        }else{
          localStorage.setItem('role','Patient');
         //  this.service.setAdminValue(false);
         this.auth.userStatus.next("loggedIn");
         this.router.navigateByUrl('doctors');
      
        }
      
              this.toastService.showSuccess("login successfull");
               //  this.router.navigate(['home'])
            },
          //   error: (err) => {
          //     this.toastService.showError("ERROR","Something when wrong!");
          //     console.log(err);
          //   },
          // });
          //   },
            error: (err) => {
                this.toastService.showError("ERROR", "Invalid credentials");
                console.log(err);
            },
        });
    } else {
        ValidateForm.validateAllFormFields(this.loginForm);
        this.toastService.showWarning("Your form is invalid");
    }
}

  
  get Emails() : FormControl{
    return this.loginForm.get("email") as FormControl;
  }
  
  get Passs(): FormControl{
    return this.loginForm.get("passs") as FormControl;
  }
    checkAdminStatus(email:string):boolean{
      return true;
      }
}
