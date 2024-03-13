import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { EmailValidator, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import { IUser } from '../interface/menu';
import { HttpService } from '../http.service';
@Component({
  selector: 'app-adduser',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule,FormsModule],
  templateUrl: './adduser.component.html',
  styleUrl: './adduser.component.css'
})
export class AdduserComponent {
  UserForm:FormGroup;
  httpService = inject(HttpService);
  roles: { name: string; value: number; }[] = [
    { name: 'Admin', value: 1 },
    { name: 'Customer', value: 2 },
    { name: 'Delivery Person', value: 3 }
  ];
  selectuser:string|undefined;
  userID!:number;
  isEdit!: false;

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
    if (this.isEdit) {
      this.httpService
        .editUser(this.userID,User)
        .subscribe(() => {
          console.log('success');
          //this.toaster.success("Record updated sucessfully.");
          this.router.navigateByUrl('user');
        });
    } else {
      this.httpService.AddUser(User).subscribe(() => {
        console.log('success');
        //this.toaster.success("Record added sucessfully.");
        this.router.navigateByUrl('user');
      });
    }
  }
}
