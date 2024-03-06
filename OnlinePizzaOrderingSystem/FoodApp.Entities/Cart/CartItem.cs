using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Entities;
using System.Security.Claims;

namespace FoodApp.Entities
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }


        
        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
        public int CartItemQuantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal CartItemPrice { get; set; }

       
       [ Required]
        public MenuItem MenuItem { get; set; }
         public ToppingType[] ToppingType { get; set; }   
        
    }
}
