using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzeria.Models
{
    [Table("Directors")]
    public class Director : Worker
    {
        
        public string Department { get; set; }
        public bool HasLeadershipExperience { get; set; }
    }
}
