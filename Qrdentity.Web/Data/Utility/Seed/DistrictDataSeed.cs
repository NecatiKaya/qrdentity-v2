using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Constants;

namespace Qrdentity.Web.Data.Utility.Seed;

internal sealed class DistrictDataSeed
{
    public async Task RemoveAll(QrdentityContext context)
    {
        await context.Districts.ExecuteDeleteAsync();
    }

    public async Task SeedDistrictData(QrdentityContext context)
    {
        District districtEntity = new District();
        districtEntity.Id = DataConstants.FatihDistrictId;
        districtEntity.CityId = DataConstants.IstanbulCityId;
        districtEntity.Name = "Fatih";

        context.Districts.Add(districtEntity);
        await context.SaveChangesAsync();
    }
}