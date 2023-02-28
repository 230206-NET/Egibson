namespace Test;
using Models;
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

}