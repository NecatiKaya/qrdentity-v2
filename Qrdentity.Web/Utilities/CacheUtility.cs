using Microsoft.Extensions.Caching.Memory;

namespace Qrdentity.Web.Utilities;

public static class CacheUtility
{
    public static void SetVehiclePreRegistration(IMemoryCache cache, Guid userId, string mfCode, string codeToRegister)
    {
        if (string.IsNullOrWhiteSpace(codeToRegister))
        {
            //TODO
            throw new Exception("");
        }

        string key = KeyForVehiclePreRegistration(userId, mfCode);
        cache.Set(key, codeToRegister, TimeSpan.FromSeconds(90));
    }

    public static bool ExistsVehiclePreRegistration(IMemoryCache cache, Guid userId, string mfCode)
    {
        string key = KeyForVehiclePreRegistration(userId, mfCode);
        return cache.TryGetValue(key, out string _);
    }

    public static string? GetVehiclePreRegistration(IMemoryCache cache, Guid userId, string mfCode)
    {
        string key = KeyForVehiclePreRegistration(userId, mfCode);
        if (cache.TryGetValue(key, out string? value))
        {
            return value;
        }

        return null;
    }

    private static string KeyForVehiclePreRegistration(Guid userId, string mfCode)
    {
        return $"MultiFactor-{mfCode}-{userId.ToString()}";
    }
}