using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class OrderSummary
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
        public Enum OrderStatus { get; set; }

        [Required(ErrorMessage = "Order total is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Order total must be greater than or equal to 0")]
        [DataType(DataType.Currency)]
        public decimal OrderTotal { get; set; }

        [Required(ErrorMessage = "Customer ID is required")]
        public int CustomerId { get; set; }
        

        // 
        [Display(Name = "Customer")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("CustomerId")]
        public virtual ICollection<Cart> Items { get; set; }

    }
}
