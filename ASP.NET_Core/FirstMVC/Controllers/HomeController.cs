using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstMVC.Models;

namespace FirstMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public static List<Pet> Pets = new List<Pet>();
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string localVariable = HttpContext.Session.GetString("UserName");
        Console.WriteLine(localVariable);
        return View();
    }

    public IActionResult Privacy()
    {
        if(HttpContext.Session.GetString("UserName")==null){
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpPost("login")]
    public IActionResult Login(string NewName){
        HttpContext.Session.SetString("UserName",NewName);
        return RedirectToAction("Privacy");
    }
    [HttpPost("logout")]
    public IActionResult Logout(){
        HttpContext.Session.Clear();
        return RedirectToAction("Privacy");
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }

    [HttpPost("process")]
    public IActionResult Process(Pet newPet){
        if(ModelState.IsValid){
            Pets.Add(newPet);
            return RedirectToAction("AllPets");
        }else{
            return View("Index");
        }
    }

    [HttpGet("AllPets")]
    public IActionResult AllPets(){
        return View("AllPets",Pets);
    }
}
