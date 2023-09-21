using Microsoft.EntityFrameworkCore;
using UserNotifications.Context;
using UserNotifications.Repositories;
using UserNotifications.Repositories.Interfaces;
using UserNotifications.SetupOptionsSwagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.ParameterFilter<CustomParameterFilter>()); //Adition ParameterFilter

//Database connection
var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

 builder.Services.AddDbContext<AppDbContext>(options =>
                     options.UseSqlServer(mySqlConnection));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

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
