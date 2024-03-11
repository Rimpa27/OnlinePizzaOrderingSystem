using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Entities;
using Microsoft.AspNetCore.Http;

namespace FoodApp.Services
{
    public class AddingMenuItem
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
       public IFormFile Photo {  get; set; }
    }
}
