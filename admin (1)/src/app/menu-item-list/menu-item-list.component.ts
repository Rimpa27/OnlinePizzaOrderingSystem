import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Imenu } from '../interface/menu';
import { SidebarComponent } from '../sidebar/sidebar.component';

@Component({
  selector: 'app-menu-item-list',
  standalone: true,
  imports: [CommonModule,RouterLink,SidebarComponent],
  templateUrl: './menu-item-list.component.html',
  styleUrl: './menu-item-list.component.css'
})
export class MenuItemListComponent {
  sidebarOpen = false;
  toggleSidebar() 
  {
    this.sidebarOpen = !this.sidebarOpen;  
  }
  menuItems:Imenu[] = [
    { name: 'Item 1', description: 'Description 1', price: 10.99, foodtype: 'Type 1', category: 'Category 1', calories: 200, preparationTime: 20, photo: '../../assets/Slideshow1.jpg'},
    { name: 'Item 2', description: 'Description 2', price: 15.99, foodtype: 'Type 2', category: 'Category 2', calories: 300, preparationTime: 25, photo: '../../assets/Slideshow1.jpg' },
    // Add more menu items here
  ];
  editMenuItem(menuItem: Imenu): void {
    // Implement edit functionality here
    console.log('Editing:', menuItem);
  }
  deleteMenuItem(menuItem: Imenu): void {
    // Implement delete functionality here
    console.log('Deleting:', menuItem);
    const index = this.menuItems.indexOf(menuItem);
    if (index !== -1) {
      this.menuItems.splice(index, 1);
    }
  }
}
