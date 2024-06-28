using MammaMia.Data;
using MammaMia.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Añadir el PizzaContext
// builder.Services.AddSqlite<PizzaContext>("Data Source=MammaMia.db");
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PizzaContext>(options => options.UseNpgsql(conn));

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

