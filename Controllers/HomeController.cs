using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chefs_N_Dishes.Models;

namespace Chefs_N_Dishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public ChefsNDishesContext _context;

    public HomeController(ILogger<HomeController> logger, ChefsNDishesContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Home()
    {
        List<Chef> chefs = _context.Chefs
        .Include(chef => chef.Dishes)
        .ToList();
        return View("Home", chefs);
    }

    [HttpGet("/new")]
    public IActionResult ChefForm()
    {
        return View("ChefForm");
    }

    [HttpPost("/chef/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            if (DateTime.Now.Year - newChef.DOB.Year < 18)
            {
                ModelState.AddModelError("DOB", "Must be 18 years or older");
                return View("ChefForm");
            }
            newChef.Age = DateTime.Now.Year - newChef.DOB.Year;
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }
        else
        {
            return View("ChefForm");
        }
    }

    [HttpGet("/dishes")]
    public IActionResult Dishes()
    {
        List<Dish> dishes = _context.Dishes
        .Include(dish => dish.Chef)
        .ToList();
        return View("Dishes", dishes);
    }

    [HttpGet("/dishes/new")]
    public IActionResult DishesForm()
    {
        List<Chef> chefs = _context.Chefs.ToList();
        ViewBag.chefs = chefs;
        return View("DishForm");
    }

    [HttpPost("/dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        }
        else
        {
            return View("DishForm");
        }
    }









    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
