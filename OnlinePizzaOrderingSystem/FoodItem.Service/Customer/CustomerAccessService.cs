using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Service.Customer
{
    public class CustomerAccessService : ICustomerAccessService
    {
        private readonly PizzaOrderingAppContext context;

        public CustomerAccessService(PizzaOrderingAppContext context)
        {
            this.context = context;
        }

        public bool Payment(OrderPayment payment)
        {
            switch (payment.PaymentType)
            {
                case PaymentType.Card:
                    
                    payment.PaymentStatus = PaymentStatus.Completed;
                    payment.TrancationId = Guid.NewGuid().ToString(); // Generate a unique transaction ID
                    return true;

                case PaymentType.UPI:
                  
                    payment.PaymentStatus = PaymentStatus.Completed;
                    payment.TrancationId = Guid.NewGuid().ToString(); // Generate a unique transaction ID
                    return true;

                case PaymentType.CashOnDelivery:
                   
                    payment.PaymentStatus = PaymentStatus.Completed;
                    payment.TrancationId = null; // No transaction ID for COD
                    return true;

                default:
                    // If payment type is not recognized, consider it as failed payment
                    payment.PaymentStatus = PaymentStatus.Pending;
                    return false;

            }

        }


    }
}
