using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers;

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
        List<Chef> AllChefs = db.Chefs.Include(c=>c.AllDishes).ToList();
        return View(AllChefs);
    }

    [HttpGet("dishes")]
    public IActionResult AllDishes(){
        List<Dish> AllDishes = db.Dishes.Include(d=>d.Creator).ToList();
        return View("AllDishes",AllDishes);
    }

    [HttpGet("chef/new")]
    public IActionResult NewChef(){
        return View("AddChef");
    }

    [HttpPost("chef/create")]
    public IActionResult CreateChef(Chef newChef){
        if(!ModelState.IsValid){
            return View("AddChef");
        }
        db.Chefs.Add(newChef);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("dish/new")]
    public IActionResult NewDish(){
        List<Chef> AllChefs = db.Chefs.ToList();
        ViewBag.AllChefs = AllChefs;
        return View("AddDish");
    }

    [HttpPost("dish/create")]
    public IActionResult CreateDish(Dish newDish){
        if(!ModelState.IsValid){
            List<Chef> AllChefs = db.Chefs.ToList();
            ViewBag.AllChefs = AllChefs;
            return View("AddDish");
        }
        db.Dishes.Add(newDish);
        db.SaveChanges();
        return RedirectToAction("AllDishes");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
