import { Routes } from '@angular/router';
import { AddMenuItemComponent } from './add-menu-item/add-menu-item.component';
import { AdduserComponent } from './adduser/adduser.component';
import { HomepageComponent } from './homepage/homepage.component';
import { LoginComponent } from './login/login.component';
import { MenuItemListComponent } from './menu-item-list/menu-item-list.component';
import { OrderComponent } from './order/order.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { UserComponent } from './user/user.component';
export const routes: Routes = [
    {path:'sidebar',component:SidebarComponent},
    {path:'menu',component:MenuItemListComponent},
    {path:'addMenuItem',component:AddMenuItemComponent},
    {path:'order',component:OrderComponent},
    {path:'user',component:UserComponent},
    {path:'addUser',component:AdduserComponent},
    {path:'homepage',component:HomepageComponent},
    // {path:'menuitemlist',component:MenuItemListComponent},
    {path:'',component:LoginComponent},
];
