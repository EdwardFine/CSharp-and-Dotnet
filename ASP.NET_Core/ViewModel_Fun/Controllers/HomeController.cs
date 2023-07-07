using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModel_Fun.Models;

namespace ViewModel_Fun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    Random rand = new Random();
    public static User user1 = new User("Neil Gaiman");
    public static User user2 = new User("Terry Prachet");
    public static User user3 = new User("Jane Austen");
    public static User user4 = new User("Shephen King");
    public static User user5 = new User("Mary Shelley");
    public static List<User> AllUsers = new List<User>(){user1,user2,user3,user4,user5};

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tincidunt tortor aliquam nulla facilisi. Cursus vitae congue mauris rhoncus aenean. Tristique risus nec feugiat in. Non curabitur gravida arcu ac tortor dignissim. Velit sed ullamcorper morbi tincidunt ornare. Viverra justo nec ultrices dui sapien eget mi proin. Sed nisi lacus sed viverra. A erat nam at lectus urna duis convallis convallis. Commodo odio aenean sed adipiscing diam donec adipiscing tristique risus.";
        return View("Index",Message);
    }

    public IActionResult Numbers()
    {
        int[] Numbers = new int[] {1,2,10,21,8,7,3};
        return View("Numbers",Numbers);
    }

    public IActionResult User(){
        return View("User",AllUsers[rand.Next(0,AllUsers.Count)]);
    }

    public IActionResult AllUser(){
        return View("AllUsers",AllUsers);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
