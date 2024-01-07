using Qrdentity.Web.Data.Cart;
using Qrdentity.Web.Data.Products;
using Qrdentity.Web.Proxies.Product;
using Qrdentity.Web.Proxies.ShoppingCart;

namespace Qrdentity.Web.Mapping;

public static class ShoppingCartMapping
{
    public static GetProductResponseProxy ToProductResponseProxy(QrProduct product)
    {
        GetProductResponseProxy proxy = new GetProductResponseProxy
        {
            Id = product.Id,
            QrFor = product.QrFor,
            ListPriceWithoutVatApplied = product.ListPriceWithoutVatApplied,
            SalePriceWithoutVatApplied = product.SalePriceWithoutVatApplied,
            Name = product.Name,
            Descriptions = product.Descriptions
        };

        return proxy;
    }

    public static ShoppingCartItemResponseProxy ToShoppingCartItemProxy(ShoppingCartItem cartItem)
    {
        ShoppingCartItemResponseProxy proxy = new ShoppingCartItemResponseProxy
        {
            Id = cartItem.Id,
            ShoppingCartId = cartItem.ShoppingCartId,
            Product = ToProductResponseProxy(cartItem.Product),
            Quantity = cartItem.Quantity
        };
        return proxy;
    }

    public static GetShoppingCartResponseProxy ToShoppingCartProxy(ShoppingCart cart)
    {
        GetShoppingCartResponseProxy proxy = new GetShoppingCartResponseProxy
        {
            Id = cart.Id,
            Items = cart.ShoppingCartItems.Select(ToShoppingCartItemProxy).ToList()
        };
        return proxy;
    }
}