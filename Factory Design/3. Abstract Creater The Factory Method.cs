namespace FactoryMethodDesignPattern
{


    //CreditCardFactory
    //factory class with a publicly exposed method. 
    public abstract class CreditCardFactory //Note this is abstract.
    {
        protected abstract CreditCard MakeProduct(); //create an abstract meathod or interface for creating the object.

        public CreditCard CreateProduct()
        {
//The factory method which will return the instance of the product. 
//The CreateProduct() method internally calls the MakeProduct() method of the subclass //We will define make product in the subclass
//which will create the product instance and return that instance.
            return this.MakeProduct(); //Go to 4.
        }
    }
}