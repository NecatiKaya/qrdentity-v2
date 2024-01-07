namespace Qrdentity.Web.Proxies.Common.Vehicle.PlateNumber;

public class PlateNumberRequest
{
    public string CityCode { get; set; } = default!;

    public string MiddleLetters { get; set; } = default!;

    public int LastPart { get; set; }
}