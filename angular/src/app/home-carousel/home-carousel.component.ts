import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { RouterOutlet } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { HomeCounterComponent } from '../home-counter/home-counter.component';
import { HomeOfferComponent } from '../home-offer/home-offer.component';
import { HomepageServiceComponent } from '../homepage-service/homepage-service.component';

@Component({
  selector: 'app-home-carousel',
  standalone: true,
  imports: [RouterOutlet, MatButtonModule,HomepageServiceComponent,MatCardModule,
    MatIconModule,HomeCounterComponent, HomeOfferComponent],
  templateUrl: './home-carousel.component.html',
  styleUrl: './home-carousel.component.css'
})
export class HomeCarouselComponent {

}
