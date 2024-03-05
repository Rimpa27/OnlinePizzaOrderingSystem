using FoodApp.Entities;


namespace FoodApp.Services.Customer
{
    public interface ICustomerAccessService
    {
        PaymentInfo GetPaymentInfoByOrderId(int orderId);

        OrderStatus GetOrderStatusByOrderID(int orderID);


        Task<bool> DeleteCartItemByIdAsync(int cartItemId);
        Task<bool> AddMenuItemToCartAsync(int cartId, int menuItemId, int quantity);

        void CreateOrder(int cartId, string customerName, string customerAddress);

        void CustomizePizza(int cartItemId, string[] toppings);
        DeliveryPerson AssignDeliveryPerson(string DeliveryPersonName);
        OrderItem ConfirmOrder(int OrderItemId);





    }
}
