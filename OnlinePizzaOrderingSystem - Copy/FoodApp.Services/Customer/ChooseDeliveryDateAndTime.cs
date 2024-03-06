using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Entities;

namespace FoodApp.Services.Customer
{
    public class ChooseDeliveryDateAndTime
    {
        public DateTime date { get; set; }
        public TimeSpan time { get; set; }

        public int CartId {  get; set; }
    }
}
