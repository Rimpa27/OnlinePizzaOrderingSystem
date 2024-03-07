using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException() { }

        public DuplicateItemException(string? message) : base(message)
        {
        }

        public DuplicateItemException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DuplicateItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
