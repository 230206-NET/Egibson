namespace FactoryMethodDesignPattern
{
    //The Concrete Creator object overrides the factory method to return an instance of a Concrete Product.
    public class MoneyBackFactory : CreditCardFactory //implementation for the abstract .3 CreditCardFactory class
    {
        protected override CreditCard MakeProduct()  //Overrides the Make Product of the Factory Method.
        {
            CreditCard product = new MoneyBack(); //Returns Concrete Product. of type .1 Credit Card
            return product;
        }
    }

    public class PlatinumFactory : CreditCardFactory
    {
        protected override CreditCard MakeProduct()
        {
            CreditCard product = new Platinum();
            return product;
        }
    }

    public class TitaniumFactory : CreditCardFactory
    {
        protected override CreditCard MakeProduct()
        {
            CreditCard product = new Titanium();
            return product;
        }
    }
}