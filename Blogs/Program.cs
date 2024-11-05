using Blogs.Models;
using Blogs.Models.DTOs;
using Blogs.Services;
using Blogs.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.Configure<UserDatabaseSettings>(
//    builder.Configuration.GetSection("BlogsDatabase"));
UserDatabaseSettings connection = builder.Configuration.GetSection("BlogsDatabase").Get<UserDatabaseSettings>() ?? throw new Exception("appsettings value: BlogsDatabase not found");
var mongoClient = new MongoClient(connection.ConnectionString);
builder.Services.AddDbContext<BlogContext>(options =>
    options.UseMongoDB(connection.ConnectionString, connection.DatabaseName)
);
//var dbContextOptions =
//    new DbContextOptionsBuilder<BlogContext>()
//    .UseMongoDB(mongoClient, connection.DatabaseName);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsersService, UsersService>();
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
