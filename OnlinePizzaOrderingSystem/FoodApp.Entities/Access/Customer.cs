using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Entities;

namespace FoodApp.Entities
{
    public class Customer : User
    {
        

        
        [MaxLength(200, ErrorMessage = "address cannot be longer than 200 characters")]
        public Address? Address { get; set; }

        [Required]
        [RegularExpression("^[0-9]{10}$")]
        public long Phone { get; set; }



       
       


    }
}
