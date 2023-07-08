#pragma warning disable CS8618
namespace Dojo_Survey_With_Validations.Models;
using System.ComponentModel.DataAnnotations;
public class Survey{
    [Required(ErrorMessage="Name is Required")]
    [MinLength(2,ErrorMessage="Name should be at least 2 characters.")]
    public string Name{get;set;}
    [Required(ErrorMessage="Location is Required")]
    public string Location{get;set;}
    [Required(ErrorMessage="Favorite Language is Required.")]
    public string FavLanguage{get;set;}
    [MinLength(20,ErrorMessage="Comment should be at least 20 characters if inputted.")]
    public string? Comment{get;set;}
}