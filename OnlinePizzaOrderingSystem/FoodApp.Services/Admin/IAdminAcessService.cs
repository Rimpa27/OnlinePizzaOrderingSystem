using System.Security.Claims;
using FoodApp.Entities;

namespace FoodApp.Services.Admin
{
    public interface IAdminAcessService
    {
    List<OrderSummary> GetOrdersForAdmin(List<OrderSummary> OrderSummaries);
        MenuItem AddMenuItem(AddingMenuItem addingMenuItem);
    void DeleteMenuItem(DeleteMenuItem request);
    MenuItem EditItem(MenuItem menuItem,EditingMenuItem editingMenuItem);
    void AdminDeleteOrder(AdminDeleteOrder request);

    } 
}