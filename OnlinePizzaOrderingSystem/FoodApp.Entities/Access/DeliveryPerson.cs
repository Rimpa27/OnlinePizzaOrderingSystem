using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Entities
{
    public class DeliveryPerson: User
    {
        [Required]
        [RegularExpression("^[0-9]{10}$")]
        public long Phone { get; set; }
    }
}

