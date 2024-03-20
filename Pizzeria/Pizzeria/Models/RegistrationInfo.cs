using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Models
{
    public class RegistrationInfo
    {
        [Required(ErrorMessage = "Name is required")]
        public string WorkerName { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        public string WorkerSurname { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string WorkerEmail { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string WorkerPhone { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string WorkerPassword { get; set; }
        [Required(ErrorMessage = "Duplicate Password is required")]
        public string WorkerDuplicatePassword { get; set; }
    }
}
