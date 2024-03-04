﻿

using FoodApp.Entities;
using FoodApp.Services.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Service.Customer
{
    public interface ICustomerAccessService
    {
        PaymentInfo GetPaymentInfoByOrderId(int orderId);

        OrderStatus GetOrderStatusByOrderID(int orderID);


        List<Claim> DeletePizzaCart(DeletePizzaFromCart request);
    }
}
