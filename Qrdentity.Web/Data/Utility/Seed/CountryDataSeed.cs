using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Constants;

namespace Qrdentity.Web.Data.Utility.Seed;

internal sealed class CountryDataSeed
{
    public async Task RemoveAll(QrdentityContext context)
    {
        await context.Countries.ExecuteDeleteAsync();
    }

    public async Task SeedCountryData(QrdentityContext context)
    {
        Country countryEntity = new Country();
        countryEntity.CountryCode = "90";
        countryEntity.Name = "Türkiye";
        countryEntity.Id = DataConstants.TurkeyCountryId;
        countryEntity.SortOrder = 0;
        countryEntity.CreatedBy = DataConstants.AdminUserId;

        context.Countries.Add(countryEntity);
        await context.SaveChangesAsync();
    }
}