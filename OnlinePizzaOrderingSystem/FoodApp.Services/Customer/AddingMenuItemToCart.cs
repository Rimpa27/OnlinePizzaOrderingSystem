using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public class AddingMenuItemToCart
    {
        public int CartId { get; set; }
        public int MenuItemId { get; set; }
       public int Quantity { get; set; }
    }
}
