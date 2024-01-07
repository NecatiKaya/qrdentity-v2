using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Core.Localization;

namespace Qrdentity.Web.Data.B2B.DataSeed;

internal sealed class BusinessSubTypeDataSeed
{
    public async Task RemoveAll(QrdentityContext context)
    {
        await context.BusinessSubTypes.ExecuteDeleteAsync();
    }

    public async Task SeedBusinessSubTypeData(QrdentityContext context)
    {
        LocalizedData carWashLocalizedData = new LocalizedData();
        // ReSharper disable once StringLiteralTypo
        carWashLocalizedData.Add(Languages.Turkish, "Araç Yıkama");
        carWashLocalizedData.Add(Languages.English, "Car Wash");

        BusinessSubType carWashBusinessAreaSubCategoryEntity = new BusinessSubType
        {
            Id = DataConstants.CarWashBusinessSubTypeId,
            Name = "CarWash",
            Descriptions = carWashLocalizedData.SerializeAsJsonString()!,
            BusinessTypeId = DataConstants.CarBusinessTypeId
        };

        LocalizedData carRepairLocalizedData = new LocalizedData();
        // ReSharper disable once StringLiteralTypo
        carRepairLocalizedData.Add(Languages.Turkish, "Araç Tamir");
        carRepairLocalizedData.Add(Languages.English, "Car Repair");
        BusinessSubType carRepairBusinessAreaSubCategoryEntity = new BusinessSubType
        {
            Id = DataConstants.CarRepairServiceBusinessSubTypeId,
            Name = "CarRepair",
            Descriptions = carRepairLocalizedData.SerializeAsJsonString()!,
            BusinessTypeId = DataConstants.CarBusinessTypeId
        };

        context.BusinessSubTypes.Add(carWashBusinessAreaSubCategoryEntity);
        context.BusinessSubTypes.Add(carRepairBusinessAreaSubCategoryEntity);
        await context.SaveChangesAsync();
    }
}