// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace Dojo_Survey.Controllers;
public class SurveyController : Controller   // Remember inheritance?    
{
    [HttpGet] // We will go over this in more detail on the next page    
    [Route("")] // We will go over this in more detail on the next page
    //http://localhost:5xxx/
    public ViewResult Index()
    {
        return View();
    }

    [HttpPost("survey")]
    public IActionResult Survey(string Name, string Location, string FavLanguage, string Comment=null){
        ViewBag.Name = Name;
        ViewBag.Location = Location;
        ViewBag.FavLanguage = FavLanguage;
        if(Comment != null){
            ViewBag.Comment = Comment;
        }else{
            ViewBag.Comment = "No Comment";
        }
        return View();
    }

}

