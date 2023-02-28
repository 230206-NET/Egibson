namespace DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;
using Models;
using Serilog;

public class DBConnector {

public static int UploadUser(Account AccountToCreate, string connectionString)
{   
        try
        {
    //This next statement sets up the db connection.
    using (SqlConnection connection = new SqlConnection(
               connectionString))
    {

        //Here we have a new command that we formulate.
        //parameterize our insert statment, @
        //Dont't ever conctenate or use string interpolation for sql command, as it is vulnerable to SQL Injection. 
        using SqlCommand command = new SqlCommand("INSERT INTO Users (AccountName, ISManager, UserName, Password) OUTPUT INSERTED.EmployeeId VALUES (@AccountName, @ISManager, @UserName, @Password);", connection);
        command.Parameters.AddWithValue("@AccountName", AccountToCreate.AccountName);
        command.Parameters.AddWithValue("@ISManager", AccountToCreate.isManager);
        command.Parameters.AddWithValue("@UserName", AccountToCreate.UserName);
        command.Parameters.AddWithValue("@Password", AccountToCreate.Password);
        command.Connection.Open();
        //command.ExecuteNonQuery(); this will run the insert command without returning anything.
        int CreatedID = (int) command.ExecuteScalar(); //will return the id of the row. 
        return CreatedID;
    }
        }
        catch(System.Data.SqlClient.SqlException ex)
        {   

            DisplaySqlErrors(ex);
            return 0;
        }

        
}


public static int UploadExpense(string connectionString, Expense ExpenseToUpload)
{   
        try
        {
    //This next statement sets up the db connection.
    using (SqlConnection connection = new SqlConnection(
               connectionString))
    {

        //Here we have a new command that we formulate.
        //parameterize our insert statment, @
        //Dont't ever conctenate or use string interpolation for sql command, as it is vulnerable to SQL Injection. 
        using SqlCommand command = new SqlCommand("INSERT INTO Expenses (ExpenseAmmount, ExpenseName, ExpenseNote, Approved, EmployeeID) OUTPUT INSERTED.ExpenseID VALUES (@ea, @ename, @en, @app, @empID);", connection);
        command.Parameters.AddWithValue("@ea", ExpenseToUpload.Cost);
        command.Parameters.AddWithValue("@ename", ExpenseToUpload.ExpenseName);
        command.Parameters.AddWithValue("@en", ExpenseToUpload.ExpenseDescription);
        command.Parameters.AddWithValue("@app", ExpenseToUpload.Approved);
        command.Parameters.AddWithValue("@empID", ExpenseToUpload.ExpenseEmpID);

        command.Connection.Open();
        //command.ExecuteNonQuery(); this will run the insert command without returning anything.
        int CreatedID = (int) command.ExecuteScalar(); //will return the id of the row. 
        return CreatedID;
    }
        }
        catch(System.Data.SqlClient.SqlException ex)
        {   

            DisplaySqlErrors(ex);
            return 0;
        }

        
}



//SqlErrorCollection Class Implements ICollection, IEnumerable
//
private static void DisplaySqlErrors(SqlException exception)
{

        for (int i = 0; i < exception.Errors.Count; i++)
    {   

        if(exception.Errors[i].ToString().Contains("Violation of UNIQUE KEY"))
        Console.WriteLine("Username Already Exists, Aborting");
    }
    Console.ReadLine();
}


 public static List<Account> GetAllAccounts(string connectionString)
    {   List<Account> Accounts = new();

            Console.WriteLine("Attemping to fetch user accounts");
            
            try
            {

            using (SqlConnection connection = new SqlConnection(
               connectionString))
               {

                
                using SqlCommand command = new SqlCommand("SELECT * FROM Users;", connection);
                command.Connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            { 
                while(reader.Read()) 
                {
                    string an = (string) reader["AccountName"];
                    int id = (int) reader["EmployeeID"];
                    bool im = (bool) reader ["IsManager"];
                    string u = (string) reader["UserName"];

                    Account Account = new Account {
                        EID = id,
                        UserName = u,
                        AccountName = an,
                        isManager = im

                    };
                    Accounts.Add(Account);

               }
            }

            }
            
     }
     catch(Exception ex)
        {
            throw;
        }
     return Accounts;
     
     }

