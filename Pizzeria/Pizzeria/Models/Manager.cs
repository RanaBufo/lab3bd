using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzeria.Models
{
    [Table("Managers")]
    public class Manager : Worker
    {

        public string Department { get; set; } // Department managed by the manager
        public bool HasLeadershipTraining { get; set; }
    }
}
