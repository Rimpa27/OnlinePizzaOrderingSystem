using FoodApp.Entities;

namespace FoodApp.Services.Admin
{
    public interface IAdminAcessService
    {
    public void AddOrderSummary(OrderSummary orderSummary);
    public List<OrderSummary> GetOrdersForAdmin(List<OrderSummary> OrderSummaries);
    public MenuItem AddMenuItem(int menuItemId, string name, string itemDescription, int calories, bool isAvailable, VegOrNonVeg vegOrNonVeg, MenuItemCategory category, string imageUrl, int preparationTime, decimal price);
    public void DeleteItem(MenuItem menuItem);
    public MenuItem EditItem(MenuItem menuItem, int newMenuItemId, string newName, string newItemDescription, int newCalories, bool newIsAvailable, VegOrNonVeg newVegOrNonVeg, MenuItemCategory newCategory, string newImageUrl, int newPreparationTime, decimal newPrice);
    }
}