namespace Qrdentity.Web.Proxies.Common;

public sealed class SaveOrganizationAddressRequestProxy
{
    public Guid DistrictId { get; set; }

    public string Address { get; set; } = default!;

    public string ZipCode { get; set; } = default!;

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public string? GoogleMapsLink { get; set; }
}