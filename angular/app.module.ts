
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './src/app/app.component';
import { CommonModule } from '@angular/common';
import { SignUpComponent } from './src/app/sign-up/sign-up.component';

 
@NgModule({
  declarations: [
    AppComponent,
    SignUpComponent
  ],
  imports: [
    FormsModule ,
    ReactiveFormsModule,CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}