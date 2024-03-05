using FoodApp.Entities.Cart;

namespace FoodApp.Service.Customers
{
    public class Topping
    {
        public string Name { get; set; }
        public CartItem CartItem { get; set; }
    }
}