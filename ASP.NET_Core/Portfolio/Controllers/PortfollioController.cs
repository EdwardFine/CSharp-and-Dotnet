// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace notes.Controllers;
public class HelloController : Controller   // Remember inheritance?    
{
    [HttpGet] // We will go over this in more detail on the next page    
    [Route("")] // We will go over this in more detail on the next page
    //http://localhost:5xxx/
    public string Index()
    {
        return "This is my Index!";
    }

    [HttpGet("projects")]
    public string Projects(){
        return "These are my projects.";
    }


    [HttpGet("contact")]
    public string Contact(){
        return "This is my Contact!";
    }

}

