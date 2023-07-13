#pragma warning disable CS8618
namespace ChefsNDishes.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Chef
{    
    [Key]    
    public int ChefId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [DateOfBirth]
    [DataType(DataType.Date)]
    public DateTime Birthday {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Dish> AllDishes { get; set; } = new List<Dish>();
}

public class DateOfBirthAttribute : ValidationAttribute
{
    private int MinAge = 18;
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
            return new ValidationResult("Birthday is required.");

        var val = (DateTime)value;
        if(val > DateTime.Now){
            return new ValidationResult("Birthday must be in the past.");
        }else if(val.AddYears(MinAge) > DateTime.Now){
            return new ValidationResult("Chef must be at least 18 years old.");
        }return ValidationResult.Success;
    }
}