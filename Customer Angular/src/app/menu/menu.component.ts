import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MenuitemDetailsComponent } from '../menuitem-details/menuitem-details.component';
import { CartItem } from '../interface/cart-item.interface';
import { CartService } from '../services/cart.service';
import { MenuItem } from '../interface/menu-item.interface';
import { Router } from '@angular/router';
import { MenuService } from '../services/menu.service';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [CommonModule,FormsModule, MenuitemDetailsComponent],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css',
  providers:[CartService]
})

export class MenuComponent implements OnInit {
  menuItem: MenuItem[] = [];
  filteredMenuItems: MenuItem[] = [];
  selectedCategory: string = 'all';
  showPopup: boolean = false;
  selectedMenuItem: MenuItem | null = null;

  constructor(private menuService: MenuService, private cartService: CartService, private router: Router) {}

  ngOnInit(): void {
    this.getMenuItems();
  }

  getMenuItems(): void {
    this.menuService.getMenuItems().subscribe(menuItems => {
      this.menuItem = menuItems;
      this.filteredMenuItems = this.menuItem;
      console.log(this.filteredMenuItems);
    });
  
  }

  selectCategory(category: string): void {
    this.selectedCategory = category;
    if (category === 'all') {
      this.filteredMenuItems = this.menuItem;
    } else {
      this.filteredMenuItems = this.menuItem.filter(item => item.category == category);
      
    }
    console.log('Filtered Menu Items:', this.filteredMenuItems);
  }

  openPopup(menuItem: MenuItem): void {
    this.selectedMenuItem = menuItem;
    this.showPopup = true;
  }

  closePopup(): void {
    this.showPopup = false;
  }

  addToCart(menuItem: MenuItem): void {
    this.cartService.addToCart(menuItem);
    this.router.navigate(['/cart']);
    alert("Added to Cart");
  }


  
  
}
