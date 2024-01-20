using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.Cart;
using Qrdentity.Web.Data.Common;
using Qrdentity.Web.Data.Order.Configuration;

namespace Qrdentity.Web.Data.Order;

[EntityTypeConfiguration(typeof(OrderConfiguration))]
public sealed class Order : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string OrderNumber { get; set; } = default!;

    public Guid ShoppingCartId { get; set; }

    public decimal OrderSalePriceWithoutVatApplied { get; set; }

    public decimal OrderSalePriceWithVatApplied { get; set; }

    public ShoppingCart ShoppingCart { get; set; } = default!;

    public OrderStatus OrderStatus { get; set; } = OrderStatus.Initial;

    public Guid BillingAddressId { get; set; }

    public Guid ShipmentAddressId { get; set; }

    public UserAddress BillingAddress { get; set; } = default!;

    public UserAddress ShipmentAddress { get; set; } = default!;

    public DateTimeOffset CreatedDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset? ModifiedDate { get; set; }
    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}