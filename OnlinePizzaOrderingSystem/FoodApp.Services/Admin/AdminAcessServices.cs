using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using FoodApp.Data;
using FoodApp.Entities;
using FoodApp.Services.Customer;

namespace FoodApp.Services.Admin
{
    public class AdminAcessServices:IAdminAcessService
    { 
        private readonly PizzaOrderingAppContext context;
        

        public AdminAcessServices(PizzaOrderingAppContext context)
        {
            this.context = context;
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
        var newMenuItem = new MenuItem
            {
                MenuItemId = addingMenuItem.menuItemId,
                MenuItemName = addingMenuItem.name,
                ItemDescription = addingMenuItem.itemDescription,
                calories = addingMenuItem.calories,
                IsAvailable = addingMenuItem.isAvailable,
                VegOrNonVeg = addingMenuItem.vegOrNonVeg,
                MenuItemCategory = addingMenuItem.category,
                ImageUrl = addingMenuItem.imageUrl,
                PreparationTime = addingMenuItem.preparationTime,
                Price = addingMenuItem.price
            };

             context.MenuItem.Add(newMenuItem);
            Console.WriteLine($"Menu item '{newMenuItem.MenuItemName}' added successfully!");
            return newMenuItem;
        }
        public void DeleteMenuItem(DeleteMenuItem request)
        {
            var MenuItemToRemove = context.MenuItem.FirstOrDefault(p => p.MenuItemId == request.MenuItemId);
            if (MenuItemToRemove==null)
            {
                throw new InvalidOperationException("Item not Found");
            }
            else
            {
                context.MenuItem.Remove(MenuItemToRemove);
            }
            
        }
        public MenuItem EditItem(MenuItem menuItem,EditingMenuItem editingMenuItem)
        {   
            menuItem.MenuItemName = editingMenuItem.newName;
            menuItem.ItemDescription = editingMenuItem.newItemDescription;
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
            }
        }
    }
}
