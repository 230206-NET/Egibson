using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using DataAccess;
using Services;
using Models;

var builder = WebApplication.CreateBuilder(args);


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
app.MapGet("/expenses/myexpense/{id}", ([FromServices] DBConnector db, int id) =>
{ return DBConnector.GetMyExpenses(builder.Configuration.GetConnectionString("MyDB"), id);
});


//This will give the user ID back if success. //Isthisauser
app.MapGet("/account/isuser/{id}/{password}", ([FromServices] DBConnector db, string id, string password) =>
{ return "UserID is: " + DBConnector.Isthisauser(builder.Configuration.GetConnectionString("MyDB"), id, password) + " \n 0 = wrong information or not a user."; 
});

//isManager
app.MapGet("/account/ismanager/{id}/{password}", ([FromServices] DBConnector db, string id, string password) =>
{ return "User is a manager?: " +  DBConnector.isManager(builder.Configuration.GetConnectionString("MyDB"), id, password);
});

//GetAllExpensesNotApproved //pending
app.MapGet("/expenses/pending/", ([FromServices] DBConnector db) =>
{ return DBConnector.ExpensesPending(builder.Configuration.GetConnectionString("MyDB"));
});

//getdeniedexpenses or GetDeleted
app.MapGet("/expenses/deleted", ([FromServices] DBConnector db) =>
{ return DBConnector.GetDeleted(builder.Configuration.GetConnectionString("MyDB"));
});

//GetAllExpensesNotApproved
app.MapGet("/expenses/denied", ([FromServices] DBConnector db) =>
{ return DBConnector.GetAllExpensesNotApproved(builder.Configuration.GetConnectionString("MyDB"));
});


//Upload Expense
app.MapPost("/expense/create/", ([FromBody] Expense exp, DBConnector db) => {

    
    return "The Expense ID is: " + Results.Created("/expense", DBConnector.UploadExpense(builder.Configuration.GetConnectionString("MyDB"), exp));
});
//usercreation
app.MapPost("/account/create/", ([FromBody] Account act, DBConnector db) => {
    return Results.Created("/account", DBConnector.UploadUser(act, builder.Configuration.GetConnectionString("MyDB")));

});
            
//ApproveExpense
app.MapPut("/expense/approve/{id}", async (int id, DBConnector db) =>
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
