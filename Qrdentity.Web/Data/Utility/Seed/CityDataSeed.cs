using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Constants;

namespace Qrdentity.Web.Data.Utility.Seed;

internal sealed class CityDataSeed
{
    public async Task RemoveAll(QrdentityContext context)
    {
        await context.Cities.ExecuteDeleteAsync();
    }

    public async Task SeedCityData(QrdentityContext context)
    {
        City cityEntity = new City();
        cityEntity.CountryId = DataConstants.TurkeyCountryId;
        cityEntity.PlateNumber = "34";
        cityEntity.Name = "İstanbul";
        cityEntity.Id = DataConstants.IstanbulCityId;

        context.Cities.Add(cityEntity);
        await context.SaveChangesAsync();
    }
}