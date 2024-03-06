using FoodApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public class PaymentInfo
    {
        public OrderSummary OrderSummary { get; set; }  
        public PaymentStatus Status { get; set; }
        public string TransactionId { get; set; }

        public PaymentType PaymentType { get; set; }

    }
}
