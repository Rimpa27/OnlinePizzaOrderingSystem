using FoodApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public class AllUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleType RoleType { get; set; }

        public Address Address { get; set; }

        public long Phone { get; set; }

        public string? ProfileImage { get; set; }

    }
}
