namespace Test;
using Models;
using Moq;

public class AccountTest
{

//testing the default constructor.
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
    //all of the inputs you would put in with new lines included.
    //so TestEmployee is the employee name
    //usernametest is the username
    //password test is the password. 
    //t is the input I expect for are they a manger.
        var input = new StringReader(@"TestEmployee
usernametest
passwordTest
t");
        Console.SetIn(input);

        Account act = new Account();
        act.setAccount();
    //this is the questions you ask when you getting input. Must be to the exact character including whitespace for good messure.
        var expectedOutput = @"Please Enter Employee name: 
What will your username be? :
What will your password be? :
Are you a Manager? [y/n]
";
        //here you will test if those inputs were set by the console.readline() inputs.
        Assert.Equal(expectedOutput, output.ToString());
        Assert.Equal("TestEmployee", act.AccountName);
        Assert.Equal("usernametest",act.UserName);
        Assert.Equal("passwordTest",act.Password);
        Assert.Equal(true,act.isManager);
    }


   

}