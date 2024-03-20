using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzeria.Models
{
    [Table("Cockers")]
    public class Cocker : Worker
    {
        public string Specialization { get; set; }
        public int ExperienceYears { get; set; }
        public bool HasFoodSafetyTraining { get; set; }
    }
}
