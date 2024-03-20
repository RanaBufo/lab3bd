namespace Pizzeria.Models
{
    public class PizzaAddModel
    {
        public string PizzaName { get; set; }
        public double PizzaPrice { get; set; } = 3;
        public string PizzaImage { get; set; }
        public List<string>?  Fillings { get; set; }
        public List<string>? Sauces { get; set; }
    }
}
