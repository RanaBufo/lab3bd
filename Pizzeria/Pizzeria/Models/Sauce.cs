using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Models
{
    public class Sauce
    {
        [Key]
        public string IDSauce { get; set; }
        public string NameSauce { get; set; }
        public int PriceSause { get; set; }
    }
}
