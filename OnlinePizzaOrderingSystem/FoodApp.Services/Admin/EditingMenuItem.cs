using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Entities;

namespace FoodApp.Services
{
    public class EditingMenuItem
    {
        public string NewName { get; set; }
        public string NewItemDescription { get; set; }
        public int NewCalories { get; set; }
        public bool NewIsAvailable { get; set; }
        public VegOrNonVeg NewVegOrNonVeg { get; set; }
        public MenuItemCategory NewCategory { get; set; }
        public string NewImageUrl { get; set; }
        public int NewPreparationTime { get; set; }
        public decimal NewPrice { get; set; }
    }
}
