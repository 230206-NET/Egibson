namespace Test;
using Models;
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

    


}