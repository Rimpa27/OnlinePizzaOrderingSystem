using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class CartItem
    {
        [Key]
        [Required(ErrorMessage = "Item name is required")]
        public string CartItemName { get; set; }//represents individual product name

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
        [Display(Name = "Quantity")]
        public int FoodItemQuantity { get; set; }//individual type of item quantity

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        [DataType(DataType.Currency)]
        public decimal FoodItemPrice { get; set; }//individual type of item's price


        public enum VegOrNonveg //enum represents the type of the foodItem
        {
            [Display(Name = "Vegetarian")] Veg,
            [Display(Name = "Non-Vegetarian")] NonVeg

        }
        public VegOrNonveg foodtype { get; set; }// to define the type of the fooditem



        [ForeignKey("FoodItemName")]//primary key of the class Cart
        public virtual Cart Cart { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
