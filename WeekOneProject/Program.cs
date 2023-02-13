while(true) {

    Console.WriteLine("\n\n___________________________________");
    Console.WriteLine("Week One Portfolio:");
    Console.WriteLine("Pick which app you would like to run: ");
    Console.WriteLine("[1]: First DotNet");
    Console.WriteLine("[2]: Coin Flipper");
    Console.WriteLine("[3]: Hot or Cold");
    Console.WriteLine("[4]: FizzBuzz");
    Console.WriteLine("[5]: ToDo App");
    Console.WriteLine("[6]: Budget App");
    Console.WriteLine("[7]: TikTakToe");
    Console.WriteLine("[x]: Exit");
    string? input = Console.ReadLine();

    if(input != null) {

        switch(input) {
            case "1":
                Console.WriteLine("Going to run FirstDotNet");
                new FirstDotNet.MainMenu().Start();
                
            break;
            case "2":
                Console.WriteLine("Going to run coin flipper");
                new CoinFlipper.MainMenu().Start();
            break;
            case "4":
                Console.WriteLine("Going to run FizzBuzz");
                new FizzBuzz.MainMenu().Start();
            break;
            case"3": 
                Console.WriteLine("Going to run Hot Or Cold");
                new HotOrCold.MainMenu().Start(); 
            break;
            case "5": 
                Console.WriteLine("Going to run ToDO");
                new ToDo.MainMenu().Start();
            break;
            case "6":
                // You can't instantiate Expense class here because it is internal, and intended for use only within the same project
                Console.WriteLine("Going to run Budget App");
                new BudgetApp.MainMenu().Start();
            break;
            case"7": 
                Console.WriteLine("Going to run TikTakToe");
                new TikTak.MainMenu().Start();
            break;
            case "x":
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
            break;
            default:
                Console.WriteLine("Unrecognized input, please try again.");
            break;
        }
    }
}