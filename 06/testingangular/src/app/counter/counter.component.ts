import { Component } from '@angular/core';

@Component({
  selector: 'app-counter',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css']
})
export class CounterComponent {
  count : number = 0;

  increment (){

    this.count = this.count +1;
  }

  arr : number[] = [1,2,3,4,5];
  show : boolean = true;

  toggleshow(e: Event){this.show = !this.show; console.log(e);}
}
