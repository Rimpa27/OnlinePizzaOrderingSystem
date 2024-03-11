using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Entities;

namespace FoodApp.Services
{
    public class ChooseDeliveryDateAndTime
    {
       public int CartId { get; set; }
       // public int DeliveryId {  get; set; }
       public DateTime SelectedDateTime { get; set; }
    }
}
