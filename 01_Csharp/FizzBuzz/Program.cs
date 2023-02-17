


namespace FizzBuzz;
    public class MainMenu
    {
        public void Start()
        {



/*
Given a posative intiger, print the following. 


*/
//Reading user input bia console.readline method, which returns string.
Console.WriteLine("Please enter a posative int! ");
int Userinput = 0;
try{
Userinput = Int32.Parse(Console.ReadLine()!);
Console.WriteLine("This is what you entered :" + Userinput);

}
catch(FormatException ex){
Console.WriteLine("I caught a format exception{0}", ex);


}

        for(int i=0; i <= Userinput; i++)
        {
                if (i % 3 == 0 && Userinput % 5 ==0)
                {
                    Console.WriteLine("FizzBuzz");

                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");

                }
                else if (i % 5 == 0)
                {
                Console.WriteLine("Buzz");
                }
            
                else{ Console.WriteLine("Neither Fizz or Buzz"); }

        }




        }


    }

