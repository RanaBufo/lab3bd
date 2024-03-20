using Pizzeria.Models;
using System.Text.RegularExpressions;

namespace Pizzeria.Services
{
    public class PizzaService
    {
        private readonly ApplicationDbContext _db;
        public PizzaService(ApplicationDbContext db) { _db = db; }
        public string FindIdPizza()
        {
            List<Pizza> pizzas = _db.Pizzas.ToList();
            if (pizzas.Count > 0)
            {

                var numbers = pizzas
            .Select(p => Regex.Match(p.IDPizza, @"\d+"))
            .Where(match => match.Success)
            .Select(match => int.Parse(match.Value));

                // Находим максимальное число
                int maxNumber = numbers.DefaultIfEmpty().Max();

                // Составляем новый ID
                string nextId = "PIZ" + (maxNumber + 1);

                return nextId;
            }
            return "PIZ1";
        } 
        public void AddPizza(PizzaAddModel ppizzaAddModel, List<string> SlectedFillings, List<string> SSouse)
        {
            if(ppizzaAddModel.PizzaName == null)
            {
                ppizzaAddModel.PizzaName = "New PIZZA";
            }
            string? id = null;
            string str = "";
            foreach (var filling in SlectedFillings)
            {
                var _filling = _db.Fillings.FirstOrDefault(f => f.NameFilling == filling);
                if (str != "")
                {
                    str += ", " + filling;
                }
                else str = filling;

                ppizzaAddModel.PizzaPrice += _filling.PriceFilling;
            }
            foreach (var filling in SSouse)
            {
                var _filling = _db.Sauces.FirstOrDefault(f => f.NameSauce == filling);
                str += ", " + filling;
                ppizzaAddModel.PizzaPrice += _filling.PriceSause;
                id = _filling.IDSauce;
                break;
            }
            if (SSouse.Count == 0) 
            {
                id = "So0";
            }
            if (ppizzaAddModel.PizzaImage == null)
            {
                ppizzaAddModel.PizzaImage = "1.png";
            }
            var newpizza = new Pizza
            {
                IDPizza = FindIdPizza(),
                PizzaName = ppizzaAddModel.PizzaName,
                PizzaImage = ppizzaAddModel.PizzaImage,
                PizzaPrice = ppizzaAddModel.PizzaPrice,
                Description = str,
                IDSauce = id

            };
            _db.Pizzas.Add(newpizza);
            _db.SaveChanges();
        }
        public void DeletePizza(string idPizza)
        {
            var pizzaToDelete = _db.Pizzas.Find(idPizza);
            if (pizzaToDelete != null)
            {
                _db.Pizzas.Remove(pizzaToDelete);
                _db.SaveChanges();
            }
        }
    }
}
