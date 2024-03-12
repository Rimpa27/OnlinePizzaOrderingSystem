
// import { CommonModule } from '@angular/common';
// import { HttpClient, HttpClientModule } from '@angular/common/http';
// import { Component, OnInit } from '@angular/core';
// import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
// import { Route, Router, RouterOutlet } from '@angular/router';
// import { UserService } from '../services/user.service';
// import { IAddress } from '../interface/signup.interface';
 
// @Component({
//   selector: 'app-sign-up',
//   templateUrl: './sign-up.component.html',
//   styleUrls: ['./sign-up.component.css'],
//   imports : [ ReactiveFormsModule, CommonModule,HttpClientModule,FormsModule,RouterOutlet],
//   standalone: true
 
// })
// export class SignUpComponent  {
//   UserForm: FormGroup;


//   constructor(private userService: UserService,private http: HttpClient,private router:Router) {
//     this.UserForm = new FormGroup({
//       'Name': new FormControl('',[
//         Validators.required,
//         Validators.minLength(2),
    
      
//       ]),
//       'Email': new FormControl('', [
//         Validators.required,
//         Validators.email,
//         // Validators.minLength(5),
//         // Validators.maxLength(50),
//       ]),
//       'Password': new FormControl('', [
//         Validators.required,
//         Validators.minLength(5),
//         // Validators.pattern("^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$")
//       ]),
//       'Phone': new FormControl('', [
//         Validators.required,
//         Validators.minLength(10),
//         Validators.maxLength(10),
//         // Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")
//       ]),
      
//       'Line1': new FormControl('',[
//         Validators.required,
//       ]),
//       'Line2':new FormControl('',[
//         Validators.required,
//       ]),
//       'PinCode':new FormControl('',[
//         Validators.required,
//       ]),
//       'City':new FormControl('',[
//         Validators.required,
//       ]),
//       'Country':new FormControl('',[
//         Validators.required,
//       ]),
//       'State':new FormControl('',[
//         Validators.required,
//       ])

//     }
//     );

//   }

  
//   onSubmit(){
//    // console.log('Registration form submitted:', this.Form.value);
//   this.UserForm.markAllAsTouched();
//   console.debug(this.UserForm.value);
//   console.debug(this.UserForm.valid);

//     if (this.UserForm.valid) {
//       var formData = new FormData();
//       //formData.append("data", JSON.stringify(this.Form.value));
    
 
//       console.log(formData);
    
     
//       try {
//         this.http.post("http://localhost:5217/api/Customer/SignUp",
//           this.UserForm.value)
//           .subscribe(o => {
//             console.log(o);
//             this.router.navigate(['/login']);
//           });
//       } catch (e: any) {
//         console.log("Error", e);
//       }
//     } 
    
//     else {
//       // Mark all form fields as touched to display validation errors
//       console.log(this.UserForm);
//       alert("invalid");
//     }
//   }
// }

import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router, RouterModule } from '@angular/router';
import { Subscription } from 'rxjs';
import { CommonModule } from '@angular/common';


@Component({
  standalone : true,
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  imports : [FormsModule,CommonModule,RouterModule,ReactiveFormsModule],
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent {
  UserForm: FormGroup;
  subscription: Subscription | null = null;

  constructor(private http: HttpClient, private router: Router, private formBuilder: FormBuilder) {
    this.UserForm = this.formBuilder.group({
      Name: ['', [Validators.required, Validators.minLength(3)]],
      Email: ['', [Validators.required, Validators.email,]],
      Password: ['', [Validators.required, Validators.minLength(5), Validators.pattern('/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$/')]],
      Phone: ['', [Validators.required, Validators.pattern("[0-9]{10}"), Validators.minLength(10)]],

    });
  }

  onSubmit() {
    this.UserForm.markAllAsTouched();
    if (this.UserForm.valid) {
      this.subscription = this.http.post("http://localhost:5217/api/Customer/SignUp", this.UserForm.value)
        .subscribe({
          next: response => {
            console.log(response);
            this.router.navigate(['/login']);
          },
          error: error => {
            console.error('Error occurred:', error);
          }
        });
    } else {
      alert("Invalid form data");
    }
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
