// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace Countdown.Controllers;
public class CountdownController : Controller   // Remember inheritance?    
{
    [HttpGet] // We will go over this in more detail on the next page    
    [Route("")] // We will go over this in more detail on the next page
    //http://localhost:5xxx/
    public ViewResult Index()
    {
        DateTime CurrentTime = DateTime.Now;
        DateTime CountTime = new DateTime(2023,7,28);
        TimeSpan WaitTime = CountTime - CurrentTime;
        ViewBag.CurrentDate = CurrentTime;
        ViewBag.CountTo = CountTime;
        ViewBag.Wait = WaitTime;
        return View();
    }

}

