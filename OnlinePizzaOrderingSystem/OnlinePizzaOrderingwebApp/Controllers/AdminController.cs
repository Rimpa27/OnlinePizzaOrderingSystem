

using FoodApp.Entities;
using FoodApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize]
        [HttpPost("AddMenuItem")]
        public ActionResult<MenuItem> AddMenuItem(AddingMenuItem addingMenuItem)
        {
            try
            {
                // Call the EditItem method from the service
                var updatedMenuItem = adminAccessService.AddMenuItem(addingMenuItem);
                // Return a success response with the updated menu item
                return Ok(updatedMenuItem);
            }
            catch (DuplicateItemException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception and return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to Add menu item. Please contact support.");
            }
        }




        //[HttpPut("EditMenuItem")]
        //public ActionResult<MenuItem> EditMenuItem(MenuItem menuItem, EditingMenuItem editingMenuItem)
        //{
        //    try
        //    {
        //        // Call the EditItem method from the service
        //        var updatedMenuItem = adminAccessService.EditMenuItem(menuItem, editingMenuItem);

        //        // Return a success response with the updated menu item
        //        return Ok(updatedMenuItem);
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update menu item. Please contact support.");
        //    }
        //}

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

    }

}
