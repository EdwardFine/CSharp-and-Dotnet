using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dojo_Survey_With_Validations.Models;

namespace Dojo_Survey_With_Validations.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost("survey")]
    public IActionResult Survey(Survey newSurvey){
        if(ModelState.IsValid){
            return RedirectToAction("results",newSurvey);
        }else{
            return View("Index");
        }
    }
    [HttpGet("results")]
    public IActionResult Results(Survey newSurvey){
        return View("Survey",newSurvey);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
