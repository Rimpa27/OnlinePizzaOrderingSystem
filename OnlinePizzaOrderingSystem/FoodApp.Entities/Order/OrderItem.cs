    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FoodApp.Entities.Menu;

namespace FoodApp.Entities.Order
{
        public class OrderItem
        {
            // A property for the order item ID
            [Key]
             public int OrderItemId { get; set; }

             public MenuItem MenuItem { get; set; }

            // A property for the quantity
            [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
            public int Quantity { get; set; }

            // A property for the unit price
            [Required(ErrorMessage = "Price required")]
            [Range(1, 1000, ErrorMessage = "Price must be between 1 and 1000")]
            [DataType(DataType.Currency)]
            public decimal Price { get; set; }
           
        }
    }
