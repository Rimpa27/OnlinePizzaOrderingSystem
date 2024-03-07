using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Entities;

namespace FoodApp.Services
{
    public interface IAdminAccessServices
    {
        Task<bool> EditOrderAsync(OrderUpdateModel updateModel);

        List<OrderSummary> GetOrdersForAdmin(List<OrderSummary> OrderSummaries);
        MenuItem AddMenuItem(AddingMenuItem addingMenuItem);
        void DeleteMenuItem(DeleteMenuItem request);
        MenuItem EditItem(MenuItem menuItem, EditingMenuItem editingMenuItem);
        void AdminDeleteOrder(AdminDeleteOrder request);

        /// <summary>
        /// Try to sign in a customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns>list of claims</returns>
        /// <exception cref="AuthenticationException"></exception>
        List<Claim> SignIn(SignInRequest request);

        Task<bool> AddOrderAsync(OrderSummary order);
        void ConfirmOrder(int cartId);
        void AssignDeliveryPerson(AssignDeliveryPerson req);
    }
}
