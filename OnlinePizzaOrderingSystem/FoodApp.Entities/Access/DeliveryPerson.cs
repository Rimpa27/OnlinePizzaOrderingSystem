using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Entities
{
    public class DeliveryPerson: User
    {
        //public int DeliveryPersonId { get; set; }

        [Required]
        [RegularExpression("^[0-9]{10}$")]
        public long DeliveryPersonPhone {  get; set; }

        [Required]
        public string DeliveryPerson { get; set; }

        
    }
}

