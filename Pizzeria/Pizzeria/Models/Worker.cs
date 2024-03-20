using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Models
{
    public class Worker
    {
        [Key]
        public string IDWorker { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }
        public string WorkerEmail { get; set; }
        public string WorkerPhone { get; set; }
        public string WorkerPassword { get; set; }
    }
}
