using System.Security.Authentication;
using FoodApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using OnlinePizzaOrderingwebApp.Services;
using Microsoft.EntityFrameworkCore;
using FoodApp.Entities;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;

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


        [HttpPost("CustomerLogin")]

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

        [Authorize]
        [HttpPost("createOrder")]
        public async Task<IActionResult> CreateOrderAsync(CreateOrderForCustomer req)
        {
            try
            {
                var order = await _customerAccessServices.CreateOrderAsync(req);
                return Ok(order);
            }
            catch (CustomerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (CartNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [Authorize]

        [HttpPost("AddMenuItemToCart")]
        public async Task<IActionResult> AddMenuItemToCart(AddingMenuItemToCart request)
        {
            try
            {
                var result = await _customerAccessServices.AddMenuItemToCartAsync(request);
                if (result)
                {
                    return Ok("MenuItem added to cart successfully.");
                }
                else
                {
                    return BadRequest("Failed to add MenuItem to cart.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("DeleteCartItem")]
        public async Task<IActionResult> DeleteCartItem(DeleteCartItemById request)
        {
            try
            {
                var result = await _customerAccessServices.DeleteCartItemByIdAsync(request);
                if (result)
                {
                    return Ok("Cart item deleted successfully.");
                }
                else
                {
                    return NotFound("Cart item not found.");
                }
            }
            catch (NotFoundException ex)
            {
                // Log the exception, if needed
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("ChooseDeliveryDateAndTime")]
        public async Task<IActionResult> ChooseDeliveryDateAndTime(ChooseDeliveryDateAndTime req)
        {
            try
            {
                var result = await _customerAccessServices.ChooseDeliveryDateAndTimeAsync(req);
                if (result != null)
                {
                    return Ok("Delivery date and time chosen successfully.");
                }
                else
                {
                    return NotFound("Order not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception, etc.
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("ViewMenuItems")]
        public ActionResult<IEnumerable<MenuItemDto>> GetMenuItems()
        {
            var menuItems = _customerAccessServices.GetMenuItems();
            return Ok(menuItems);
        }




        [HttpGet("OrderStatus/{orderId}")]
        public ActionResult<OrderStatus> GetOrderStatusByOrderId(int orderId)
        {
            try
            {
                var orderStatus = _customerAccessServices.GetOrderStatusByOrderID(orderId);
                return Ok(orderStatus);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }



}

