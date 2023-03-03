using System;
using Serilog;
using System.Threading;
namespace Models;
using Services;


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

        Console.WriteLine("Please Enter Employee name: ");
        this.AccountName = Console.ReadLine()!;
        Console.WriteLine("What will your username be? :");
        this.UserName = Console.ReadLine()!;
        Console.WriteLine("What will your password be? :");
       // string pass = passWordClass.passwordInput();
        string pass = Console.ReadLine()!;
        this.Password = pass;
        Console.WriteLine("Are you a Manager? [y/n]");
        string tempString = Console.ReadLine()!;
        if("t" == tempString || "y" == tempString) this.isManager = true; 
        
    }


public static void printListOfAccounts(List<Account> tempAccounts)
{
        foreach(Account a in tempAccounts)
        {
            Console.WriteLine(a);
        }


}



public override string ToString()
    {
        return $"ID:{this.EID} Name: {this.AccountName}, Manager Status: {this.isManager}, Username: {this.UserName}";
    }





} 
