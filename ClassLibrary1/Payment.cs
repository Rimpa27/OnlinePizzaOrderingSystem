using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Order Value can be of decimal value")]
        public decimal Amount { get; set; }
        [Required]
        public int Orderid { get; set; }
        [Required(ErrorMessage = "Payment method type is required")]
        [EnumDataType(typeof(PaymentType), ErrorMessage = "Invalid payment method")]
        [Display(Name = "Payment method type")]
        public PaymentType PaymentMethod { get; set; }
        [Required]
        public bool Issuccessful { get; set; }


    }
    public enum PaymentType
    {
        CreditCard,
        DebitCard,
        UPI,
        Cash
    }
}
   