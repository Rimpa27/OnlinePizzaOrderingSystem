using FoodApp.Data;
using FoodApp.Entities;
using FoodApp.Services.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


namespace FoodApp.Service.Customers
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
        public async Task<bool> AddMenuItemToCartAsync(int cartId, int menuItemId, int quantity)
        {
            try
            {
                var cart = await context.Carts.Include(c => c.CartItemList).FirstOrDefaultAsync(c => c.CartId == cartId);
                var menuItem = await context.MenuItems.FindAsync(menuItemId);

                if (cart == null || menuItem == null)
                {
                    throw new Exception("Cart or MenuItem not found.");
                }

                var cartItem = cart.CartItemList.FirstOrDefault(ci => ci.MenuItem.MenuItemId == menuItemId);

                if (cartItem != null)
                {
                    cartItem.CartItemQuantity += quantity;
                }
                else
                {
                    cart.CartItemList.Add(new CartItem
                    {
                        CartItemQuantity = quantity,
                        CartItemPrice = menuItem.Price * quantity,
                        MenuItem = menuItem
                    });
                }

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception, log error, etc.
                throw new Exception("An error occurred while adding the MenuItem to the Cart.", ex);
            }
        }


        public async Task<bool> DeleteCartItemByIdAsync(int cartItemId)
            {
                try
                {
                    var cartItem = await context.CartItems.FindAsync(cartItemId);

                    if (cartItem == null)
                    {
                        throw new NotFoundException("CartItem not found.");
                    }

                    context.CartItems.Remove(cartItem);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch (NotFoundException ex)
                {
                    // Log the exception, etc.
                    throw;
                }
                catch (Exception ex)
                {
                    // Log the exception, etc.
                    throw new Exception("An error occurred while deleting the cart item.", ex);
                }



            public void CreateOrder(int cartId, string customerName, string customerAddress)
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

           public  void CustomizePizza(int cartItemId, string[] toppings)
            {
                var cartItem = context.CartItems
                    .FirstOrDefault(ci => ci.CartItemId == cartItemId);

                if (cartItem == null)
                {
                    throw new ArgumentException("Cart item not found.");
                }

                // Add or update toppings for the pizza
                cartItem.ToppingType = toppings;

                // Save changes to the database
                context.SaveChanges();
            }

            public DeliveryPerson AssignDeliveryPerson(string DeliveryPersonName)
            {
                var person = context.DeliveryPeople.FirstOrDefault(d => d.DeliveryPersonName == DeliveryPersonName);
                if (person != null)
                {
                    return person.DeliveryPerson;
                }
                else
                {
                    throw new Exception($"Person with Name {DeliveryPersonName}is not assigned");

                }

            }

            public OrderItem ConfirmOrder(int OrderItemId)
            {
                var order = context.OrderItems.FirstOrDefault(d => d.orderId == OrderItemId);
                if (order != null)
                {
                    return order.ConfirmOrder;
                }

                else
                {
                    throw new Exception($"Order with {OrderItemId} is not valid");
                }
            }
        }
    }
    }
    



       



        

        



