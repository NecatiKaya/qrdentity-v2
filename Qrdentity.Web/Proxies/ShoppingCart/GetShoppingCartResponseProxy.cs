namespace Qrdentity.Web.Proxies.ShoppingCart;

public sealed class GetShoppingCartResponseProxy
{
    public Guid Id { get; set; }

    public List<ShoppingCartItemResponseProxy> Items { get; set; } = new List<ShoppingCartItemResponseProxy>();
}