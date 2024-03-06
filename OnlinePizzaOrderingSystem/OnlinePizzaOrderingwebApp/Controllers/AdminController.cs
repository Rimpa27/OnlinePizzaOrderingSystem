

using FoodApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlinePizzaOrderingwebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminAccessServices adminAccessService;

        public AdminController(IAdminAccessServices AdminAccessService)
        {
            this.adminAccessService = AdminAccessService;
        }

        [HttpPost("Admin Login")]
        public IActionResult Post(SignInRequest request)
        {
            try
            {
                var claims = this.adminAccessService.SignIn(request);
                //Create JWT and Sent
                return Ok();
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
    }
}
