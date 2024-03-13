
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { AddMenuItemComponent } from './add-menu-item/add-menu-item.component';

import { SidebarComponent } from './sidebar/sidebar.component';
import { MenuItemListComponent } from './menu-item-list/menu-item-list.component';
import { HttpClientModule } from '@angular/common/http';
@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,AddMenuItemComponent,MenuItemListComponent
  ],
  imports:[
    FormsModule ,
    ReactiveFormsModule,CommonModule,HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}