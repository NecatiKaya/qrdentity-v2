using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Core.Localization;

namespace Qrdentity.Web.Data.B2B.DataSeed;

internal sealed class BusinessTypeDataSeed
{
     public async Task RemoveAll(QrdentityContext context)
    {
        await context.BusinessTypes.ExecuteDeleteAsync();
    }

    public async Task SeedBusinessTypeData(QrdentityContext context)
    {
        LocalizedData carCategoryLocalizedData = new LocalizedData();
        // ReSharper disable once StringLiteralTypo
        carCategoryLocalizedData.Add(Languages.Turkish, "Araç Kategorisi");
        carCategoryLocalizedData.Add(Languages.English, "Car Category");

        BusinessType carBusinessAreaCategoryEntity = new BusinessType
        {
            Id = DataConstants.CarBusinessTypeId,
            Name = "Car",
            Descriptions = carCategoryLocalizedData.SerializeAsJsonString()!
        };

        LocalizedData locationCategoryLocalizedData = new LocalizedData();
        // ReSharper disable once StringLiteralTypo
        locationCategoryLocalizedData.Add(Languages.Turkish, "Konum Kategorisi");
        locationCategoryLocalizedData.Add(Languages.English, "Location Category");
        BusinessType locationBusinessAreaCategoryEntity = new BusinessType
        {
            Id = DataConstants.LocationBusinessTypeId,
            Name = "Location",
            Descriptions = locationCategoryLocalizedData.SerializeAsJsonString()!
        };

        LocalizedData transportCategoryLocalizedData = new LocalizedData();
        // ReSharper disable once StringLiteralTypo
        transportCategoryLocalizedData.Add(Languages.Turkish, "Ulaşım Kategorisi");
        transportCategoryLocalizedData.Add(Languages.English, "Transport Category");
        BusinessType transportBusinessAreaCategoryEntity = new BusinessType
        {
            Id = DataConstants.TransportBusinessTypeId,
            Name = "Transport",
            Descriptions = transportCategoryLocalizedData.SerializeAsJsonString()!
        };

        context.BusinessTypes.Add(carBusinessAreaCategoryEntity);
        context.BusinessTypes.Add(locationBusinessAreaCategoryEntity);
        context.BusinessTypes.Add(transportBusinessAreaCategoryEntity);

        await context.SaveChangesAsync();
    }
}