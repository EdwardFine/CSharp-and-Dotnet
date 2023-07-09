using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session_Workshop.Models;

namespace Session_Workshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Login(string? Name){
        if(Name != null){
            HttpContext.Session.SetString("UserName",Name);
            HttpContext.Session.SetInt32("Count",22);
        }
        return RedirectToAction("Dashboard");
    }

    public IActionResult DashBoard(){
        if(HttpContext.Session.GetString("UserName")==null){
            return RedirectToAction("Index");
        }return View("Dashboard");
    }

    public IActionResult Logout(){
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    public IActionResult Count(int Value){
        int CurrentCount = (int)HttpContext.Session.GetInt32("Count");
        if(Value==1){
            HttpContext.Session.SetInt32("Count",(CurrentCount+1));
        }else if(Value==2){
            HttpContext.Session.SetInt32("Count",(CurrentCount-1));
        }else if(Value==3){
            HttpContext.Session.SetInt32("Count",(CurrentCount*2));
        }else if(Value==4){
            Random rand = new Random();
            HttpContext.Session.SetInt32("Count",(CurrentCount+rand.Next(1,11)));
        }return RedirectToAction("DashBoard");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
