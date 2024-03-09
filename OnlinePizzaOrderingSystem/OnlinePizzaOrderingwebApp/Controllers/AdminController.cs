

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

       
[HttpPost("Login")]

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
        //[Authorize]
        //[HttpPost("AddMenuItem")]
        //public ActionResult<MenuItem> AddMenuItem(AddingMenuItem addingMenuItem)
        //{
        //    try
        //    {
        //        // Call the EditItem method from the service
        //        var updatedMenuItem = adminAccessService.AddMenuItem(addingMenuItem);
        //        // Return a success response with the updated menu item
        //        return Ok(updatedMenuItem);
        //    }
        //    catch (DuplicateItemException ex)
        //    {
        //        return Conflict(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {

        //        // Log the exception and return a generic error message
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Failed to Add menu item. Please contact support.");

        //    }
        //}

        [HttpGet("AllUser")]
        public IActionResult GetAllUsers()
        {
            List<User> users = adminAccessService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("AllOrders")]
        public IActionResult GetAllOrders()
        {
            List<OrderSummary> orders = adminAccessService.GetAllOrders();
            return Ok(orders);
        }

        [HttpPost("AddMenuItem")]  //Done
        public IActionResult Post()
        {
            AddingMenuItem request = JsonSerializer.Deserialize<AddingMenuItem>(HttpContext.Request.Form["data"]);
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                request.photo = HttpContext.Request.Form.Files[0];
            }

            adminAccessService.AddMenuItem(request);

            return Ok("Product added successfully.");
        }
        [HttpPut("EditMenuItem")]
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


    [HttpDelete("DeleteMenuItem")]
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
        
        //[HttpDelete("DeleteUser")]
        //public IActionResult DeleteUser(User )
        //{
        //    try
        //    {
        //        // Check if adminAccessService is initialized
        //        if (adminAccessService == null)
        //        {
        //            return StatusCode(500, "adminAccessService is not initialized");
        //        }

        //        // Attempt to delete the menu item
        //        adminAccessService.

        //        // Return success message
        //        return Ok("Item deleted successfully");
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        // Handle invalid operation exception (e.g., item not found)
        //        return NotFound(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle other unexpected exceptions
        //        return StatusCode(500, $"An error occurred: {ex.Message}");
        //    }
        //}

    }

}
