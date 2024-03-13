import { Component } from '@angular/core';
import { HomeCarouselComponent } from '../home-carousel/home-carousel.component';
import { HomeCounterComponent } from '../home-counter/home-counter.component';
import { HomeOfferComponent } from '../home-offer/home-offer.component';
import { HomepageServiceComponent } from '../homepage-service/homepage-service.component';

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [HomeCarouselComponent, HomeCounterComponent, HomeOfferComponent, HomepageServiceComponent],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})
export class HomepageComponent {

}
