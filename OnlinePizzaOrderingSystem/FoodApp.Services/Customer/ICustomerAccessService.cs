using System.Security.Claims;
using FoodApp.Entities;


namespace FoodApp.Services
{
    public interface ICustomerAccessService
    {
        PaymentInfo GetPaymentInfoByOrderId(int orderId);

        OrderStatus GetOrderStatusByOrderID(int orderID);


        Task<bool> DeleteCartItemByIdAsync(DeleteCartItemById req);
        Task<bool> AddMenuItemToCartAsync(AddingMenuItemToCart request);

        Task<DeliveryDetails?> ChooseDeliveryDateAndTimeAsync(ChooseDeliveryDateAndTime req);
        //void CustomizePizza(CustomizedPizza cp);

        /// <summary>
        /// Signup Request for a new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Customer</returns>
        /// <exception cref="ArgumentNullException">When the request is null</exception>
        Customer SignUp(SignUpRequest request);

        Task<OrderSummary> CreateOrderAsync(CreateOrderForCustomer req);


        /// <summary>
        /// Try to sign in a customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns>list of claims</returns>
        /// <exception cref="AuthenticationException"></exception>
        List<Claim> SignIn(SignInRequest request);

    }
}
