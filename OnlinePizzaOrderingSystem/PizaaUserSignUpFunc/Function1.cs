using FoodApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace PizaaUserSignUpFunc
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly ICustomerAccessService _customerAccessServices;

        public Function1(ILogger<Function1> logger,ICustomerAccessService customerAccessService)
        {
            _logger = logger;
            _customerAccessServices = customerAccessService;
        }

        [Function("signup")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            try
            {
                var body = await new StreamReader(req.Body).ReadToEndAsync();
                var signuprequest = JsonSerializer.Deserialize<SignUpRequest>(body);

                var customer = _customerAccessServices.SignUp(signuprequest);

                return new OkObjectResult(new { Name = customer.Name, Email = customer.Email });
            }
            catch(Exception excp)
            {
                return new BadRequestObjectResult(excp.ToString());
            }

        }
    }
}
