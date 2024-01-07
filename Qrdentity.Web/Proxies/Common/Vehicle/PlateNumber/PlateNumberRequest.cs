namespace Qrdentity.Web.Proxies.Common.Vehicle.PlateNumber;

public sealed class PlateNumberRequest
{
    public string CityCode { get; set; } = default!;

    public string MiddlePart { get; set; } = default!;

    public int LastPart { get; set; }
}