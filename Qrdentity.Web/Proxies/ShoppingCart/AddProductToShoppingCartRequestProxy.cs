namespace Qrdentity.Web.Proxies.ShoppingCart;

public sealed class AddProductToShoppingCartRequestProxy
{
    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
}