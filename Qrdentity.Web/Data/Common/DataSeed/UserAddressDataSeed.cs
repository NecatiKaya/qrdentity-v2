using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Constants;

namespace Qrdentity.Web.Data.Common.DataSeed;

internal sealed class UserAddressDataSeed
{
    public async Task RemoveAll(QrdentityContext context)
    {
        await context.UserAddresses.ExecuteDeleteAsync();
    }

    public async Task SeedUserAddressData(QrdentityContext context)
    {
        UserAddress address = new UserAddress();
        address.Address = "Göktürk merkez mah. Soydan sok.";
        address.DistrictId = DataConstants.FatihDistrictId;
        address.ZipCode = "3420";
        address.Latitude = 41.1803575;
        address.Longitude = 28.8787463;

        await context.UserAddresses.AddAsync(address);
        await context.SaveChangesAsync();
    }
}