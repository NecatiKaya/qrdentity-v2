using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.Cart;
using Qrdentity.Web.Data.Products.Configurations;
using Qrdentity.Web.Proxies.Qr;

namespace Qrdentity.Web.Data.Products;

[EntityTypeConfiguration(typeof(QrProductConfiguration))]
public sealed class QrProduct : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public QrTypes QrFor { get; set; }

    public decimal ListPriceWithoutVatApplied { get; set; }

    public decimal SalePriceWithoutVatApplied { get; set; }

    public string Name { get; set; } = default!;

    public string Descriptions { get; set; } = default!;

    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

    public DateTimeOffset CreatedDate { get; set; } 

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}