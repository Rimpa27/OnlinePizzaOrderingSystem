
import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
 
@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css'],
  imports : [ ReactiveFormsModule, CommonModule,FormsModule],
  standalone: true,
 
})
export class SignUpComponent implements OnInit {
  signupForm!: FormGroup;
  constructor(private  formBuilder: FormBuilder,private router:Router) {}
  ngOnInit(): void {
   this.signupForm = this.formBuilder.group({
    username: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      phone:['',Validators.required],
      line1: ['', Validators.required],
      line2:  ['', Validators.required],
      pincode:['',Validators.required],
      City:['',Validators.required],

   })
  }
  onSubmit(): void {
    if (this.signupForm.valid) {
      // Process signup logic here
      console.log('Registration form submitted:', this.signupForm.value);
      this.router.navigate(['/login'])
    } 
    
    else {
      // Mark all form fields as touched to display validation errors
      this.signupForm.markAllAsTouched();
    }
  }
}