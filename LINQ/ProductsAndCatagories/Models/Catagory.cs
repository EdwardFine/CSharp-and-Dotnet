#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProductsAndCatagories.Models;

public class Catagory{
    [Key]
    public int CatagoryId {get;set;}
    [Required]
    public string Name {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    public List<Association> Products {get;set;} = new List<Association>();
}