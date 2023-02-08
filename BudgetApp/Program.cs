
/*
Your app should be able to do the following
- Prompt the user to enter the initial budget
- Prompt the user to enter expenses with amount and description
- Display the all expenses and the remaining amount
*/



Console.WriteLine("Please Enter The ammount of your budget");

int BudgetAmmount = Int32.Parse(Console.ReadLine()!);

List<BudgetItem> UserBudget = new List<BudgetItem>();

while(true)
{
    Console.WriteLine("Please Enter the Description of the expense");
    string UserDesc = Console.ReadLine()!;
    Console.WriteLine("Please Enter the ammount of the expense");
    int  UserExp = Int32.Parse(Console.ReadLine()!);
    UserBudget.Add(new BudgetItem(UserExp, UserDesc));


    Console.WriteLine("Please enter y to continue or n to stop enetering items.");
    string Response = Console.ReadLine()!;
    if(Response == "y" )
    {
        continue;
    }
    if( Response  == "n") 
    {
        break;
    }
}

int ExpenseTotal = 0;
for(int i = 0; i < UserBudget.Count; i++)
{
Console.WriteLine("Item : " + UserBudget[i].GetDesc() + " Amount of item : " + UserBudget[i].GetExpense());
ExpenseTotal += UserBudget[i].GetExpense(); 
}
int RemainingAmount = BudgetAmmount - ExpenseTotal;
Console.WriteLine("The Remaining amount in your budget is : " + RemainingAmount);


public class BudgetItem
{
public int expense = 0;
//int BCount = 0; what Item on the budget it is. 
public string desc = "";

public BudgetItem(int ItemExpense, string ItemDesctiption)
{
    expense = ItemExpense;
    desc = ItemDesctiption;
}

public int GetExpense()
{
    return expense;
}
public string GetDesc()
{
    return desc;
}


// void BCountIncrease(){BudgetItem.BCount++} this might increase the the count of the budget item.

}