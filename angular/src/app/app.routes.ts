import { Routes } from '@angular/router';

import { HomepageComponent } from './homepage/homepage.component';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { MenuComponent } from './menu/menu.component';
import { DemoComponent } from './demo/demo.component';
import { CartComponent } from './cart/cart.component';




export const routes: Routes = [
    {path:"",component:HomepageComponent},
    {path: "signup", component:SignUpComponent},
    {path:'login',component:LoginComponent},
    {path:'menu',component:MenuComponent},
    {path:'demo',component:DemoComponent},
    {path:'cart', component:CartComponent }

];
