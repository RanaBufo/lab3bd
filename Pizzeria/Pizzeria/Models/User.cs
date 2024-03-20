using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Models
{
    public class User
    {
        [Key]
        public string IDUser { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string UserPassword { get; set; }
    }
}
