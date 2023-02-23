using Serilog;
using DataAccess;
using Models;
using services;
using Tests;

namespace project;

public class MainMenu{

    static void Main(string[] args)
    {
        Console.WriteLine();
        
    int Selection;
    int.TryParse(Console.ReadLine(), out Selection);
switch (Selection) 
{
  case 1:
    Console.WriteLine("Starting New Account");
    break;
  case 2:
    Console.WriteLine("Starting Login");
    break;
}

    }






}


