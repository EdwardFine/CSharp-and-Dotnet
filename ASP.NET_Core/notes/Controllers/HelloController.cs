// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace notes.Controllers;
public class HelloController : Controller   // Remember inheritance?    
{
    [HttpGet] // We will go over this in more detail on the next page    
    [Route("")] // We will go over this in more detail on the next page
    //http://localhost:5xxx/
    public ViewResult Index()
    {
        ViewBag.Name = "Carlie";
        ViewBag.Number = 9025;
        return View("Index");
    }
    //http://localhost:5xxx/users/more
    [HttpGet("users/more")]
    public ViewResult AUser(){
        return View();
    }

    //http://localhost:5xxx/users/{id}
    [HttpGet("user/{id}")]
    public string OneUser(int id){
        return $"Hello World, here is my id: {id}";
    }

    [HttpPost("process")]
    public IActionResult Process(string favoriteAnimal){
        if(favoriteAnimal.ToLower() =="dog"){
            ViewBag.Name = "Carlie";
            ViewBag.Number = 0925;
            ViewBag.Error = "Dogs are the best, but try something else.";
            return View("Index");
        }
            return RedirectToAction("Index");
    }
}

