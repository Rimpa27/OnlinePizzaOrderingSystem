import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import {  FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule, RouterOutlet,  } from '@angular/router';
import { MenuComponent } from '../menu/menu.component';
import { UserService } from '../services/user.service';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule,CommonModule,RouterOutlet,MenuComponent,ReactiveFormsModule, HttpClientModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent  {
  loginForm: FormGroup ;
  constructor(private router: Router, private userService: UserService) {
    this.loginForm = new FormGroup({
      'Email': new FormControl('', [
        Validators.required, 
        Validators.email]),
    'Password': new FormControl('',[ 
      Validators.required
    ])
    });
}
 

  onSubmit(){
    if (this.loginForm.valid) {
      console.log(this.loginForm.value);
      this.userService.login(this.loginForm.value);
 
     
     
    } else {
      // If form is invalid, do not proceed with submission
      alert("Form is invalid. Please fill in all required fields.");
    }
  }
 
}


 
 
