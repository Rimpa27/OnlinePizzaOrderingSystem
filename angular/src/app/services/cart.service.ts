import { Injectable } from '@angular/core';
import { CartItem } from '../interface/cart-item.interface';
import { MenuItem } from '../interface/menu-item.interface';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  cartItems: CartItem[] = [];

  constructor() {}

  addItemToCart(menuItem:MenuItem): void {
    const existingItem = this.cartItems.find(item => item.name === menuItem.name);
    if (existingItem) {
      existingItem.quantity++;
    } else {
      this.cartItems.push({ ...menuItem, quantity: 1 });
    }
  }

  removeItemFromCart(item: CartItem): void {
    const index = this.cartItems.indexOf(item);
    if (index !== -1) {
      this.cartItems.splice(index, 1);
    }
  }

  getItemsInCart(): CartItem[] {
    return this.cartItems;
  }

  getTotalPrice(): number {
    return this.cartItems.reduce((total, item) => total + (item.price * item.quantity), 0);
  } 
 
}
