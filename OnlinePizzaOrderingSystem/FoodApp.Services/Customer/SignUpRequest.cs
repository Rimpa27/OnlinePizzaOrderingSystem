using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Entities;

namespace FoodApp.Services
{
    public class SignUpRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public long Phone {  get; set; }

        public Address City {  get; set; }   
    }
}
