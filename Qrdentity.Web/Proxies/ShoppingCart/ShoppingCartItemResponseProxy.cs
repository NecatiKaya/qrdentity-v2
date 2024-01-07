using Qrdentity.Web.Proxies.Product;

namespace Qrdentity.Web.Proxies.ShoppingCart;

public sealed class ShoppingCartItemResponseProxy
{
    public Guid Id { get; set; }

    public Guid ShoppingCartId { get; set; }

    public GetProductResponseProxy Product { get; set; } = default!;

    public int Quantity { get; set; }
}