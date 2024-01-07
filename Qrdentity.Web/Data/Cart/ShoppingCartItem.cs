using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.Cart.Configurations;
using Qrdentity.Web.Data.Products;

namespace Qrdentity.Web.Data.Cart;

[EntityTypeConfiguration(typeof(ShoppingCartItemConfiguration))]
public sealed class ShoppingCartItem : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid ShoppingCartId { get; set; }

    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal ListPriceWithoutVatApplied { get; set; }

    public decimal SalePriceWithoutVatApplied { get; set; }

    public QrProduct Product { get; private set; } = default!;

    public ShoppingCart ShoppingCart { get; private set; } = default!;

    public DateTimeOffset CreatedDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset? ModifiedDate { get; set; }
    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}