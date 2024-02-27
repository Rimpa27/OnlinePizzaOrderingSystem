using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class DeliveryPersonnel
    {
        // Unique identifier for each delivery
        [Key]
        public int DeliveryId { get; set; }
        [Required]
        [StringLength(100)]
        public string DeliveryName { get; set; }
        // Identifier for the order associated with this delivery
        [ForeignKey("Orderid")]
        public int OrderId { get; set; }
        // Name of the person who will receive the delivery
        [ForeignKey("Customer")]
        [StringLength(100)]
        public string CustomerName { get; set; }
        // Address where the delivery should be made
        [Required]
        [StringLength(200)]
        public string DeliveryAddress { get; set; }
        // Date when the delivery is scheduled
        [Required]
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }
        // Current status of the delivery (e.g., "Pending", "In Transit", "Delivered")
        [StringLength(20)]
        public string Status { get; set; }
    }
}
