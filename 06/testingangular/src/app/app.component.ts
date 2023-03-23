import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Angular App';


}

//var let

var number : number = 1;
let count : number = 0;
let a : any;
a = 4;
a = 'apple'; 
let f: any[] = [1,'any',[]] 
enum Color {Red =0, Green =1, Blue = 3}
let BackGroundColor = Color.Red;


//casting
let message = 'abc';
let endsWithC = (<string>message).endsWith('c');
let alternative = (message as string).endsWith('c');



//arrow funtions
let log = function(message : string){
  console.log(message);

}




function doSomething()
{
  for (let i = 0; i < 5; i++)
  {
    console.log(i);

  }

}


