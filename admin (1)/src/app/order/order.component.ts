import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Iorder } from '../interface/menu';
import { OrderService } from '../order.service';
import { SidebarComponent } from '../sidebar/sidebar.component';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [RouterLink,CommonModule,SidebarComponent],
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})
export class OrderComponent {
  sidebarOpen = false;
  toggleSidebar() 
  {
    this.sidebarOpen = !this.sidebarOpen;  
  }
  orders: Iorder[] | undefined;
  constructor(private orderService:OrderService) {  }
  ngOnInit(): void {
    this.getOrders();
  }
  getOrders(): void {
    this.orderService.getOrders()
      .subscribe((orders: Iorder[]) => this.orders = orders);
  }
  confirmOrder(id: number): void {
    this.orderService.updateOrderStatus(id, 'Confirmed')
      .subscribe(() => this.getOrders());
  }
  declineOrder(id: number): void {
    this.orderService.updateOrderStatus(id, 'Declined')
      .subscribe(() => this.getOrders());
  }
}
