using Qrdentity.Web.Proxies.Qr;

namespace Qrdentity.Web.Proxies.Product;

public sealed class GetProductResponseProxy
{
    public Guid Id { get; set; }

    public QrTypes QrFor { get; set; }

    public decimal ListPriceWithoutVatApplied { get; set; }

    public decimal SalePriceWithoutVatApplied { get; set; }

    public string Name { get; set; } = default!;

    public string Descriptions { get; set; } = default!;
}