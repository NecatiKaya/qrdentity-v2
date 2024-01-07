namespace Qrdentity.Web.Proxies.Common;

public sealed class GetOrganizationAddressResponseProxy
{
    public Guid Id { get; set; }

    public string Country { get; set; } = default!;

    public string City { get; set; } = default!;

    public string District { get; set; } = default!;

    public string Address { get; set; } = default!;

    public string ZipCode { get; set; } = default!;

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public string? GoogleMapsLink { get; set; }
}