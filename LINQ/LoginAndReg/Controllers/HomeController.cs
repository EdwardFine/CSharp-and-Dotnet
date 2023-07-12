using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginAndReg.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;

namespace LoginAndReg.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext db;
    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _logger = logger;
        db = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [SessionCheck]
    [HttpGet("dashboard")]
    public IActionResult Dashboard(){
        ViewBag.Id = HttpContext.Session.GetInt32("UserId");
        return View();
    }

    [HttpPost("users/create")]
    public IActionResult Register(User newUser){
        if(!ModelState.IsValid){
            return View("Index");
        }
        PasswordHasher<User> Hasher = new PasswordHasher<User>();
        newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
        db.Users.Add(newUser);
        db.SaveChanges();
        HttpContext.Session.SetInt32("UserId",newUser.UserId);
        return RedirectToAction("Dashboard");
    }
    
    [HttpPost("users/login")]
    public IActionResult Login(LoginUser userForm){
        if(!ModelState.IsValid){
            return View("Index");
        }
        User? UserInDb = db.Users.FirstOrDefault(u=>u.Email == userForm.Email);
        if(UserInDb == null){
            ModelState.AddModelError("Email", "Invalid Email/Password");
            return View("Index");
        }
        PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
        var result = hasher.VerifyHashedPassword(userForm, UserInDb.Password, userForm.Password);
        if(result ==0){
            ModelState.AddModelError("Email", "Invalid Email/Password");            
            return View("Index");    
        }
        HttpContext.Session.SetInt32("UserId",UserInDb.UserId);
        return RedirectToAction("Dashboard");
    }


    [HttpPost("logout")]
    public IActionResult Logout(){
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


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