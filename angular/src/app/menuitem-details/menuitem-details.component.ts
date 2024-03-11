import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input,Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

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

}
