#pragma warning disable CS8618
namespace FirstMVC.Models;
using System.ComponentModel.DataAnnotations;

public class Pet{
    [Required(ErrorMessage="Name is Requiered")]
    [MinLength(2)]
    public string Name{get;set;}

    [Required(ErrorMessage="Species is Requiered")]
    [MinLength(2)]
    [MaxLength(50)]
    public string Species{get;set;}

    [Required(ErrorMessage="Age is Requiered")]
    [Range(0,int.MaxValue)]
    public int Age{get;set;}

    public string Color{get;set;}
    public bool IsFriendly{get;set;}
    
}