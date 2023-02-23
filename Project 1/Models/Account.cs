using System;
namespace Models;

/// <summary>
/// This class needs a employee made to use.
/// </summary>
public class Account
{  
 
    
    string UserName 
    {
        get{return this.UserName;} 
        
        set {
                bool UserNameIsNull = string.IsNullOrEmpty(value);
                if(!UserNameIsNull) 
                throw new ArgumentNullException("Username must not be null or empty.");
            
            }
    }


    string Password
        {
        get{return this.Password;} 
        
        set {
                bool PasswordIsNull = string.IsNullOrEmpty(value);
                if(!PasswordIsNull) 
                throw new ArgumentNullException("Password must not be null or empty.");
            
            }
    }
    bool isManager{get; set;} = false;
    public string AccountName {set; get;} = "";
    public int EID {set; get;} 
  
    public void CreateAccount(string user, string pass, bool MangerStatus)
    {   
        this.UserName = user;
        this.Password = pass;
        this.isManager = MangerStatus;
        Employee e = new Employee();
        this.AccountName = e.EmployeeName;
        this.EID = e.EmployeeID;
        //return true; we may want to return true when created
    }
   // public void CreateAccount(ref Employee e)
   // {


   // }


}
