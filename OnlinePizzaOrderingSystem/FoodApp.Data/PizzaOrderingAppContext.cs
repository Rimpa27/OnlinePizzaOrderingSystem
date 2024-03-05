using FoodApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Data
{
    public class PizzaOrderingAppContext:DbContext
    {
        public PizzaOrderingAppContext(DbContextOptions<PizzaOrderingAppContext> options) : base(options) { }

        public DbSet<OrderPayment> OrderPayments { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }   

        public DbSet<OrderSummary> OrderSummaries { get; set; }

        public DbSet<User> Users { get; set; }  

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<DeliveryPerson> DeliveryPeople { get; set; }
        
        public DbSet<Address> Addresses { get; set; }
        public object OrderItems { get; set; }
    }
}
