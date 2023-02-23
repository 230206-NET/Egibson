namespace Services;
using System;

public static class FailureOnInput
{

    public static void ExpectedInt(){
        Console.WriteLine("That was not an intiger value.");
        Console.WriteLine("Would you mind trying that agian?");   
        Console.Beep(); 
        Console.Beep(); 
        Console.Beep(); 
        Console.ReadKey();
        }
    public static void ExpectedString(){
        Console.WriteLine("That was a empty string!");
        Console.WriteLine("Would you mind trying that agian?");   
        Console.Beep(); 
        Console.Beep(); 
        Console.Beep(); 
        Console.WriteLine("press any key to coninute");
        Console.ReadKey();
        }
        
    public static void BeeAtThemAndPause(){
        Console.Beep(); 
        Console.Beep(); 
        Console.Beep(); 
        Console.WriteLine("Error, press any key to coninute");
        Console.ReadKey();
    }

}
