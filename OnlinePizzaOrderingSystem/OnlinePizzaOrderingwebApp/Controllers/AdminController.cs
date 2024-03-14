

using System;
using System.Text.Json;
using FoodApp.Entities;
using FoodApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlinePizzaOrderingwebApp;
using OnlinePizzaOrderingwebApp.Services;

namespace OnlinePizzaOrderingwebApp.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    
    public class AdminController : ControllerBase
    {
        private readonly IAdminAccessServices adminAccessService;

        public AdminController(IAdminAccessServices AdminAccessService)
        {
            this.adminAccessService = AdminAccessService;
        }

       
[HttpPost("Login")]//done

public IActionResult Post(SignInRequest request)

        {

            try

            {

                var claims = this.adminAccessService.SignIn(request);

                string jwtToken = JwtTokenGenerator.GenerateToken(claims);

                return Ok(new { Token = jwtToken, Email = claims.First(d => d.Type == "Email").Value });

            }

            catch (Exception ex)

            {

                return Unauthorized(ex.Message);

            }

        }
       

        [HttpGet("AllUser")]//done
        public IActionResult GetAllUsers()
        {
            List<User> users = adminAccessService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("AllOrders")]//done
        public IActionResult GetAllOrders()
        {
            List<OrderSummary> orders = adminAccessService.GetAllOrders();
            return Ok(orders);
        }
        
        [HttpPost("AddMenuItem")]  //Done
        public IActionResult Post()
        {
            AddingMenuItem request = JsonSerializer.Deserialize<AddingMenuItem>( HttpContext.Request.Form["data"]);

            if (HttpContext.Request.Form.Files.Count > 0)
            {
                request.Photo = HttpContext.Request.Form.Files[0];
            }

            adminAccessService.AddMenuItem(request);

            return Ok("Product added successfully.");
        }
        [HttpPut("EditMenuItem")]//done
        public async Task<IActionResult> EditMenuItem(MenuItem menuItem)
        {
            try
            {
                var result = await adminAccessService.EditMenuItem(menuItem);
                if (result)
                {
                    return Ok("Menu item edited successfully.");
                }
                else
                {
                    return NotFound("Menu item not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("AllMenuItems")]
        public IActionResult GetAllMenuItem()
        {
            List<MenuItem> menuitems = adminAccessService.GetAllMenuItem();
            return Ok(menuitems);
        }


        [HttpDelete("DeleteMenuItem")]//done
        public IActionResult DeleteMenuItem(DeleteMenuItem request)
        {
            try
            {
                // Check if adminAccessService is initialized
                if (adminAccessService == null)
                {
                    return StatusCode(500, "adminAccessService is not initialized");
                }

                // Attempt to delete the menu item
                adminAccessService.DeleteMenuItem(request);

                // Return success message
                return Ok("Item deleted successfully");
            }
            catch (InvalidOperationException ex)
            {
                // Handle invalid operation exception (e.g., item not found)
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        
        [HttpDelete("AdminDeleteOrder")]
        public IActionResult AdminDeleteOrder(AdminDeleteOrder orderId)
        {
            try
            {
                // Call your service method to delete the order
                adminAccessService.AdminDeleteOrder(orderId);
                return NoContent(); // 204 No Content response
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., order not found, database error)
                return BadRequest(ex.Message); // 400 Bad Request response
            }
        }


        [HttpPost("addUser")]
        public async Task<IActionResult> AddUserAsync(AllUser alluser)
        {
            try
            {
                var result = await adminAccessService.AddUserAsync(alluser);
                if (result)
                {
                    return Ok("User added successfully.");
                }
                else
                {
                    return StatusCode(500, "Failed to add user.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPut("EditUser")]
        public async Task<IActionResult> EditUserAsync(EditUser req)
        {
            try
            {
                var result = await adminAccessService.EditUserDetailsAsync(req);
                if (result)
                {
                    return Ok("User edited successfully.");
                }
                else
                {
                    return StatusCode(500, "Failed to edit user.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpDelete("DeleteUser")]

        public async Task<IActionResult> DeleteUserAsync(AdminDeleteUser adminDeleteUser)
        {
            try
            {
                var result = await adminAccessService.DeleteUserAsync(adminDeleteUser);
                if (result)
                {
                    return Ok("User deleted successfully.");
                }
                else
                {
                    return StatusCode(500, "Failed to delete user.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("ConfirmOrder/{orderid}")]
        public IActionResult ConfirmOrder([FromRoute]int orderid)
        {
            try
            {
                adminAccessService.ConfirmOrder(orderid);
                return Ok("Order confirmed successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while confirming the order.");
            }
        }
        [HttpPost("AssignDeliveryPerson")]
        public IActionResult AssignDeliveryPerson(AssignDeliveryPerson req)
        {
            try
            {
                // Check if adminAccessService is initialized
                if (adminAccessService == null)
                {
                    return StatusCode(500, "adminAccessService is not initialized");
                }

                // Attempt to delete the menu item
                adminAccessService.AssignDeliveryPerson(req);

                // Return success message
                return Ok("Assigned successfully");
            }
            catch (InvalidOperationException ex)
            {
                // Handle invalid operation exception (e.g., item not found)
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }       
    }

}
