namespace Models;
using System;
public class Employee
{
    //EmployeeName
    //EmployeeID
    //EmployeeIsManager
    
    
    public string EmployeeName 
     {
            get { return EmployeeName; }
            set {
                bool inputStringBool = string.IsNullOrEmpty(value);
                if(!inputStringBool)
                EmployeeName = value;
                else EmployeeName=value; //ToDo: can add proper validation here later.
                }
        }
    public int EmployeeID{get; set;} // ToDo: ask the database for the next Employee ID available. 
    protected bool  EmployeeIsManager {get; set;} = false;
    //public bool EmployeeHasLogin {set; get;}
   
    public Employee(int eID, bool isManager, string name)
    {
        this.EmployeeName = name;
        this.EmployeeIsManager = isManager;
        this.EmployeeID = eID;
    }
    public Employee(string name, bool isManager)
    {
        this.EmployeeName = name;
        this.EmployeeIsManager = isManager;
        this.EmployeeID = 999;
    }
        public Employee(string name)
    {
        this.EmployeeName = name;
        this.EmployeeID = 999;
    }

    public Employee()
    {

        Console.WriteLine("Please Enter Emplyee Name.");
        this.EmployeeName = Console.ReadLine() ?? throw new ArgumentNullException("Name must not be null or empty.");
        
        Console.WriteLine("Please Enter Employee ID");
        if(!Int32.TryParse(Console.ReadLine(), out int number))
        {
             throw new ArgumentNullException("Name must not be null or empty.");
        }
        else this.EmployeeID = number;
        Console.WriteLine("Please Enter Value for is manager [t,f]");
        if(Console.ReadLine() == "t") this.EmployeeIsManager = true;
        else Console.WriteLine("they will not be set as a manager.");
        

    }



    }


   
   
    /* ToDO:
    
    public override string ToString()
    {
        return $"Name: {this.EmployeeName}\nID:{this.EmployeeID}\nIs a manager{EmployeeIsManager}";
    }
    
    
    */



