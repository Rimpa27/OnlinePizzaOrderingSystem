import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { HttpService } from '../http.service';
import { IUser } from '../interface/menu';
import { SidebarComponent } from '../sidebar/sidebar.component';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [CommonModule,RouterLink,SidebarComponent,HttpClientModule],
  providers:[HttpService],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent implements OnInit {
  Users:IUser[]=[];
  router = inject(Router);
  httpService = inject(HttpService);
  sidebarOpen = false;
  toggleSidebar() 
  {
    this.sidebarOpen = !this.sidebarOpen;  
  }
  
  displayedColumns: string[] = [
    'UserID',
    'Name',
    'Email',
    'Password',
    'RoleType',
    'Action'
  ];

ngOnInit() {
  this.getUserFromServer();
} 
getUserFromServer() {
  this.httpService.getAllUser().subscribe((result) => {
    this.Users = result;
    console.log(this.Users);
  });
}
edit(UserID: number) {
  console.log(UserID);
  this.router.navigateByUrl('addUser');
}
// delete(UserID: number) {
//   this.httpService.deleteUser(UserID).subscribe(() => {
//     console.log('deleted');
//     this.getUserFromServer();
//     //this.toastr.success('Record deleted sucessfully');
//   });
// }
// editUser(Users: IUser): void {
//   // Implement edit functionality here
//   console.log('Editing:',Users);
// }
delete(User: IUser): void {
  // Implement delete functionality here
  console.log('Deleting:',User);
  alert("Deleted Sucessfully")
  const index = this.Users.indexOf(User);
  if (index !== -1) {
    this.Users.splice(index, 1);
  }
}
}
