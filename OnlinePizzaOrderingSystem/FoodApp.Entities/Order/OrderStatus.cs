using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Entities.Order
{
    public enum OrderStatus
    {
        //Created = 1,
        //PaymentPending,
        //PaymentCompleted,
        PaymentFailed =1,
        InProgress,
        OutForDelivery,
        Delivered
    }
}
