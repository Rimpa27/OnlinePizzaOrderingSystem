using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public class CartNotFoundException : Exception
    {
        public CartNotFoundException(string message) : base(message)
        {
        }

        public CartNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
