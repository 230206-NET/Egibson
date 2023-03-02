namespace Services;
using System;
using Serilog;
// using Models;
// using DataAccess;


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
        Console.WriteLine("That was a empty!");
        Console.WriteLine("Would you mind trying that agian?");   
        Console.Beep(); 
        Console.Beep(); 
        Console.Beep(); 
        }
        
    public static void BeeAtThemAndPause(){
        Console.Beep(); 
        Console.Beep(); 
        Console.Beep(); 
        Console.WriteLine("Error, press any key to coninute");
        Console.ReadKey();
    }
public static void inputWasBad(){
        Console.Beep(); 
        Console.Beep(); 
        Console.Beep(); 
Console.WriteLine("You input was bad, and something went wrong.");


}

public static string checkString()
{   while(true){
    string stringtocheck = Console.ReadLine()!;
    if(string.IsNullOrWhiteSpace(stringtocheck))
    {
        ExpectedString();
    }
    else return stringtocheck;
}
    
}
public static int checkINT()
{   while(true){
    string stringtocheck = Console.ReadLine()!;
    if(string.IsNullOrWhiteSpace(stringtocheck))
    {
        ExpectedString();
    }
        bool success = Int32.TryParse( stringtocheck, out int tempINT);
        if(success) { return tempINT;}
        else 
        {
            Log.Warning("Models: Expense, Cost not an int.");
            ExpectedInt();
        
        }
}
    
}


}


public static class passWordClass{

public static string passwordInput(){
var pass = string.Empty;
        ConsoleKey key;
        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && pass.Length > 0)
            {
                Console.Write("\b \b");
                pass = pass[0..^1];
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                pass += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);
        return pass;

}




}

// public static class dataServices{

// public static int CreateNewUser(Account newAccount)
// {   
//     return DBConnector.UploadUser(newAccount, Secrets.getConnectionString());
// }
//}

