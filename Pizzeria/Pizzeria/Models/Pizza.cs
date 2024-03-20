using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Models
{
    public class Pizza
    {
        [Key]
        public string IDPizza { get; set; }
        public string PizzaName { get; set; }
        public double PizzaPrice { get; set; }
        public string PizzaImage { get; set; }
        public string IDSauce { get; set; }
        public string Description { get; set; }
    }
}
