import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { HttpService } from '../http.service';
import { Imenu } from '../interface/menu';
import { SidebarComponent } from '../sidebar/sidebar.component';

@Component({
  selector: 'app-menu-item-list',
  standalone: true,
  imports: [CommonModule,RouterLink,SidebarComponent,HttpClientModule],
  templateUrl: './menu-item-list.component.html',
  styleUrl: './menu-item-list.component.css'
})
export class MenuItemListComponent implements OnInit {
  router = inject(Router);
  httpservice = inject(HttpService);
  //toaster = inject(ToastrService);
  sidebarOpen = false;
  toggleSidebar() 
  {
    this.sidebarOpen = !this.sidebarOpen;  
  }
  menuItems:Imenu[] = [];
  displayedColumns: string[] = [
  'MenuItemId',
  'MenuItemName',
  'MenuItemDescription',
  'Price',
  'VegOrNonVeg',
  'MenuItemCategory',
  'Calories',
  'IsAvailable',
  'PreparationTime'
  ];
  //
  ngOnInit(){
    this.getMenuItemFromServer();
  }
  getMenuItemFromServer() {
    this.httpservice.getAllMenuItem().subscribe((result) => {
      this.menuItems = result;
      console.log(this.menuItems);
    });
  }
  editMenuItem(menuItemId: number) {
    console.log(menuItemId);
    this.router.navigateByUrl('AddMenuItem');
  }
  deleteMenuItem(menuItem:Imenu): void {
      // Implement delete functionality here
      console.log('Deleting:', menuItem);
      const index = this.menuItems.indexOf(menuItem);
      if (index !== -1) {
        this.menuItems.splice(index, 1);
      }
    }
  // deleteMenuItem(menuItemId:number) {
  //   this.httpservice.deleteMenuItem(menuItemId).subscribe(() => {
  //     console.log('deleted');
  //     this.getMenuItemFromServer();
  //     alert('Delete Sucessfully ')
  //     //this.toastr.success('Record deleted sucessfully');
  //   });
  // }
  
}
