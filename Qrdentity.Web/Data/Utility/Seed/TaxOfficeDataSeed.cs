using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Constants;

namespace Qrdentity.Web.Data.Utility.Seed;

internal sealed class TaxOfficeDataSeed
{
    public async Task RemoveAll(QrdentityContext context)
    {
        await context.TaxOffices.ExecuteDeleteAsync();
    }

    public async Task SeedTaxOfficeData(QrdentityContext context)
    {
        TaxOffice taxOfficeEntity = new TaxOffice();
        taxOfficeEntity.DistrictId = DataConstants.FatihDistrictId;
        taxOfficeEntity.OfficeName = "Fatih";
        taxOfficeEntity.PlateNumber = "34";
        taxOfficeEntity.SortOrder = 0;
        taxOfficeEntity.Id = DataConstants.FatihTaxOfficeId;

        context.TaxOffices.Add(taxOfficeEntity);
        await context.SaveChangesAsync();
    }
}