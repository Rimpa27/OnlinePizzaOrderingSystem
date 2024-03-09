import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormsModule, NgForm, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';

import { Directive, Input } from '@angular/core';
import { NG_VALIDATORS, Validator, AbstractControl, ValidationErrors, FormGroup } from '@angular/forms';

import { finalize, fromEvent } from 'rxjs';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [FormsModule, CommonModule,HttpClientModule,ReactiveFormsModule,BrowserModule],
 
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent implements OnInit {
  signupForm!: FormGroup;

  constructor(private formBuilder: FormBuilder,private router: Router) { }
  ngOnInit(): void {
    this.signupForm = this.formBuilder.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      phone:['',Validators.required],
      line1: ['', Validators.required],
      line2: '',
      pincode:['',Validators.required],
      City:['',Validators.required],
      gender:['',Validators.required]
 
    });
  }
  onSubmit(): void {
    if (this.signupForm.valid) {
      // Process registration logic here
      console.log('Registration form submitted:', this.signupForm.value);
    } else {
      // Mark all form fields as touched to display validation errors
      this.signupForm.markAllAsTouched();
    }
  }
  // router: any;
  
  // constructor(private formBuilder: FormBuilder) { }
  // // formBuilder = inject(FormBuilder);
  // // // userService = inject(UserService);
  // // router = inject(Router);
  // // route = inject(ActivatedRoute);
  // ngOnInit(): void {
  //   this.signupForm = this.formBuilder.group({
  //     name: ['', Validators.required],
  //     email: ['', [Validators.required, Validators.email]],
  //     password: ['', [Validators.required, Validators.pattern(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/)]],
  //     phone: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]],
  //     addressLine1: [''],
  //     addressLine2: [''],
  //     city: [''],
  //     country: [''],
  //     pincode: ['']
  //   });
  // // ngOnInit(): void {
  // //   this.signupForm = this.formBuilder.group({
  // //     userName: ['', Validators.required], // UserName field with required validation
  // //     userEmail: ['', [Validators.required, Validators.email]], // UserEmail field with required and email validation
  // //     password: ['', [Validators.required, Validators.minLength(6)]], // Password field with required and min length 6 validation
  // //     phone: ['', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]] // Phone field with required and pattern validation for a 10-digit Indian phone number
  // //   });
  // }
 
  // onSubmit(signupForm:any){
 
  //   // this.userService.signup(signupForm.value).subscribe((response:any)=>{
  //   //   console.log(response);
  //   // });
  // }
 
 
 
  navigateLogin(): void {
    this.router.navigate(['/login']);
  }
}


// export class RegistrationComponent implements OnInit {
//   registrationForm!: FormGroup ;
//   constructor(private formBuilder: FormBuilder) { }
//   ngOnInit(): void {
//     this.registrationForm = this.formBuilder.group({
//       username: ['', Validators.required],
//       email: ['', [Validators.required, Validators.email]],
//       password: ['', Validators.required],
//       phone:['',Validators.required],
//       line1: ['', Validators.required],
//       line2: '',
//       pincode:['',Validators.required],
//       City:['',Validators.required],
//       gender:['',Validators.required]
 
//     });
//   }
//   onSubmit(): void {
//     if (this.registrationForm.valid) {
//       // Process registration logic here
//       console.log('Registration form submitted:', this.registrationForm.value);
//     } else {
//       // Mark all form fields as touched to display validation errors
//       this.registrationForm.markAllAsTouched();
//     }
//   }
// }
 
 
// // @Component({
// //   selector: 'app-signup',
// //   standalone: true,
// //   imports: [FormsModule,CommonModule,RouterOutlet,HomeComponent],
// //   providers : [UserService],
// //   templateUrl: './signup.component.html',
// //   styleUrl: './signup.component.css'
// // })


 