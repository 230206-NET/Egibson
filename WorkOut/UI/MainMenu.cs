namespace UI;

public class MainMenu{


public void Start()
{
    Console.WriteLine("Worout Tracker");
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    string input = Console.ReadLine();
    switch(input)
    {
        case "1":
            Console.WriteLine("Creating New Workout: ");
            string? workoutDate = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(workoutDate)){
                session.WorkoutDate = new DateTime();
            }
        break;
        case "2":
        break;
        case "3":
        break;
        case "4":
        break;
        case "5":
        break;
        case "6":
        break;
        case "x":
        break;
        default: Console.WriteLine("Goodbye");
        break;
    }

}




}