## Create .Net ASP Project file
dotnet new mvc --no-https -o ProjectName

## Program.cs

using Microsoft.EntityFrameworkCore;
using ProjectName.Models;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

## Validations on Model

using System.ComponentModel.DataAnnotations;

## appsettings.json - MySql

"ConnectionStrings":    
    {        
        "DefaultConnection": "Server=localhost;port=3306;userid=root;password=root;database=monsterdb;"    
    }

## MySql commands setup

dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.1
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.3

## MySql Migration

dotnet ef migrations add FirstMigration
dotnet ef database update

## Model

#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProjectName.Models;

public class Pet{
    [Key]
    public int PetId {get;set;}
    public string Name {get;set;}
    public string Type {get;set;}
    public int Age {get;set;}
    public bool HasFur {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}

## MyContext

#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace ProjectName.Models;

public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }      
    public DbSet<Model> MyContext { get; set; } 
}

## Empty Controller

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectName.Controllers;

public class Controller : Controller
{
    private readonly ILogger<Controller> _logger;
    private MyContext db;

    public Controller(ILogger<Controller> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }

}
