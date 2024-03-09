using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Entities;
using FoodApp.Services;

namespace FoodApp.Services
{
    public interface IAdminAccessServices
    {
        /// <summary>
        /// Try to sign in a customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns>list of claims</returns>
        /// <exception cref="AuthenticationException"></exception>
        List<Claim> SignIn(SignInRequest request);

        MenuItem AddMenuItem(AddingMenuItem addingMenuItem);

        void DeleteMenuItem(DeleteMenuItem request);

        Task<bool> EditMenuItem(MenuItem menuItem);
        List<User> GetAllUsers();
        List<OrderSummary> GetAllOrders();

        //Task AddUserAsync(User newUser);
        Task<bool> AddUserAsync(AllUser allUser);

        //Task<bool> DeleteUserAsync(AdminDeleteUser deleteUser);

        Task<bool> EditUserDetailsAsync(AccessOrder req);

        Task<bool> EditOrderAsync(OrderUpdateModel updateModel);

        List<OrderSummary> GetOrdersForAdmin(List<OrderSummary> OrderSummaries);
 
        void AdminDeleteOrder(AdminDeleteOrder request);

        Task<bool> AddOrderAsync(OrderSummary order);

        void ConfirmOrder(int cartId);

        void AssignDeliveryPerson(AssignDeliveryPerson req);

        
    }
}
