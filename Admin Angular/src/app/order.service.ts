
import { Injectable } from '@angular/core';
import { map, Observable, of } from 'rxjs';
import { Iorder } from './interface/menu';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private orders: Iorder[] = [
    { orderid :1,
        orderdate:'12/03/2024',
        orderstatus:'Pending',
        ordertotal:'400.00',
        paymenttype:'UHFDY78914',
        orderitem:[
            {name:'Margherita',quantity:1},
            {name:'7CheeseBrust',quantity:1}]
    },
    { 
      orderid :2,
      orderdate:'13/03/2024',
      orderstatus:'Pending',
      ordertotal:'250.00',
      paymenttype:'HURGK79429',
      orderitem:[
          {name:'Masala Pasta',quantity:1},
          {name:'Margherita',quantity:1}]
    },
    // Add more sample orders as needed
  ];
  getOrders(): Observable<Iorder[]> {
    return of(this.orders);
  }
  updateOrderStatus(orderid: number, orderstatus: string): Observable<Iorder> {
    return of(this.orders).pipe(
      map((orders: any[]) => {
        const orderToUpdate = orders.find((order: { orderid: number; }) => order.orderid === orderid);
        if (orderToUpdate) {
          orderToUpdate.orderstatus = orderstatus;
        }
        return orderToUpdate;
      })
    );
  }
}
  
