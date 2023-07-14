#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProductsAndCatagories.Models;

public class Association{
    [Key]
    public int AssociationId {get;set;}
    public int ProductId {get;set;}
    public int CatagoryId {get;set;}
    public Product? Product {get;set;}
    public Catagory? Catagory {get;set;}
}