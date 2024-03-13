import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { IUser } from '../interface/menu';
import { SidebarComponent } from '../sidebar/sidebar.component';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [CommonModule,RouterLink,SidebarComponent],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent {
  sidebarOpen = false;
  toggleSidebar() 
  {
    this.sidebarOpen = !this.sidebarOpen;  
  }
Users:IUser[]=[
  {username:'Manish',email:'manish@gmail.com',password:'maisha@676',phone:9876054321,line1:'street1',line2:'panki',city:'kanpur',pincode:678967},
  {username:'Manoj',email:'manoj34@gmail.com',password:'amit@676',phone:9876504321,line1:'street1',line2:'panki',city:'kanpur',pincode:678967}
]
editUser(Users: IUser): void {
  // Implement edit functionality here
  console.log('Editing:',Users);
}
deleteUser(User: IUser): void {
  // Implement delete functionality here
  console.log('Deleting:',User);
  const index = this.Users.indexOf(User);
  if (index !== -1) {
    this.Users.splice(index, 1);
  }
}
}
