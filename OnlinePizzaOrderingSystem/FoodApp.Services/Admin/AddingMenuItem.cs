using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Entities;

namespace FoodApp.Services
{
    public class AddingMenuItem
    {
        public int menuItemId { get; set; }
        public string name { get; set; }
        public string itemDescription { get; set; }
        public int calories { get; set; }
        public bool isAvailable { get; set; }
        public VegOrNonVeg vegOrNonVeg { get; set; }
        public MenuItemCategory category { get; set; }
        public string imageUrl { get; set; }
        public int preparationTime { get; set; }
        public decimal price { get; set; }
    }
}
