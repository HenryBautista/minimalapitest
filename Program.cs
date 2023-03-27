using Microsoft.EntityFrameworkCore;
using TodoApi.Repository;
using TodoApi.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BussinesLogic>();

//DB
builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("items"));

var app = builder.Build();

//App config
app.UseSwagger();
app.UseSwaggerUI();

//Endpoints
app.MapGet("/", () => "Hello World!");

app.MapGet("/sum", 
    (BussinesLogic bussinesLogic, int a, int b) =>
    bussinesLogic.Sum(a,b));

app.MapPost("/", (string value) => {});

app.MapGet("/pizzas", 
    async (BussinesLogic bussinesLogic) => 
    await bussinesLogic.Get());

app.Run();
