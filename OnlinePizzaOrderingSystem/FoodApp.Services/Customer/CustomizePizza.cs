using FoodApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services.Customer
{
    public class CustomizePizza
    {

        public MenuItem MenuItem { get; set; }

        public int MenuItemId { get; set; }
        public string size { get; set; }
        //public List<Topping> Toppings { get; set; }
    }
}
