using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;
    private MyContext db;

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }

    [HttpGet("")]
    public IActionResult Index(){
        List<Dish> AllDishes = db.Dishes.OrderByDescending(db=>db.CreatedAt).ToList();
        return View("Dishes",AllDishes);
    }

    [HttpGet("dishes/new")]
    public IActionResult NewDish(){
        return View("DishForm");
    }

    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish){
        if(!ModelState.IsValid){
            return View("DishForm");
        }
        db.Dishes.Add(newDish);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("dishes/{id}")]
    public IActionResult DisplayDish(int id){
        Dish OneDish = db.Dishes.FirstOrDefault(d=>d.DishId == id);
        return View("OneDish",OneDish);
    }
    
    [HttpGet("dishes/{id}/edit")]
    public IActionResult EditDish(int id){
        Dish? DishToEdit = db.Dishes.FirstOrDefault(d=>d.DishId == id);
        return View("EditDish",DishToEdit);
    }

    [HttpPost("dishes/{id}/update")]
    public IActionResult UpdateDish(Dish UpdatedDish, int id){
        Dish? OldDish = db.Dishes.FirstOrDefault(d=>d.DishId == id);
        if(!ModelState.IsValid){
            return View("EditDish",OldDish);
        }
        OldDish.Name = UpdatedDish.Name;
        OldDish.Chef = UpdatedDish.Chef;
        OldDish.Tastiness = UpdatedDish.Tastiness;
        OldDish.Calories = UpdatedDish.Calories;
        OldDish.Description = UpdatedDish.Description;
        OldDish.UpdatedAt = DateTime.Now;
        db.SaveChanges();
        return RedirectToAction("DisplayDish", new {id=id});
    }

    [HttpPost("dishes/{id}/delete")]
    public IActionResult DeleteDish(int id){
        Dish? DishToDel = db.Dishes.FirstOrDefault(d=>d.DishId == id);
        db.Dishes.Remove(DishToDel);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}
