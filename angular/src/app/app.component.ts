import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import {MatButtonModule} from '@angular/material/button'

import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { HomeCounterComponent } from './home-counter/home-counter.component';
import { HomeOfferComponent } from './home-offer/home-offer.component';
import { HomepageServiceComponent } from './homepage-service/homepage-service.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,NavbarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'onlinepizza';
}
