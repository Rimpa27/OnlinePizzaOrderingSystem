import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { EmailValidator, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import { IUser } from '../interface/menu';
import { HttpService } from '../http.service';
import { HttpClientModule } from '@angular/common/http';
@Component({
  selector: 'app-adduser',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule,FormsModule,HttpClientModule],
  templateUrl: './adduser.component.html',
  styleUrl: './adduser.component.css'
})
export class AdduserComponent {
  UserForm:FormGroup;
  httpService = inject(HttpService);
  roles: string[] = ['Admin', 'Customer', 'Delivery Person'];
  selectuser:string|undefined;
  userID!:number;
  isEdit!: false;
selectedroletype:string | undefined

  constructor(private formBuilder: FormBuilder,private router: Router,private route:ActivatedRoute) {
    this.UserForm=this.formBuilder.group({
      Name: ['', Validators.required],
      Email: ['', [Validators.required, Validators.email]],
      RoleType:[ ,[Validators.required]],
      Password: ['', Validators.required],
    });
  }
  onSubmit() {
    console.log('Form submitted!');
    console.log(this.UserForm.value);
    console.log(this.UserForm.value);
    const User: IUser = {
      name:this.UserForm.value.name!,
      email:this.UserForm.value.email!,
      password:this.UserForm.value.password!,
      roleType:this.UserForm.value.roleType!
    };
      this.httpService.AddUser(User).subscribe(() => {
        console.log('success');
        alert("User Added Successfully")
        this.router.navigateByUrl('user');
      });
    }
}
