#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace ProductsAndCatagories.Models;

public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }      
    public DbSet<Product> Products { get; set; } 
    public DbSet<Association> Associations { get; set; } 
    public DbSet<Catagory> Catagories { get; set; } 
}