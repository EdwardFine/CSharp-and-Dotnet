#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProductsAndCatagories.Models;

public class Product{
    [Key]
    public int ProductId {get;set;}
    [Required]
    public string Name {get;set;}
    [Required]
    public float Price {get;set;}
    public string Description {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    public List<Association> Catagories {get;set;} = new List<Association>();
}