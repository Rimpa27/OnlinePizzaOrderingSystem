using System.Security.Authentication;
using FoodApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using OnlinePizzaOrderingwebApp.Services;

namespace OnlinePizzaOrderingwebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerAccessService _customerAccessServices;

        public CustomerController(ICustomerAccessService customerAccessServices)
        {
            _customerAccessServices = customerAccessServices;
        }


        [HttpPost("SignUp")]
        public IActionResult SignUp([FromBody] SignUpRequest request)
        {
            try
            {
                var customer = _customerAccessServices.SignUp(request);
                return Ok(customer);
            }
            catch (DuplicateEmailException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception, etc.
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        //[HttpPost("SignIn")]
        //public IActionResult SignIn([FromBody] SignInRequest request)
        //{
        //    try
        //    {
        //        var claims = _customerAccessServices.SignIn(request);
        //        var token = GenerateToken(claims); // Assuming you have a method to generate JWT token
        //        return Ok(new { Token = token });
        //    }
        //    catch (AuthenticationException ex)
        //    {
        //        return Unauthorized(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception, etc.
        //        return StatusCode(500, $"An error occurred: {ex.Message}");
        //    }
        //}

        [HttpPost("Customer Login")]

        public IActionResult Post(SignInRequest request)

        {

            try

            {

                var claims = this._customerAccessServices.SignIn(request);

                string jwtToken = JwtTokenGenerator.GenerateToken(claims);

                return Ok(new { Token = jwtToken, Email = claims.First(d => d.Type == "Email").Value });

            }

            catch (Exception ex)

            {

                return Unauthorized(ex);

            }

        }
    }



    //[HttpPost("AddMenuItemToCart")]
    //    public async Task<IActionResult> AddMenuItemToCart([FromBody] AddingMenuItemToCart request)
    //    {
    //        try
    //        {
    //            var result = await _customerAccessServices.AddMenuItemToCartAsync(request);
    //            if (result)
    //            {
    //                return Ok("MenuItem added to cart successfully.");
    //            }
    //            else
    //            {
    //                return BadRequest("Failed to add MenuItem to cart.");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            // Log the exception
    //            return StatusCode(500, $"An error occurred: {ex.Message}");
    //        }
    //    }

    //    [HttpDelete("DeleteCartItem/{cartItemId}")]
    //    public async Task<IActionResult> DeleteCartItem(int cartItemId)
    //    {
    //        try
    //        {
    //            var result = await _customerAccessServices.DeleteCartItemByIdAsync(cartItemId);
    //            if (result)
    //            {
    //                return Ok("CartItem deleted successfully.");
    //            }
    //            else
    //            {
    //                return NotFound("CartItem not found.");
    //            }
    //        }
    //        catch (NotFoundException ex)
    //        {
    //            // Log the exception, etc.
    //            return NotFound(ex.Message);
    //        }
    //        catch (Exception ex)
    //        {
    //            // Log the exception, etc.
    //            return StatusCode(500, $"An error occurred: {ex.Message}");
    //        }
    //    }

    //    [HttpPost("ChooseDeliveryDateAndTime")]
    //    public async Task<IActionResult> ChooseDeliveryDateAndTime([FromBody] ChooseDeliveryDateAndTime req)
    //    {
    //        try
    //        {
    //            var result = await _customerAccessServices.ChooseDeliveryDateAndTimeAsync(req);
    //            if (result != null)
    //            {
    //                return Ok("Delivery date and time chosen successfully.");
    //            }
    //            else
    //            {
    //                return NotFound("Order not found.");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            // Log the exception, etc.
    //            return StatusCode(500, $"An error occurred: {ex.Message}");
    //        }
    //    }


    }

