import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class CartService {

  cartItems: any[] = [];

  constructor() {}

  addToCart(item: any): void {
    const existingItem = this.cartItems.find(cartItem => cartItem.id === item.id);

    if (existingItem) {
      
      existingItem.quantity += 1;
    } else {
      // If item doesn't exist, add it to the cart
      item.quantity = 1;
      this.cartItems.push(item);
    }
    localStorage.setItem('cartItems', JSON.stringify(this.cartItems));
  }
  // addToCart(item: any):void{
  //   // const existingItem = this.cartItems.find(cartItem => cartItem.id === item.id);
  //   // if (existingItem) {
  //   //   existingItem.quantity++;
  //   // } else {
  //   //   this.cartItems.push({ ...item, quantity: 1 });
  //   // }
  //   this.cartItems.push(item);
  //   localStorage.setItem('cartItems', JSON.stringify(this.cartItems));
  // }

  removeFromCart(itemId: number) {
    this.cartItems = this.cartItems.filter(item => item.id !== itemId);
    this.saveCart();
  }

  updateQuantity(itemId: number, quantity: number) {
    const item = this.cartItems.find(cartItem => cartItem.id === itemId);
    if (item) {
      item.quantity = quantity;
    }
  }

  getTotalPrice(): number {
    return this.cartItems.reduce((total, item) => total + (item.price * item.quantity), 0);
  }
  getCartItems(): any[] {
     return JSON.parse(localStorage.getItem('cartItems') || '[]');
     //return this.cartItems;
  }
  private saveCart(): void {
    localStorage.setItem('cartItems', JSON.stringify(this.cartItems));
  }
}
