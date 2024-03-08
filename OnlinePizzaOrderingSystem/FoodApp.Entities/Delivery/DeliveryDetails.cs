using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Entities
{
    public class DeliveryDetails
    {
        [Key]
       public int DeliveryId { get; set; }
        public DateTime DeliveryDateTime { get; set; }
    }
}
