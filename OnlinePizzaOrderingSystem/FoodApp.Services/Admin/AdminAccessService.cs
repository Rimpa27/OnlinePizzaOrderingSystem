using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using FoodApp.Data;
using FoodApp.Entities;
using FoodApp.Services;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.Services
{
    public class AdminAccessService : IAdminAccessServices
    {
        private readonly PizzaOrderingAppContext context;
        private const string conStr = "BlobEndpoint=https://onlinepizaa.blob.core.windows.net/;QueueEndpoint=https://onlinepizaa.queue.core.windows.net/;FileEndpoint=https://onlinepizaa.file.core.windows.net/;TableEndpoint=https://onlinepizaa.table.core.windows.net/;SharedAccessSignature=sv=2022-11-02&ss=bfqt&srt=sco&sp=rwdlacupiytfx&se=2024-03-30T13:41:26Z&st=2024-03-11T05:41:26Z&spr=https,http&sig=Xv3z%2B8%2FyUp3975oM1pGePH7S4rPqyynv%2F3HwMicnXkE%3D";
        private BlobContainerClient containerClient;
        public AdminAccessService(PizzaOrderingAppContext context)
        {
            this.context = context;
            containerClient = new BlobContainerClient(conStr, "images");
        }


        public List<Claim> SignIn(SignInRequest request)//done

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

        public List<User> GetAllUsers()//done
        {
            var users = context.Users.ToList();
            return users;
        }
        public List<OrderSummary> GetAllOrders()//done
        {
            var orders=context.OrderSummaries.ToList();
            return orders;
        }
        public MenuItem AddMenuItem(AddingMenuItem addingMenuItem)//done
        {

            var newMenuItem = new MenuItem
            {

                MenuItemId = addingMenuItem.MenuItemId,
                MenuItemName = addingMenuItem.ItemName,
                MenuItemDescription = addingMenuItem.ItemDescription,
                Calories = addingMenuItem.Calories,
                IsAvailable = addingMenuItem.IsAvailable,
                VegOrNonVeg = addingMenuItem.VegOrNonVeg,
                MenuItemCategory = addingMenuItem.Category,
                PreparationTime = addingMenuItem.PreparationTime,
                Price = addingMenuItem.Price


            };
            if (addingMenuItem.Photo != null)
            {
                string fileName = Guid.NewGuid() + ".png";
                containerClient.UploadBlob(fileName, addingMenuItem.Photo.OpenReadStream());
                newMenuItem.ProductPhoto = "https://onlinepizaa.blob.core.windows.net/images/garlic_bread.png" + fileName;

            }
            context.MenuItems.Add(newMenuItem);
            context.SaveChanges();
            return newMenuItem;

        }

        public async Task<bool> EditMenuItem(MenuItem menuItem)//done
        {
            var existingMenuItem = await context.MenuItems.FindAsync(menuItem.MenuItemId);

            if (existingMenuItem == null)
            {
                return false; // Item not found
            }

            existingMenuItem.MenuItemName = menuItem.MenuItemName;
            existingMenuItem.MenuItemDescription = menuItem.MenuItemDescription;
            existingMenuItem.Price = menuItem.Price;
            existingMenuItem.Calories = menuItem.Calories;
            existingMenuItem.IsAvailable = menuItem.IsAvailable;
            existingMenuItem.PreparationTime = menuItem.PreparationTime;
            existingMenuItem.VegOrNonVeg = menuItem.VegOrNonVeg;
            existingMenuItem.MenuItemCategory = menuItem.MenuItemCategory;

            await context.SaveChangesAsync();

            return true; // Item edited successfully
        }
        public void DeleteMenuItem(DeleteMenuItem request)//done
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

        public async Task<bool> AddOrderAsync(OrderSummary order)//done
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
        //===============================================================================
        public void AddOrderSummary(OrderSummary orderSummary)//done
        {
            // Add an order summary to the log
            context.OrderSummaries.Add(orderSummary);
        }
        //================================================================================

       
        public async Task<bool> EditOrderAsync(OrderUpdateModel updateModel)//done
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

       
        
        

       


        public void AdminDeleteOrder(AdminDeleteOrder request)//done
        {
            // Find the order to delete
            var order = context.OrderSummaries.FirstOrDefault(o => o.OrderId == request.OrderId);

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
        public async Task<bool> AddUserAsync(AllUser allUser)//done
        {
            try
            {
                // Logic to save the user to the database based on RoleType
                switch (allUser.RoleType)
                {
                    case RoleType.Admin:
                        var admin = new Admin
                        {
                            Name = allUser.Name,
                            Email = allUser.Email,
                            Password = allUser.Password,
                            RoleType = allUser.RoleType,
                            ProfileImage = allUser.ProfileImage

                        };
                        context.Add(admin);
                        break;

                    case RoleType.Customer:
                        var customer = new Customer
                        {
                            Name = allUser.Name,
                            Email = allUser.Email,
                            Password = allUser.Password,
                            Address = allUser.Address,
                            Phone = allUser.Phone,
                            RoleType = allUser.RoleType,
                            ProfileImage = allUser.ProfileImage


                        };
                        context.Add(customer);
                        break;

                    case RoleType.DeliveryPerson:
                        var deliveryPerson = new DeliveryPerson
                        {
                            Name = allUser.Name,
                            Email = allUser.Email,
                            Password = allUser.Password,
                            RoleType = allUser.RoleType,
                            Phone = allUser.Phone,
                            ProfileImage = allUser.ProfileImage

                        };
                        context.Add(deliveryPerson);
                        break;

                    default:
                        return false; // Unsupported role type
                }

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Log the exception or handle it as required
                return false;
            }
        }


        public async Task<bool> EditUserDetailsAsync(EditUser req)//done
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserID == req.UserId);
            if (user == null)
            {
                // User not found
                return false;
            }

            // Update user details
            user.Name = req.NewName;
            user.Email = req.NewEmailAddress;

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUserAsync(AdminDeleteUser adminDeleteUser)//done
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserID == adminDeleteUser.UserId);
            if (user == null)
            {
                // User not found
                return false;
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return true;
        }
        public void ConfirmOrder(int cartId)//done
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

        public void AssignDeliveryPerson(AssignDeliveryPerson req)
        {
            var order = context.OrderSummaries.FirstOrDefault(o => o.OrderId == req.OrderId);
            var deliveryPerson = context.DeliveryPersons.FirstOrDefault(dp => dp.UserID == req.DeliveryPersonId);

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







    }
}


