using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Data;
using FoodApp.Entities;

namespace FoodApp.Services.Admin
{
    public class AdminAcessServices:IAdminAcessService
    { 
        private readonly PizzaOrderingAppContext context;
        private readonly List<OrderSummary> OrderSummaries;
        private readonly List<MenuItem> menuItems = new List<MenuItem>();
        public AdminAcessServices(PizzaOrderingAppContext context)
        {
            this.context = context;
        }
        public void AddOrderSummary(OrderSummary orderSummary)
        {
            // Add an order summary to the log
            OrderSummaries.Add(orderSummary);
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
        public MenuItem AddMenuItem(int menuItemId, string name, string itemDescription, int calories, bool isAvailable, VegOrNonVeg vegOrNonVeg, MenuItemCategory category, string imageUrl, int preparationTime, decimal price)
        {
            var newMenuItem = new MenuItem
            {
                MenuItemId = menuItemId,
                MenuItemName = name,
                ItemDescription = itemDescription,
                calories = calories,
                IsAvailable = isAvailable,
                VegOrNonVeg = vegOrNonVeg,
                MenuItemCategory = category,
                ImageUrl = imageUrl,
                PreparationTime = preparationTime,
                Price = price
            };

            menuItems.Add(newMenuItem);
            Console.WriteLine($"Menu item '{newMenuItem.MenuItemName}' added successfully!");
            return newMenuItem;
        }
        public void DeleteItem(MenuItem menuItem)
        {
            menuItems.Remove(menuItem);
        }
        public MenuItem EditItem(MenuItem menuItem, int newMenuItemId, string newName, string newItemDescription, int newCalories, bool newIsAvailable, VegOrNonVeg newVegOrNonVeg, MenuItemCategory newCategory, string newImageUrl, int newPreparationTime, decimal newPrice)
        {   
            menuItem.MenuItemName = newName;
            menuItem.ItemDescription = newItemDescription;
            menuItem.calories = newCalories;
            menuItem.IsAvailable = newIsAvailable;
            menuItem.VegOrNonVeg = newVegOrNonVeg;
            menuItem.MenuItemCategory = newCategory;
            menuItem.ImageUrl = newImageUrl;
            menuItem.PreparationTime = newPreparationTime;
            menuItem.Price = newPrice;
            return menuItem;
        }
    }
}