// See https://aka.ms/new-console-template for more information
// this is a comment. 
// double slash is a comment line. 
Console.WriteLine("Hello, World!");
Console.WriteLine("What is the big deal my friends? This is simple for me to do on my own");

Console.WriteLine("This is the start of your program.");
Console.WriteLine("Please input a number that will go into balance\n\n");

//here is the start of the balance section.
int Balance = Convert.ToInt32(Console.ReadLine());


if (Balance < 0)
{
	Console.WriteLine("You balance is negative");
}

if (Balance == 0)
{
	Console.WriteLine("Balance is Zero. You are out of Money!");
}

else 
{

	Console.WriteLine("Your Balance is:" + Balance);

}


Console.WriteLine("end of program");

 
