using FoodApp.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public class MenuItemDto
    {
        public int MenuItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int Calories { get; set; }
        public bool IsAvailable { get; set; }
        public VegOrNonVeg VegOrNonVeg { get; set; }
        public MenuItemCategory Category { get; set; }
        public int PreparationTime { get; set; }
        public decimal Price { get; set; }

        public string ProductPhoto { get; set; }
    }
}
