using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public class AddingMenuItemToCart
    {
        public int cartId { get; set; }
        public int menuItemId { get; set; }
       public int quantity { get; set; }
    }
}
