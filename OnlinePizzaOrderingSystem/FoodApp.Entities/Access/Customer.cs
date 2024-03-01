using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Entities.Access
{
    public class Customer : User
    {
        [Key]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(200, ErrorMessage = "address cannot be longer than 200 characters")]
        public Address Address { get; set; }

        [Required]
        [RegularExpression("^[0-9]{10}$")]
        public long Phone { get; set; }


        //Suggested by Mam
        //[ForeignKey("CustomerID")]
        //public User? user { get; set; }
    }
}
