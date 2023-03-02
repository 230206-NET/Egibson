namespace Test;
using Models;
using Moq;

public class AccountTest
{


        [Fact]
    public void AccountEmptyConstructor()
    {
       
       //Act
       Account act = new Account();
       
       //Assert.Throws()
        Assert.Equal("",act.UserName);
        Assert.Equal("",act.Password);
        Assert.NotEqual(true,act.isManager);
        Assert.Equal("",act.AccountName);


    }


[Fact]
    public void setAccount()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        var input = new StringReader(@"TestEmployee
usernametest
passwordTest
t");
        Console.SetIn(input);

        Account act = new Account();
        act.setAccount();

        var expectedOutput = @"Please Enter Employee name: 
What will your username be? :
What will your password be? :
Are you a Manager? [y/n]
";
        
        Assert.Equal(expectedOutput, output.ToString());
        Assert.Equal("TestEmployee", act.AccountName);
        Assert.Equal("usernametest",act.UserName);
        Assert.Equal("passwordTest",act.Password);
        Assert.Equal(true,act.isManager);
    }


   

}