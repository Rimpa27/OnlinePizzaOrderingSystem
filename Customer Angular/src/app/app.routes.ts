import { Routes } from '@angular/router';

import { HomepageComponent } from './homepage/homepage.component';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { MenuComponent } from './menu/menu.component';
import { DemoComponent } from './demo/demo.component';
import { CartComponent } from './cart/cart.component';
import { PaymentComponent } from './payment/payment.component';
import { PaymentstatusComponent } from './paymentstatus/paymentstatus.component';
import { DeliveryAddressComponent } from './delivery-address/delivery-address.component';




export const routes: Routes = [
    {path:"",component:HomepageComponent},
    {path:"home",component:HomepageComponent},
    {path: "signup", component:SignUpComponent},
    {path:'login',component:LoginComponent},
    {path:'menu',component:MenuComponent},
    {path:'demo',component:DemoComponent},
    {path:'cart', component:CartComponent },
    {path:'payment', component:PaymentComponent},
    {path:'paystatus', component:PaymentstatusComponent},
    {path:'delivery_address', component:DeliveryAddressComponent}

];
