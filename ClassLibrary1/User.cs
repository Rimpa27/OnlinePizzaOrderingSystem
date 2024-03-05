using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class User
    {
        [Key]
        public int userID { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [MinLength(10, ErrorMessage = "Phone number must contain atleast 10 digits")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(200, ErrorMessage = "address cannot be longer than 200 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Role is mandatory")]
        public string Role { get; set; }
    }
}
