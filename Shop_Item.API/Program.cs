using Microsoft.EntityFrameworkCore;
using Shop_Item.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Connection String
string dbConnectionString = "Data Source=DESKTOP-2N17KLJ;Initial Catalog=StudentAppDb;Integrated Security=True";

//Configure AppDbContext
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
