﻿namespace Models;
using Services;
using System;

    /// <summary>
    /// This class holds the data for an expense. 
    /// </summary>
    /// <value>Test Value Bracket</value>
    /// There are a couple of ways of setting and getting used here. 
public class Expense
{
    //if no name for eName it is set to DateTime by default.
    public string ExpenseName {set; get;}
    public string ExpenseDescription {set; get;}
    public double Cost {set; get;}
    public bool Approved {get; set;}
    public int ExpenseID{get; set;} = 0;
    public string ExpenseDate {get; set;} ="";

//Can I replace these with something more efficent? 
//These are here because I want to return expenses with the proper user information.
//Should I use a dictionary instead and print off that? 
//although it makes it easier to return and change expenses in manager doing it this way as well.
    public string ExpenseUser{get; set;} = "";
    public string ExpenseAccountName{get; set;} = "";
    public int ExpenseEmpID{set; get;}

//end of copy of user information.
public Expense(){}
public Expense(int empID)
{
ExpenseEmpID = empID;
Console.WriteLine("Please enter the Expense Name: ");
ExpenseName = Console.ReadLine()!;
Console.WriteLine("Please enter Expense Discription");
ExpenseDescription = Console.ReadLine()!;
        while(true)
        {
        Console.WriteLine("Please Enter Expense Amount");
        bool success = Int32.TryParse( Console.ReadLine(), out int tempcost);
        if(success) {Cost = tempcost; break;}
        else FailureOnInput.ExpectedInt();
        }
        



}

            public override string ToString()
            {   
                if (this.ExpenseID == 0) return $"Name of Expense: {this.ExpenseName} Approval Sataus: {this.Approved} Cost: {this.Cost} \n  Expense Notes: {this.ExpenseDescription}\n  Expense Date {this.ExpenseDate}\n_________________";
                 return $"Expense ID {this.ExpenseID} Approval Sataus: {this.Approved}\n  Name of Expense: {this.ExpenseName} Cost: {this.Cost} \n  Employee Name:{this.ExpenseAccountName}\n  Expense Notes: {this.ExpenseDescription}\n  Expense Date {this.ExpenseDate}\n_________________";
            }









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






    */





}