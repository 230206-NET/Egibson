namespace project;
using DataAccess;
using Models;
using Serilog;




public class MainMenu{

    static void Main(string[] args)
    {
    Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("../logs/logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

while(true){

        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        Console.WriteLine("Hello and Welcome to the login screen");
        Console.WriteLine("1. Make a new account");
        Console.WriteLine("2. Login to your account.");
        Console.WriteLine("x. Exit Application.");
       
        
    string Selection;
   Selection = Console.ReadLine()!;
switch (Selection) 
{
  case "1":
    while(true)
    
    {
        Console.WriteLine("""
        --------------------------
        Starting Account Creation. 
        -------------------------
        """);
        Account newAccount = new Account();
        newAccount.setAccount();
        int returnID = DBConnector.UploadUser(newAccount, Secrets.getConnectionString());
        newAccount.EID = returnID;
          if (returnID == 0) 
          {
            Services.FailureOnInput.inputWasBad();
            continue;
          }
        Console.WriteLine("Sucess the user was created");  
        Console.WriteLine($"ID {returnID}");
        Console.WriteLine(newAccount);
    break;
    }
    break;
  case "2":
    string inputConinue = "y";
    string username="";
    string password="";
    while(inputConinue == "y")
    {
        Console.WriteLine("Starting Login");
        Console.WriteLine("Please Enter you Username");
        username = Console.ReadLine()!;
        Console.WriteLine("Please Enter you Password");
        password = Services.passWordClass.passwordInput();
        int returnedID = DBConnector.Isthisauser(Secrets.getConnectionString(), username, password);
        if(returnedID == 0) 
          {
              Console.WriteLine("Not a valid User/password combination.");
              Console.WriteLine("Would you like to try logging in again? [y,n]");
              inputConinue = Console.ReadLine()!;
          }
          else if(DBConnector.isManager(Secrets.getConnectionString(), username, password))
                    {MainMenu.PostLoginManager(returnedID); break;}
                    else {
                      MainMenu.PostLoginEmployee(returnedID); break;}

    }
    break;
  case "x": System.Environment.Exit(1);
    break;
}
    
    }
    }

public static void PostLoginManager(int emplyeeID)
{
Console.WriteLine("Welcome to Post Login as a Manager");
Console.WriteLine("Now that you are here what would you like to do?");
bool stayloggedin=true;
while(stayloggedin)
  {
          Console.WriteLine("You Options are: ");
          Console.WriteLine("1. Create an Expense");
          Console.WriteLine("2. Get All Expenses");
          Console.WriteLine("3. Approve an Expense");
          Console.WriteLine("4. Promote/Demote User to Manager/Employee");
          Console.WriteLine("5. LogOUT!");
          string plmSelection = Console.ReadLine()!;
          switch(plmSelection)
          {
          case "1":
          Expense newExpense = new Expense(emplyeeID);
          int expID = 0;
          expID = DBConnector.UploadExpense(Secrets.getConnectionString(), newExpense);
          if(expID == 0) {Services.FailureOnInput.inputWasBad();}
          break;
          case "2": List<Expense> expensesToPrint = new List<Expense>();
          expensesToPrint = DBConnector.GetAllExpenses(Secrets.getConnectionString());
          foreach(Expense e in expensesToPrint)
          {
            Console.WriteLine(e);
          }
          break;
          case "3": 
            int aInput =0;
            while(true)
              {
                  Console.WriteLine("Welcome to Expense Approval");
                  Console.WriteLine("You may enter anything other than a number to exit approval.");
                  Console.WriteLine("1. Get Unapproved Expenses");
                  Console.WriteLine("2. Make an Approval");
                  bool aValid = Int32.TryParse(Console.ReadLine(), out aInput);
                  if (aValid == false) break;
                  if (aInput != 1 && aInput != 2) continue; 
                      if (aInput == 1) 
                      {
                        List<Expense> approvalExpensesToPrint = new List<Expense>();
                        approvalExpensesToPrint = DBConnector.GetAllExpensesNotApproved(Secrets.getConnectionString());
                        foreach(Expense e in approvalExpensesToPrint)
                                {
                                  Console.WriteLine(e);
                                }

                      }//end option 1.
                      if(aInput == 2)
                        {
                              Console.WriteLine("Please enter an expense ID to approve or anything other than a number to exit.");
                              bool bValid = Int32.TryParse(Console.ReadLine(), out int eID);
                              if (bValid == false) break;
                              int returnedexpID = DBConnector.ApproveExpense(Secrets.getConnectionString(), eID);
                              if(returnedexpID == 0) Console.WriteLine("That did not work! Is the ID wrong?");
                              else Console.WriteLine(" Expense with ID: " + returnedexpID + " Was removed");

                        }
                      
              }
          break;
          case "4": bool stay = true;
                    while(stay){
                      Console.WriteLine(""" 
                      Premote and Demote Screen
                      ------------------------
                      Selections
                      1. Get All Accounts
                      2. Premote a user to manager
                      3. Demote user to Employee
                      x. Leave Screen                      
                      """);
                      Console.Write("=>");
                      string promoteSelection = Services.FailureOnInput.checkString();
                      int EID = 0;
                      switch(promoteSelection){
                      case "1": List<Account> tempAccounts = new List<Account>();
                                tempAccounts = DBConnector.GetAllAccounts(Secrets.getConnectionString());
                                Account.printListOfAccounts(tempAccounts);
                      break;
                      case "2":Console.WriteLine("What is the UserID of the user?");
                                EID = Services.FailureOnInput.checkINT();
                                DBConnector.PromoteDemoteUser(Secrets.getConnectionString(),EID,true); 
                      break;
                      case "3": Console.WriteLine("What is the UserID of the user?");
                                EID = Services.FailureOnInput.checkINT();
                                DBConnector.PromoteDemoteUser(Secrets.getConnectionString(),EID,false);
                      break;
                      case "x": stay = false;
                      break;
                      }
                      
                    }
                    
                    
          break;
          case "5": stayloggedin = false;
          break;
          } //switch end

} //While end

} //PostLoginManager end


public static void PostLoginEmployee(int employeeID)
{
Console.WriteLine("Welcome to Post Login as a User");
Console.WriteLine("Now that you are here what would you like to do?");
bool stayloggedin=true;
while(stayloggedin)
  {
          Console.WriteLine("You Options are: ");
          Console.WriteLine("1. Create an Expense");
          Console.WriteLine("2. Check all my expenses");
          Console.WriteLine("3. LogOut");
          Console.WriteLine("");
          String pleSelection = Console.ReadLine()!;
          switch(pleSelection)
          {
          case "1":
          Expense newExpense = new Expense(employeeID);
          int expID = 0;
          expID = DBConnector.UploadExpense(Secrets.getConnectionString(), newExpense);
          if(expID == 0) {Console.WriteLine("Expense input Failed");}
          break;
          case "2": List<Expense> expensesToPrint = new List<Expense>();
          expensesToPrint = DBConnector.GetMyExpenses(Secrets.getConnectionString(), employeeID);
          foreach(Expense e in expensesToPrint)
          {
            Console.WriteLine(e);
          }
          break;
          case "3": stayloggedin = false;
          break;


          } //switch end

  } //while end



}


}