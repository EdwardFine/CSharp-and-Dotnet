using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkLecture.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLecture.Controllers;

public class MonsterController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext db;

    public MonsterController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }

    [HttpGet("")]
    public IActionResult Index(){
        List<Monster> AllMonsters = db.Monsters.ToList();
        return View("AllMonsters",AllMonsters);
    }

    [HttpGet("monsters/new")]
    public IActionResult NewPost(){
        return View("New");
    }

    [HttpPost("monsters/create")]
    public IActionResult CreateMonster(Monster newMonster){
        if(!ModelState.IsValid){
            return View("New");
        }
        db.Monsters.Add(newMonster);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

}
