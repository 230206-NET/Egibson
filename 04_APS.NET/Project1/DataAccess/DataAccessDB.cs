﻿namespace DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;
using Models;
using Serilog;

public class DBConnector {

// public DBConnector dbconn = new DBConnector();

private readonly string _connectionString;
public DBConnector(string connectionString)
{
    _connectionString = connectionString;

}
public static int UploadUser(Account AccountToCreate, string _connectionString)
{   
        try
        {
    //This next statement sets up the db connection.
    using (SqlConnection connection = new SqlConnection(
               _connectionString))
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


public static int UploadExpense(string _connectionString, Expense ExpenseToUpload)
{   
        try
        {
    //This next statement sets up the db connection.
    using (SqlConnection connection = new SqlConnection(
               _connectionString))
    {

        //Here we have a new command that we formulate.
        //parameterize our insert statment, @
        //Dont't ever conctenate or use string interpolation for sql command, as it is vulnerable to SQL Injection. 
        using SqlCommand command = new SqlCommand("INSERT INTO Expenses (ExpenseAmmount, ExpenseName, ExpenseNote, EmployeeID, ExpenseDate) OUTPUT INSERTED.ExpenseID VALUES (@ea, @ename, @en, @empID, @eDate);", connection);
        command.Parameters.AddWithValue("@ea", ExpenseToUpload.Cost);
        command.Parameters.AddWithValue("@ename", ExpenseToUpload.ExpenseName);
        command.Parameters.AddWithValue("@en", ExpenseToUpload.ExpenseDescription);
        command.Parameters.AddWithValue("@empID", ExpenseToUpload.ExpenseEmpID);
        string dateString = DateTime.Now.ToString();
        command.Parameters.AddWithValue("@EDate", dateString);

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


 public static List<Account> GetAllAccounts(string _connectionString)
    {   List<Account> Accounts = new();

            Console.WriteLine("Attemping to fetch user accounts");
            
            try
            {

            using (SqlConnection connection = new SqlConnection(
               _connectionString))
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

     public static List<Expense> GetAllExpenses(string _connectionString)
    {   List<Expense> expenses = new();
            
            try
            {

            using (SqlConnection connection = new SqlConnection(
               _connectionString))
               {

                
                //using SqlCommand command = new SqlCommand("Select ExpenseID, ExpenseName, AccountName, UserName, ExpenseDate, ExpenseAmmount, ExpenseNote, Approved from users right join expenses on users.EmployeeID = expenses.EmployeeID;", connection);
                using SqlCommand command = new SqlCommand("Select ExpenseID, ExpenseName, AccountName, UserName, ExpenseDate, ExpenseAmmount, ExpenseNote, users.EmployeeID, Approved from users right join expenses on users.EmployeeID = expenses.EmployeeID;", connection);

                //Select ExpenseID, ExpenseName, AccountName, UserName, ExpenseDate, ExpenseAmmount, ExpenseNote, users.EmployeeID, Approved from users right join expenses on users.EmployeeID = expenses.EmployeeID;

                command.Connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            { 
                while(reader.Read()) 
                {
                    int eid = (int) reader["ExpenseID"];
                    string expName = (string) reader["ExpenseName"];
                    string an = (string) reader["AccountName"];
                    string  un = (string) reader ["UserName"];
                    string u = (string) reader["ExpenseDate"];
                    int ea = (int) reader["ExpenseAmmount"];
                    string en = (string) reader["ExpenseNote"];
                    int eeID = (int) reader["EmployeeID"];
                    bool ad = (bool) reader["Approved"];

                    Expense expense = new Expense(){
                        ExpenseID = eid,
                        ExpenseName = expName,
                        ExpenseAccountName = an,
                        ExpenseUser = un,
                        ExpenseDate = u,
                        Cost = ea,
                        ExpenseDescription = en,
                        Approved = ad,
                        ExpenseEmpID = eeID,
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
      public static List<Expense> ExpensesPending(string _connectionString)
    {   List<Expense> expenses = new();
            
            try
            {

            using (SqlConnection connection = new SqlConnection(
               _connectionString))
               {

                
                //using SqlCommand command = new SqlCommand("Select ExpenseID, ExpenseName, AccountName, UserName, ExpenseDate, ExpenseAmmount, ExpenseNote, Approved from users right join expenses on users.EmployeeID = expenses.EmployeeID;", connection);
                using SqlCommand command = new SqlCommand("Select ExpenseID, ExpenseName, AccountName, UserName, ExpenseDate, ExpenseAmmount, ExpenseNote, users.EmployeeID, Approved from users right join expenses on users.EmployeeID = expenses.EmployeeID where approved = 0;", connection);

                //Select ExpenseID, ExpenseName, AccountName, UserName, ExpenseDate, ExpenseAmmount, ExpenseNote, users.EmployeeID, Approved from users right join expenses on users.EmployeeID = expenses.EmployeeID;

                command.Connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            { 
                while(reader.Read()) 
                {
                    int eid = (int) reader["ExpenseID"];
                    string expName = (string) reader["ExpenseName"];
                    string an = (string) reader["AccountName"];
                    string  un = (string) reader ["UserName"];
                    string u = (string) reader["ExpenseDate"];
                    int ea = (int) reader["ExpenseAmmount"];
                    string en = (string) reader["ExpenseNote"];
                    int eeID = (int) reader["EmployeeID"];
                    bool ad = (bool) reader["Approved"];

                    Expense expense = new Expense(){
                        ExpenseID = eid,
                        ExpenseName = expName,
                        ExpenseAccountName = an,
                        ExpenseUser = un,
                        ExpenseDate = u,
                        Cost = ea,
                        ExpenseDescription = en,
                        Approved = ad,
                        ExpenseEmpID = eeID,
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

 public static List<Expense> GetAllExpensesNotApproved(string _connectionString)
    {   List<Expense> expenses = new();
            
            try
            {

            using (SqlConnection connection = new SqlConnection(
               _connectionString))
               {

                
                using SqlCommand command = new SqlCommand("Select * from deletedexpenses where approved = 0", connection);
                command.Connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            { 
                while(reader.Read()) 
                {
                    int eid1 = (int) reader["EmpID"];
                    string uedate1 = (string) reader["ExpDate"];
                    int ea1 = (int) reader["ExpenseAmmount"];
                    string en1 = (string) reader["ExpenseNote"];
                    bool ad1 = (bool) reader["Approved"];
                    string expensenames1 = (string) reader["ExpenseName"];

                    Expense expense = new Expense(){
                        ExpenseID = eid1,
                        ExpenseDate = uedate1,
                        Cost = ea1,
                        ExpenseDescription = en1,
                        Approved = ad1,
                        ExpenseName = expensenames1,
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

     public static List<Expense> GetMyExpenses(string _connectionString, int empID)
    {   List<Expense> expenses = new();
            
            try
            {

            using (SqlConnection connection = new SqlConnection(
               _connectionString))
               {

                
                using SqlCommand command = new SqlCommand("Select ExpenseName, ExpenseID, ExpenseDate, ExpenseAmmount, ExpenseNote, users.EmployeeID, Approved from users right join expenses on users.EmployeeID = expenses.EmployeeID where expenses.EmployeeID = @myID;", connection);
                command.Parameters.AddWithValue("@myID", empID);
                command.Connection.Open();
                using SqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            { 
                while(reader.Read()) 
                {
                    string ename = (string) reader["ExpenseName"];
                    string dt = (string) reader["ExpenseDate"];
                    int ea = (int) reader["ExpenseAmmount"];
                    string en = (string) reader["ExpenseNote"];
                    int emplID = (int) reader["EmployeeID"];
                    int emxlID = (int) reader["ExpenseID"];
                    bool ad = (bool) reader["Approved"];

                    Expense expense = new Expense(){
                        ExpenseName = ename,
                        ExpenseDate = dt,
                        Cost = ea,
                        ExpenseDescription = en,
                        Approved = ad,
                        ExpenseEmpID = emplID,
                        ExpenseID = emplID,
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


public static List<Expense> GetDeleted(string _connectionString)
    {   List<Expense> expenses = new();
            
            try
            {

            using (SqlConnection connection = new SqlConnection(
               _connectionString))
               {

                
                using SqlCommand command = new SqlCommand("get_removed", connection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                using SqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            { 
                while(reader.Read()) 
                {
                    string ename = (string) reader["ExpenseName"];
                    int ExpenseID = (int) reader["ExpenseID"];
                    int ea = (int) reader["ExpenseAmmount"];
                    string en = (string) reader["ExpenseNote"];
                    string dt = (string) reader["ExpDate"];
                    int empoyID = (int) reader["EmpID"];
                    bool approvval = (bool) reader["Approved"];

                    Expense expense = new Expense(){
                        ExpenseName = ename,
                        Cost = ea,
                        ExpenseDescription = en,
                        ExpenseEmpID = empoyID,
                        ExpenseDate = dt,
                        Approved = approvval,
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

public static int ApproveExpense(string _connectionString, int eID)
{
    Int32 appExpID = 0;
    string sql = "Update expenses set Approved = 1 where ExpenseID = @eID;";
    using (SqlConnection conn = new SqlConnection(_connectionString))
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
public static void removeExpense(string _connectionString, int expID)
{
    string sql = "remove_expense";
    using (SqlConnection conn = new SqlConnection(_connectionString))
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@expID", expID);

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
public static void PromoteDemoteUser(string _connectionString, int eID,bool selection)
{

    string sql = "Update Users set IsManager = @status where EmployeeID = @eID;";
    using (SqlConnection conn = new SqlConnection(_connectionString))
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
public static bool isManager(string _connectionString, string username, string password)
{
    
    bool isMan = false;
    string sql = "Select isManager From [Users] where UserName = @a and [Password] = @b ;";
    using (SqlConnection conn = new SqlConnection(_connectionString))
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
     
static public int Isthisauser(string _connectionString, string username, string password)
{
    Int32 userID = 0;
    string sql = "Select EmployeeID From [Users] where UserName = @a and [Password] = @b ;";
    using (SqlConnection conn = new SqlConnection(_connectionString))
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@a", username);
        cmd.Parameters.AddWithValue("@b", password);
        try
        {
            conn.Open();
            userID = (Int32)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    return (int)userID;
}








}


 //public static List<Account> GetAllExpenses(string _connectionString)