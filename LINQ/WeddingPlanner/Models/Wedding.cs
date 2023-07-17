#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;

public class Wedding{
    [Key]
    public int WeddingId {get;set;}
    [Required]
    public string Wedder1 {get;set;}
    [Required]
    public string Wedder2 {get;set;}
    [Required]
    [FutureDate]
    [DataType(DataType.DateTime)]
    public DateTime WeddingDate{get;set;}
    [Required]
    public string Address{get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<RSVP> Attendants {get;set;} = new List<RSVP>();
    public int UserId {get;set;}
    public User? Creator{get;set;}
    
}

public class FutureDate : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
            return new ValidationResult("Wedding Date Required");

        var val = (DateTime)value;
        if(val < DateTime.Now){
            return new ValidationResult("Wedding must be in the future");
        }return ValidationResult.Success;
    }
}