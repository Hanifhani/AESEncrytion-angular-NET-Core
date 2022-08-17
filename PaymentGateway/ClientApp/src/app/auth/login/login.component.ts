import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthserviceService } from '../../../services/authservice.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  formModel = {
    UserName: '',
    Password: '',
  };
  loginError: string;

  constructor(private router: Router, private authService: AuthserviceService) { this.loginError = "" }



  ngOnInit(): void {
  }
  onSubmit(form: NgForm) {
    this.authService.login(form.value).subscribe(x => {

      if (x) {
        localStorage.setItem("auth", "somesecret");
        this.router.navigate(['/']);
      }
      this.loginError = "Username or password is incorrect";
    },
      error => {

      })
    
  }
}
