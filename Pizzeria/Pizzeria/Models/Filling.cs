using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Models
{
    public class Filling
    {
        [Key]
        public string IdFilling { get; set; }
        public string NameFilling { get; set; }
        public int PriceFilling { get; set; }
    }
}
