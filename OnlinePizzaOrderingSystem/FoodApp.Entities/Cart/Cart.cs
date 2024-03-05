using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Entities
{
    public class Cart
    {
        [Key]
        [Required(ErrorMessage = "CartId is required")]
        public int CartId { get; set; }// represents the name of the food item

        public List<CartItem> CartItemList { get; set; } // List to store cart items

 

        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice//calculates the total price of each type of food in the cart 
        {
            get
            {
                return CartItemList.Sum(d => d.CartItemPrice);
            }
        }
        public Customer Customers { get; set; }
    }
}
