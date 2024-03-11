import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart.service';
import { CartItem } from '../interface/cart-item.interface';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent implements OnInit{
  cartItems:CartItem[] = [];
  
  constructor(private cartService: CartService) {}

  ngOnInit(): void {
    this.cartItems = this.cartService.getItemsInCart();
  }

  removeFromCart(item: CartItem): void {
    this.cartService.removeItemFromCart(item);
    this.cartItems = this.cartService.getItemsInCart();
  }

  getTotal(): number {
    return this.cartService.getTotalPrice();
  }

}
