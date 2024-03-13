import { CommonModule } from '@angular/common';
import { Component, NgModule, ViewChild } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { AddMenuItemComponent } from './add-menu-item/add-menu-item.component';
import { HomepageComponent } from './homepage/homepage.component';
import { LoginComponent } from './login/login.component';
import { MenuItemListComponent } from './menu-item-list/menu-item-list.component';
import { OrderComponent } from './order/order.component';
import { SidebarComponent } from './sidebar/sidebar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,CommonModule,FormsModule,LoginComponent,OrderComponent,ReactiveFormsModule,HomepageComponent,MenuItemListComponent,AddMenuItemComponent,SidebarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'OnlinePizzaOrdering';
  sidebarOpen = false;
  toggleSidebar() 
  {
    this.sidebarOpen = !this.sidebarOpen;  
  }
  
}

