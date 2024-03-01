using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Entities.Cart
{
    public class Cart
    {
        [Key]
        [Required(ErrorMessage = "Name is required")]
        public int CartItemName { get; set; }// represents the name of the food item
 
        [Display(Name = "Items")]
        public List<CartItem> CartItems { get; set; } //collection of items
                                                                //CartItem represents an individual item in the cart with its name,quantity,price
 
 
        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice//calculates the total price of each type of food in the cart 
        {
            get
            {
                return CartItems.Sum(d => d.Price);
            }
        }
    }
}
