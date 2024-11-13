import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-page-header',
  templateUrl: './page-header.component.html',
  styleUrls: ['./page-header.component.css']
})
export class PageHeaderComponent implements OnInit {

  loggedIn: boolean = false;
  name: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.authService.userStatus.subscribe(status => {
      this.loggedIn = status === 'loggedIn';
      if (this.loggedIn) {
        this.name = this.authService.getfullNameFromToken();
        this.checkUserType();
      } else {
        this.name = '';
        this.router.navigate(['/doctors']); 
      }
    });
    
   
    this.checkAuthenticationStatus();
  }

  private checkAuthenticationStatus() {
    this.loggedIn = this.authService.isLoggedIn();
    if (this.loggedIn) {
      this.name = this.authService.getfullNameFromToken();
      this.checkUserType();
    } else {
      this.router.navigate(['/doctors']); 
    }
  }

  private checkUserType() {
    const role = this.authService.getRoleFromToken();
    if (role === 'Doctor') {
      this.router.navigate(['/appointments']); 
    } else if (role === 'Patient') {
      this.router.navigate(['/doctors']);
    }
  }

  logout() {
    this.authService.logOut();
    this.router.navigate(['/login']);
  }
}

//   ngOnInit() {
//     this.authService.userStatus.subscribe(status => {
//       this.loggedIn = status === 'loggedIn';
//       if (this.loggedIn) {
//         this.name = this.authService.getfullNameFromToken();
//       } else {
//         this.name = '';
//       }
//     });
//     this.checkAuthenticationStatus();
//     //this.name = this.authService.getfullNameFromToken();
//   }

//   private checkAuthenticationStatus() {
//     this.loggedIn = this.authService.isLoggedIn();
//     if (this.loggedIn) {
//       this.name = this.authService.getfullNameFromToken();
//     } else {
//       this.router.navigate(['/login']);
//     }
//   }
//   logout() {
//     this.authService.logOut();
//     this.router.navigate(['/login']);
//   }
// }
