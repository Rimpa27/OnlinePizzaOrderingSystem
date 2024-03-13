import { Component, OnInit } from '@angular/core';
import { trigger, state, style, animate, transition } from '@angular/animations';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css'],
  standalone: true,
  imports:[RouterLink],
  animations: [
    trigger('slideInOut', [
      state('in', style({
        transform: 'translate3d(100, 100, 100)'
      })),
      state('out', style({
        transform: 'translate3d(100%,100% , 100%)'
      })),
      transition('in => out', animate('4000000ms ease-in-out')),
      transition('out => in', animate('400ms ease-in-out'))
    ])
  ]
})
export class SidebarComponent {
  sidebarState = 'out';
  sidebarOpen = false;
  toggleSidebar() {
    this.sidebarState = this.sidebarState === 'out' ? 'in' : 'out';
    this.sidebarOpen = !this.sidebarOpen;
    console.log('Toggling sidebar...');
    this.sidebarOpen = !this.sidebarOpen;
    console.log('Sidebar open:', this.sidebarOpen);
 }
}
