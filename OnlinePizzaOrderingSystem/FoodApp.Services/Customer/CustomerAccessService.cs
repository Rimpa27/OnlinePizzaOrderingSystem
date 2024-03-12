using System.Security.Authentication;
using System.Security.Claims;
using FoodApp.Data;
using FoodApp.Entities;
using FoodApp.Services;
using Microsoft.EntityFrameworkCore;


namespace FoodApp.Services
{
    public class CustomerAccessService : ICustomerAccessService
    {
        private readonly PizzaOrderingAppContext context;

        //public object CartId { get; private set; }

        public CustomerAccessService(PizzaOrderingAppContext context)
        {
            this.context = context;
        }




        public Customer SignUp(SignUpRequest request)//cdone

        {

            //Check if the email is already in use

            if (context.Customers.Any(d => d.Email == request.Email))

                throw new DuplicateEmailException("Email already exist");

            var customer = new Customer();
            customer.Name = request.Name;

            customer.Email = request.Email;
            customer.Password = request.Password;
            customer.Phone = request.Phone;
            // customer.Address = new Address { request.City };
            customer.Address = request.City;
            context.Customers.Add(customer);

            context.SaveChanges();

            return customer;


        }

        public List<Claim> SignIn(SignInRequest request)//cdone

        {

            var customer = context.Customers.FirstOrDefault(d => d.Email == request.Email

                                        && d.Password == request.Password);

            if (customer == null)

                throw new AuthenticationException("Login Failed");

            var result = new List<Claim> {

            new Claim("Email",customer.Email),

            new Claim(ClaimTypes.NameIdentifier,customer.Name),

        };

            return result;

        }


        public async Task<OrderSummary> CreateOrderAsync(CreateOrderForCustomer req)
        {
            var customer = await context.Customers.FindAsync(req.CustomerId);
            var cart = await context.Carts.Include(d => d.CartItemList).ThenInclude(d => d.MenuItem).FirstOrDefaultAsync(d => d.CartId == req.CartId);

            if (customer == null)
                throw new CustomerNotFoundException("Customer not found");

            if (cart == null)
                throw new CartNotFoundException("Cart not found");

            var order = new OrderSummary
            {
                OrderDate = DateTime.Now,
                OrderStatus = OrderStatus.Pending,
                OrderTotal = cart.TotalPrice,
                Customer = customer,
                OrderItems = new List<OrderItem>()
                //Cart = cart
            };

            foreach (var cartItem in cart.CartItemList)
            {
                var orderItem = new OrderItem
                {
                    MenuItem = cartItem.MenuItem,
                    CartItemPrice = cartItem.CartItemPrice,
                    CartItemQuantity = cartItem.CartItemQuantity
                };
                order.OrderItems.Add(orderItem);
            }

            context.OrderSummaries.Add(order);
            await context.SaveChangesAsync();

            return order;
        }

        //public void CustomizePizza(CustomizedPizza cp)
        //{
        //    var cartItem = context.CartItems
        //        .FirstOrDefault(ci => ci.CartItemId == cp.CartItemId);

        //    if (cartItem == null)
        //    {
        //        throw new ArgumentException("Cart item not found.");
        //    }

        //    // Add or update toppings for the pizza
        //    cartItem.ToppingType = cp.Topping;

        //    // Save changes to the database
        //    context.SaveChanges();
        //}




        public async Task<bool> AddMenuItemToCartAsync(AddingMenuItemToCart request)//cdone
        {
            try
            {
                var cart = await context.Carts.Include(c => c.CartItemList).ThenInclude(d => d.MenuItem).FirstOrDefaultAsync(c => c.CartId == request.CartId);
                var menuItem = await context.MenuItems.FindAsync(request.MenuItemId);

                if (cart == null || menuItem == null)
                {
                    throw new Exception("Cart or MenuItem not found.");
                }

                var cartItem = cart.CartItemList.FirstOrDefault(ci => ci.MenuItem.MenuItemId == request.MenuItemId);

                if (cartItem != null)
                {
                    cartItem.CartItemQuantity += request.Quantity;
                }
                else
                {
                    cart.CartItemList.Add(new CartItem
                    {
                        CartItemQuantity = request.Quantity,
                        CartItemPrice = menuItem.Price * request.Quantity,
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


        public async Task<bool> DeleteCartItemByIdAsync(DeleteCartItemById req)//cdone
        {
            try
            {
                var cart = await context.Carts
                                .Include(c => c.CartItemList)
                                .FirstOrDefaultAsync(c => c.CartId == req.CartId);

                if (cart == null)
                {
                    throw new NotFoundException("Cart not found.");
                }

                var cartItem = cart.CartItemList.FirstOrDefault(ci => ci.CartItemId == req.CartItemId);

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


        public async Task<DeliveryDetails?> ChooseDeliveryDateAndTimeAsync(ChooseDeliveryDateAndTime req)//cdone
        {
            try
            {
                var cart = await context.Carts.FirstOrDefaultAsync(c => c.CartId == req.CartId);

                if (cart == null)
                {
                    // Cart not found
                    return null;
                }

                // Assuming you have a DeliveryDetails table or property in Order table to store delivery info
                cart.DeliveryDetails = new DeliveryDetails
                {

                    DeliveryDateTime = req.SelectedDateTime
                };

                context.Carts.Update(cart);
                await context.SaveChangesAsync();

                return cart.DeliveryDetails;
            }
            catch (Exception ex)
            {
                // Log the exception, etc.
                throw new Exception("An error occurred while choosing delivery date and time.", ex);
            }
        }

        public PaymentInfo GetPaymentInfoByOrderId(int orderId)
        {

            var orderPayment = context.OrderSummaries.FirstOrDefault(p => p.OrderId == orderId).Payment;

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

        public static void CustomizedPizza(CustomizedPizza cp)
        {
            throw new NotImplementedException();
        }
    }
}














