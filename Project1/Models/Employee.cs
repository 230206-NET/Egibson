/*
namespace Models;
using System;
public class Employee
{
    //EmployeeName
    //EmployeeID
    //EmployeeIsManager
    
    
    public string EmployeeName {get; set;}
    public int EmployeeID{get; set;} // ToDo: ask the database for the next Employee ID available. 
    public bool  EmployeeIsManager {get; set;} = false;
    //public bool EmployeeHasLogin {set; get;}
   
    public Employee( bool isManager, string name)
    {
        this.EmployeeName = name;
        this.EmployeeIsManager = isManager;
    }
    public Employee(string name, bool isManager)
    {
        this.EmployeeName = name;
        this.EmployeeIsManager = isManager;
    }
        public Employee(string name)
    {
        this.EmployeeName = name;
    }

    public Employee setUpNewEmployee(Employee newEmployee)
    {

        while(true)
        {
            Console.WriteLine("Please Enter Emplyee Name.");
            string eName = "Debra";
            //this.EmployeeName = Console.ReadLine() ?? throw new ArgumentNullException("Name must not be null or empty.");
            eName = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(eName))
            {
                Console.WriteLine($"Name invalid {eName}");
                continue;
            }
            else
            {
                    newEmployee.EmployeeName = eName;
                    break;
            }

        }
        
        Console.WriteLine("Please Enter Value for is manager [t,f]");
        if(Console.ReadLine() == "t") newEmployee.EmployeeIsManager = true;
        else Console.WriteLine("they will not be set as a manager.");

    return newEmployee;
    }


    }


   
   
 ToDO:
    
    public override string ToString()
    {
        return $"Name: {this.EmployeeName}\nID:{this.EmployeeID}\nIs a manager{EmployeeIsManager}";
    }
    
    
    */


