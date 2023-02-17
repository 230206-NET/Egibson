
namespace HotOrCold;

	public class MainMenu
	{
	
		public void Start()
		{
		var rand = new Random();
		int target = rand.Next(21); //generate a random number between 0 - 20
		
		//****************
		//Console.WriteLine(target);
		//****************
		Console.WriteLine("Please Guess a number between zero and twenty. We will stop once you have got it right.");
		
			while(true)
			{
				int guess = Int32.Parse(Console.ReadLine()!);
				if ( guess == target)
				{
					Console.WriteLine("You got it!\n");
					break;
				}
		
				else if (guess > target)
				{
					Console.WriteLine("To High");
				}
				else
				{
					Console.WriteLine("To LOW");
				}
		
			}
		
	
		}


	}



