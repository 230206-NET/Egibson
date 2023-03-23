import { Component } from '@angular/core';

@Component({
  selector: 'app-showitems',
  templateUrl: './showitems.component.html',
  styleUrls: ['./showitems.component.css']
})
export class ShowitemsComponent {

  
}


async function getItemPic() {
  const response = await fetch('https://acnhapi.com/v1a/houseware/');
  console.log("@@@");
  const data = await response.json();
  console.log(data);
  console.log(countInObject(data));
  console.log(countInObject(data[1]));
  const numof = countInObject(data);
  let arr = [[]];
  console.log(arr);

  let itempicDiv = document.querySelector('#item-pic-container')

   for (let i = 0; i < numof;i++){
      if(data[i][0]['buy-price'] === null) continue;
      let itemname = document.createElement('p');
      itemname.id = 'item-name'
      itemname.className = 'name-container'
     
      let itembuyprice = document.createElement('p');
      itembuyprice.id = 'item-buy-price'
      itembuyprice.className = 'buyprice-container'
  
      let itemImg = document.createElement('img');
      itemImg.id = 'item-image';
      itemImg.className = 'image-container';
  itemname.innerText = data[i][0]['name']['name-USen'];
  itempicDiv!.appendChild(itemname);
  itemImg.src = data[i][0].image_uri;
  itempicDiv!.appendChild(itemImg);
  itembuyprice.innerText = data[i][0]['buy-price'];
  itempicDiv!.appendChild(itembuyprice);

   }

function countInObject(y : object) {
  let count = 0;
  // iterate over properties, increment if a non-prototype property
  for(var key in y) if(y.hasOwnProperty(key)) count++;
  return count;
}

}