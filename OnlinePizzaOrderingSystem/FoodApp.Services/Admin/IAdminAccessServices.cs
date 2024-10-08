﻿using System;
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

        List<MenuItem> GetAllMenuItem();

        Task<bool> AddUserAsync(AllUser allUser);
        Task<bool> EditUserDetailsAsync(EditUser req);
        Task<bool> DeleteUserAsync(AdminDeleteUser adminDeleteUser);
        List<OrderSummary> GetOrdersForAdmin(List<OrderSummary> OrderSummaries);
 
        void AdminDeleteOrder(AdminDeleteOrder request);
        void ConfirmOrder(int cartId);

        void AssignDeliveryPerson(AssignDeliveryPerson req);

        
    }
}
