import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
export interface NavigationItem  {
  value: string;
  link: string;
}
@Component({
  selector: 'app-page-side-nav',
  templateUrl: './page-side-nav.component.html',
  styleUrls: ['./page-side-nav.component.css']
})
export class PageSideNavComponent implements OnInit {
  panelName: string = '';
  navItems: NavigationItem[] = [];
  loggedIn: boolean = false;
  name: string = '';
  constructor(private authService: AuthService, private router: Router) {
  }
  ngOnInit() {
    this.authService.userStatus.subscribe(status => {
      this.loggedIn = status === 'loggedIn';
      if (this.loggedIn) {
        this.name = this.authService.getfullNameFromToken();
      } else {
        this.name = '';
      }
    });
    this.checkAuthenticationStatus();

    this.authService.userStatus.subscribe(status => {
      this.updateNavigation(status);
    });
  }

  private checkAuthenticationStatus() {
    if (this.authService.isLoggedIn()) {
      const role = localStorage.getItem('role');
      this.updateNavigation('loggedIn');
    } else {
      this.updateNavigation('loggedOff');
    }
  }

  private updateNavigation(status: string) {
    if (status === 'loggedIn') {
      const role = localStorage.getItem('role');
      console.log(role);
      if (role === 'Patient') {
        this.panelName = 'Patient Panel';
        this.navItems = [
         
          { value: 'Book Appointment', link: '/doctors' },
          { value: 'Appointement Details', link: '/bookAppiontment' },
        //  { value: 'login', link: '/login' },
          // { value: 'Register', link: '/signup' },
         
   
        ];
      } else if (role === 'Doctor') {
        this.panelName = 'Hospital Staff Panel';
        this.navItems = [
          { value: 'View Appointments', link: '/appointments' },
          {value:'AddUpdateDetails',link:'/AddUpdate'},
          { value: 'Patient Details', link: '/update' },
         
        ];
      }
    } else if (status === 'loggedOff') {
      this.panelName = 'Auth Panel';
      this.router.navigateByUrl('/login');
      this.navItems = [];
    }
}

}
