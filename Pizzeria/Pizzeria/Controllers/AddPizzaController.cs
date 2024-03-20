using Microsoft.AspNetCore.Mvc;
using Pizzeria.Models;
using Pizzeria.Services;

namespace Pizzeria.Controllers
{
    public class AddPizzaController : Controller
    {
        public PizzaAddModel _pizzaAddModel {  get; set; }
        private readonly ApplicationDbContext _db;
        public PizzaService _pizzaService { get; set; }
        public AddPizzaController(ApplicationDbContext db)
        {
            _db = db;
            _pizzaService = new PizzaService(db);
        }

        public IActionResult Index()
        {
            PizzaAddModel pizzaAddModel = new PizzaAddModel();
            pizzaAddModel.Fillings = _db.Fillings.Select(f => f.NameFilling).ToList();

            pizzaAddModel.Sauces = _db.Sauces.Select(f => f.NameSauce).ToList();
            return View(pizzaAddModel);
        }

        [HttpPost]
        public IActionResult Details(PizzaAddModel pizzaAddModel, List<string> selectedFillings, List<string> souse)
        {
            _pizzaService.AddPizza(pizzaAddModel, selectedFillings, souse);
            return Redirect("/Pizza/Index");
        }
        
       
    }
}
