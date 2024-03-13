import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-adduser',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule,FormsModule],
  templateUrl: './adduser.component.html',
  styleUrl: './adduser.component.css'
})
export class AdduserComponent {
  UserForm:FormGroup;
  roles: string[] = ['Admin','Customer','Delivery Person'];
  selectuser:string|undefined;
  constructor(private formBuilder: FormBuilder) {
    this.UserForm=this.formBuilder.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      role:['',[Validators.required]],
      password: ['', Validators.required],
      phone:['',Validators.required],
    })
  }
  onSubmit() {
    this.UserForm.markAllAsTouched();
    console.log('Form submitted!');
    console.log(this.UserForm.value)
  }

}
