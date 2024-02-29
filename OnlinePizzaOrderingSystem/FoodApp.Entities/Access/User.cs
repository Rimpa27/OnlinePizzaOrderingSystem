using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Entities.Access
{
    public class User
    {
        [Key]
        public int userID { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Role is mandatory")]
        public RoleType RoleType { get; set; }
       

    }
}
