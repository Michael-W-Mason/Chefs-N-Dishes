#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Chefs_N_Dishes.Models;

public class Chef{
    [Key]
    public int ChefId {get; set;}
    [Required]
    public string FirstName {get; set;}
    [Required]
    public string LastName {get; set;}
    [Required]
    public DateTime DOB {get; set;}
    public int Age {get; set;} = DateTime.Now.Year;
    public List<Dish> Dishes {get; set;} = new List<Dish>();
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
};
