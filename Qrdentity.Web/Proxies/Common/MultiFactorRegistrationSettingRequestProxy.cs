namespace Qrdentity.Web.Proxies.Common;

public sealed class MultiFactorRegistrationSettingRequestProxy
{
    public string Code { get; set; } = default!;

    public string Value { get; set; } = default!;

    public string CodeToAuthenticate { get; set; } = default!;

    public void Validate()
    {
        if (!string.Equals(Code, "sms-notification", StringComparison.OrdinalIgnoreCase) &&
            !string.Equals(Code, "email-notification", StringComparison.OrdinalIgnoreCase))
        {
            //TODO
            throw new Exception("");
        }

        if (string.IsNullOrWhiteSpace(CodeToAuthenticate))
        {
            //TODO
            throw new Exception("");
        }
        
        if (string.IsNullOrWhiteSpace(Value))
        {
            //TODO
            throw new Exception("");
        }
    }
}