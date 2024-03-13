import { CommonModule } from '@angular/common';
import { Component, ViewEncapsulation } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterLink, RouterOutlet } from '@angular/router';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { AddMenuItemComponent } from '../add-menu-item/add-menu-item.component';
import { MenuItemListComponent } from '../menu-item-list/menu-item-list.component';
import { HttpService } from '../http.service';
@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [RouterOutlet,CommonModule,FormsModule,ReactiveFormsModule,HomepageComponent,MenuItemListComponent,
    AddMenuItemComponent,SidebarComponent],
  providers:[HttpService],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css',
  
})
export class HomepageComponent {
  sidebarOpen = false;
  toggleSidebar() 
  {
    this.sidebarOpen = !this.sidebarOpen;  
  }
}
