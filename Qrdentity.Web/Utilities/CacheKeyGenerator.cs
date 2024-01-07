using Microsoft.Extensions.Caching.Memory;

namespace Qrdentity.Web.Utilities;

public static class CacheUtility
{
    public static void SetVehiclePreRegistration(IMemoryCache cache, Guid userId, Guid multiFactorRegistrationId,
        string codeToRegister)
    {
        string key = KeyForVehiclePreRegistration(userId);
        cache.Set(key, new KeyValuePair<Guid, string>(multiFactorRegistrationId, codeToRegister),
            TimeSpan.FromSeconds(90));
    }

    public static bool ValidateVehiclePreRegistration(IMemoryCache cache, Guid userId, Guid registrationId,
        string registrationCode)
    {
        string key = KeyForVehiclePreRegistration(userId);
        KeyValuePair<Guid, string>? keyValuePair = cache.Get<KeyValuePair<Guid, string>>(key);

        string? registrationCodeInCache = keyValuePair?.Value ?? null;
        Guid? registrationIdInCache = keyValuePair?.Key ?? null;

        if (string.IsNullOrWhiteSpace(registrationCodeInCache))
        {
            return false;
        }

        if (registrationIdInCache == null || registrationIdInCache.Value == Guid.Empty)
        {
            return false;
        }

        return string.Equals(registrationCode, registrationCodeInCache) && registrationIdInCache == registrationId;
    }

    public static void ClearVehiclePreRegistration(IMemoryCache cache, Guid userId)
    {
        string key = KeyForVehiclePreRegistration(userId);
        cache.Remove(key);
    }

    public static bool ExistsVehiclePreRegistration(IMemoryCache cache, Guid userId)
    {
        string key = KeyForVehiclePreRegistration(userId);
        return cache.TryGetValue(key, out KeyValuePair<Guid, string> _);
    }

    private static string KeyForVehiclePreRegistration(Guid userId)
    {
        return $"MultiFactor-{userId.ToString()}";
    }
}