using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Entities;

namespace FoodApp.Entities
{
    public class OrderSummary
    {
        [Key]
        public int OrderId { get; set; }

        /// <summary>
        /// The date in which the order was places
        /// </summary>
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Order status is required")]
        [StringLength(50, ErrorMessage = "Order status must be less than 50 characters")]
        public OrderStatus OrderStatus { get; set; }

        [Required(ErrorMessage = "Order total is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Order total must be greater than or equal to 1")]
        [DataType(DataType.Currency)]
        public decimal OrderTotal { get; set; }

        public Customer Customer { get; set; }

        public OrderPayment Payment { get; set; }

        public List<OrderItem> OrderItems { get; set; }

       

    }
}
