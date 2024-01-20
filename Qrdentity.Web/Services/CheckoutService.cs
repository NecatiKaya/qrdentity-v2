using Qrdentity.Web.Constants;
using Qrdentity.Web.Data;
using Qrdentity.Web.Data.Cart;
using Qrdentity.Web.Data.Order;
using Qrdentity.Web.Proxies.Checkout;
using Qrdentity.Web.Utilities;

namespace Qrdentity.Web.Services;

public sealed class CheckoutService : ICheckoutService
{
    private readonly QrdentityContext _qrdentityContext;
    private readonly IShoppingCartService _shoppingCartService;

    public CheckoutService(QrdentityContext qrdentityContext, IShoppingCartService shoppingCartService)
    {
        _qrdentityContext = qrdentityContext;
        _shoppingCartService = shoppingCartService;
    }

    public async Task Complete(Guid shoppingCartId, CompleteCheckoutRequestProxy proxy,
        CancellationToken cancellationToken = default)
    {
        Guid adminUser = DataConstants.AdminUserId;
        ShoppingCart? userCart =
            await _shoppingCartService.GetShoppingCartByIdAsync(adminUser, shoppingCartId, cancellationToken);

        if (userCart == null || userCart.IsShoppingDone || !userCart.IsActive)
        {
            //TODO
            throw new Exception("");
        }

        if (userCart.Id != shoppingCartId)
        {
            //TODO
            throw new Exception("");
        }

        decimal cartPrice =
            await _shoppingCartService.CalculateCartPriceWithoutVatAppliedAsync(userCart, cancellationToken);
        if (cartPrice <= 0)
        {
            //TODO
            throw new Exception("");
        }

        userCart.IsShoppingDone = true;
        userCart.CartPriceAfterCheckout = cartPrice;
        userCart.IsActive = false;

        Order order = new Order();
        order.OrderNumber = OrderNumberGenerator.Generate();
        order.ShoppingCartId = shoppingCartId;
        order.OrderSalePriceWithoutVatApplied = cartPrice;
        order.OrderSalePriceWithoutVatApplied = cartPrice * (decimal)1.2;
        order.BillingAddressId = proxy.BillingAddressId;
        order.ShipmentAddressId = proxy.ShipmentAddressId;
        userCart.OrderId = order.Id;

        await _qrdentityContext.Orders.AddAsync(order, cancellationToken);
        await _qrdentityContext.SaveChangesAsync(cancellationToken);
    }
}