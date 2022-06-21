#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Chefs_N_Dishes.Models;

public class Dish{
    [Key]
    public int DishId {get; set;}
    [Required]
    public string Name {get; set;}
    [Required]
    [Range(0, int.MaxValue)]
    public int Calories {get; set;}
    [Required]
    public string Description {get; set;}
    [Required]
    [Range(1,5)]
    public int Tastiness {get; set;}
    [Required]
    public int ChefId {get; set;}
    public Chef? Chef {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
}