using FoodApp.Entities;


namespace FoodApp.Services
{
    public interface ICustomerAccessService
    {
        PaymentInfo GetPaymentInfoByOrderId(int orderId);

        OrderStatus GetOrderStatusByOrderID(int orderID);


        Task<bool> DeleteCartItemByIdAsync(int cartItemId);
        Task<bool> AddMenuItemToCartAsync(AddingMenuItemToCart request);

        Task<OrderSummary> ChooseDeliveryDateAndTimeAsync(ChooseDeliveryDateAndTime req);
        void CustomizePizza(CustomizedPizza cp);

    }
}
