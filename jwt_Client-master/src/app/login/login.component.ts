import { Component } from '@angular/core';
import { User } from '../Models/User';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  currentuser: User = { userId: 0, userName: '', userRole: '', mobileNumber: '', email: '', profileImage: '' };

  constructor(private _service: AuthService, private router: Router) { }

  isLoggedIn: string = 'true'

  Role: string = ''
  onSubmit(form: any) {
    let loginuser = form.value;
    this._service.Login(loginuser).subscribe((res: any) => {
      if (res.status == 200) {
        localStorage.setItem('logged', this.isLoggedIn)
        sessionStorage.setItem('loginToken', res.body.token)
        console.log("token is .....")
        console.log(res.body.token)
        sessionStorage.setItem("userrole", res.body.role)
        this.Role = sessionStorage.getItem("userrole") || 'Educator';
        if (this.Role == "Educator") {
          alert("login success!");
          this.router.navigate(['edashboard'])
        }
        else{
          alert("Sorry You are not an Educator")
        }
      }
    }, (err: any) => {
      alert("There was a problem logging" + err.message);

    });
  }

}



