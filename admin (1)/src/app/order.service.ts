
import { Injectable } from '@angular/core';
import { map, Observable, of } from 'rxjs';
import { Iorder } from './interface/menu';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private orders: Iorder[] = [
    { orderid :6768,
        orderdate:'12/03/2024',
        orderstatus:'Pending',
        ordertotal:2000,
        paymenttype:'UPI',
        orderitem:[
            {name:'Pizza',quantity:2},
            {name:'Pasta',quantity:3}]
    },
    { 
      orderid :6708,
      orderdate:'12/03/2024',
      orderstatus:'Pending',
      ordertotal:600,
      paymenttype:'UPI',
      orderitem:[
          {name:'Noodles',quantity:2},
          {name:'Garlic Bread',quantity:3}]
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
  
