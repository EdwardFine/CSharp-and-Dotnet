#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace EntityFrameworkLecture.Models;
public class Monster
{
    [Key]
    public int MonsterId { get; set; }
    [Required]
    public string Name { get; set; } 
    [Required]
    public int Height { get; set; }
    [Required]
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
                
