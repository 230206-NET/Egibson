namespace Models;
using System;

    /// <summary>
    /// This class holds the data for an expense. 
    /// </summary>
    /// <value>Test Value Bracket</value>
    /// There are a couple of ways of setting and getting used here. 
public class Expense
{
    //if no name for eName it is set to DateTime by default.
    public string ExpenseName
        {
            
        get { return ExpenseName; }
        set {
            bool inputStringBool = string.IsNullOrEmpty(value);
            if(!inputStringBool)
            ExpenseName = value + DateTime.Now.ToString("dddd, dd MMMM yyyy");
            else ExpenseName =  "Didn't include input " + DateTime.Now.ToString("dddd, dd MMMM yyyy");
            }
        }
    public string ExpenseDescription
        {
            get { return ExpenseDescription; }
            set {
                bool inputStringBool = string.IsNullOrEmpty(value);
                if(!inputStringBool)
                ExpenseDescription = value;
                else ExpenseDescription =  "Didn't include input " + DateTime.Now.ToString("dddd, dd MMMM yyyy");
                }
        }
    public double Cost {set; get;}
    











    /* ToDo:

    ### This will be were I put anything outside of MVP for the time being. ###
            public int eID 
            {   get => eID;
                set
                {
                    //this sets the current expense object's eID to the 'value' passed in. value is a keyword for the value passed in. 
                    //ToDO: validate the input here. int eIDNew = int.TryParse(value, out eIDNew) ;
                    this.eID = value;
                }
            }


            public override string ToString()
            {
                return $"Name: {this.eName}\nExpenseDescription: {this.ExpenseDescription}\nCost: {Cost}";
            }



    */





}
