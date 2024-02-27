using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class Cart
    {
        [Key]
        [Required(ErrorMessage = "Name is required")]
        public int FoodItemName { get; set; }// represents the name of the food item

        [Display(Name = "Items")]
        public virtual ICollection<CartItem> Items { get; set; }//collection of items
                                                                //CartItem represents an individual item in the cart with its name,quantity,price


        [Display(Name = "Total Items")]

        public int TotalItems//calculates the total number of items in the cart
        {
            get
            {
                int total = 0;
                foreach (var item in Items)
                {
                    total += item.Quantity;//we have created Quantity Property in CartItem class
                }
                return total;
            }
        }


        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice//calculates the total price of each type of food in the cart 
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.Quantity * item.Price;//we have created Price Property in CartItem class
                }
                return totalPrice;
            }
        }

        [Display(Name = "Total Amount")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalAmount => TotalPrice;//represents the total amount,formatted as currency using[DisplayFormat]


        [Display(Name = "Checkout")]
        public bool CheckoutsButton
        {
            get
            {
                return Items != null && Items.Count > 0;//cart should not be empty to enable checkout
            }
        }
    }
}
