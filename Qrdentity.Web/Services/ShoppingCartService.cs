using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Data;
using Qrdentity.Web.Data.Cart;
using Qrdentity.Web.Data.Products;

namespace Qrdentity.Web.Services;

public sealed class ShoppingCartService : IShoppingCartService
{
    private readonly QrdentityContext _qrdentityContext;

    private readonly IProductService _productService;

    public ShoppingCartService(QrdentityContext qrdentityContext, IProductService productService)
    {
        _qrdentityContext = qrdentityContext;
        _productService = productService;
    }

    public async Task<ShoppingCart?> GetShoppingCartOfUserAsync(Guid userId,
        CancellationToken cancellationToken = default)
    {
        ShoppingCart? cart = await _qrdentityContext.ShoppingCarts
            .Include(cart => cart.ShoppingCartItems)
            .ThenInclude(cartItem => cartItem.Product)
            .Where(eachCart => eachCart.UserId == userId && !eachCart.IsShoppingDone && eachCart.IsActive)
            .FirstOrDefaultAsync(cancellationToken);

        return cart;
    }

    public async Task<ShoppingCart> AddToBasketAsync(Guid basketOwnerId, Guid productId, int quantity = 1,
        CancellationToken cancellationToken = default)
    {
        if (quantity < 1)
        {
            //TODO
            throw new ArgumentException();
        }

        ShoppingCart? cart = await GetShoppingCartOfUserAsync(basketOwnerId, cancellationToken);
        if (cart == null)
        {
            cart = new ShoppingCart
            {
                Id = Guid.NewGuid(),
                UserId = basketOwnerId
            };

            await _qrdentityContext.ShoppingCarts.AddAsync(cart, cancellationToken);
        }

        QrProduct product = await _productService.GetByIdAsync(productId, cancellationToken);

        ShoppingCartItem? shoppingCartItem =
            cart.ShoppingCartItems.FirstOrDefault(eachItem => eachItem.ProductId == productId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem
            {
                UserId = basketOwnerId,
                ProductId = product.Id,
                Quantity = quantity,
                ListPriceWithoutVatApplied = product.ListPriceWithoutVatApplied,
                SalePriceWithoutVatApplied = product.SalePriceWithoutVatApplied
            };

            cart.ShoppingCartItems.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Quantity += quantity;
        }

        await _qrdentityContext.SaveChangesAsync(cancellationToken);
        return cart;
    }

    public async Task<ShoppingCart> RemoveItemFromCartAsync(Guid basketOwnerId, Guid cartItemId,
        int quantity = 1,
        CancellationToken cancellationToken = default)
    {
        if (quantity < 1)
        {
            //TODO
            throw new ArgumentException();
        }

        ShoppingCart? cart = await GetShoppingCartOfUserAsync(basketOwnerId, cancellationToken);
        //TODO
        ArgumentNullException.ThrowIfNull(cart);

        ShoppingCartItem? item = cart.ShoppingCartItems.FirstOrDefault(eachItem => eachItem.Id == cartItemId);
        if (item == null)
        {
            return cart;
        }

        if (item.Quantity <= quantity)
        {
            cart.ShoppingCartItems.Remove(item);
        }
        else
        {
            item.Quantity -= quantity;
        }

        await _qrdentityContext.SaveChangesAsync(cancellationToken);
        return cart;
    }

    public async Task DeleteShoppingCartAsync(Guid basketOwnerId, CancellationToken cancellationToken = default)
    {
        ShoppingCart? cart = await GetShoppingCartOfUserAsync(basketOwnerId, cancellationToken);
        if (cart == null)
        {
            return;
        }

        _qrdentityContext.ShoppingCarts.Remove(cart);
        await _qrdentityContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<ShoppingCart?> GetShoppingCartByIdAsync(Guid userId, Guid cartId,
        CancellationToken cancellationToken = default)
    {
        ShoppingCart? cart = await _qrdentityContext.ShoppingCarts
            .Include(cart => cart.ShoppingCartItems)
            .ThenInclude(cartItem => cartItem.Product)
            .Where(eachCart => eachCart.Id == cartId && eachCart.UserId == userId)
            .FirstOrDefaultAsync(cancellationToken);

        return cart;
    }
}