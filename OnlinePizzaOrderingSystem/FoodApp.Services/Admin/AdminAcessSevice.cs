using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Data;
using FoodApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.Services.Admin
{

    namespace FoodApp.Services.Admin
    {
        public class AdminAccessService
        {
            private readonly PizzaOrderingAppContext _context;

            public AdminAccessService(PizzaOrderingAppContext context)
            {
                _context = context;
            }

            public async Task AddUserAsync(User newUser)
            {
                // Assuming you have a User DbSet in your context
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
            }
            
            public async Task<bool> EditUserDetailsAsync(int userId, string newName, string newEmailAddress)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
                if (user == null)
                {
                    // User not found
                    return false;
                }

                // Update user details
                user.Name = newName;
                user.Email = newEmailAddress;

                await _context.SaveChangesAsync();

                return true;
            }

            public async Task<bool> DeleteUserAsync(int userId)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
                if (user == null)
                {
                    // User not found
                    return false;
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return true;
            }
        }
    }
}
