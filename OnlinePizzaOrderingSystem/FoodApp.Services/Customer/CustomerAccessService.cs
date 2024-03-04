using FoodApp.Data;
using FoodApp.Entities.Order;
using FoodApp.Entities.Payment;
using FoodApp.Service.Customer;
using FoodApp.Services.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Service.Customers
{
    public class CustomerAccessService : ICustomerAccessService
    {
        private readonly PizzaOrderingAppContext context;

        public CustomerAccessService(PizzaOrderingAppContext context)
        {
            this.context = context;
        }

        //public bool Payment(OrderPayment orderPayment)
        //{
        //    switch (orderPayment.PaymentType)
        //    {
        //        case PaymentType.Card:
                    
        //            orderPayment.PaymentStatus = PaymentStatus.Completed;
        //            orderPayment.TrancationId = Guid.NewGuid().ToString(); // Generate a unique transaction ID
        //            return true;

        //        case PaymentType.UPI:
                  
        //            orderPayment.PaymentStatus = PaymentStatus.Completed;
        //            orderPayment.TrancationId = Guid.NewGuid().ToString(); // Generate a unique transaction ID
        //            return true;

        //        case PaymentType.CashOnDelivery:
                   
        //            orderPayment.PaymentStatus = PaymentStatus.Completed;
        //            orderPayment.TrancationId = null; // No transaction ID for COD
        //            return true;

        //        default:
        //            // If payment type is not recognized, consider it as failed payment
        //            orderPayment.PaymentStatus = PaymentStatus.Pending;
        //            return false;


        //    }

        //}

       public OrderStatus GetOrderStatusByOrderID(int orderId)
        {
            var orderSummary = context.OrderSummaries.FirstOrDefault(o => o.OrderId == orderId);

            if (orderSummary != null)
            {
                return orderSummary.OrderStatus;
            }
            else
            {
                // If the order summary does not exist, throw a new exception
                throw new Exception($"Order summary with ID {orderId} does not exist.");
            }

        }
        public List<Claim> DeletePizzaCart(DeletePizzaFromCart request)
        {
            var customer = new Customer();
            var pizzaToRemove = context.customer.Cart.Find(p => p.PizzaId == request.PizzaId);
            if (pizzaToRemove != null)
            {
                context.customer.Cart.Remove(pizzaToRemove);
            }
            else
            {
                throw new InvalidOperationException("Pizza not deleted");
            }



        }

    }
}
