using System;
namespace FactoryMethodDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CreditCard creditCard = new PlatinumFactory().CreateProduct(); //notice we are using CreateProduct
            if (creditCard != null)
            {
                Console.WriteLine("Card Type : " + creditCard.GetCardType());
                Console.WriteLine("Credit Limit : " + creditCard.GetCreditLimit());
                Console.WriteLine("Annual Charge :" + creditCard.GetAnnualCharge());
            }
            else
            {
                Console.Write("Invalid Card Type");
            }
            Console.WriteLine("--------------");
            creditCard = new MoneyBackFactory().CreateProduct();
            if (creditCard != null)
            {
                Console.WriteLine("Card Type : " + creditCard.GetCardType());
                Console.WriteLine("Credit Limit : " + creditCard.GetCreditLimit());
                Console.WriteLine("Annual Charge :" + creditCard.GetAnnualCharge());
            }
            else
            {
                Console.Write("Invalid Card Type");
            }
            Console.ReadLine();

            Console.WriteLine("Thank you DotNet Tutorials \n https://dotnettutorials.net/lesson/factory-method-design-pattern-csharp/");
        }
    }
}