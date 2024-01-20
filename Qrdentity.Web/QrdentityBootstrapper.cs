using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Data;
using Qrdentity.Web.Data.B2B.DataSeed;
using Qrdentity.Web.Data.Common.DataSeed;
using Qrdentity.Web.Data.MultiFactor.DataSeed;
using Qrdentity.Web.Data.Products.DataSeed;
using Qrdentity.Web.Data.Utility.Seed;

namespace Qrdentity.Web;

public static class QrdentityBootstrapper
{
    public static void AddQrdentityContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<QrdentityContext>(options => { options.UseNpgsql(connectionString); });
    }

    public static void RunMigrations(this IServiceProvider provider)
    {
        using (IServiceScope scope = provider.CreateScope())
        {
            QrdentityContext? context = scope.ServiceProvider.GetRequiredService<QrdentityContext>();
            context?.Database.Migrate();
        }
    }

    public static async Task SeedData(this IServiceProvider provider)
    {
        using (IServiceScope scope = provider.CreateScope())
        {
            QrdentityContext? context = scope.ServiceProvider.GetRequiredService<QrdentityContext>();
            CountryDataSeed countryDataSeed = new CountryDataSeed();
            CityDataSeed cityDataSeed = new CityDataSeed();
            DistrictDataSeed districtDataSeed = new DistrictDataSeed();
            BusinessTypeDataSeed businessTypeDataSeed = new BusinessTypeDataSeed();
            BusinessSubTypeDataSeed businessSubTypeDataSeed = new BusinessSubTypeDataSeed();
            TaxOfficeDataSeed taxOfficeDataSeed = new TaxOfficeDataSeed();
            ProductDataSeed productDataSeed = new ProductDataSeed();
            MultiFactorConfigurationDataSeed multiFactorConfigurationDataSeed = new MultiFactorConfigurationDataSeed();
            UserAddressDataSeed userAddressDataSeed = new UserAddressDataSeed();
            
            await districtDataSeed.RemoveAll(context);
            await cityDataSeed.RemoveAll(context);
            await countryDataSeed.RemoveAll(context);
            await businessSubTypeDataSeed.RemoveAll(context);
            await businessTypeDataSeed.RemoveAll(context);
            await taxOfficeDataSeed.RemoveAll(context);
            await productDataSeed.RemoveAll(context);
            await multiFactorConfigurationDataSeed.RemoveAll(context);
            await userAddressDataSeed.RemoveAll(context);
            
            await countryDataSeed.SeedCountryData(context);
            await cityDataSeed.SeedCityData(context);
            await districtDataSeed.SeedDistrictData(context);
            await businessTypeDataSeed.SeedBusinessTypeData(context);
            await businessSubTypeDataSeed.SeedBusinessSubTypeData(context);
            await taxOfficeDataSeed.SeedTaxOfficeData(context);
            await productDataSeed.SeedProductData(context);
            await multiFactorConfigurationDataSeed.SeedMultiFactorSettingsData(context);
            await userAddressDataSeed.SeedUserAddressData(context);
        }
    }
}