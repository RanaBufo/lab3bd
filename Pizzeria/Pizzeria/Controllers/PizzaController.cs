using Microsoft.AspNetCore.Mvc;
using Pizzeria.Models;
using Pizzeria.Services;

namespace Pizzeria.Controllers
{
    public class PizzaController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PizzaService pizzaService { get; set; }
        public PizzaController(ApplicationDbContext db)
        {
            _db = db;
            pizzaService = new PizzaService(db);
        }
        public IActionResult Index()
        {
            IEnumerable<Pizza> objCategoryList = _db.Pizzas;
            return View(objCategoryList);
        }
        [HttpPost]
        public IActionResult Delete(string idPizza)
        {
            pizzaService.DeletePizza(idPizza);


            return Redirect("/Pizza/Index");
        }
    }
}
