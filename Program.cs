using MammaMia.Data;
using MammaMia.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Añadir el pizzacontext
builder.Services.AddSqlite<PizzaContext>("Data Source=MammaMia.db");

builder.Services.AddScoped<PizzaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.CreateDBIfNoExists();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => @"MammaMía Pizza management API. Navega a /swagger para testear con la UI de Swagger");

app.Run();

