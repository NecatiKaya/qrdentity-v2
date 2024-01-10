using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Core.Localization;

namespace Qrdentity.Web.Data.MultiFactor.DataSeed;

internal class MultiFactorConfigurationDataSeed
{
    public async Task RemoveAll(QrdentityContext context)
    {
        await context.MultiFactorSettings.ExecuteDeleteAsync();
    }

    public async Task SeedMultiFactorSettingsData(QrdentityContext context)
    {
        LocalizedData smsMfConfiguration = new LocalizedData();
        smsMfConfiguration.Add(Languages.Turkish, "Sms Bildirimi");
        smsMfConfiguration.Add(Languages.English, "Sms Notification");

        context.MultiFactorSettings.Add(new MultiFactorSetting()
        {
            Id = DataConstants.SmsNotificationCode,
            Descriptions = smsMfConfiguration.SerializeAsJsonString()!
        });

        LocalizedData emailMfConfiguration = new LocalizedData();
        emailMfConfiguration.Add(Languages.Turkish, "Email Bildirimi");
        emailMfConfiguration.Add(Languages.English, "Email Notification");

        context.MultiFactorSettings.Add(new MultiFactorSetting()
        {
            Id = DataConstants.EmailNotificationCode,
            Descriptions = emailMfConfiguration.SerializeAsJsonString()!
        });

        LocalizedData whatsAppMfConfiguration = new LocalizedData();
        whatsAppMfConfiguration.Add(Languages.Turkish, "WhatsApp Bildirimi");
        whatsAppMfConfiguration.Add(Languages.English, "WhatsApp Notification");

        context.MultiFactorSettings.Add(new MultiFactorSetting()
        {
            Id = DataConstants.WhatsAppNotificationCode,
            Descriptions = whatsAppMfConfiguration.SerializeAsJsonString()!
        });

        LocalizedData callMfConfiguration = new LocalizedData();
        callMfConfiguration.Add(Languages.Turkish, "Direkt Arama");
        callMfConfiguration.Add(Languages.English, "Direct Call");

        context.MultiFactorSettings.Add(new MultiFactorSetting()
        {
            Id = DataConstants.DirectCallNotification,
            Descriptions = callMfConfiguration.SerializeAsJsonString()!
        });

        await context.SaveChangesAsync();
    }
}