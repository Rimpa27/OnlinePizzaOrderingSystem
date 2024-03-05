using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class OrderItem
    {
        // A property for the order item ID
        [Key]
        public int OrderItemId { get; set; }

        // A property for the order ID
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        // A property for the pizza ID
        [ForeignKey("FoodItem")]
        public int FoodItemId { get; set; }

        // A property for the quantity
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

        // A property for the unit price
        [DataType(DataType.Currency)]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public decimal Price { get; set; }

        // A navigation property for the order
        [Required]
        public OrderSummary Order { get; set; }

        // A navigation property for the pizza
        [Required]
        public MenuItem FoodItem { get; set; }
    }
}
