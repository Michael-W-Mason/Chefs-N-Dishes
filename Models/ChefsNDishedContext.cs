#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace Chefs_N_Dishes.Models;
public class ChefsNDishesContext : DbContext 
{ 
    public ChefsNDishesContext(DbContextOptions options) : base(options) { }
    public DbSet<Chef> Chefs { get; set; } 
    public DbSet<Dish> Dishes { get; set; } 
}
