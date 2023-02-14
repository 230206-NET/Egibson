namespace CoinFlipper;


public class MainMenu {


public void Start(){
    Console.WriteLine("Coin Flipper Starting");
bool coin = true;
var rand = new Random();
int value = rand.Next();
//Console.WriteLine(value);
int remainder = value % 2;
	if (remainder == 1)
	{
		coin = false;
	}        
	if (coin) // if (coin == true)
        {
            Console.WriteLine("Your coin was flipped it was heads");
        }
        else
        {
            Console.WriteLine("Your coin was flipped it was tails");

        }

}

}


