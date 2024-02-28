
import { Component } from '@angular/core';
import { MenuItem } from '../menu-item.model';
 
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  isMobileMenuOpen = false;
  navigationItems: MenuItem[] = [
    new MenuItem('Dashboard', '/dashboard', true),
    new MenuItem('Team', '/team', false),
    new MenuItem('Projects', '/projects', false),
    new MenuItem('Calendar', '/calendar', false),
  ];
 
  toggleMobileMenu() {
    this.isMobileMenuOpen = !this.isMobileMenuOpen;
  }
 
  getMenuItemClasses(item: MenuItem) {
    return {
      'bg-gray-900 text-white': item.isCurrent,
      'text-gray-300 hover:bg-gray-700 hover:text-white': !item.isCurrent
    };
  }
}
 