     public static List<Expense> GetAllExpenses(string connectionString)
    {   List<Expense> expenses = new();
            
            try
            {

            using (SqlConnection connection = new SqlConnection(
               connectionString))
               {

                
                using SqlCommand command = new SqlCommand("Select ExpenseID, AccountName, UserName,CONVERT(varchar(10), [CreationDate], 20) as CreationDatestring, ExpenseAmmount, ExpenseNote, Approved from users right join expenses on users.EmployeeID = expenses.EmployeeID;", connection);
                command.Connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            { 
                while(reader.Read()) 
                {
                    int eid = (int) reader["ExpenseID"];
                    string an = (string) reader["AccountName"];
                    string  un = (string) reader ["UserName"];
                    string u = (string) reader["CreationDatestring"];
                    int ea = (int) reader["ExpenseAmmount"];
                    string en = (string) reader["ExpenseNote"];
                    bool ad = (bool) reader["Approved"];

                    Expense expense = new Expense(){
                        ExpenseID = eid,
                        ExpenseAccountName = an,
                        ExpenseUser = un,
                        ExpenseDate = u,
                        Cost = ea,
                        ExpenseDescription = en,
                        Approved = ad,
                    };
                    expenses.Add(expense);

               }
            }

            }
            
     }
     catch(Exception ex)
        {
            throw;
        }
     return expenses;
     
     }

 public static List<Expense> GetAllExpensesNotApproved(string connectionString)
    {   List<Expense> expenses = new();
            
            try
            {

            using (SqlConnection connection = new SqlConnection(
               connectionString))
               {

                
                using SqlCommand command = new SqlCommand("Select ExpenseID, AccountName, UserName,CONVERT(varchar(10), [CreationDate], 20) as CreationDatestring, ExpenseAmmount, ExpenseNote, Approved from users right join expenses on users.EmployeeID = expenses.EmployeeID where Expenses.Approved = 0;", connection);
                command.Connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            { 
                while(reader.Read()) 
                {
                    int eid = (int) reader["ExpenseID"];
                    string an = (string) reader["AccountName"];
                    string  un = (string) reader ["UserName"];
                    string u = (string) reader["CreationDatestring"];
                    int ea = (int) reader["ExpenseAmmount"];
                    string en = (string) reader["ExpenseNote"];
                    bool ad = (bool) reader["Approved"];

                    Expense expense = new Expense(){
                        ExpenseID = eid,
                        ExpenseAccountName = an,
                        ExpenseUser = un,
                        ExpenseDate = u,
                        Cost = ea,
                        ExpenseDescription = en,
                        Approved = ad,
                    };
                    expenses.Add(expense);

               }
            }

            }
            
     }
     catch(Exception ex)
        {
            throw;
        }
     return expenses;
     
     }

     public static List<Expense> GetMyExpenses(string connectionString, int empID)
    {   List<Expense> expenses = new();
            
            try
            {

            using (SqlConnection connection = new SqlConnection(
               connectionString))
               {

                
                using SqlCommand command = new SqlCommand("Select ExpenseName, CONVERT(varchar(10), [CreationDate], 20) as CreationDatestring, ExpenseAmmount, ExpenseNote, Approved from users right join expenses on users.EmployeeID = expenses.EmployeeID where expenses.EmployeeID = @myID;", connection);
                command.Parameters.AddWithValue("@myID", empID);
                command.Connection.Open();
                using SqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            { 
                while(reader.Read()) 
                {
                    string ename = (string) reader["ExpenseName"];
                    string u = (string) reader["CreationDatestring"];
                    int ea = (int) reader["ExpenseAmmount"];
                    string en = (string) reader["ExpenseNote"];
                    bool ad = (bool) reader["Approved"];

                    Expense expense = new Expense(){
                        ExpenseName = ename,
                        ExpenseDate = u,
                        Cost = ea,
                        ExpenseDescription = en,
                        Approved = ad,
                    };
                    expenses.Add(expense);

               }
            }

            }
            
     }
     catch(Exception ex)
        {
            throw;
        }
     return expenses;
     
     }

public static int ApproveExpense(string connectionString, int eID)
{
    Int32 appExpID = 0;
    string sql = "Update expenses set Approved = 1 where ExpenseID = @eID;";
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@eID", eID);

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            appExpID = eID;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    return appExpID;




}
public static void PromoteDemoteUser(string connectionString, int eID,bool selection)
{

    string sql = "Update Users set IsManager = @status where EmployeeID = @eID;";
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@eID", eID);
        cmd.Parameters.AddWithValue("@status", selection);

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {   
            Log.Warning(ex.Message);
            Console.WriteLine(ex.Message);
        }
    }




}
public static bool isManager(string connectionString, string username, string password)
{
    
    bool isMan = false;
    string sql = "Select isManager From [Users] where UserName = @a and [Password] = @b ;";
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@a", username);
        cmd.Parameters.AddWithValue("@b", password);
        try
        {
            conn.Open();
            isMan = (bool)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    return (bool)isMan;



}
     
static public int Isthisauser(string connectionString, string username, string password)
{
    Int32 newProdID = 0;
    string sql = "Select EmployeeID From [Users] where UserName = @a and [Password] = @b ;";
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@a", username);
        cmd.Parameters.AddWithValue("@b", password);
        try
        {
            conn.Open();
            newProdID = (Int32)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    return (int)newProdID;
}








}


 //public static List<Account> GetAllExpenses(string connectionString)