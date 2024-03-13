import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-home-counter',
  standalone: true,
  imports: [MatCardModule, MatIconModule],
  templateUrl: './home-counter.component.html',
  styleUrl: './home-counter.component.css'
})
export class HomeCounterComponent {
  happycustomer:number = 0;
  numberofawards:number = 0;
  numberofbranches:number = 0;

  happycustomerstop:any = setInterval(() => {
    this.happycustomer++;

    if(this.happycustomer == 5037 ){
      clearInterval(this.happycustomerstop);
    }
  },0.01)

  numberofawardsstop:any = setInterval(() => {
    this.numberofawards++;

    if(this.numberofawards == 108 ){
      clearInterval(this.numberofawardsstop);
    }
  },25)

  numberofbranchesstop:any = setInterval(() => {
    this.numberofbranches++;

    if(this.numberofbranches == 72 ){
      clearInterval(this.numberofbranchesstop);
    }
  },30)
}
