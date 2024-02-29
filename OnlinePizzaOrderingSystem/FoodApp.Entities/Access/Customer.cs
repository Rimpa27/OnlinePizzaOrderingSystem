using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Entities.Access
{
    public class Customer : User
    {
        [Key]
        public int adminID { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [MaxLength(200, ErrorMessage = "address cannot be longer than 200 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [MinLength(10, ErrorMessage = "Phone number must contain atleast 10 digits")]
        public int PhoneNumber { get; set; }
    }
}
