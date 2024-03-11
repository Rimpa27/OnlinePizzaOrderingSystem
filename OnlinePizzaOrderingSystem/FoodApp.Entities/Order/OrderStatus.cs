using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Entities
{
    public enum OrderStatus
    {
        
        PaymentFailed =1,
        Pending,
        ConfirmOrder,
        InProgress,
        OutForDelivery,
        Delivered
    }
}
