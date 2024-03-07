using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Data;
using FoodApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.Services
{
    public class AdminAccessService : IAdminAccessServices
    {
        private readonly PizzaOrderingAppContext context;

        public List<Claim> SignIn(SignInRequest request)

        {

            var admin = context.Admins.FirstOrDefault(d => d.Email == request.Email

                                        && d.Password == request.Password);

            if (admin == null)

                throw new AuthenticationException("Login Failed");

            var result = new List<Claim> {

            new Claim("Email",admin.Email),

            new Claim(ClaimTypes.NameIdentifier,admin.Name),

        };

            return result;

        }


        public async Task<bool> AddOrderAsync(OrderSummary order)
        {
            try
            {
                context.OrderSummaries.Add(order);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception, log error, etc.
                throw new Exception("An error occurred while adding the order.", ex);
            }
        }






        public void AddOrderSummary(OrderSummary orderSummary)
        {
            // Add an order summary to the log
            context.OrderSummaries.Add(orderSummary);
        }

       
        public List<OrderSummary> GetOrdersForAdmin(List<OrderSummary> OrderSummaries)
        {
            // Retrieve order summaries associated with the given admin username
            var adminOrderSummaries = new List<OrderSummary>();
            foreach (var summary in OrderSummaries)
            {
                adminOrderSummaries.Add(summary);
            }
            return adminOrderSummaries;
        }
        public MenuItem AddMenuItem(AddingMenuItem addingMenuItem)
        {
            
            var newMenuItem = new MenuItem { 

            MenuItemId = addingMenuItem.menuItemId,
            MenuItemName = addingMenuItem.name,
                MenuItemDescription = addingMenuItem.itemDescription,
                calories = addingMenuItem.calories,
                IsAvailable = addingMenuItem.isAvailable,
                VegOrNonVeg = addingMenuItem.vegOrNonVeg,
                MenuItemCategory = addingMenuItem.category,
                ImageUrl = addingMenuItem.imageUrl,
                PreparationTime = addingMenuItem.preparationTime,
                Price = addingMenuItem.price


};
             context.MenuItems.Add(newMenuItem);
            context.SaveChanges();
            return newMenuItem;
            
          
        }
        public void DeleteMenuItem(DeleteMenuItem request)
        {
            var MenuItemToRemove = context.MenuItems.FirstOrDefault(p => p.MenuItemId == request.MenuItemId);
            if (MenuItemToRemove == null)
            {
                throw new InvalidOperationException("Item not Found");
            }
            else
            {
                context.MenuItems.Remove(MenuItemToRemove);
                context.SaveChanges();
            }
        }
        public MenuItem EditMenuItem(MenuItem menuItem, EditingMenuItem editingMenuItem)
        {
            menuItem.MenuItemName = editingMenuItem.newName;
            menuItem.MenuItemDescription = editingMenuItem.newItemDescription;
            menuItem.calories = editingMenuItem.newCalories;
            menuItem.IsAvailable = editingMenuItem.newIsAvailable;
            menuItem.VegOrNonVeg = editingMenuItem.newVegOrNonVeg;
            menuItem.MenuItemCategory = editingMenuItem.newCategory;
            menuItem.ImageUrl = editingMenuItem.newImageUrl;
            menuItem.PreparationTime = editingMenuItem.newPreparationTime;
            menuItem.Price = editingMenuItem.newPrice;
            return menuItem;
        }
        public void AdminDeleteOrder(AdminDeleteOrder request)
        {
            // Find the order to delete
            var order = context.OrderSummaries.FirstOrDefault(o => o.OrderId == request.orderId);

            if (order == null)
            {
                throw new InvalidOperationException("Order Not Found");
            }
            else
            {
                context.OrderSummaries.Remove(order);
                context.SaveChanges();
            }
        }

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

        public void AssignDeliveryPerson(AssignDeliveryPerson req)
        {
            var order = context.OrderSummaries.FirstOrDefault(o => o.OrderId == req.orderId);
            var deliveryPerson = context.DeliveryPersons.FirstOrDefault(dp => dp.UserID == req.deliveryPersonId);

            if (order != null && deliveryPerson != null)
            {
                order.DeliveryPerson = deliveryPerson;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Order or delivery person not found.");
            }
        }

        public void ConfirmOrder(int cartId)
        {
            var cart = context.Carts.Include(c => c.Customers).Include(c => c.CartItemList).FirstOrDefault(c => c.CartId == cartId);

            if (cart != null)
            {
                var orderSummary = new OrderSummary
                {
                    // Populate OrderSummary properties based on the cart and customer details
                    OrderDate = DateTime.Now,
                    OrderStatus = OrderStatus.ConfirmOrder, // Assuming OrderStatus is an enum with Confirmed, Failed, etc.
                    OrderTotal = cart.TotalPrice,
                    Customer = cart.Customers,
                    OrderItems = cart.CartItemList.Select(ci => new OrderItem
                    {
                        // Populate OrderItem properties based on the cart item details
                    }).ToList()
                };

                context.OrderSummaries.Add(orderSummary);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Cart not found.");
            }
        }

        public async Task AddUserAsync(User newUser)
        {
            // Assuming you have a User DbSet in your context
            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();
        }

        public async Task<bool> EditUserDetailsAsync(AccessOrder req)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserID == req.userId);
            if (user == null)
            {
                // User not found
                return false;
            }

            // Update user details
            user.Name = req.newName;
            user.Email = req.newEmailAddress;

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserID == userId);
            if (user == null)
            {
                // User not found
                return false;
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return true;
        }
        


    }
}


