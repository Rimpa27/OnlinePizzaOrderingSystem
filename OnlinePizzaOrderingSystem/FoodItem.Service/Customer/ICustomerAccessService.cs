
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
        bool Payment(OrderPayment payment);
    }
}
