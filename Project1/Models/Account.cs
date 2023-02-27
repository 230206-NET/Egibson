using System;
using Serilog;
namespace Models;

/// <summary>
/// This class needs a employee made to use.
/// </summary>
public class Account
{  
 
    public string UserName {get; set;} = "";
    public string Password {get; set;} = "";
    public bool isManager{get; set;} = false;
    public string AccountName {get; set;} = "";
    public int EID {set; get;} 
  
    public void setAccount()
    {   
        Console.WriteLine("Please enter your account Information.");
        Console.WriteLine("Please Enter Employee name: ");
        this.AccountName = Console.ReadLine();
        Console.WriteLine("What will your username be? :");
        this.UserName = Console.ReadLine()!;
        Console.WriteLine("What will your password be? :");
        this.Password = Console.ReadLine()!;
        Console.WriteLine("Are you a Manager?");
        if("t" == Console.ReadLine()) this.isManager = true; 
        
    }

public override string ToString()
    {
        return $"Name: {this.AccountName}, Manager Status: {this.isManager}, Username: {this.UserName}, Password: {this.Password}";
    }

} 
