import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart.service';
import { CartItem } from '../interface/cart-item.interface';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule,FormsModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent implements OnInit{
  cartItems:any[] = [];
  totalPrice:number =0;
  
  constructor(private cartService: CartService) {}

  ngOnInit(): void {
    this.loadCart();
    console.log("load cart "+this.cartItems)
  }

  loadCart(){
    this.cartItems = this.cartService.getCartItems();
    this.totalPrice = this.cartService.getTotalPrice();
  }
  removeFromCart(itemId: number) {
    this.cartService.removeFromCart(itemId);
    this.loadCart();
  }

  updateQuantity(itemId: number, quantity: number) {
    this.cartService.updateQuantity(itemId, quantity);
    this.loadCart();
  }

  increaseQuantity(item: any): void {
    item.quantity++;
    this.saveCart();
  }

  decreaseQuantity(item: any): void {
    if (item.quantity > 1) {
      item.quantity--;
      this.saveCart();
    }
}
private saveCart(): void {
  localStorage.setItem('cartItems', JSON.stringify(this.cartItems));
}
}
