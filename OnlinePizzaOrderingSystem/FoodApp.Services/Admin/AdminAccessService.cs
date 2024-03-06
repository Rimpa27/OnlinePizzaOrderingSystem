using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.Services
{
    public class AdminAccessService : IAdminAccessServices
    {
        private readonly PizzaOrderingAppContext context;

        //public object CartId { get; private set; }

        public AdminAccessService(PizzaOrderingAppContext context)
        {
            this.context = context;
        }

        public async Task<bool> EditOrderAsync(OrderUpdateModel updateModel)
        {
            try
            {
                var existingOrder = await context.OrderSummaries
                    .Include(o => o.OrderItems)
                    .FirstOrDefaultAsync(o => o.OrderId == updateModel.OrderId);

                if (existingOrder == null)
                {
                    throw new Exception("Order not found.");
                }

                // Update order properties
                existingOrder.OrderDate = updateModel.OrderDate;
                existingOrder.OrderStatus = updateModel.OrderStatus;
                existingOrder.OrderTotal = updateModel.OrderTotal;

                // Update related entities (e.g., customer, payment, order items)

                // Update customer
                existingOrder.Customer = updateModel.Customer;

                // Update payment
                existingOrder.Payment = updateModel.Payment;

                // Update order items (if necessary)
                // This is just an example; you may need to implement logic to update order items

                // Save changes to the database
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception, log error, etc.
                throw new Exception("An error occurred while editing the order.", ex);
            }
        }
    }
}
