import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input,Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menuitem-details',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './menuitem-details.component.html',
  styleUrl: './menuitem-details.component.css'
})
export class MenuitemDetailsComponent {
  @Input() menuItem: any;
  @Output() close: EventEmitter<void> = new EventEmitter<void>();
  cartService: any;
  constructor(private router: Router) {
   
  }

  addToCart(menuItem: any):void {
    this.cartService.addToCart(menuItem);
   // console.log(this.cartService.getCartItems());
    this.router.navigate(['/cart']);
    alert("Added to Cart");
  }
}
