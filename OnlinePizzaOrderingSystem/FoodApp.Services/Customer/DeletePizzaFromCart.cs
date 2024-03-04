using FoodApp.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services.Customer
{
    public class DeletePizzaFromCart
    {
        public int CustomerId { get; set; }
         public Cart CartId { get; set; } 
        //public CartItem CartItemId { get; set; }
        public int CartItemId { get; set; }
    }
}
