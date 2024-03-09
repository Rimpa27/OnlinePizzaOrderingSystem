import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule, FormsModule],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.css'
})
export class SignUpComponent implements OnInit {

  signupForm!: FormGroup;
  constructor(private  formBuilder: FormBuilder) {}
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
      gender:['',Validators.required]
 
   })
  }
  // onSubmit(): void {
  //   if (this.signupForm.valid) {
  //     // Process registration logic here
  //     console.log('Registration form submitted:', this.signupForm.value);
  //   } else {
  //     // Mark all form fields as touched to display validation errors
  //     this.signupForm.markAllAsTouched();
  //   }
  // }
  onSubmit(){
    alert("successful");
  }
}
