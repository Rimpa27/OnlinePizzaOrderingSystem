import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MenuitemDetailsComponent } from '../menuitem-details/menuitem-details.component';
import { CartItem } from '../interface/cart-item.interface';
import { CartService } from '../services/cart.service';
import { MenuItem } from '../interface/menu-item.interface';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [CommonModule,FormsModule, MenuitemDetailsComponent],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css',
  providers:[CartService]
})
export class MenuComponent {
  
  menuItem = [
    {
     id:1, 
     name: 'Margherita',
      image: '../../assets/Margherita.jpg',
      description: 'Classic cheese and tomato base pizza.',
      veg: true,
      toppings: ['Cheese', 'Tomato'],
      category: 'pizza',
      price: 200
    },
    {
      id:2,
      name: 'Pepperoni',
      image: '../../assets/Margherita.jpg',
      description: 'Classic pepperoni pizza with extra cheese.',
      veg: false,
      toppings: ['Cheese', 'Pepperoni'],
      price: 200,
      category: 'pasta'
    },
    {
      
      id:3,
      name: 'Margherita',
      image: 'https://via.placeholder.com/150',
      description: 'Classic cheese and tomato base pizza.',
      veg: true,
      toppings: ['Cheese', 'Tomato'],
      price: 200,
      category: 'dessert'
    },
    {
      id:4,
      name: 'Pepperoni',
      image: 'https://via.placeholder.com/150',
      description: 'Classic pepperoni pizza with extra cheese.',
      veg: false,
      toppings: ['Cheese', 'Pepperoni'],
      price: 200,
      category: 'sides'
    },
    {
      id:5,
      name: 'Margherita',
      image: 'https://via.placeholder.com/150',
      description: 'Classic cheese and tomato base pizza.',
      veg: true,
      toppings: ['Cheese', 'Tomato'],
      price: 200,
      category: 'beverages'

    },
    {
      id:6,
      name: 'Pepperoni',
      image: 'https://via.placeholder.com/150',
      description: 'Classic pepperoni pizza with extra cheese.',
      veg: false,
      toppings: ['Cheese', 'Pepperoni'],
      price: 200,
      category: 'salad'
    },
    {
      id:7,
      name: 'Margherita',
      image: 'https://via.placeholder.com/150',
      description: 'Classic cheese and tomato base pizza.',
      veg: true,
      toppings: ['Cheese', 'Tomato'],
      price: 200,
      category: 'pizza'
    },
    {
      id:8,
      name: 'Pepperoni',
      image: 'https://via.placeholder.com/150',
      description: 'Classic pepperoni pizza with extra cheese.',
      veg: false,
      toppings: ['Cheese', 'Pepperoni'],
      price: 200,
      category: 'pizza'

    },
    {
      id:9,
      name: 'Margherita',
      image: 'https://via.placeholder.com/150',
      description: 'Classic cheese and tomato base pizza.',
      veg: true,
      toppings: ['Cheese', 'Tomato'],
      price: 180,
      category: 'pasta'
    },
    {
      id:10,
      name: 'Pepperoni',
      image: 'https://via.placeholder.com/150',
      description: 'Classic pepperoni pizza with extra cheese.',
      veg: false,
      toppings: ['Cheese', 'Pepperoni'],
      price: 120,
      category: 'dessert'
    },
    {
      id:11,
      name: 'Margherita',
      image: 'https://via.placeholder.com/150',
      description: 'Classic cheese and tomato base pizza.',
      veg: true,
      toppings: ['Cheese', 'Tomato'],
      price: 280,
      category: 'sides'
    },
    {
      id:4,
      name: 'Pepperoni',
      image: 'https://via.placeholder.com/150',
      description: 'Classic pepperoni pizza with extra cheese.',
      veg: false,
      toppings: ['Cheese', 'Pepperoni'],
      price: 599,
      category: 'beverages'
    },
    {
      id:4,
      name: 'Margherita',
      image: 'https://via.placeholder.com/150',
      description: 'Classic cheese and tomato base pizza.',
      veg: true,
      toppings: ['Cheese', 'Tomato'],
      price: 199,
      category: 'sides'
    },
    {
      id:4,
      name: 'Pepperoni',
      image: 'https://via.placeholder.com/150',
      description: 'Classic pepperoni pizza with extra cheese.',
      veg: false,
      toppings: ['Cheese', 'Pepperoni'],
      price: 400,
      category: 'beverages'
    },
    {
      id:4,
      name: 'Margherita',
      image: 'https://via.placeholder.com/150',
      description: 'Classic cheese and tomato base pizza.',
      veg: true,
      toppings: ['Cheese', 'Tomato'],
      price: 230,
      category: 'sides'
    },
    {
      id:4,
      name: 'Pepperoni',
      image: 'https://via.placeholder.com/150',
      description: 'Classic pepperoni pizza with extra cheese.',
      veg: false,
      toppings: ['Cheese', 'Pepperoni'],
      price: 500,
      category: 'beverages'
    },
    {
      id:4,
      name: 'Margherita',
      image: 'https://via.placeholder.com/150',
      description: 'Classic cheese and tomato base pizza.',
      veg: true,
      toppings: ['Cheese', 'Tomato'],
      price: 250,
      category: 'beverages'
    },
    {
      id:4,
      name: 'Pepperoni',
      image: 'https://via.placeholder.com/150',
      description: 'Classic pepperoni pizza with extra cheese.',
      veg: false,
      toppings: ['Cheese', 'Pepperoni'],
      price: 300,
      category: 'beverages'
    },
   
  ];
  filteredMenuItems: any[] = [];
  selectedCategory: string = 'all';
  showPopup: boolean = false;
  selectedMenuItem: any;
  selectedToppings: { [key: string]: boolean } = {};
  cartService: any;
  // selectedItem:any;
  // isPopupOpen: boolean = false;

  constructor() {
    this.filteredMenuItems = this.menuItem;
  }

  selectCategory(category: string): void {
    this.selectedCategory = category;
    if (category === 'all') {
      this.filteredMenuItems = this.menuItem;
    } else {
      this.filteredMenuItems = this.menuItem.filter(item => item.category === category);
    }
  }
  openPopup(menuItem: any): void {
    this.selectedMenuItem = menuItem;
    // this.selectedToppings = {};
    this.showPopup = true;
    console.log(this.selectedMenuItem);
  }

  closePopup(): void {
    // console.log(this.selectedToppings);
    this.showPopup = false;
  }
  addToCart(menuItem:MenuItem): void {
    this.cartService.addItemToCart(menuItem);
    console.log(this.menuItem);
  }


}
