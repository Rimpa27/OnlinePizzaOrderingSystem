import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { HttpService } from '../http.service';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule,RouterLink,HttpClientModule],
  providers:[HttpService],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;
  constructor(private router:Router,private fb: FormBuilder,private httpservice:HttpService) 
  { 
    this.loginForm = this.fb.group({
    Email: ['',Validators.required],
    Password: ['', Validators.required] });
  }
  onSubmit() {
    const Email = this.loginForm.value.Email!;
    const Password = this.loginForm.value.Password!;
    this.httpservice.login(Email,Password).subscribe((result) => {
      console.log(result);
      localStorage.setItem('token', result.token);
      alert("Login Successful")
      this.router.navigate(['/homepage'])
    });
}
}
