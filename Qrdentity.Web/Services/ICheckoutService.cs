using Qrdentity.Web.Proxies.Checkout;

namespace Qrdentity.Web.Services;

public interface ICheckoutService
{
    Task Complete(Guid shoppingCartId, CompleteCheckoutRequestProxy proxy,
        CancellationToken cancellationToken = default);
}