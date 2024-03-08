using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Entities;

namespace FoodApp.Services
{
    public class OrderUpdateModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal OrderTotal { get; set; }
        public Customer Customer { get; set; }
        public OrderPayment Payment { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
