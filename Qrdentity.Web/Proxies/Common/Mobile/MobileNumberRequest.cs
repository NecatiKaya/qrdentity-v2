namespace Qrdentity.Web.Proxies.Common.Mobile;

public sealed class MobileNumberRequest
{
    public string CountryCode { get; set; } = "+90";

    public string CountryWithoutPlusSign => CountryCode.Replace("+", string.Empty);

    public string AreaCodeWithoutZero { get; set; } = default!;

    public string Number { get; set; } = default!;

    public override string ToString()
    {
        return $"{CountryWithoutPlusSign}{AreaCodeWithoutZero}{Number}";
    }
}