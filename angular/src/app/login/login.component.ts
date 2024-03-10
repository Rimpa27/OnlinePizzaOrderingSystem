import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule,  } from '@angular/router';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule,CommonModule,ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  constructor(private router: Router, private formBuilder:FormBuilder) { }
 
  ngOnInit(): void {
      this.loginForm = this.formBuilder.group({
        email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      })
  }
 
  // navigateDashboard() {
  //   this.router.navigate(['/dashboard']); // Replace 'destination' with the route you want to navigate to
  // }
  onSubmit(): void {
    if (this.loginForm.valid) {
      // Process signup logic here
      console.log('Login form submitted:', this.loginForm.value);
     
    } else {
      // Mark all form fields as touched to display validation errors
      this.loginForm.markAllAsTouched();
    }
  }
 
}


 
 
