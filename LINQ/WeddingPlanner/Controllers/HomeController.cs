using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;

namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext db;

    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _logger = logger;
        db=context;
    }

    public IActionResult Index()
    {
        return View();
    }

    //User Login, logout, register
    [HttpPost("user/register")]
    public IActionResult Register(User newUser){
        if(!ModelState.IsValid){
            return View("Index");
        }
        PasswordHasher<User> Hasher = new PasswordHasher<User>();
        newUser.Password = Hasher.HashPassword(newUser,newUser.Password);
        db.Users.Add(newUser);
        db.SaveChanges();
        HttpContext.Session.SetInt32("UserId",newUser.UserId);
        return RedirectToAction("Dashboard");
    }
    [HttpPost("user/login")]
    public IActionResult Login(LoginUser logUser){
        if(!ModelState.IsValid){
            return View("Index");
        }
        User? UserInDb = db.Users.FirstOrDefault(u=>u.Email == logUser.Email);
        if(UserInDb == null){
            ModelState.AddModelError("Email", "Invalid Email/Password");
            return View("Index");
        }
        PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
        var result = hasher.VerifyHashedPassword(logUser, UserInDb.Password, logUser.Password);
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

    //Dashboard
    [SessionCheck]
    public IActionResult Dashboard(){
        User? activeUser = db.Users.FirstOrDefault(u=>u.UserId == HttpContext.Session.GetInt32("UserId"));
        ViewBag.User = activeUser;
        List<Wedding> AllWeddings = db.Weddings.Include(w=>w.Attendants).ToList();
        return View(AllWeddings);
    }

    //New Wedding and create wedding and delete wedding
    [SessionCheck]
    [HttpPost("wedding/new")]
    public IActionResult NewWedding(){
        User? activeUser = db.Users.FirstOrDefault(u=>u.UserId == HttpContext.Session.GetInt32("UserId"));
        ViewBag.User = activeUser;
        return View();
    }

    [SessionCheck]
    [HttpPost("wedding/create")]
    public IActionResult CreateWedding(Wedding newWedding){
        if(!ModelState.IsValid){
            User? activeUser = db.Users.FirstOrDefault(u=>u.UserId == HttpContext.Session.GetInt32("UserId"));
            ViewBag.User = activeUser;
            return View("NewWedding");
        }
        db.Weddings.Add(newWedding);
        db.SaveChanges();
        return RedirectToAction("Dashboard");
    }
    [SessionCheck]
    [HttpPost("wedding/delete")]
    public IActionResult DeleteWedding(Wedding weddingForm){
        Wedding? WeddingToDel = db.Weddings.FirstOrDefault(w=>w.WeddingId == weddingForm.WeddingId);
        db.Weddings.Remove(WeddingToDel);
        db.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    //RSVP Add and subtract
    [SessionCheck]
    [HttpPost("rsvp/add")]
    public IActionResult AddRSVP(RSVP newRSVP){
        db.RSVPs.Add(newRSVP);
        db.SaveChanges();
        return RedirectToAction("Dashboard");
    }
    [SessionCheck]
    [HttpPost("rsvp/delete")]
    public IActionResult DeleteRSVP(RSVP newRSVP){
        RSVP? RSVPtoDel = db.RSVPs.FirstOrDefault(r=>r.UserId == newRSVP.UserId && r.WeddingId==newRSVP.WeddingId);
        db.RSVPs.Remove(RSVPtoDel);
        db.SaveChanges();
        return RedirectToAction("Dashboard");
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