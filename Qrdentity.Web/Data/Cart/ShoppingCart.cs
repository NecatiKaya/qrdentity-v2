using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.Cart.Configurations;

namespace Qrdentity.Web.Data.Cart;

[EntityTypeConfiguration(typeof(ShoppingCartConfiguration))]
public sealed class ShoppingCart : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid UserId { get; set; }

    public bool IsShoppingDone { get; set; }

    public DateTimeOffset CreatedDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset? ModifiedDate { get; set; }
    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

    public static ShoppingCart Create(Guid basketOwnerId)
    {
        return new ShoppingCart
        {
            UserId = basketOwnerId,
        };
    }
}