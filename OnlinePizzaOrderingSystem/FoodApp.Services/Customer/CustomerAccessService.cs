        using FoodApp.Data;
        using FoodApp.Entities;
        using FoodApp.Services;
        using Microsoft.EntityFrameworkCore;
        


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

                }

            public async Task<OrderSummary?> ChooseDeliveryDateAndTimeAsync(int OrderId, DateTime selectedDateTime)
             {
                // Logic to validate and save selected date and time for delivery

                var order = await context.OrderSummaries.FirstOrDefaultAsync(c => c.OrderId == OrderId);
                if (order == null)
                {
                    // Order not found
                    return null;
                }

                // Assuming you have a DeliveryDetails table or property in Order table to store delivery info
                order.DeliveryDetails = new DeliveryDetails
                {
                    DeliveryDateTime = selectedDateTime
                };

                await context.SaveChangesAsync();

                return order;
             }
        }
            }
    



       



        

        



