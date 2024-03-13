import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart.service';
import { CartItem } from '../interface/cart-item.interface';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MenuComponent } from '../menu/menu.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule,FormsModule,MenuComponent],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent implements OnInit{
  cartItems:any[] = [];
  totalPrice:number = 0;
  
  constructor(private cartService: CartService, private router:Router) {}

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

checkout(){
  this.router.navigate(['/delivery_address']);
}

}
