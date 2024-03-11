using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Entities;

namespace FoodApp.Services
{
    public class CustomizedPizza
    {
       public int CartItemId {  get; set; }
       public ToppingType[] Topping { get; set; } 
    }
}
