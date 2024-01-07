using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Core.Localization;
using Qrdentity.Web.Proxies.Qr;

namespace Qrdentity.Web.Data.Products.DataSeed;

internal sealed class ProductDataSeed
{
    public async Task RemoveAll(QrdentityContext context)
    {
        await context.QrProducts.ExecuteDeleteAsync();
    }

    public async Task SeedProductData(QrdentityContext context)
    {
        LocalizedData vehicleQrDescription = new LocalizedData();
        // ReSharper disable once StringLiteralTypo
        vehicleQrDescription.Add(Languages.Turkish,
            "Araç için qr etiketidir. Motorlu (otomobil, akülü araba vbg.) ve motorsuz (Bisiklet, elektrikli bisiklet vbg.) her türlü aracınız için kullanabileceğiniz etiket tipidir.");
        vehicleQrDescription.Add(Languages.English, "For your vehicle both with or without engine.");

        QrProduct vehicleQrProduct = new QrProduct
        {
            Id = DataConstants.QrProductForVehicleId,
            QrFor = QrTypes.Vehicle,
            ListPriceWithoutVatApplied = 100,
            SalePriceWithoutVatApplied = 100,
            Name = "CarQR",
            Descriptions = vehicleQrDescription.SerializeAsJsonString()!,
            IsActive = true
        };

        context.QrProducts.Add(vehicleQrProduct);
        await context.SaveChangesAsync();
    }
}