using System.Globalization;
using System.Text.Json;

namespace Qrdentity.Web.Core.Localization;


public sealed record LocalizedData
{
    private Dictionary<string, string?> _localizedData { get; } =
        new Dictionary<string, string?>();

    public void Add(CultureInfo culture, string? localization)
    {
        // ReSharper disable once CanSimplifyDictionaryLookupWithTryAdd
        if (_localizedData.ContainsKey(culture.Name))
        {
            _localizedData[culture.Name] = localization;
            return;
        }
        
        _localizedData.Add(culture.Name, localization);
    }

    public string? Get(CultureInfo culture)
    {
        if (_localizedData.TryGetValue(culture.Name, out string? localization))
        {
            return localization;
        }

        return null;
    }

    public string? SerializeAsJsonString()
    {
        if (!_localizedData.Any())
        {
            return null;
        }

        string localizedDataAsString = JsonSerializer.Serialize(_localizedData, JsonSerializerOptions.Default);
        return localizedDataAsString;
    }
}