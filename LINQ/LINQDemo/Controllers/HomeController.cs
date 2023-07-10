using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LINQDemo.Models;

namespace LINQDemo.Controllers;

public class HomeController : Controller
{
    public static Game[] AllGames = new Game[]{
        new Game {Title="Overwatch", Price=39.00, Genre="First-person Shooter", Rating="T", Platform="PC"},
        new Game {Title="Red Dead Redemption 2", Price=59.00, Genre="Western", Rating="M", Platform="PS4"},
        new Game {Title="Spiderman", Price=59.00, Genre="Superhero", Rating="T", Platform="Xbox"},
        new Game {Title="FFXIV", Price=15.00,Genre="MMO RPG",Rating="T",Platform="PC and PS4/PS5"},
        new Game {Title="The Legend of Zelda: Tears of the Kingdom", Price=69.99, Genre="Fantasy", Rating="E", Platform="Nintendo Switch"},
        new Game {Title="Phasmophobia", Price=16.00, Genre="Survival Game", Rating="T", Platform="PC"},
        new Game {Title="Dragon Age: Inquistion", Price=10.99, Genre="RPG", Rating="E", Platform="PC"},
        new Game {Title="The Last of Us", Price=59.00, Genre="Horror", Rating="M", Platform="PlayStation"}
    };
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Game> AllGamesFromData = AllGames.OrderBy(s=>s.Title).ThenBy(p=>p.Price).ToList();
        ViewBag.AllGames = AllGamesFromData;

        List<Game> PCPlatformAndT = AllGames.Where(g=>g.Rating=="T" || g.Platform=="PC").ToList();
        ViewBag.PCPlatform = PCPlatformAndT;

        Game SingleGame = AllGames.FirstOrDefault(g=>g.Title=="Overwatch");
        ViewBag.SingleGame= SingleGame;
        return View();
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
