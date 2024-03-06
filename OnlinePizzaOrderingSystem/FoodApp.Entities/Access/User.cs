using FoodApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Entities
{
    public abstract class User 
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        [RegularExpression("^[a-zA-Z ]{2,50}$")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(5)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is mandatory")]
        public RoleType RoleType { get; set; }
       

    }
}
