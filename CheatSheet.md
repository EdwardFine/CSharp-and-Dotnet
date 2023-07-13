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

## Loading Partials
@await Html.PartialAsync("_Partial")

## Model

#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectName.Models;

public class Pet{
    [Key]
    public int PetId {get;set;}
    [Required]
    [MinLength(2)]
    public string Name {get;set;}
    [MaxLength(20)]
    public string Type {get;set;}
    [Range(0,20)]
    public int Age {get;set;}
    public bool HasFur {get;set;}
    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string Email {get;set;}
    [Required]
    [DataType(DataType.Password)]
    public string Password {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    [NotMapped]
    [Compare("Password")]
    public string PasswordConfirm { get; set; }
}

## One To Many Example

#pragma warning disable CS8618
namespace YourProjectName.Models;
using System.ComponentModel.DataAnnotations;
public class User
{    
    [Key]    
    public int UserId { get; set; }
    public string Name { get; set; } 
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // Our navigation property to track the many Posts our user has made
    // Be sure to include the part about instantiating a new List!
    public List<Post> AllPosts { get; set; } = new List<Post>();
}

#pragma warning disable CS8618
namespace YourProjectName.Models;
using System.ComponentModel.DataAnnotations;
public class Post
{    
    [Key]    
    public int PostId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public int UserId { get; set; }
    // Our navigation property to track which User made this Post
    // It is VERY important to include the ? on the datatype or this won't work!
    public User? Creator { get; set; }
}

## .Include Linq

//.Include is like a MySql JOIN
List<Post> AllPosts = _context.Posts.Include(c => c.Creator).ToList();
int numPosts = _context.Users.Include(user => user.AllPosts).FirstOrDefault(user => user.UserId == userId).AllPosts.Count;

## Validate Unique Email

public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
    	// Though we have Required as a validation, sometimes we make it here anyways
    	// In which case we must first verify the value is not null before we proceed
        if(value == null)
        {
    	    // If it was, return the required error
            return new ValidationResult("Email is required!");
        }
    
    	// This will connect us to our database since we are not in our Controller
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
        // Check to see if there are any records of this email in our database
    	if(_context.Users.Any(e => e.Email == value.ToString()))
        {
    	    // If yes, throw an error
            return new ValidationResult("Email must be unique!");
        } else {
    	    // If no, proceed
            return ValidationResult.Success;
        }
    }
}

## Session Security

//Insert into top of Controller
using Microsoft.AspNetCore.Mvc.Filters;

//Insert into bottom of Cntroller
// Name this anything you want with the word "Attribute" at the end
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        // Check to see if we got back null
        if(userId == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}

//Routing
// The name we gave our class minus "Attribute"
[SessionCheck]
[HttpGet("someRoute")]
// The rest of the code



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
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;

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

## Password Hasher

using Microsoft.AspNetCore.Identity;

PasswordHasher<Model> Hasher = new PasswordHasher<Model>();
newModel.Password = Hasher.HashPassword(newModel, newModel.Password);

## Compare Hashed Passwords

PasswordHasher<Model> hasher = new PasswordHasher<Model>();
var result = hasher.VerifyHashedPassword(modelSubmission, modelInDb.Password, modelSubmission.Password);
// Result can be compared to 0 for failure