using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using DataAccess;
using Services;
using Models;

var builder = WebApplication.CreateBuilder(args);

// AddSingleton => The same instance is shared across the entire app over the lifetime of the application
// AddScoped => The instance is created every new request
// AddTransient => The instance is created every single time it is required as a dependency 
// builder.Services.AddScoped<IRepository, DBRepository>();
// builder.Services.AddScoped<WorkoutService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DBConnector>(ctx => new  DBConnector(builder.Configuration.GetConnectionString("MyDB")));
builder.Services.AddScoped<Account>();
builder.Services.AddScoped<Expense>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
//GetAllExpenses
app.MapGet("/expenses", ( [FromServices] DBConnector conn) => {

    return DBConnector.GetAllExpenses(builder.Configuration.GetConnectionString("MyDB"));
});

//GetAllAccounts
app.MapGet("/accounts", ( [FromServices] DBConnector conn) => {

    return DBConnector.GetAllAccounts(builder.Configuration.GetConnectionString("MyDB"));
});


//GetMyExpenses
app.MapGet("/expenses/{id}", ([FromServices] DBConnector db, int id) =>
{ return DBConnector.GetMyExpenses(builder.Configuration.GetConnectionString("MyDB"), id);
});


//This will give the user ID back if success. //Isthisauser
app.MapGet("/account/{id}/{password}", ([FromServices] DBConnector db, string id, string password) =>
{ return DBConnector.Isthisauser(builder.Configuration.GetConnectionString("MyDB"), id, password);
});

//isManager
app.MapGet("/account/m/{id}/{password}", ([FromServices] DBConnector db, string id, string password) =>
{ return DBConnector.isManager(builder.Configuration.GetConnectionString("MyDB"), id, password);
});

//GetAllExpensesNotApproved //pending
app.MapGet("/expenses/p/", ([FromServices] DBConnector db) =>
{ return DBConnector.GetAllExpensesNotApproved(builder.Configuration.GetConnectionString("MyDB"));
});

//Upload Expense
app.MapPost("/expense/create/{expEmpId}/{expName}/{expDescription}/{Cost}/{expAcctName}", ([FromBody] Expense exp, DBConnector db, int Cost, string expName, string expAcctName, string expDescription, int expEmpId) => {
    
    exp.Cost = Cost;
    exp.ExpenseName = expName;
    exp.ExpenseDate = DateTime.Now.ToString();
    exp.ExpenseAccountName = expAcctName;
    exp.ExpenseDescription = expDescription;
    exp.ExpenseEmpID =expEmpId;
    
    
    return Results.Created("/expense", DBConnector.UploadExpense(builder.Configuration.GetConnectionString("MyDB"), exp));
});
//usercreation
app.MapPost("/account/create/{accountName}/{userName}/{passWord}", ([FromBody] Account act, DBConnector db, string accountName, string userName, string passWord) => {
    
    act.Password=passWord; 
    act.UserName=userName;
    act.isManager=false;
    act.AccountName=accountName;
    
    return Results.Created("/account", DBConnector.UploadUser(act, builder.Configuration.GetConnectionString("MyDB")));

});
            
//ApproveExpense
app.MapPut("/expense/{id}", async (int id, DBConnector db) =>
{
  
    DBConnector.ApproveExpense(builder.Configuration.GetConnectionString("MyDB"), id);
    return Results.NoContent();
});
//removeExpense
app.MapPut("/expense/remove/{id}", async (int id, DBConnector db) =>
{
  
    DBConnector.removeExpense(builder.Configuration.GetConnectionString("MyDB"), id);
    return Results.NoContent();
});
//getdeniedexpenses or GetDeleted
app.MapGet("/expenses/denied", ([FromServices] DBConnector db) =>
{ return DBConnector.GetDeleted(builder.Configuration.GetConnectionString("MyDB"));
});

//demote user
app.MapPut("/account/demote/{id}", async (int id, DBConnector db) =>
{
    DBConnector.PromoteDemoteUser(builder.Configuration.GetConnectionString("MyDB"), id, false);
    return Results.NoContent();
});
//promote user
app.MapPut("/account/promote/{id}", async (int id, DBConnector db) =>
{
    DBConnector.PromoteDemoteUser(builder.Configuration.GetConnectionString("MyDB"), id, true);
    return Results.NoContent();
});
 app.Run();
