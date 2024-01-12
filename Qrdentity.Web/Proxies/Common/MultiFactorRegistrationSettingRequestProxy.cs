namespace Qrdentity.Web.Proxies.Common;

public sealed class MultiFactorRegistrationSettingRequestProxy
{
    public string Code { get; set; } = default!;

    public string Value { get; set; } = default!;

    public string CodeToAuthenticate { get; set; } = default!;
}