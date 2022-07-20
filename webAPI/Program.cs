using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Microsoft.AspNetCore.Http.Json;
using DataAccess;
using services;
using Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer(); 
//builder.Services.AddSwaggerGen();




builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null;
});




builder.Services.AddTransient<UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<Usercontroller>();

builder.Services.AddTransient<TicketServices>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddTransient<Ticketcontroller>();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseSwagger(); 
app.UseSwaggerUI();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});



app.MapGet("/h", () => "Hello World!");

app.MapGet("/GetAllUsers", (Usercontroller usercont) => 
usercont.GetAllUsers()
);


app.MapGet("/users/userName/{userID}", (string userID, Usercontroller usercont) => usercont.GetUserById(int.Parse(userID)));

app.MapPost("/users/CreateUser", (User u, Usercontroller usercont) => usercont.CreateUser(u));


/*
app.MapGet("/GetAllTickets", (Ticketcontroller ticketcont) => 
ticketcont.GetAllTickets()
);


app.MapGet("/CreateTicket", (Ticketcontroller ticketcont) => 
ticketcont.CreateTicket(zeld)
);


app.MapGet("/UpdateTicket", (Ticketcontroller ticketcont) => 
ticketcont.UpdateTicket(zeld)
);

app.MapGet("/GetTicketsByID", (Ticketcontroller ticketcont) => 
ticketcont.GetTicketsByID(ID)
);

app.MapGet("/GetTicketsByAuthor", (Ticketcontroller ticketcont) => 
ticketcont.GetTicketsByAuthor(authorID)
);

app.MapGet("/GetTicketsByStatus", (Ticketcontroller ticketcont) => 
ticketcont.GetTicketsByStatus(status)
);

*/
//app.MapGet("/");

app.Run();
