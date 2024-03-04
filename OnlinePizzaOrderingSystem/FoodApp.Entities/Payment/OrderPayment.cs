using FoodApp.Entities.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Entities.Payment
{
    public class OrderPayment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required(ErrorMessage = "Payment method type is required")]
        [EnumDataType(typeof(PaymentType), ErrorMessage = "Invalid payment method")]
        public PaymentType PaymentType { get; set; }

        [Required(ErrorMessage = "Payment Status is required")]
        [EnumDataType(typeof(PaymentStatus), ErrorMessage = "Invalid payment Status")]
        public PaymentStatus PaymentStatus { get; set; } 

        public string TransactionId { get; set; }

        public OrderSummary OrderSummary { get; set; }
    }
}
