namespace Qrdentity.Web.Proxies.ShoppingCart;

public sealed class RemoveItemFromShoppingCartRequestProxy
{
    public Guid ShoppingCartId { get; set; }

    public Guid ShoppingCartItemId { get; set; }

    public int Quantity { get; set; } = 1;
}