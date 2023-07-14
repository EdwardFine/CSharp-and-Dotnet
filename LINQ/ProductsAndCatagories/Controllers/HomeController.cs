using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCatagories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCatagories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext db;

    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _logger = logger;
        db = context;
    }

    //Render Create Products and Catagory Pages along with a list of all previously created
    public IActionResult Index()
    {
        List<Product> AllProducts = db.Products.ToList();
        ViewBag.AllProducts = AllProducts;
        return View();
    }
    public IActionResult Catagories()
    {
        List<Catagory> AllCatagories = db.Catagories.ToList();
        ViewBag.AllCatagories = AllCatagories;
        return View();
    }

    //Create New Product/Catagory
    [HttpPost("products/create")]
    public IActionResult CreateProduct(Product newProduct){
        if(!ModelState.IsValid){
            List<Product> AllProducts = db.Products.ToList();
            ViewBag.AllProducts = AllProducts;
            return View("Index");
        }
        db.Products.Add(newProduct);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost("catagories/create")]
    public IActionResult CreateCatagory(Catagory newCatagory){
        if(!ModelState.IsValid){
            List<Catagory> AllCatagories = db.Catagories.ToList();
            ViewBag.AllCatagories = AllCatagories;
            return View("Catagories");
        }
        db.Catagories.Add(newCatagory);
        db.SaveChanges();
        return RedirectToAction("Catagories");
    }

    //View One Product/Catagory
    [HttpGet("view/{id}/product")]
    public IActionResult ViewProduct(int id){
        Product ProductWithCat = db.Products.Include(p=>p.Catagories).ThenInclude(c=>c.Catagory).FirstOrDefault(p=>p.ProductId == id);
        List<Catagory> AllCatagories = db.Catagories.ToList();
        ViewBag.AllCatagories = AllCatagories;
        return View("OneProduct",ProductWithCat);
    }

    [HttpGet("view/{id}/catagory")]
    public IActionResult ViewCatagory(int id){
        Catagory CatagoryWithPro = db.Catagories.Include(p=>p.Products).ThenInclude(c=>c.Product).FirstOrDefault(p=>p.CatagoryId == id);
        List<Product> AllProducts = db.Products.ToList();
        ViewBag.AllProducts = AllProducts;
        return View("OneCatagory",CatagoryWithPro);
    }

    //Add Association from Product>Catagory and Catagory>Product
    [HttpPost("product/addCatagory")]
    public IActionResult AddCatagory(Association newAssociate){
        db.Associations.Add(newAssociate);
        db.SaveChanges();
        return RedirectToAction("ViewProduct",new{id=newAssociate.ProductId});
    }

    [HttpPost("catagory/addProduct")]
    public IActionResult AddProduct(Association newAssociate){
        db.Associations.Add(newAssociate);
        db.SaveChanges();
        return RedirectToAction("ViewCatagory",new{id=newAssociate.CatagoryId});
    }

    //Delete Associations
    [HttpPost("association/delete/cat")]
    public IActionResult DeleteAssociationFromCat(Association newAsso){
        Association AssociationToDel = db.Associations.FirstOrDefault(a=> a.CatagoryId == newAsso.CatagoryId && a.ProductId == newAsso.ProductId);
        db.Associations.Remove(AssociationToDel);
        db.SaveChanges();
        return RedirectToAction("ViewCatagory",new{id=newAsso.CatagoryId});
    }

    [HttpPost("association/delete/pro")]
    public IActionResult DeleteAssociationFromPro(Association newAsso){
        Association AssociationToDel = db.Associations.FirstOrDefault(a=> a.CatagoryId == newAsso.CatagoryId && a.ProductId == newAsso.ProductId);
        db.Associations.Remove(AssociationToDel);
        db.SaveChanges();
        return RedirectToAction("ViewProduct",new{id=newAsso.ProductId});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
