using FoodApp.Data;
using FoodApp.Entities;
using FoodApp.Entities;
using FoodApp.Service.Customers;
using FoodApp.Services;



//using FoodApp.Entities.Cart;
using FoodApp.Services.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FoodApp.Service
{
    public class CustomerAccessService:ICustomerAccessService
    {
        private readonly PizzaOrderingAppContext context;

        public object CartId { get; private set; }

        public CustomerAccessService(PizzaOrderingAppContext context)
        {
            this.context = context;
        }

        public PaymentInfo GetPaymentInfoByOrderId(int orderId)
        {
         
            var orderPayment = context.OrderPayments.FirstOrDefault(p => p.OrderSummary.OrderId == orderId);

            if (orderPayment != null)
            {
                if (orderPayment.PaymentStatus != PaymentStatus.Completed)
                {
                    throw new Exception($"Payment is not completed for this order. Status:{PaymentStatus.Pending}");
                }

                return new PaymentInfo
                {
                    Status = orderPayment.PaymentStatus,
                    TransactionId = orderPayment.TransactionId,
                    PaymentType = orderPayment.PaymentType
                };
            }

            else
            {
                throw new Exception("No payment found for this order.");
               
            }
        }

        

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
                throw new Exception($"Order with ID {orderId} not exist.");
            }

        }
        


        public List<Claim> DeletePizzaCart(DeletePizzaFromCart request)
        {
            
           var pizzaToRemove = context.CartItems.FirstOrDefault(p => p.CartItemId == request.CartItemId);
            if (pizzaToRemove != null)
            {
                return CartItem.Remove(pizzaToRemove);
            }
            else
            {
                throw new InvalidOperationException("Pizza not deleted");
            }


        }

        public DateTime ChooseDeliveryDateAndTime(ChooseDeliveryDateAndTime request)
        {
            
            var chooseDateAndTime = context.Carts.FirstOrDefault(p => p.CartId == request.CartId);

            if (CartId != null)
            {
                DateTime deliveryDateTime = request.date + request.time;
                return deliveryDateTime;
            }
            else
            {
                throw new InvalidOperationException("Cannot choose date and time");
            }

        }


        public void  CustomizePizza(int cartItemId, ToppingType[] Topping)
        {
            var cartItem = context.CartItems
                .FirstOrDefault(ci => ci.CartItemId == cartItemId);

            if (cartItem == null)
            {
                throw new ArgumentException("Cart item not found.");
            }

                // Add or update toppings for the pizza
                cartItem.ToppingType = Topping;

            // Save changes to the database
            context.SaveChanges();
        }


        public void CreateOrder(int cartId)
        {
            // Get the cart with the specified ID
            var cart = context.Carts
                .FirstOrDefault(c => c.CartId == cartId);

            if (cart == null)
            {
                throw new ArgumentException("Cart not found.");
            }

            // Create a new order
            var order = new OrderSummary
            {
                OrderId = cartId,

                OrderDate = DateTime.Now // Assuming current date and time for the order date
            };

            // Add the order to the database
            context.OrderSummaries.Add(order);
            context.SaveChanges();
        }

        





        }
    }


