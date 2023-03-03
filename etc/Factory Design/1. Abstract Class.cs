namespace FactoryMethodDesignPattern
{
    //Step 1.
    //provide the signature of the common functionalities
    //An interface is a completely "abstract class", which can only contain abstract methods and properties
    // WE don't provide logic. You provide logic in child classes.
    public interface CreditCard 
    {
        string GetCardType();
        int GetCreditLimit();
        int GetAnnualCharge();
    }
}