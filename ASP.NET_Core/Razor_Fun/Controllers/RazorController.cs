// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace Razor_Fun.Controllers;
public class RazorController : Controller   // Remember inheritance?    
{
    public static List<string> Foods = new List<string>() {"Apple Pie","Pizza","Cinnamon Rolls","Lasagna","Donuts","Chocolate Cake","Burritos"};
    [HttpGet] // We will go over this in more detail on the next page    
    [Route("")] // We will go over this in more detail on the next page
    public ViewResult Index()
    {
        return View("Index",Foods);
    }
    
}

