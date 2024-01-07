namespace Qrdentity.Web.Proxies.Common.Mobile;

public sealed class MobileNumberRequest
{
    public string Country { get; set; } = "+90";

    public string AreaCodeWithoutZero { get; set; } = default!;

    public string Number { get; set; } = default!;

    public override string ToString()
    {
        return $"{Country}{AreaCodeWithoutZero}{Number}";
    }
}