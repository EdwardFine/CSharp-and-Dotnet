namespace Dojo_Survey_With_Model.Models;
using System.ComponentModel.DataAnnotations;
public class Survey{
    public string Name{get;set;}
    public string Location{get;set;}
    public string FavLanguage{get;set;}
    public string? Comment{get;set;}
}