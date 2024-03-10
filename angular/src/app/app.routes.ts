import { Routes } from '@angular/router';

import { HomepageComponent } from './homepage/homepage.component';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/sign-up.component';



export const routes: Routes = [
    {path:"",component:HomepageComponent},
    {path: "signup", component:SignUpComponent},
    {path:'login',component:LoginComponent}

];
