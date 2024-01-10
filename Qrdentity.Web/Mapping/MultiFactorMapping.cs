using Qrdentity.Web.Data.MultiFactor;
using Qrdentity.Web.Proxies.Setting;

namespace Qrdentity.Web.Mapping;

public static class MultiFactorMapping
{
    public static MultiFactorSettingProxy ToMultiFactorSettingProxy(MultiFactorSetting setting)
    {
        MultiFactorSettingProxy settingProxy = new MultiFactorSettingProxy
        {
            Id = setting.Id,
            Descriptions = setting.Descriptions
        };
        return settingProxy;
    }
}