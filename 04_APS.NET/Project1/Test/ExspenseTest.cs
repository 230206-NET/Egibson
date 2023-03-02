namespace Test;
using Models;
using Moq;
public class ExpenseTest
{
    [Fact]
    public void TrueMustBeTrue()
    {
        Assert.True(true);


    }

        [Fact]
    public void ExpenseEmptyConstructor()
    {
       
       //Act
       Expense exp = new Expense();
       
        Assert.Equal("",exp.ExpenseDate);
        Assert.Equal("",exp.ExpenseUser);
        Assert.Equal("",exp.ExpenseAccountName);
        Assert.Equal(0,exp.ExpenseID);


    }





    [Fact]
    public void createexpenseWithEID()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        var input = new StringReader(@"expense
something
100");
        Console.SetIn(input);

        Expense exp = new Expense(5);

        var expectedOutput = @"Please enter the Expense Name: 
Please enter Expense Discription
Please Enter Expense Amount
";
        
        Assert.Equal(expectedOutput, output.ToString());
        Assert.Equal(100, exp.Cost);
        Assert.Equal("expense",exp.ExpenseName);
        Assert.Equal("something",exp.ExpenseDescription);
        //Assert.Equal("""Expense ID {this.ExpenseID}\n Approval Sataus: {this.Approved}\n  Name of Expense: {this.ExpenseName} Cost: {this.Cost} \n  Employee Name:{this.ExpenseAccountName}\n  Expense Notes: {this.ExpenseDescription}\n  Expense Date {this.ExpenseDate}\n_________________""",exp.ToString());
    }



}