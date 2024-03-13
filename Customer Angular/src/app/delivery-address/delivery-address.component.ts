import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-delivery-address',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule,CommonModule],
  templateUrl: './delivery-address.component.html',
  styleUrl: './delivery-address.component.css'
})
export class DeliveryAddressComponent {

}
