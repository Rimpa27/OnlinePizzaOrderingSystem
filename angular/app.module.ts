
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './src/app/app.component';
import { CommonModule } from '@angular/common';
import { SignUpComponent } from './src/app/sign-up/sign-up.component';
import { LoginComponent } from './src/app/login/login.component';
import { MenuComponent } from './src/app/menu/menu.component';
import { CartComponent } from './src/app/cart/cart.component';
import { RouterModule } from '@angular/router';
import { CartService } from './src/app/services/cart.service';
import { HttpClientModule } from '@angular/common/http';

 
@NgModule({
  declarations: [
    AppComponent,
    SignUpComponent,LoginComponent,MenuComponent,CartComponent
  ],
  imports: [
    FormsModule ,
    ReactiveFormsModule,CommonModule,RouterModule,HttpClientModule
  ],
  exports:[RouterModule],
  providers: [CartService],
  bootstrap: [AppComponent]
})
export class AppModule {}