using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using UserNotifications.Api.Services;
using UserNotifications.Api.Services.Interface;
using UserNotifications.Context;
using UserNotifications.Repositories;
using UserNotifications.Repositories.Interfaces;
using UserNotifications.SetupOptionsSwagger;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.ParameterFilter<CustomParameterFilter>()); //Adition ParameterFilter

//Database connection
var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

 builder.Services.AddDbContext<AppDbContext>(options =>
                     options.UseSqlServer(mySqlConnection));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IQueueNotificationService, QueueNotificationService>();



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
